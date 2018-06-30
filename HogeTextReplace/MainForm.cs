using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using utils;

namespace HogeTextReplace
{
    public partial class MainForm : Form
    {
        #region Fields

        IniForMainForm iniFile;
        const int defaultPanelLWidth = 320;
        const int chWidth = 760;

        const string beforeTextSaveFile = "text_before.ini";
        const string afterTextSaveFile = "text_after.ini";

        string[] eolCodes = { "CRLF (Windows)", "LF (UNIX)", "CR (Mac)" };
        BackupArgs _BackupArgs = new BackupArgs();
        Progress _Progress = new Progress();
        #endregion

        #region Public Properties

        public BackupArgs BackupArgs { get { return _BackupArgs; } set { _BackupArgs = value; } }

        public Progress Progress { get { return _Progress; } set { _Progress = value; } }

        public FileListView FileListView { get { return fileListView; } set { fileListView = value; } }

        //
        // Azuki Editor
        //
        public Color EditorForeColor { get { return azukiAfter.ForeColor; } set { azukiAfter.ForeColor = azukiBefore.ForeColor = value; } }
        public Color EditorMarkerColor { get { return azukiAfter.MarkerColor; } set { azukiAfter.MarkerColor = azukiBefore.MarkerColor = value; } }
        public Color EditorBeforeBackColor { get { return azukiBefore.BackColor; } set { azukiBefore.BackColor = value; } }
        public Color EditorAfterBackColor { get { return azukiAfter.BackColor; } set { azukiAfter.BackColor = value; } }

        public Font EditorFont { get { return azukiAfter.Font; } set { azukiAfter.Font = azukiBefore.Font = value; } }

        public bool DrawEOF { get { return azukiAfter.DrawsEofMark; } set { azukiAfter.DrawsEofMark = azukiBefore.DrawsEofMark = value; } }
        public bool DrawFullWidthSpace { get { return azukiAfter.DrawsFullWidthSpace; } set { azukiAfter.DrawsFullWidthSpace = azukiBefore.DrawsFullWidthSpace = value; } }
        public bool DrawNewline { get { return azukiAfter.DrawsEolCode; } set { azukiAfter.DrawsEolCode = azukiBefore.DrawsEolCode = value; } }
        public bool DrawSpace { get { return azukiAfter.DrawsSpace; } set { azukiAfter.DrawsSpace = azukiBefore.DrawsSpace = value; } }
        public bool DrawTab { get { return azukiAfter.DrawsTab; } set { azukiAfter.DrawsTab = azukiBefore.DrawsTab = value; } }

        public string NewlineChars
        {
            get
            {
                switch (comboBoxNewline.SelectedIndex)
                {
                    case 1:
                        return "\n";
                    case 2:
                        return "\r";
                    default:
                        return "\r\n";
                }
            }
            set
            {
                comboBoxNewline.SelectedIndex = value == "\n" ? 1 : (value == "\r" ? 2 : 0);
            }
        }
        //
        // Notice
        //
        public bool InformBeforeSearch { get; set; }
        public bool InformAfterSearch { get; set; }
        public bool InformBeforeTextEmpty { get; set; }
        public bool InformBeforeReplace { get; set; }
        public bool InformAfterReplace { get; set; }
        public bool InformAfterTextEmpty { get; set; }

        //
        // Find & Replace
        //
        public string DirPath { get { return tbDirPath.Text; } set { tbDirPath.Text = value; } }
        public string Pattern { get { return tbPattern.Text; } set { tbPattern.Text = value; } }
        public string BeforeText { get { return azukiBefore.Text; } set { azukiBefore.Text = value; } }
        public string AfterText { get { return azukiAfter.Text; } set { azukiAfter.Text = value; } }
        public bool InclSubDir { get { return cbSubDir.Checked; } set { cbSubDir.Checked = value; } }
        public bool InclSubDirCheckBoxEnabled
        {
            get { return cbSubDir.Enabled; }
            set
            {
                cbSubDir.Enabled = value;
                if (!value) { cbSubDir.Checked = false; }
                cbHiddenDir.Enabled = cbSubDir.Enabled && cbSubDir.Checked;
            }
        }
        public bool InclHiddenDir { get { return cbHiddenDir.Checked; } set { cbHiddenDir.Checked = value; } }
        public bool InclHiddenFile { get { return cbHiddenFile.Checked; } set { cbHiddenFile.Checked = value; } }
        public bool RegexEnabled { get { return cbRegex.Checked; } set { cbRegex.Checked = value; } }
        public bool RegexMultiline { get { return comboBoxRegexLine.SelectedIndex == 0; } set { comboBoxRegexLine.SelectedIndex = (value ? 0 : 1); } } 
        public int EncNumber { get { return comboBoxEnc.SelectedIndex; } set { comboBoxEnc.SelectedIndex = value; } }

