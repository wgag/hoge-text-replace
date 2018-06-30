using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HogeTextReplace
{
    partial class OptionDialog : Form
    {
        #region Properties
        //
        // tabView
        //
        public Color EditorForeColor { get { return btnForeColor.BackColor; } set { btnForeColor.BackColor = value; } }
        public Color EditorMarkerColor { get { return btnMarkerColor.BackColor; } set { btnMarkerColor.BackColor = value; } }
        public Color EcitorBeforeBackColor { get { return btnBackColorBefore.BackColor; } set { btnBackColorBefore.BackColor = value; } }
        public Color EditorAfterBackColor { get { return btnBackColorAfter.BackColor; } set { btnBackColorAfter.BackColor = value; } }

        public Font EditorFont { get { return lbFontSample.Font; } set { lbFontSample.Font = value; } }
        public Color SuccessColour { get { return btnSuccessColor.BackColor; } set { btnSuccessColor.BackColor = value; } }
        public Color FailureColour { get { return btnFailureColor.BackColor; } set { btnFailureColor.BackColor = value; } }

        public bool DrawEOF { get { return cbEOF.Checked; } set { cbEOF.Checked = value; } }
        public bool DrawFullWidthSpace { get { return cbFullWidthSpace.Checked; } set { cbFullWidthSpace.Checked = value; } }
        public bool DrawNewline { get { return cbNewline.Checked; } set { cbNewline.Checked = value; } }
        public bool DrawSpace { get { return cbSpace.Checked; } set { cbSpace.Checked = value; } }
        public bool DrawTab { get { return cbTab.Checked; } set { cbTab.Checked = value; } }

        //
        // tabNotice
        //
        public bool NotifyUnauthorizedAccessException { get { return cbNotifyUnauthorizedAccessException.Checked; } set { cbNotifyUnauthorizedAccessException.Checked = value; } }
        public bool NotifyPathTooLongException { get { return cbNotifyPathTooLongException.Checked; } set { cbNotifyPathTooLongException.Checked = value; } }
        public bool NotifyDirectoryNotFoundException { get { return cbNotifyDirectoryNotFoundException.Checked; } set { cbNotifyDirectoryNotFoundException.Checked = value; } }
        public bool NotifyIOException { get { return cbNotifyIOException.Checked; } set { cbNotifyIOException.Checked = value; } }
        public bool NotifyOtherException { get { return cbNotifyOtherException.Checked; } set { cbNotifyOtherException.Checked = value; } }

        public bool InformBeforeSearch { get { return cbInformBeforeSearch.Checked; } set { cbInformBeforeSearch.Checked = value; } }
        public bool InformAfterSearch { get { return cbInformAfterSearch.Checked; } set { cbInformAfterSearch.Checked = value; } }
        public bool InformBeforeTextEmpty { get { return cbInformBeforeTextEmpty.Checked; } set { cbInformBeforeTextEmpty.Checked = value; } }
        public bool InformBeforeReplace { get { return cbInformBeforeReplace.Checked; } set { cbInformBeforeReplace.Checked = value; } }
        public bool InformAfterReplace { get { return cbInformAfterReplace.Checked; } set { cbInformAfterReplace.Checked = value; } }
        public bool InformAfterTextEmpty { get { return cbInformAfterTextEmpty.Checked; } set { cbInformAfterTextEmpty.Checked = value; } }

        //
        // tabBackup
        //
        public bool BackupEnabled { get { return cbEnableBackup.Checked; } set { cbEnableBackup.Checked = value; } }
        public bool BackupAppending { get { return rbAppend.Checked; } set { rbAppend.Checked = value; rbOverWrite.Checked = !value; } }

        public BackupMode BackupMode
        {
            get
            {
                if (rbReplaceExtension.Checked) { return BackupMode.ReplaceExtension; }
                if (rbAnotherFolder.Checked) { return BackupMode.SubFolder; }
                if (rbUserDefinition.Checked) { return BackupMode.UserDefined; }
                else { return 0; }
            }
            set
            {
                rbReplaceExtension.Checked = value == BackupMode.ReplaceExtension;
                rbAnotherFolder.Checked = value == BackupMode.SubFolder;
                rbUserDefinition.Checked = value == BackupMode.UserDefined;
            }
        }

        public string BackupExtension { get { return tbExtension.Text; } set { tbExtension.Text = value; UpdateTabBackup(); } }
        public string BackupFolder { get { return tbAnotherFolder.Text; } set { tbAnotherFolder.Text = value; UpdateTabBackup(); } }
        public string BackupUserDefinition { get { return tbUserDefinition.Text; } set { tbUserDefinition.Text = value; UpdateTabBackup(); } }

        private void UpdateTabBackup()
        {
            if (cbEnableBackup.Checked)
            {
                gbAppend.Enabled = true;
                gbFilePath.Enabled = true;

                tbExtension.Enabled = label6.Enabled = rbReplaceExtension.Checked;
                tbAnotherFolder.Enabled = label13.Enabled = label14.Enabled = rbAnotherFolder.Checked;
                tbUserDefinition.Enabled = label7.Enabled =
                    lbUserDefinitionSampleResult.Enabled =
                    tbPatternDescription.Enabled =
                    rbUserDefinition.Checked;
            }
            else // !cbEnableBackup.Checked
            {
                gbAppend.Enabled = false;
                gbFilePath.Enabled = false;
            }
        }
        #endregion

        #region Fields
        private static bool onceNoticedAboutUserDefinition = false;
        private static int startTabIndex = 0;

        private bool initializationFinished = false;
        #endregion

        #region Constructor
        public OptionDialog()
        {
            this.InitializeComponent();
            tbUserDefinition_TextChanged(null, null);
        }

        #endregion

        #region EventHandlers

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tabControl.SelectedIndex = startTabIndex;

            initializationFinished = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DetectErrors()) { e.Cancel = true; return; }
            base.OnClosing(e);

            startTabIndex = tabControl.SelectedIndex;

        }

        // if errors found, returns true
        bool DetectErrors()
        {
            //
            // error
            //
            if (tbExtension.Text.Length == 0 ||
                tbAnotherFolder.Text.Length == 0 ||
                tbUserDefinition.Text.Length == 0)
            {
                MessageBox.Show("テキストを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            foreach (char ch in System.IO.Path.GetInvalidFileNameChars())
            {
                string str = ch.ToString();
                if (tbExtension.Text.Contains(str) ||
                    tbUserDefinition.Text.Contains(str))
                {
                    MessageBox.Show(string.Format("文字 {0} は指定できません。", str), "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }


        private void tabBackup_CheckedChanged(object sender, EventArgs eventArgs)
        {
            UpdateTabBackup();

            if (BackupEnabled && rbUserDefinition.Checked && initializationFinished && !onceNoticedAboutUserDefinition)
            {
                onceNoticedAboutUserDefinition = true;
                string msg = "バックアップファイルが検索対象とならないないように、\nパターンの指定方法を工夫してください。";
                MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnChangeFont_Click(object sender, EventArgs eventArgs)
        {
            fontDialog.Font = lbFontSample.Font;

            try
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    float modifiedSize;
                    if (fontDialog.Font.Size == 8.25)
                    {
                        modifiedSize = 8f;
                    }
                    else if (fontDialog.Font.Size == 9.75)
                    {
                        modifiedSize = 10f;
                    }
                    else if (fontDialog.Font.Size == 11.25)
                    {
                        modifiedSize = 11f;
                    }
                    else if (fontDialog.Font.Size == 12.75)
                    {
                        modifiedSize = 13f;
                    }
                    else if (fontDialog.Font.Size == 14.25)
                    {
                        modifiedSize = 14f;
                    }
                    else if (fontDialog.Font.Size == 15.75)
                    {
                        modifiedSize = 16f;
                    }
                    else
                    {
                        modifiedSize = fontDialog.Font.Size;
                    }

                    lbFontSample.Font = new System.Drawing.Font(fontDialog.Font.FontFamily, modifiedSize, fontDialog.Font.Style, fontDialog.Font.Unit);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lbFontSample_FontChanged(object sender, EventArgs eventArgs)
        {
            string fontName = lbFontSample.Font.Name;
            string fontSize = lbFontSample.Font.SizeInPoints.ToString();
            lbFontDescription.Text
                = string.Format("{0} ({1} pt)", fontName, fontSize);
        }

        private void btnForeColor_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnForeColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnForeColor.BackColor = colorDialog.Color;
            }
        }

        private void btnMarkerColor_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnMarkerColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnMarkerColor.BackColor = colorDialog.Color;
            }
        }


        private void btnBackColorBefore_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnBackColorBefore.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnBackColorBefore.BackColor = colorDialog.Color;
            }
        }

        private void btnBackColorAfter_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnBackColorAfter.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnBackColorAfter.BackColor = colorDialog.Color;
            }
        }

        private void btnSuccessColor_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnSuccessColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnSuccessColor.BackColor = colorDialog.Color;
            }
        }

        private void btnFailureColor_Click(object sender, EventArgs eventArgs)
        {
            colorDialog.Color = btnFailureColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnFailureColor.BackColor = colorDialog.Color;
            }
        }

        private void tbUserDefinition_TextChanged(object sender, EventArgs eventArgs)
        {
            string tmp_path = @"c:\" + "sample.txt";
            string result = BackupArgs.UserDefinedBackupFileName(tmp_path, tbUserDefinition.Text);
            result = result.Replace(@"c:\", "");
            lbUserDefinitionSampleResult.Text = result;
        }

        #endregion

    }
}
