using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using utils;

namespace HogeTextReplace
{
    partial class MainForm
    {

        #region Replace
        void Replace(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(azukiBefore.Text))
            {
                MessageBox.Show(
                    "置換前のテキストが入力されていません。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!fileListView.ListValid)
            {

                Progress.Clear();

                Find(sender, e);

                if (Progress.Canceled)
                {
                    // error message has been already shown
                    return;
                }
            }

            if (fileListView.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                  "置換するファイルがありません。",
                   "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InformAfterTextEmpty && string.IsNullOrEmpty(azukiAfter.Text))
            {
                string msg = "置換後のテキストが入力されていません。置換を実行しますか？\n\n" +
                     string.Format("対象ファイル: {0} 件 ({1} 件中)\nバックアップ: {2}\n正規表現: {3}",
                    fileListView.CheckedItems.Count, fileListView.Items.Count,
                    BackupArgs.Enabled ? "する" : "しない",
                    cbRegex.Checked ? "適用する" : "適用しない");
                DialogResult dr = MessageBox.Show(
                    msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }
            else if (InformBeforeReplace) // 'else if' to avoid inquiring twice in succession
            {
                string msg = "置換を開始します。よろしいですか？\n\n" +
                            string.Format("対象ファイル: {0} 件 ({1} 件中)\nバックアップ: {2}\n正規表現: {3}",
                    fileListView.CheckedItems.Count, fileListView.Items.Count,
                    BackupArgs.Enabled ? "する" : "しない",
                    cbRegex.Checked ? "適用する" : "適用しない");
                DialogResult dr = MessageBox.Show(
                    msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }

            btnReplace.Enabled = false;

            int _fileListView_CheckedItems_Count = fileListView.CheckedItems.Count;

            if (!fileListView.ListValid)
            {
                this.Find(sender, e);
                if (!fileListView.ListValid)
                {
                    btnReplace.Enabled = true;
                    return;
                }
            }

            _dirPath = DirPath;
            _pattern = Pattern;
            _beforeText = BeforeText;
            _afterText = AfterText;
            _inclSubDir = InclSubDir;
            _regEx = RegexEnabled;
            _encNumber = EncNumber;
            _regExMultiline = RegexMultiline;

            // copy of reference is not approved
            _fileListView.ListValid = fileListView.ListValid;
            _fileListView.Items.Clear();
            foreach (ListViewItem item in fileListView.Items)
            {
                _fileListView.Items.Add(item.Clone() as ListViewItem);
            }

            Progress.Clear();

            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(DoReplaceBkgnd);

                // progress dialog
                progressDialog = new ProgressDialog(bw, Progress);
                progressDialog.Text = "置換中...";

                bw.RunWorkerAsync();
            }

            ProgressDialogResult result = progressDialog.ShowDialog();

            if (_fileListView != null)
            {
                fileListView.ListValid = _fileListView.ListValid;
                fileListView.Items.Clear();
                foreach (ListViewItem item in _fileListView.Items)
                {
                    fileListView.Items.Add(item.Clone() as ListViewItem);
                }
            }

            if (result == ProgressDialogResult.Success)
            {
                fileListView.ListValid = _fileListView.ListValid;
                fileListView.Items.Clear();
                foreach (ListViewItem item in _fileListView.Items)
                {
                    fileListView.Items.Add(item.Clone() as ListViewItem);
                }
                if (Progress.ErrorOccured)
                {
                    Progress.ErrorDescription = "アクセスできないファイルは無視されました。\n" +
                        "バックアップエラーだけであれば、置換は行われています。";
                    ErrorDialog dialog = new ErrorDialog(Progress);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileListView.ListValid = true;
                    }
                    else
                    {
                        fileListView.ListValid = false;
                    }
                }

                btnReplace.Enabled = true;
                btnReplace.Focus();

                if (InformAfterReplace)
                {
                    int fileNum = fileListView.Items[0].Checked ? fileListView.Items.Count : 0;
                    string msg = "置換が完了しました。\n\n" +
                       string.Format("置換に成功したファイル: {0} 件\n置換に失敗したファイル: {1} 件",
                       _fileListView_CheckedItems_Count - fileListView.CheckedItems.Count,
                       fileListView.CheckedItems.Count);
                    MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (result == ProgressDialogResult.Failure)
            {
                Progress.ErrorDescription = "置換に失敗しました。";
                ErrorDialog dialog = new ErrorDialog(Progress);
                dialog.ShowDialog();

                btnReplace.Enabled = true;
                btnReplace.Focus();
            }

        }

        // background process
        void DoReplaceBkgnd(object sender, DoWorkEventArgs eventArgs)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                Progress.ProgressUpdated += bw.ReportProgress;

                OperationReplace operationReplace = new OperationReplace(
                 _fileListView, _beforeText, _afterText, _regEx,
                 _regExMultiline ? RegexOptions.Multiline : RegexOptions.Singleline,
                 Progress, BackupArgs); 

                _fileListView = operationReplace.ExecuteOperationReplace();
            }
            catch (Exception)
            {
                throw; // RunWorkerCompleted event handler will be called
            }
        }
        #endregion

        #region OperationReplace Class

        internal class OperationReplace
        {
            // given as parameters
            public FileListView FileListView { get; set; }
            public string BeforeText { get; set; }
            public string AfterText { get; set; }
            public bool RegExEnabled { get; set; }
            public BackupArgs BackupArgs { get; set; }
            public Progress Progress { get; set; }
            public RegexOptions RegexOptions { get; set; }

            public OperationReplace(FileListView fileListView, string before, string after, bool regex, RegexOptions regexOptions, Progress progress, BackupArgs backupArgs)
            {
                FileListView = fileListView;
                BeforeText = before;
                AfterText = after;
                RegExEnabled = regex;
                RegexOptions = regexOptions;
                BackupArgs = backupArgs;
                Progress = progress;
            }

            public FileListView ExecuteOperationReplace()
            {
                foreach (ListViewItem item in FileListView.Items)
                {
                    if (!item.Checked) { continue; }

                    string path = item.SubItems[FileListView.ClmnPathNumber].Text;

                    if (!string.IsNullOrEmpty(BackupArgs.TextAsUserDefined()))
                    {
                        Progress.ReportProgress(0, "バックアップファイルを作成しています...\n" + path);
                        Progress.CheckCanceledOrNot();

                        BackupFiles(item);
                    }

                    Progress.ReportProgress(0, "ファイルを置換しています...\n" + path);
                    Progress.CheckCanceledOrNot();

                    WriteFiles(item);
                }

                Progress.ReportProgress(0, "ファイルリストを更新しています...\n");
                Progress.CheckCanceledOrNot();

                return UpdateListView();
            }

            void BackupFiles(ListViewItem item)
            {
                try
                {
                    string sourcePath = item.SubItems[FileListView.ClmnPathNumber].Text;
                    string destPath = BackupArgs.UserDefinedBackupFileName(sourcePath, BackupArgs.TextAsUserDefined());
                    string destDir = Path.GetDirectoryName(destPath);

                    if (!Directory.Exists(destDir))
                    {
                        Directory.CreateDirectory(destDir);
                    }

                    if (BackupArgs.AppendMode)
                    {
                        int codepg = JpnEncoding.NameToJpnEncoding(item.SubItems[1].Text).Encoding.CodePage;
                        Encoding enc = null;
                        if (codepg == 65001)
                        {
                            // avoid Encoding.GetEncoding(65001) as it refers to UTF-8 with BOM
                            enc = new UTF8Encoding(false);
                        }
                        else
                        {
                            enc = Encoding.GetEncoding(codepg);
                        }

                        string text;
                        using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs, enc))
                            {
                                text = sr.ReadToEnd();
                            }
                            DateTime dtNow = DateTime.Now;
                            string eol = Environment.NewLine;
                            string borderline = new string('-', sourcePath.Length > 20 ? sourcePath.Length : 20);  // 20 is length of date string
                            text = borderline + eol + text;
                            text = sourcePath + eol + text;
                            text = dtNow.ToString("yyyy-MM-dd HH:mm:ss") + eol + text;
                            text = borderline + eol + text;
                            text = eol + text + eol;
                        }
                        using (FileStream fs = new FileStream(destPath, FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, enc))
                            {
                                sw.Write(text);
                            }
                        }
                    }
                    else
                    {
                        File.Copy(sourcePath, destPath, true);
                    }

                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    Progress.ReportError(exception, "バックアップエラー: ");
                }
            }

