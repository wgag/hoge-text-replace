namespace HogeTextReplace
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            Sgry.Azuki.FontInfo fontInfo2 = new Sgry.Azuki.FontInfo();
            this.panelR = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRegexLine = new System.Windows.Forms.ComboBox();
            this.comboBoxEnc = new System.Windows.Forms.ComboBox();
            this.cbRegex = new System.Windows.Forms.CheckBox();
            this.comboBoxNewline = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fileListView = new utils.FileListView();
            this.llDeselectAllItems = new System.Windows.Forms.LinkLabel();
            this.llSelectAllItems = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPattern = new System.Windows.Forms.TextBox();
            this.btnBrouse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubDir = new System.Windows.Forms.CheckBox();
            this.cbHiddenDir = new System.Windows.Forms.CheckBox();
            this.tbDirPath = new System.Windows.Forms.TextBox();
            this.cbHiddenFile = new System.Windows.Forms.CheckBox();
            this.panelRT = new System.Windows.Forms.Panel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.azukiBefore = new utils.AzukiTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.azukiAfter = new utils.AzukiTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelR.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelRT.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelR
            // 
            this.panelR.Controls.Add(this.groupBox2);
            this.panelR.Controls.Add(this.groupBox3);
            this.panelR.Controls.Add(this.groupBox1);
            this.panelR.Controls.Add(this.panelRT);
            this.panelR.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelR.Location = new System.Drawing.Point(320, 1);
            this.panelR.Name = "panelR";
            this.panelR.Padding = new System.Windows.Forms.Padding(3);
            this.panelR.Size = new System.Drawing.Size(320, 420);
            this.panelR.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxRegexLine);
            this.groupBox2.Controls.Add(this.comboBoxEnc);
            this.groupBox2.Controls.Add(this.cbRegex);
            this.groupBox2.Controls.Add(this.comboBoxNewline);
            this.groupBox2.Location = new System.Drawing.Point(4, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 97);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "オプション";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "改行文字:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "文字コード:";
            // 
            // comboBoxRegexLine
            // 
            this.comboBoxRegexLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegexLine.FormattingEnabled = true;
            this.comboBoxRegexLine.Items.AddRange(new object[] {
            "複数行モード",
            "単一行モード"});
            this.comboBoxRegexLine.Location = new System.Drawing.Point(115, 68);
            this.comboBoxRegexLine.Name = "comboBoxRegexLine";
            this.comboBoxRegexLine.Size = new System.Drawing.Size(98, 20);
            this.comboBoxRegexLine.TabIndex = 4;
            this.comboBoxRegexLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegexLine_SelectedIndexChanged);
            // 
            // comboBoxEnc
            // 
            this.comboBoxEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnc.FormattingEnabled = true;
            this.comboBoxEnc.Location = new System.Drawing.Point(85, 42);
            this.comboBoxEnc.Name = "comboBoxEnc";
            this.comboBoxEnc.Size = new System.Drawing.Size(128, 20);
            this.comboBoxEnc.TabIndex = 7;
            this.comboBoxEnc.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnc_SelectedIndexChanged);
            // 
            // cbRegex
            // 
            this.cbRegex.AutoSize = true;
            this.cbRegex.Location = new System.Drawing.Point(8, 70);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.Size = new System.Drawing.Size(102, 16);
            this.cbRegex.TabIndex = 3;
            this.cbRegex.Text = "正規表現を使う:";
            this.cbRegex.UseVisualStyleBackColor = true;
            this.cbRegex.CheckedChanged += new System.EventHandler(this.cbRegEx_CheckedChanged);
            // 
            // comboBoxNewline
            // 
            this.comboBoxNewline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNewline.FormattingEnabled = true;
            this.comboBoxNewline.Location = new System.Drawing.Point(85, 16);
            this.comboBoxNewline.Name = "comboBoxNewline";
            this.comboBoxNewline.Size = new System.Drawing.Size(128, 20);
            this.comboBoxNewline.TabIndex = 8;
            this.comboBoxNewline.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewline_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fileListView);
            this.groupBox3.Controls.Add(this.llDeselectAllItems);
            this.groupBox3.Controls.Add(this.llSelectAllItems);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(314, 190);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "対象ファイル";
            // 
            // fileListView
            // 
            this.fileListView.AzukiAfter = null;
            this.fileListView.AzukiBefore = null;
            this.fileListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.fileListView.CheckBoxes = true;
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.ForeColor = System.Drawing.SystemColors.GrayText;
            this.fileListView.FullRowSelect = true;
            this.fileListView.GridLines = true;
            this.fileListView.ListValid = false;
            this.fileListView.Location = new System.Drawing.Point(3, 32);
            this.fileListView.Name = "fileListView";
            this.fileListView.OwnerForm = this;
            this.fileListView.RegexEnabled = false;
            this.fileListView.RegexOptions = System.Text.RegularExpressions.RegexOptions.None;
            this.fileListView.ShowItemToolTips = true;
            this.fileListView.Size = new System.Drawing.Size(308, 155);
            this.fileListView.TabIndex = 1;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ListValidityChanged += new utils.FileListView.ListValidityChangedEventHandler(this.fileListView_ListValidityChanged);
            // 
            // llDeselectAllItems
            // 
            this.llDeselectAllItems.AutoSize = true;
            this.llDeselectAllItems.Location = new System.Drawing.Point(67, 18);
            this.llDeselectAllItems.Name = "llDeselectAllItems";
            this.llDeselectAllItems.Size = new System.Drawing.Size(58, 12);
            this.llDeselectAllItems.TabIndex = 16;
            this.llDeselectAllItems.TabStop = true;
            this.llDeselectAllItems.Text = "すべて解除";
            this.llDeselectAllItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDeselectAllItems_LinkClicked);
            // 
            // llSelectAllItems
            // 
            this.llSelectAllItems.AutoSize = true;
            this.llSelectAllItems.Location = new System.Drawing.Point(5, 18);
            this.llSelectAllItems.Name = "llSelectAllItems";
            this.llSelectAllItems.Size = new System.Drawing.Size(58, 12);
            this.llSelectAllItems.TabIndex = 15;
            this.llSelectAllItems.TabStop = true;
            this.llSelectAllItems.Text = "すべて選択";
            this.llSelectAllItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSelectAllItems_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPattern);
            this.groupBox1.Controls.Add(this.btnBrouse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbSubDir);
            this.groupBox1.Controls.Add(this.cbHiddenDir);
            this.groupBox1.Controls.Add(this.tbDirPath);
            this.groupBox1.Controls.Add(this.cbHiddenFile);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 111);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // tbPattern
            // 
            this.tbPattern.Location = new System.Drawing.Point(55, 40);
            this.tbPattern.Name = "tbPattern";
            this.tbPattern.Size = new System.Drawing.Size(197, 19);
            this.tbPattern.TabIndex = 5;
            this.tbPattern.TextChanged += new System.EventHandler(this.tbPattern_TextChanged);
            this.tbPattern.Enter += new System.EventHandler(this.tbPattern_Enter);
            this.tbPattern.Leave += new System.EventHandler(this.tbPattern_Leave);
            // 
            // btnBrouse
            // 
            this.btnBrouse.Location = new System.Drawing.Point(258, 13);
            this.btnBrouse.Name = "btnBrouse";
            this.btnBrouse.Size = new System.Drawing.Size(47, 24);
            this.btnBrouse.TabIndex = 2;
            this.btnBrouse.Text = "参照...";
            this.btnBrouse.UseVisualStyleBackColor = true;
            this.btnBrouse.Click += new System.EventHandler(this.btnBrouse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "ファイル:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "フォルダ:";
            // 
            // cbSubDir
            // 
            this.cbSubDir.AutoSize = true;
            this.cbSubDir.Location = new System.Drawing.Point(8, 66);
            this.cbSubDir.Name = "cbSubDir";
            this.cbSubDir.Size = new System.Drawing.Size(118, 16);
            this.cbSubDir.TabIndex = 3;
            this.cbSubDir.Text = "サブフォルダを含める";
            this.cbSubDir.UseVisualStyleBackColor = true;
            this.cbSubDir.CheckedChanged += new System.EventHandler(this.cbSubDir_CheckedChanged);
            this.cbSubDir.EnabledChanged += new System.EventHandler(this.cbSubDir_EnabledChanged);
            // 
            // cbHiddenDir
            // 
            this.cbHiddenDir.AutoSize = true;
            this.cbHiddenDir.Location = new System.Drawing.Point(132, 66);
            this.cbHiddenDir.Name = "cbHiddenDir";
            this.cbHiddenDir.Size = new System.Drawing.Size(120, 16);
            this.cbHiddenDir.TabIndex = 4;
            this.cbHiddenDir.Text = "隠しフォルダを含める";
            this.cbHiddenDir.UseVisualStyleBackColor = true;
            this.cbHiddenDir.CheckedChanged += new System.EventHandler(this.cbHiddenDir_CheckedChanged);
            // 
            // tbDirPath
            // 
            this.tbDirPath.Location = new System.Drawing.Point(55, 16);
            this.tbDirPath.Name = "tbDirPath";
            this.tbDirPath.Size = new System.Drawing.Size(197, 19);
            this.tbDirPath.TabIndex = 3;
            this.tbDirPath.TextChanged += new System.EventHandler(this.tbDirPath_TextChanged);
            this.tbDirPath.Enter += new System.EventHandler(this.tbDirPath_Enter);
            this.tbDirPath.Leave += new System.EventHandler(this.tbDirPath_Leave);
            // 
            // cbHiddenFile
            // 
            this.cbHiddenFile.AutoSize = true;
            this.cbHiddenFile.Location = new System.Drawing.Point(8, 87);
            this.cbHiddenFile.Name = "cbHiddenFile";
            this.cbHiddenFile.Size = new System.Drawing.Size(119, 16);
            this.cbHiddenFile.TabIndex = 6;
            this.cbHiddenFile.Text = "隠しファイルを含める";
            this.cbHiddenFile.UseVisualStyleBackColor = true;
            this.cbHiddenFile.CheckedChanged += new System.EventHandler(this.cbHiddenFile_CheckedChanged);
            // 
            // panelRT
            // 
            this.panelRT.Controls.Add(this.btnReplace);
            this.panelRT.Controls.Add(this.btnFind);
            this.panelRT.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRT.Location = new System.Drawing.Point(3, 3);
            this.panelRT.Name = "panelRT";
            this.panelRT.Size = new System.Drawing.Size(314, 224);
            this.panelRT.TabIndex = 0;
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Location = new System.Drawing.Point(229, 175);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(80, 35);
            this.btnReplace.TabIndex = 1;
            this.btnReplace.Text = "置換";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(229, 128);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 35);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "検索";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(1, 1);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.azukiBefore);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 22, 0, 0);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.azukiAfter);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 22, 0, 0);
            this.splitContainer.Size = new System.Drawing.Size(319, 420);
            this.splitContainer.SplitterDistance = 212;
            this.splitContainer.TabIndex = 1;
            // 
            // azukiBefore
            // 
            this.azukiBefore.BackColor = System.Drawing.SystemColors.Window;
            this.azukiBefore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.azukiBefore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azukiBefore.DrawingOption = ((Sgry.Azuki.DrawingOption)((Sgry.Azuki.DrawingOption.DrawsTab | Sgry.Azuki.DrawingOption.DrawsEol)));
            this.azukiBefore.DrawsFullWidthSpace = false;
            this.azukiBefore.FirstVisibleLine = 0;
            this.azukiBefore.Font = new System.Drawing.Font("MS Gothic", 9F);
            fontInfo1.Name = "MS Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azukiBefore.FontInfo = fontInfo1;
            this.azukiBefore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.azukiBefore.HighlightsCurrentLine = false;
            this.azukiBefore.HighlightsMatchedBracket = false;
            this.azukiBefore.Location = new System.Drawing.Point(0, 22);
            this.azukiBefore.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.azukiBefore.Name = "azukiBefore";
            this.azukiBefore.NewlineChars = "\r\n";
            this.azukiBefore.ScrollPos = new System.Drawing.Point(0, 0);
            this.azukiBefore.ScrollsBeyondLastLine = false;
            this.azukiBefore.ShowsDirtBar = false;
            this.azukiBefore.ShowsLineNumber = false;
            this.azukiBefore.Size = new System.Drawing.Size(319, 190);
            this.azukiBefore.TabIndex = 5;
            this.azukiBefore.TabWidth = 4;
            this.azukiBefore.ViewWidth = 4097;
            this.azukiBefore.TextChanged += new System.EventHandler(this.azukiBefore_TextChanged);
            this.azukiBefore.Enter += new System.EventHandler(this.azukiBefore_Enter);
            this.azukiBefore.Leave += new System.EventHandler(this.azukiBefore_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "置換前:";
            // 
            // azukiAfter
            // 
            this.azukiAfter.BackColor = System.Drawing.SystemColors.Window;
            this.azukiAfter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.azukiAfter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azukiAfter.DrawingOption = ((Sgry.Azuki.DrawingOption)((Sgry.Azuki.DrawingOption.DrawsTab | Sgry.Azuki.DrawingOption.DrawsEol)));
            this.azukiAfter.DrawsFullWidthSpace = false;
            this.azukiAfter.FirstVisibleLine = 0;
            this.azukiAfter.Font = new System.Drawing.Font("MS Gothic", 9F);
            fontInfo2.Name = "MS Gothic";
            fontInfo2.Size = 9;
            fontInfo2.Style = System.Drawing.FontStyle.Regular;
            this.azukiAfter.FontInfo = fontInfo2;
            this.azukiAfter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.azukiAfter.HighlightsCurrentLine = false;
            this.azukiAfter.HighlightsMatchedBracket = false;
            this.azukiAfter.Location = new System.Drawing.Point(0, 22);
            this.azukiAfter.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.azukiAfter.Name = "azukiAfter";
            this.azukiAfter.NewlineChars = "\r\n";
            this.azukiAfter.ScrollPos = new System.Drawing.Point(0, 0);
            this.azukiAfter.ScrollsBeyondLastLine = false;
            this.azukiAfter.ShowsDirtBar = false;
            this.azukiAfter.ShowsLineNumber = false;
            this.azukiAfter.Size = new System.Drawing.Size(319, 182);
            this.azukiAfter.TabIndex = 3;
            this.azukiAfter.TabWidth = 4;
            this.azukiAfter.ViewWidth = 4097;
            this.azukiAfter.TextChanged += new System.EventHandler(this.azukiAfter_TextChanged);
            this.azukiAfter.Enter += new System.EventHandler(this.azukiAfter_Enter);
            this.azukiAfter.Leave += new System.EventHandler(this.azukiAfter_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "置換後:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 422);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelR);
            this.MinimumSize = new System.Drawing.Size(580, 400);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Hoge Text Replace";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.panelR.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelRT.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelR;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelRT;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.LinkLabel llDeselectAllItems;
        private System.Windows.Forms.LinkLabel llSelectAllItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPattern;
        private System.Windows.Forms.TextBox tbDirPath;
        private System.Windows.Forms.Button btnBrouse;
        private System.Windows.Forms.ComboBox comboBoxEnc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbHiddenFile;
        private System.Windows.Forms.CheckBox cbHiddenDir;
        private System.Windows.Forms.CheckBox cbSubDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbRegex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxNewline;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxRegexLine;
        private utils.FileListView fileListView;
        private utils.AzukiTextBox azukiBefore;
        private utils.AzukiTextBox azukiAfter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}