        #endregion

        #region Edit
        //
        // Copy, Paste, ...
        //
        void Undo(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { _textBox.Undo(); }
            else if (_azukiTextBox != null) { _azukiTextBox.Undo(); }
        }

        void Redo(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { }
            else if (_azukiTextBox != null) { _azukiTextBox.Redo(); }
        }

        void Cut(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { _textBox.Cut(); }
            else if (_azukiTextBox != null) { _azukiTextBox.Cut(); }
        }

        void Copy(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { _textBox.Copy(); }
            else if (_azukiTextBox != null) { _azukiTextBox.Copy(); }
        }

        void Paste(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { _textBox.Paste(); }
            else if (_azukiTextBox != null) { _azukiTextBox.Paste(); }
        }

        void SelectAll(object sender, EventArgs e)
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { _textBox.SelectAll(); }
            else if (_azukiTextBox != null) { _azukiTextBox.SelectAll(); }
        }

        //
        // CanCopy, CanPaste, ...
        //
        bool CanUndo()
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return _textBox.CanUndo; }
            else if (_azukiTextBox != null) { return _azukiTextBox.CanUndo; }
            else { return false; }
        }
        bool CanRedo()
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return false; }
            else if (_azukiTextBox != null) { return _azukiTextBox.CanRedo; }
            else { return false; }
        }
        bool CanCut()
        {
            TextBox _textBox = new TextBox();
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return _textBox.SelectionLength > 0; }
            else if (_azukiTextBox != null) { return !_azukiTextBox.CanCut; }  // ???
            else { return false; }
        }
        bool CanCopy()
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return _textBox.SelectionLength > 0; }
            else if (_azukiTextBox != null) { return !_azukiTextBox.CanCopy; }  // ???
            else { return false; }
        }
        bool CanPaste()
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return Clipboard.ContainsText(); }
            else if (_azukiTextBox != null) { return _azukiTextBox.CanPaste; }
            else { return false; }
        }
        bool CanSelectAll()
        {
            TextBox _textBox;
            AzukiTextBox _azukiTextBox;
            GetFocusedTextBox(out _textBox, out _azukiTextBox);

            if (_textBox != null) { return true; }
            else if (_azukiTextBox != null) { return true; }
            else { return false; }
        }

        //
        // FocusedTextBox
        //
        TextBox _focusedNormalTextBox = null;
        AzukiTextBox _focusedAzukiTextBox = null;

        void GetFocusedTextBox(out TextBox _textBox, out AzukiTextBox _azukiTextBox)
        {
            _textBox = null;
            _azukiTextBox = null;

            if (_focusedNormalTextBox != null)
            {
                _textBox = _focusedNormalTextBox;
            }
            else if (_focusedAzukiTextBox != null)
            {
                _azukiTextBox = _focusedAzukiTextBox;
            }
        }

        // overload: normal TextBox version
        void SetFocusedTextBox(TextBox _textBox)
        {
            if (_textBox.Focused)
            {
                _focusedNormalTextBox = _textBox;
            }
            else // !textBox.Focused
            {
                _focusedNormalTextBox = null;
            }
            _focusedAzukiTextBox = null;
        }

        // overload: AzukiTextBox version
        void SetFocusedTextBox(AzukiTextBox _azukiTextBox)
        {
            if (_azukiTextBox.Focused)
            {
                _focusedAzukiTextBox = _azukiTextBox;
            }
            else // !textBox.Focused
            {
                _focusedAzukiTextBox = null;
            }
            _focusedNormalTextBox = null;
        }
        #endregion

        #region File

        void Brouse(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                OpenFolderDialog dialog = new OpenFolderDialog();

                if (System.IO.Directory.Exists(DirPath))
                {
                    dialog.InitialFolder = DirPath;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DirPath = dialog.Folder;
                }
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog()
                {
                    Description = "検索対象のフォルダを選択してください。",
                };
                if (System.IO.Directory.Exists(DirPath))
                {
                    dialog.SelectedPath = DirPath;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DirPath = dialog.SelectedPath;
                }
            }
        }

        void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Help
        void About(object sender, EventArgs e)
        {
            using (AboutDialog dialog = new AboutDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK) { }
            }
        }

        void ViewHelp(object sender, EventArgs eventArgs)
        {
            try
            {
                System.Diagnostics.Process.Start("doc\\index.html");
                //System.Diagnostics.Process.Start("HogeTextReplacer.chm");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Menu

        void InitializeMainMenu()
        {
            //
            // miFile
            //
            miFile = new MenuItem("ファイル(&F)");
            miBrouse = new MenuItem("参照(&R)...", Brouse);
            miExit = new MenuItem("終了(&X)", Exit, Shortcut.AltF4);
            miFile.MenuItems.AddRange(new MenuItem[]
            {
                miBrouse, miExit
            });
            //
            // miEdit
            //
            miEdit = new MenuItem("編集(&E)");
            miUndo = new MenuItem("元に戻す(&U)", Undo, Shortcut.CtrlZ);
            miRedo = new MenuItem("やり直し(&R)", Redo, Shortcut.CtrlY);
            miCut = new MenuItem("切り取り(&T)", Cut, Shortcut.CtrlX);
            miCopy = new MenuItem("コピー(&C)", Copy, Shortcut.CtrlC);
            miPaste = new MenuItem("貼り付け(&P)", Paste, Shortcut.CtrlV);
            //miDelete = new MenuItem("削除(&D)", Delete, Shortcut.Del);
            miSelectAll = new MenuItem("すべて選択(&A)", SelectAll, Shortcut.CtrlA);
            miEdit.Popup += (object sender, EventArgs eventArgs) =>
            {
                miUndo.Enabled = CanUndo();
                miRedo.Enabled = CanRedo();
                miCut.Enabled = CanCut();
                miCopy.Enabled = CanCopy();
                miPaste.Enabled = CanPaste();
                miSelectAll.Enabled = CanSelectAll();

            };
            miEdit.MenuItems.AddRange(new MenuItem[]
            {
                miUndo, miRedo, new MenuItem("-"),
                miCut, miCopy, miPaste, new MenuItem("-"),
                miSelectAll
            });
            //
            // miOperation
            //
            miOperation = new MenuItem("操作(&O)");
            miFind = new MenuItem("検索(&F)", Find, Shortcut.F3);
            miReplace = new MenuItem("置換(&R)", Replace, Shortcut.F4);
            miOperation.Popup += delegate(object sender, EventArgs eventArgs)
            {
                miReplace.Enabled = btnReplace.Enabled;
            };
            miOperation.MenuItems.AddRange(new MenuItem[]
            {
                miFind, miReplace
            });

            //
            // miSettings
            //
            miSettings = new MenuItem("設定(&S)");
            miSettings.Popup += delegate(object sender, EventArgs eventArgs)
            {
                miRegEx.Checked = cbRegex.Checked;
            };
            miRegEx = new MenuItem("正規表現(&R)");
            miRegEx.Click += delegate(object sender, EventArgs eventArgs)
            {
                cbRegex.Checked = cbRegex.Checked ? false : true;
            };

            miOptions = new MenuItem("オプション(&O)...", OptionDlg);
            miSettings.MenuItems.AddRange(new MenuItem[]
            {
                 miRegEx, miOptions
            });

            //
            // miHelp
            //
            miHelp = new MenuItem("ヘルプ(&H)");
            miAbout = new MenuItem("バージョン情報(&A)...", About);
            miViewHelp = new MenuItem("ヘルプの表示(&H)", ViewHelp, Shortcut.F1);
            miHelp.MenuItems.AddRange(new MenuItem[]
            {
                miViewHelp, miAbout
            });
            //
            // mainMenu
            //
            mainMenu.MenuItems.AddRange(new MenuItem[]
            {
                miFile, miEdit, miOperation, miSettings, miHelp
            });
            //
            // MainForm
            //
            this.Menu = mainMenu;

        }

        //
        // MainMenuItems
        //
        MenuItem miFile;
        MenuItem miBrouse;
        MenuItem miExit;

        MenuItem miEdit;
        MenuItem miUndo;
        MenuItem miRedo;
        MenuItem miCut;
        MenuItem miCopy;
        MenuItem miPaste;
        MenuItem miSelectAll;

        MenuItem miOperation;
        MenuItem miFind;
        MenuItem miReplace;

        MenuItem miSettings;
        MenuItem miRegEx;
        MenuItem miOptions;

        MenuItem miHelp;
        MenuItem miAbout;
        MenuItem miViewHelp;

        MainMenu mainMenu = new MainMenu();

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            InitializeMainMenu();

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            this.Text = "Hoge Text Replace " + assemblyName.Version.Major + "." + assemblyName.Version.Minor;

            this.Icon = global::HogeTextReplace.Properties.Resources.ProgramIcon;

            for (int i = 0; i <= JpnEncoding.MaxNumber; i++)
            {
                comboBoxEnc.Items.Add(JpnEncoding.NumberToJpnEncoding(i).Name);
            }
            comboBoxEnc.SelectedIndex = 0;

            cbRegEx_CheckedChanged(null, null);
            cbSubDir_CheckedChanged(null, null);
            cbSubDir_EnabledChanged(null, null);

            InclSubDirCheckBoxEnabled = (BackupArgs.Mode != BackupMode.SubFolder); // to avoid backup files found

            comboBoxNewline.Items.AddRange(eolCodes);
            comboBoxNewline.SelectedIndex = 0;

            LoadTextContent();  // from text_before.ini and text_after.ini

            azukiBefore.ScrollToCaret();
            azukiAfter.ScrollToCaret();
           
            azukiBefore.Document.ClearHistory();
            azukiAfter.Document.ClearHistory();

            iniFile = new IniForMainForm("config.ini", this);
            iniFile.LoadIni();
        }

        #endregion

        #region Event Handlers

        protected override void OnLoad(EventArgs e)
        {
            Width = iniFile.Width;
            Height = iniFile.Height;
            Top = iniFile.Top;
            Left = iniFile.Left;

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            iniFile.SaveIni();
            this.SaveTextContent();

            base.OnFormClosing(e);
        }

        void LoadTextContent()
        {
            try
            {
                using (StreamReader sr = new StreamReader(beforeTextSaveFile, Encoding.UTF8))
                {
                    azukiBefore.Text = sr.ReadToEnd();
                }
                using (StreamReader sr = new StreamReader(afterTextSaveFile, Encoding.UTF8))
                {
                    azukiAfter.Text = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
            }
        }

        void SaveTextContent()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(beforeTextSaveFile, false, Encoding.UTF8))
                {
                    sw.Write(azukiBefore.Text);
                    sw.Close();
                }
                using (StreamWriter sw = new StreamWriter(afterTextSaveFile, false, Encoding.UTF8))
                {
                    sw.Write(azukiAfter.Text);
                }
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width < chWidth)
            {
                panelR.Width = defaultPanelLWidth;
            }
            else
            {
                panelR.Width = defaultPanelLWidth + (this.ClientSize.Width - chWidth) / 3;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find(sender, e);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Replace(sender, e);
        }

        private void btnBrouse_Click(object sender, EventArgs e)
        {
            Brouse(sender, e);
        }

        private void tbDirPath_TextChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void tbDirPath_Enter(object sender, EventArgs e)
        {
            SetFocusedTextBox(tbDirPath);
        }

        private void tbDirPath_Leave(object sender, EventArgs e)
        {
            SetFocusedTextBox(tbDirPath);
        }

        private void tbPattern_TextChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void tbPattern_Enter(object sender, EventArgs e)
        {
            SetFocusedTextBox(tbPattern);
        }

        private void tbPattern_Leave(object sender, EventArgs e)
        {
            SetFocusedTextBox(tbPattern);
        }

        private void cbSubDir_CheckedChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
            cbHiddenDir.Enabled = cbSubDir.Checked;
        }

        private void cbSubDir_EnabledChanged(object sender, EventArgs e)
        {
            cbHiddenDir.Enabled = cbSubDir.Checked;
        }

        private void cbHiddenDir_CheckedChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void cbHiddenFile_CheckedChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void comboBoxEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void cbRegEx_CheckedChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
            comboBoxRegexLine.Enabled = cbRegex.Checked && cbRegex.Enabled;
        }


        private void comboBoxRegexLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void azukiBefore_TextChanged(object sender, EventArgs e)
        {
            fileListView.ListValid = false;
        }

        private void azukiBefore_Enter(object sender, EventArgs e)
        {
            SetFocusedTextBox(azukiBefore);
        }

        private void azukiBefore_Leave(object sender, EventArgs e)
        {
            SetFocusedTextBox(azukiBefore);

        }

        private void azukiAfter_Enter(object sender, EventArgs e)
        {
            SetFocusedTextBox(azukiAfter);
        }

        private void azukiAfter_Leave(object sender, EventArgs e)
        {
            SetFocusedTextBox(azukiAfter);
        }

        private void llSelectAllItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
            {
                item.Checked = true;
            }
        }

        private void llDeselectAllItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
            {
                item.Checked = false;
            }
        }

        private void fileListView_ListValidityChanged()
        {

            if (!fileListView.ListValid)
            {
                foreach (ListViewItem item in fileListView.CheckedItems)
                {
                    item.Checked = false;
                }
            }

            btnReplace.Enabled = fileListView.ListValid;
            if (btnReplace.Enabled) { btnReplace.Focus(); }
        }

        private void comboBoxNewline_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            azukiAfter.NewlineChars = azukiBefore.NewlineChars = NewlineChars;
            azukiAfter.UpdateNewlineChars();
            azukiBefore.UpdateNewlineChars();
        }

        private void azukiAfter_TextChanged(object sender, EventArgs e)
        {
            // do nothing
        }

        #endregion

    }
}