            void WriteFiles(ListViewItem item)
            {
                string path = item.SubItems[FileListView.ClmnPathNumber].Text;

                int codepg = JpnEncoding.NameToJpnEncoding(item.SubItems[1].Text).Encoding.CodePage;
                Encoding enc = null;
                if (codepg == 65001)
                {
                    // avoid Encoding.GetEncoding(65001) as it refers to UTF-8 with BOM
                    enc = new UTF8Encoding(false);
                }
                else
                {
                    enc = Encoding.GetEncoding(codepg);
                }

                string text;

                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs, enc, false))  // false is not specified in 1.3.0
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                    if (RegExEnabled)
                    {
                        Regex regex = new Regex(BeforeText, RegexOptions);
                        text = regex.Replace(text, AfterText);
                    }
                    else // !RegExEnabled
                    {
                        text = text.Replace(BeforeText, AfterText);
                    }
                    using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, enc))
                        {
                            sw.Write(text);
                        }
                    }
                    item.Checked = false;
                    item.BackColor = FileListView.SuccessBackColor;
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    item.BackColor = FileListView.FailureBackColor;
                    Progress.ReportError(exception);
                }
            }

            FileListView UpdateListView()
            {
                // there's nothing special to do
                return FileListView;
            }
        }
        #endregion

    }
}
