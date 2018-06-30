using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using utils;

namespace HogeTextReplace
{
    partial class MainForm
    {

        #region Find

        ProgressDialog progressDialog;
        FileListView _fileListView = new FileListView();

        string _dirPath;
        string _pattern;
        string _beforeText;
        string _afterText;
        bool _inclSubDir;
        bool _inclHiddenDir;
        bool _inclHiddenFile;
        bool _regEx;
        int _encNumber;
        bool _regExMultiline;

        void Find(object sender, EventArgs e)
        {
            azukiAfter.UpdateNewlineChars();
            azukiBefore.UpdateNewlineChars();

            if (!Directory.Exists(DirPath))
            {
                MessageBox.Show("存在しないフォルダです。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Pattern))
            {
                MessageBox.Show("フィルタが入力されていません。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (InformBeforeTextEmpty && string.IsNullOrEmpty(BeforeText))
            {
                string msg = "置換前のテキストが入力されていません。検索を実行しますか？\n\n" +
                     string.Format("場所: {0}\nサブフォルダ: {1}\nフィルタ: {2}\n文字コード: {3}\n正規表現: {4}",
                    tbDirPath.Text, cbSubDir.Checked ? "含める" : "含めない",
                    tbPattern.Text, comboBoxEnc.SelectedItem.ToString(),
                    cbRegex.Checked ? "適用する" : "適用しない");
                DialogResult dr = MessageBox.Show(
                    msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }
            else if (InformBeforeSearch) // 'else if' to avoid inquiring twice in succession
            {
                string msg = "検索を開始します。よろしいですか？\n\n" +
                     string.Format("場所: {0}\nサブフォルダ: {1}\nフィルタ: {2}\n文字コード: {3}\n正規表現: {4}",
                    tbDirPath.Text, cbSubDir.Checked ? "含め" : "含めない",
                    tbPattern.Text, comboBoxEnc.SelectedItem.ToString(),
                    cbRegex.Checked ? "適用する" : "適用しない");
                DialogResult dr = MessageBox.Show(
                    msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }

            fileListView.AzukiBefore = azukiBefore;
            fileListView.AzukiAfter = azukiAfter;
            fileListView.RegexEnabled = RegexEnabled;
            fileListView.RegexOptions = RegexMultiline ? RegexOptions.Multiline : RegexOptions.Singleline;  // do not use |= 

            _dirPath = DirPath;
            _pattern = Pattern;
            _beforeText = BeforeText;
            _inclSubDir = InclSubDir;
            _inclHiddenDir = InclHiddenDir;
            _inclHiddenFile = InclHiddenFile;
            _regEx = RegexEnabled;
            _encNumber = EncNumber;
            _regExMultiline = RegexMultiline;

            btnFind.Enabled = false;
            fileListView.Items.Clear();

            Progress.Clear();

            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(DoFindBkgnd);

                progressDialog = new ProgressDialog(bw, Progress);
                progressDialog.Text = "検索中...";

                bw.RunWorkerAsync();
            }

            ProgressDialogResult result = progressDialog.ShowDialog();

            if (result == ProgressDialogResult.Success)
            {
                fileListView.Items.Clear();
                foreach (ListViewItem item in _fileListView.Items)
                {
                    fileListView.Items.Add(item.Clone() as ListViewItem);
                }
                fileListView.ListValid = _fileListView.ListValid;
            }

            btnFind.Enabled = true;

            if (btnReplace.Enabled)
            {
                btnReplace.Focus();
            }
            else
            {
                btnFind.Focus();
            }

            if (Progress.Canceled)
            {
                Progress.ErrorDescription = "処理が中断されました。";
                ErrorDialog dialog = new ErrorDialog(Progress);
                dialog.ShowDialog();
                fileListView.ListValid = false;
            }
            else
            {
                if (Progress.ErrorOccured)
                {
                    Progress.ErrorDescription = "アクセスできないファイルまたはフォルダがありました。" + Environment.NewLine + "または、その他のエラーが発生しました。";
                    ErrorDialog dialog = new ErrorDialog(Progress);
                    dialog.ShowDialog();

                    if (fileListView.Items.Count > 0 &&
                        !string.IsNullOrEmpty(fileListView.Items[0].SubItems[1].Text))
                    {
                        fileListView.ListValid = true;
                    }
                    else
                    {
                        fileListView.ListValid = false;
                    }
                }
                if (InformAfterSearch)
                {
                    int fileNum = fileListView.Items[0].Checked ? fileListView.Items.Count : 0;
                    string msg = "検索が完了しました。\n\n" +
                       string.Format("見つかったファイル: {0} 件", fileNum);
                    MessageBox.Show(msg, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void DoFindBkgnd(object sender, DoWorkEventArgs eventArgs)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            try
            {
                Progress.ProgressUpdated += bw.ReportProgress;

                OperationFindOptions options =
                    (_inclSubDir ? OperationFindOptions.IncludeSubDirectory : OperationFindOptions.None) |
                    (_inclHiddenDir ? OperationFindOptions.IncludeHiddenDirectory : OperationFindOptions.None) |
                    (_inclHiddenFile ? OperationFindOptions.IncludeHiddenFile : OperationFindOptions.None) |
                    (_regEx ? OperationFindOptions.RegexEnabled : OperationFindOptions.None);

                OperationFind operationFind = new OperationFind(
                    _dirPath, _pattern, _beforeText, options,
                    JpnEncoding.NumberToJpnEncoding(_encNumber),
                    _regExMultiline ? RegexOptions.Multiline : RegexOptions.Singleline,
                    Progress);

                _fileListView = operationFind.ExecuteOperationFind();
            }
            catch (Exception)
            {
                _fileListView.ListValid = false;
                throw; // RunWorkerCompleted event handler will be called
            }
        }
        #endregion

        #region OperationFind Class

        [Flags]
        public enum OperationFindOptions
        {
            None = 0,
            IncludeSubDirectory = 1,
            IncludeHiddenDirectory = 2,
            IncludeHiddenFile = 4,
            RegexEnabled = 8,
        }

        public class OperationFind
        {
            // given as parameter
            public string DirPath { get; set; }
            public string Pattern { get; set; }
            public string Content { get; set; }
            public OperationFindOptions Options { get; set; }
            public JpnEncoding Encoding { get; set; }
            public Progress Progress { get; set; }
            public RegexOptions RegexOptions { get; set; }

            public OperationFind(string dirPath, string pattern, string content, OperationFindOptions options, JpnEncoding encoding, RegexOptions regexOptions, Progress progress)
            {
                DirPath = dirPath;
                Pattern = pattern;
                Content = content;
                Options = options;
                Encoding = encoding;
                RegexOptions = regexOptions;
                Progress = progress;
            }

            public FileListView ExecuteOperationFind()
            {
                Progress.ReportProgress(0, "ファイルを検索しています...\n");
                Progress.CheckCanceledOrNot();

                string[] arrPatterns = Pattern.Split(new char[] { '|' });

                // GetFiles() often includes files that don't exactly match the pattern
                List<Regex> patternsRegex = StrArrToRegexListOfPatterns(arrPatterns);

                string[] arrPtnMtchPaths = ListUpPatternMatchedFiles(DirPath, patternsRegex);

                Dictionary<string, JpnEncoding> dicPtnMtchPathAndEnc;

                if (Encoding.Number == JpnEncoding.AutoDetection.Number)
                {
                    dicPtnMtchPathAndEnc = DetectEncodingOfEachFile(arrPtnMtchPaths);
                }
                else
                {
                    dicPtnMtchPathAndEnc = new Dictionary<string, JpnEncoding>();
                    for (int i = 0; i < arrPtnMtchPaths.Length; i++)
                    {
                        dicPtnMtchPathAndEnc.Add(arrPtnMtchPaths[i], Encoding);
                    }
                }

                Dictionary<string, JpnEncoding> dicCntMtchPathAndEncName
                    = ListUpContentMatchedFiles(dicPtnMtchPathAndEnc);

                Progress.ReportProgress(0, "ファイルリストを更新しています...\n");
                Progress.CheckCanceledOrNot();

                return DicToFileListView(dicCntMtchPathAndEncName);
            }

            List<Regex> StrArrToRegexListOfPatterns(string[] patterns)
            {
                List<Regex> patternsRegex = new List<Regex>();

                foreach (string pattern in patterns)
                {
                    string patternRegex = pattern.Trim();
                    patternRegex = patternRegex.Replace(@".", @"\.");
                    string[] beforeEscape = { "{", "}", "(", ")", "[", "]", "-", "+" };
                    for (int i = 0; i < beforeEscape.Length; i++)
                    {
                        patternRegex = patternRegex.Replace(beforeEscape[i], @"\" + beforeEscape[i]);
                    }
                    patternRegex = patternRegex.Replace(@"?", @".{1}");
                    patternRegex = patternRegex.Replace(@"*", @".*");
                    patternRegex = @"^" + patternRegex + @"$";
                    patternsRegex.Add(new Regex(patternRegex, RegexOptions.Singleline));
                }

                return patternsRegex;
            }

            string[] ListUpPatternMatchedFiles(string path, List<Regex> patternsRegex)
            {
                Progress.ReportProgress(0, "ファイルを検索しています...\n" + path);
                Progress.CheckCanceledOrNot();

                List<string> filePaths = new List<string>();
                SearchOption searchOption = SearchOption.TopDirectoryOnly; // do not use AllDirectory option

                foreach (string candidateFilePath in Directory.GetFiles(path, "*", searchOption))
                {
                    try
                    {
                        string candidateFileName = Path.GetFileName(candidateFilePath);

                        foreach (Regex regex in patternsRegex)
                        {
                            try
                            {
                                if (regex.IsMatch(candidateFileName))
                                {
                                    if ((Options & OperationFindOptions.IncludeHiddenFile) == 0) // i.e. exclude hidden files
                                    {
                                        FileInfo fi = new FileInfo(candidateFilePath);
                                        if ((fi.Attributes & FileAttributes.Hidden) != 0)
                                        {
                                            continue;
                                        }
                                    }
                                    filePaths.Add(candidateFilePath);
                                }
                            }
                            catch (OperationCanceledException)
                            {
                                throw;
                            }
                            catch (Exception exception)
                            {
                                Progress.ReportError(exception);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Progress.ReportError(exception);
                    }
                }

                if ((Options & OperationFindOptions.IncludeSubDirectory) != 0)
                {
                    try
                    {
                        string[] subdirs = Directory.GetDirectories(path, "*", searchOption);

                        foreach (string subdir in subdirs)
                        {
                            try
                            {
                                if ((Options & OperationFindOptions.IncludeHiddenDirectory) == 0) // i.e. exclude hidden directories
                                {
                                    DirectoryInfo di = new DirectoryInfo(subdir);
                                    if ((di.Attributes & FileAttributes.Hidden) != 0)
                                    {
                                        continue;
                                    }
                                }
                                filePaths.AddRange(ListUpPatternMatchedFiles(subdir, patternsRegex));
                            }
                            catch (OperationCanceledException)
                            {
                                throw;
                            }
                            catch (Exception exception)
                            {
                                Progress.ReportError(exception);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Progress.ReportError(exception);
                    }
                }
                return filePaths.ToArray();
            }

            Dictionary<string, JpnEncoding> DetectEncodingOfEachFile(string[] arrPtnMtchPaths)
            {
                Dictionary<string, JpnEncoding> dicPtnMtchPathAndEnc = new Dictionary<string, JpnEncoding>();

                for (int i = 0; i < arrPtnMtchPaths.Length; i++)
                {
                    try
                    {
                        string path = arrPtnMtchPaths[i];

                        Progress.ReportProgress(0, "エンコーディングを調べています...\n" + path);
                        Progress.CheckCanceledOrNot();

                        JpnEncoding jenc = JpnEncoding.DetectEncoding(path, JpnEncoding.Shift_JIS);
                        if (jenc != null)
                        {
                            dicPtnMtchPathAndEnc.Add(path, jenc);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Progress.ReportError(exception);
                    }
                }
                return dicPtnMtchPathAndEnc;
            }


            Dictionary<string, JpnEncoding> ListUpContentMatchedFiles(Dictionary<string, JpnEncoding> dicPtnMtchPathAndEnc)
            {
                Dictionary<string, JpnEncoding> dicCntMtchPathAndEncName = new Dictionary<string, JpnEncoding>();

                foreach (string path in dicPtnMtchPathAndEnc.Keys)
                {
                    Progress.ReportProgress(0, "ファイルの内容を調べています...\n" + path);
                    Progress.CheckCanceledOrNot();

                    try
                    {
                        bool match = false;
                        using (StreamReader sr = new StreamReader(path, dicPtnMtchPathAndEnc[path].Encoding, false))  // false is not specified in 1.3.0
                        {
                            if ((Options & OperationFindOptions.RegexEnabled) != 0)
                            {
                                Regex regex = new Regex(Content, RegexOptions);
                                if (regex.IsMatch(sr.ReadToEnd()))
                                {
                                    match = true;
                                }
                            }
                            else
                            {
                                if (sr.ReadToEnd().Contains(Content))
                                {
                                    match = true;
                                }
                            }
                        }
                        if (match)
                        {
                            dicCntMtchPathAndEncName.Add(path, dicPtnMtchPathAndEnc[path]);
                        }
                    }
                    catch (OperationCanceledException) 
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Progress.ReportError(exception);
                    }
                }
                return dicCntMtchPathAndEncName;
            }


            FileListView DicToFileListView(Dictionary<string, JpnEncoding> dicCntMtchPathAndEncName)
            {
                FileListView fileListView = new FileListView();

                if (dicCntMtchPathAndEncName.Count == 0)
                {
                    fileListView.Items.Add(new ListViewItem(
                        new string[] { "見つかりませんでした。", "", "" }));
                    fileListView.ListValid = false;
                }
                else
                {
                    foreach (string key in dicCntMtchPathAndEncName.Keys)
                    {
                        string name = Path.GetFileName(key);
                        string path = key;
                        string enc = dicCntMtchPathAndEncName[key].Name;
                        fileListView.AddNewItem(name, enc, path);
                    }

                    foreach (ListViewItem item in fileListView.Items)
                    {

                        item.Checked = true;
                    }

                    fileListView.ListValid = true;
                }

                return fileListView;
            }
        }

        #endregion

    }
}
