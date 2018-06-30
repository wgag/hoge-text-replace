using System;
using System.Drawing;
using System.Windows.Forms;
using utils;

namespace HogeTextReplace
{
    class IniForMainForm : IniBase
    {
        private MainForm caller;

        public IniForMainForm(string filename, MainForm caller)
            : base(filename)
        {
            this.caller = caller;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public override void LoadIni()
        {
            string value;
            //
            // MainForm
            //
            value = GetProperty(secMainForm, keyWindowState, "Normal");
            if (value == "Maximized")
            {
                caller.WindowState = FormWindowState.Maximized;
            }
            else
            {
                caller.WindowState = FormWindowState.Normal;
            }

            value = GetProperty(secMainForm, keyWidth, "760");
            Width = caller.Width = int.Parse(value);

            value = GetProperty(secMainForm, keyHeight, "560");
            Height = caller.Height = int.Parse(value);

            value = GetProperty(secMainForm, keyTop, "60");
            Top = caller.Top = int.Parse(value);

            value = GetProperty(secMainForm, keyLeft, "40");
            Left = caller.Left = int.Parse(value);

            //
            // Search
            //
            string myDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            value = GetProperty(secSearch, keyDirectory, myDocDir);
            caller.DirPath = value;

            value = GetProperty(secSearch, keyInclSubDir, "0");
            caller.InclSubDir = (value == "0") ? false : true;

            value = GetProperty(secSearch, keyInclHiddenDir, "0");
            caller.InclHiddenDir = (value == "0") ? false : true;

            value = GetProperty(secSearch, keyInclHiddenFile, "0");
            caller.InclHiddenFile = (value == "0") ? false : true;

            value = GetProperty(secSearch, keyFilter, "*.txt|*.html");
            caller.Pattern = value;

            value = GetProperty(secSearch, keyEncoding, "0");
            caller.EncNumber = int.Parse(value);

            //
            // Format
            //
            value = GetProperty(secFormat, keyRegEx, "0");
            caller.RegexEnabled = (value == "0") ? false : true;

            value = GetProperty(secFormat, keyRegExMultiline, "1");
            caller.RegexMultiline = (value == "0") ? false : true;

            //
            // ErrorNotification
            //
            value = GetProperty(secErrorNotice, keyUnauthorizedAccess, "1");
            Progress.NotifyUnauthorizedAccessException = (value == "0") ? false : true;

            value = GetProperty(secErrorNotice, keyPathTooLong, "1");
            Progress.NotifyPathTooLongException = (value == "0") ? false : true;

            value = GetProperty(secErrorNotice, keyDirectoryNotFound, "1");
            Progress.NotifyDirectoryNotFoundException = (value == "0") ? false : true;

            value = GetProperty(secErrorNotice, keyIO, "1");
            Progress.NotifyIOException = (value == "0") ? false : true;

            value = GetProperty(secErrorNotice, keyOtherErrors, "1");
            Progress.NotifyOtherException = (value == "0") ? false : true;

            //
            // FileListView
            //
            value = GetProperty(secFileListView, clmnNameWidth, "120");
            caller.FileListView.ClmnName.Width = int.Parse(value);

            value = GetProperty(secFileListView, clmnCodeWidth, "80");
            caller.FileListView.ClmnCode.Width = int.Parse(value);

            value = GetProperty(secFileListView, clmnPathWidth, "110");
            caller.FileListView.ClmnPath.Width = int.Parse(value);

            value = GetProperty(secFileListView, keySuccessBackColor, "FFAACCFF");
            FileListView.SuccessBackColor =
                Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            value = GetProperty(secFileListView, keyFailureBackColor, "FFFFBB88");
            FileListView.FailureBackColor =
                Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            //
            // AzukiTextBox
            //
            value = GetProperty(secAzukiTextBox, keyForeColor, "FF000000");
            caller.EditorForeColor = Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            value = GetProperty(secAzukiTextBox, keyMarkerColor, "FF7F7F7F");
            caller.EditorMarkerColor = Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            value = GetProperty(secAzukiTextBox, keyBackColorBefore, "FFFFFFFF");
            caller.EditorBeforeBackColor =
                Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            value = GetProperty(secAzukiTextBox, keyBackColorAfter, "FFFFFFFF");
            caller.EditorAfterBackColor =
                Color.FromArgb(int.Parse(value, System.Globalization.NumberStyles.HexNumber));

            value = GetProperty(secAzukiTextBox, keyFontName, "ＭＳ ゴシック");
            string fontName = value;
            value = GetProperty(secAzukiTextBox, keyFontSize, "11");
            float fontSize = float.Parse(value);
            caller.EditorFont = new Font(fontName, fontSize);

            value = GetProperty(secAzukiTextBox, keySpaceVisible, "0");
            caller.DrawSpace = (value == "0") ? false : true;

            value = GetProperty(secAzukiTextBox, keyFullWidthSpaceVisible, "0");
            caller.DrawFullWidthSpace = (value == "0") ? false : true;

            value = GetProperty(secAzukiTextBox, keyTabVisible, "0");
            caller.DrawTab = (value == "0") ? false : true;

            value = GetProperty(secAzukiTextBox, keyNewlineVisible, "1");
            caller.DrawNewline = (value == "0") ? false : true;

            value = GetProperty(secAzukiTextBox, keyEOFVisible, "0");
            caller.DrawEOF = (value == "0") ? false : true;

            value = GetProperty(secAzukiTextBox, keyNewlineChars, "CRLF");
            caller.NewlineChars = value == "CR" ? "\r" : (value == "LF" ? "\n" : "\r\n");

            //
            // Backup
            //
            value = GetProperty(secBackup, keyEnabled, "0");
            caller.BackupArgs.Enabled = (value == "0") ? false : true;

            value = GetProperty(secBackup, keyReplaceExtensionText, "bak");
            caller.BackupArgs.ReplaceExtensionText = value;

            value = GetProperty(secBackup, keyAnotherFolderText, "backup");
            caller.BackupArgs.AnotherFolderText = value;

            value = GetProperty(secBackup, keyUserDefinedText, "%F.bak");
            caller.BackupArgs.UserDefinedText = value;

            value = GetProperty(secBackup, keyBackupOptions, "ReplaceExtension");
            caller.BackupArgs.Mode = (BackupMode) Enum.Parse(typeof(BackupMode), value);
            if (caller.BackupArgs.Enabled && caller.BackupArgs.Mode == BackupMode.SubFolder)
            {
                caller.InclSubDirCheckBoxEnabled = false;
            }

            value = GetProperty(secBackup, keyAppend, "1");
            caller.BackupArgs.AppendMode = (value == "0") ? false : true;

            //
            // Confirm
            //
            value = GetProperty(secConfirm, keyBeforeSearch, "0");
            caller.InformBeforeSearch = (value == "0") ? false : true;

            value = GetProperty(secConfirm, keyAfterSearch, "0");
            caller.InformAfterSearch = (value == "0") ? false : true;

            value = GetProperty(secConfirm, keyBeforeSearchWhereEmpty, "1");
            caller.InformBeforeTextEmpty = (value == "0") ? false : true;

            value = GetProperty(secConfirm, keyBeforeReplace, "1");
            caller.InformBeforeReplace = (value == "0") ? false : true;

            value = GetProperty(secConfirm, keyAfterReplace, "1");
            caller.InformAfterReplace = (value == "0") ? false : true;

            value = GetProperty(secConfirm, keyBeforeReplaceWhereEmpty, "1");
            caller.InformAfterTextEmpty = (value == "0") ? false : true;

            //
            // PrevForm
            //
            value = GetProperty(secPrevForm, keyPrevWidth, "500");
            PreviewForm.DefaultWidth = int.Parse(value);

            value = GetProperty(secPrevForm, keyPrevHeight, "400");
            PreviewForm.DefaultHeight = int.Parse(value);
        }

        public override void SaveIni()
        {
            string value;

            //
            // MainForm
            //
            value = caller.WindowState.ToString();
            SetProperty(secMainForm, keyWindowState, value);

            if (caller.WindowState == FormWindowState.Normal)
            {
                value = caller.Width.ToString();
                SetProperty(secMainForm, keyWidth, value);

                value = caller.Height.ToString();
                SetProperty(secMainForm, keyHeight, value);

                value = caller.Top.ToString();
                SetProperty(secMainForm, keyTop, value);

                value = caller.Left.ToString();
                SetProperty(secMainForm, keyLeft, value);
            }

            //
            // Search
            //
            value = caller.DirPath;
            SetProperty(secSearch, keyDirectory, value);

            value = caller.InclSubDir ? "1" : "0";
            SetProperty(secSearch, keyInclSubDir, value);

            value = caller.InclHiddenDir ? "1" : "0";
            SetProperty(secSearch, keyInclHiddenDir, value);

            value = caller.InclHiddenFile ? "1" : "0";
            SetProperty(secSearch, keyInclHiddenFile, value);

            value = caller.Pattern;
            SetProperty(secSearch, keyFilter, value);

            value = caller.EncNumber.ToString();
            SetProperty(secSearch, keyEncoding, value);

            //
            // Format
            //
            value = caller.RegexEnabled ? "1" : "0";
            SetProperty(secFormat, keyRegEx, value);
            
            value = caller.RegexMultiline ? "1" : "0";
            SetProperty(secFormat, keyRegExMultiline, value);

            //
            // ErrorNotification
            //
            value = Progress.NotifyUnauthorizedAccessException ? "1" : "0";
            SetProperty(secErrorNotice, keyUnauthorizedAccess, value);

            value = Progress.NotifyDirectoryNotFoundException ? "1" : "0";
            SetProperty(secErrorNotice, keyDirectoryNotFound, value);

            value = Progress.NotifyPathTooLongException ? "1" : "0";
            SetProperty(secErrorNotice, keyPathTooLong, value);

            value = Progress.NotifyIOException ? "1" : "0";
            SetProperty(secErrorNotice, keyIO, value);

            value = Progress.NotifyOtherException ? "1" : "0";
            SetProperty(secErrorNotice, keyOtherErrors, value);

            //
            // FileListView
            //
            value = caller.FileListView.ClmnName.Width.ToString();
            SetProperty(secFileListView, clmnNameWidth, value);

            value = caller.FileListView.ClmnCode.Width.ToString();
            SetProperty(secFileListView, clmnCodeWidth, value);

            value = caller.FileListView.ClmnPath.Width.ToString();
            SetProperty(secFileListView, clmnPathWidth, value);

            value = FileListView.SuccessBackColor.ToArgb().ToString("X8");
            SetProperty(secFileListView, keySuccessBackColor, value);

            value = FileListView.FailureBackColor.ToArgb().ToString("X8");
            SetProperty(secFileListView, keyFailureBackColor, value);

            //
            // AzukiTextBox
            //
            value = caller.EditorForeColor.ToArgb().ToString("X8");
            SetProperty(secAzukiTextBox, keyForeColor, value);

            value = caller.EditorMarkerColor.ToArgb().ToString("X8");
            SetProperty(secAzukiTextBox, keyMarkerColor, value);

            value = caller.EditorBeforeBackColor.ToArgb().ToString("X8");
            SetProperty(secAzukiTextBox, keyBackColorBefore, value);

            value = caller.EditorAfterBackColor.ToArgb().ToString("X8");
            SetProperty(secAzukiTextBox, keyBackColorAfter, value);

            value = caller.EditorFont.Name;
            SetProperty(secAzukiTextBox, keyFontName, value);

            value = caller.EditorFont.SizeInPoints.ToString();
            SetProperty(secAzukiTextBox, keyFontSize, value);

            value = caller.DrawSpace ? "1" : "0";
            SetProperty(secAzukiTextBox, keySpaceVisible, value);

            value = caller.DrawFullWidthSpace ? "1" : "0";
            SetProperty(secAzukiTextBox, keyFullWidthSpaceVisible, value);

            value = caller.DrawTab ? "1" : "0";
            SetProperty(secAzukiTextBox, keyTabVisible, value);

            value = caller.DrawNewline ? "1" : "0";
            SetProperty(secAzukiTextBox, keyNewlineVisible, value);

            value = caller.DrawEOF ? "1" : "0";
            SetProperty(secAzukiTextBox, keyEOFVisible, value);

            value = caller.NewlineChars == "\r" ? "CR" : (caller.NewlineChars == "\n" ? "LF" : "CRLF");
            SetProperty(secAzukiTextBox, keyNewlineChars, value);

            //
            // Backup
            //
            value = caller.BackupArgs.Enabled ? "1" : "0";
            SetProperty(secBackup, keyEnabled, value);

            value = caller.BackupArgs.ReplaceExtensionText;
            SetProperty(secBackup, keyReplaceExtensionText, value);

            value = caller.BackupArgs.AnotherFolderText;
            SetProperty(secBackup, keyAnotherFolderText, value);

            value = caller.BackupArgs.UserDefinedText;
            SetProperty(secBackup, keyUserDefinedText, value);

            value = Enum.GetName(typeof(BackupMode), caller.BackupArgs.Mode);
            SetProperty(secBackup, keyBackupOptions, value);

            value = caller.BackupArgs.AppendMode ? "1" : "0";
            SetProperty(secBackup, keyAppend, value);

            //
            // Confirm
            //
            value = caller.InformBeforeSearch ? "1" : "0";
            SetProperty(secConfirm, keyBeforeSearch, value);

            value = caller.InformAfterSearch ? "1" : "0";
            SetProperty(secConfirm, keyAfterSearch, value);

            value = caller.InformBeforeTextEmpty ? "1" : "0";
            SetProperty(secConfirm, keyBeforeSearchWhereEmpty, value);

            value = caller.InformBeforeReplace ? "1" : "0";
            SetProperty(secConfirm, keyBeforeReplace, value);

            value = caller.InformBeforeReplace ? "1" : "0";
            SetProperty(secConfirm, keyAfterReplace, value);

            value = caller.InformAfterTextEmpty ? "1" : "0";
            SetProperty(secConfirm, keyBeforeReplaceWhereEmpty, value);

            //
            // PrevForm
            //
            value = PreviewForm.DefaultWidth.ToString();
            SetProperty(secPrevForm, keyPrevWidth, value);

            value = PreviewForm.DefaultHeight.ToString();
            SetProperty(secPrevForm, keyPrevHeight, value);
        }

        //
        // MainForm
        //
        string secMainForm = "MainForm";
        string keyWindowState = "WindowState";
        string keyWidth = "Width";
        string keyHeight = "Height";
        string keyTop = "Top";
        string keyLeft = "Left";

        //
        // Search
        //
        string secSearch = "Search";
        string keyDirectory = "Directory";
        string keyInclSubDir = "InclSubDir";
        string keyInclHiddenDir = "InclHiddenDir";
        string keyInclHiddenFile = "InclHiddenFile";
        string keyFilter = "Filter";
        string keyEncoding = "Encoding";

        //
        // Format
        //
        string secFormat = "Format";
        string keyRegEx = "RegEx";
        string keyRegExMultiline = "RegExLine";

        //
        // ErrorNotification
        //
        string secErrorNotice = "ErrorNotice";
        string keyUnauthorizedAccess = "UnauthorizedAccess";
        string keyIO = "IO";
        string keyPathTooLong = "PathTooLong";
        string keyDirectoryNotFound = "DirectoryNotFound";
        string keyOtherErrors = "OtherErrors";

        //
        // FileListView
        //
        string secFileListView = "FileListView";
        string clmnNameWidth = "NameColumnWidth";
        string clmnCodeWidth = "EncodigColumnWidth";
        string clmnPathWidth = "PathColumnWidth";
        string keySuccessBackColor = "SuccessBackColor";
        string keyFailureBackColor = "FailureBackColor";

        //
        // AzukiTextBox
        //
        string secAzukiTextBox = "AzukiTextBox";
        string keyForeColor = "ForeColor";
        string keyMarkerColor = "MarkerColor";
        string keyBackColorBefore = "BackColorBefore";
        string keyBackColorAfter = "BackColorAfter";
        string keyFontName = "FontName";
        string keyFontSize = "FontSize";
        string keySpaceVisible = "Space";
        string keyFullWidthSpaceVisible = "FullWidthSpace";
        string keyTabVisible = "Tab";
        string keyNewlineVisible = "Newline";
        string keyEOFVisible = "EOF";
        string keyNewlineChars = "EolCode";

        //
        // Backup
        //
        string secBackup = "Backup";
        string keyEnabled = "Enabled";
        string keyReplaceExtensionText = "Extension";
        string keyAnotherFolderText = "Folder";
        string keyUserDefinedText = "UserDefined";
        string keyBackupOptions = "Mode";
        string keyAppend = "Append";

        //
        // Confirm
        //
        string secConfirm = "Confirm";
        string keyBeforeSearch = "BeforeSearch";
        string keyAfterSearch = "AfterSearch";
        string keyBeforeSearchWhereEmpty = "BeforeSearchWhereEmpty";
        string keyBeforeReplace = "BeforeReplace";
        string keyAfterReplace = "AfterReplace";
        string keyBeforeReplaceWhereEmpty = "BeforeReplaceWhereEmpty";

        //
        // PreviewForm
        //
        string secPrevForm = "Preview";
        string keyPrevWidth = "Width";
        string keyPrevHeight = "Height";
    }
}
