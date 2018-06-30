using System;
using System.Windows.Forms;
using utils;

namespace HogeTextReplace
{
    partial class MainForm
    {
        #region Settings

        public int startTabIndexOfOptionDlg = 0;

        void OptionDlg(object sender, EventArgs e)
        {
            OptionDialog dialog = new OptionDialog();

            SetSettingsToDialog(dialog);

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ApplySettings(dialog);
            }
        }

        void SetSettingsToDialog(OptionDialog dialog)
        {
            //
            // tabView
            //
            dialog.EditorForeColor = EditorForeColor;
            dialog.EditorMarkerColor = EditorMarkerColor;
            dialog.EcitorBeforeBackColor = EditorBeforeBackColor;
            dialog.EditorAfterBackColor = EditorAfterBackColor;

            dialog.EditorFont = EditorFont;

            dialog.SuccessColour = FileListView.SuccessBackColor;
            dialog.FailureColour = FileListView.FailureBackColor;

            dialog.DrawEOF = DrawEOF;
            dialog.DrawFullWidthSpace = DrawFullWidthSpace;
            dialog.DrawNewline = DrawNewline;
            dialog.DrawSpace = DrawSpace;
            dialog.DrawTab = DrawTab;

            //
            // tabNotice
            //
            dialog.NotifyUnauthorizedAccessException = Progress.NotifyUnauthorizedAccessException;
            dialog.NotifyPathTooLongException = Progress.NotifyPathTooLongException;
            dialog.NotifyDirectoryNotFoundException = Progress.NotifyDirectoryNotFoundException;
            dialog.NotifyIOException = Progress.NotifyIOException;
            dialog.NotifyOtherException = Progress.NotifyOtherException;

            dialog.InformBeforeSearch = InformBeforeSearch;
            dialog.InformAfterSearch = InformAfterSearch;
            dialog.InformBeforeTextEmpty = InformBeforeTextEmpty;
            dialog.InformBeforeReplace = InformBeforeReplace;
            dialog.InformAfterReplace = InformAfterReplace;
            dialog.InformAfterTextEmpty = InformAfterTextEmpty;

            //
            // tabBackup
            //
            dialog.BackupEnabled = BackupArgs.Enabled;
            dialog.BackupAppending = BackupArgs.AppendMode;
            dialog.BackupMode = BackupArgs.Mode;

            dialog.BackupExtension = BackupArgs.ReplaceExtensionText;
            dialog.BackupFolder = BackupArgs.AnotherFolderText;
            dialog.BackupUserDefinition = BackupArgs.UserDefinedText;
        }

        void ApplySettings(OptionDialog dialog)
        {
            //
            // tabView
            //
            EditorForeColor = dialog.EditorForeColor;
            EditorMarkerColor = dialog.EditorMarkerColor;
            EditorBeforeBackColor = dialog.EcitorBeforeBackColor;
            EditorAfterBackColor = dialog.EditorAfterBackColor;

            EditorFont = dialog.EditorFont;

            FileListView.SuccessBackColor = dialog.SuccessColour;
            FileListView.FailureBackColor = dialog.FailureColour;

            DrawEOF = dialog.DrawEOF;
            DrawFullWidthSpace = dialog.DrawFullWidthSpace;
            DrawNewline = dialog.DrawNewline;
            DrawSpace = dialog.DrawSpace;
            DrawTab = dialog.DrawTab;

            //
            // tabNotice
            //
            Progress.NotifyUnauthorizedAccessException = dialog.NotifyUnauthorizedAccessException;
            Progress.NotifyPathTooLongException = dialog.NotifyPathTooLongException;
            Progress.NotifyDirectoryNotFoundException = dialog.NotifyDirectoryNotFoundException;
            Progress.NotifyIOException = dialog.NotifyIOException;
            Progress.NotifyOtherException = dialog.NotifyOtherException;

            InformBeforeSearch = dialog.InformBeforeSearch;
            InformAfterSearch = dialog.InformAfterSearch;
            InformBeforeTextEmpty = dialog.InformBeforeTextEmpty;
            InformBeforeReplace = dialog.InformBeforeReplace;
            InformAfterReplace = dialog.InformAfterReplace;
            InformAfterTextEmpty = dialog.InformAfterTextEmpty;

            //
            // tabBackup
            //
            BackupArgs.Enabled = dialog.BackupEnabled;
            BackupArgs.AppendMode = dialog.BackupAppending;
            BackupArgs.Mode = dialog.BackupMode;

            BackupArgs.ReplaceExtensionText = dialog.BackupExtension;
            BackupArgs.AnotherFolderText = dialog.BackupFolder;
            BackupArgs.UserDefinedText = dialog.BackupUserDefinition;

            if (dialog.BackupMode == BackupMode.SubFolder && dialog.BackupEnabled)
            {
                bool _inclSubdirCBEnabled = InclSubDirCheckBoxEnabled;

                InclSubDir = false;
                InclSubDirCheckBoxEnabled = false;

                if (_inclSubdirCBEnabled)
                {
                    MessageBox.Show("バックアップファイルが検索対象とならないように、\n" +
                        "サブフォルダの検索を無効にしました。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                InclSubDirCheckBoxEnabled = true;
            }
        }
        #endregion

    }
}
