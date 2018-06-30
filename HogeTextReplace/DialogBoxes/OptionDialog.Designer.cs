namespace HogeTextReplace
{
    partial class OptionDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.gbAppend = new System.Windows.Forms.GroupBox();
            this.rbAppend = new System.Windows.Forms.RadioButton();
            this.rbOverWrite = new System.Windows.Forms.RadioButton();
            this.gbFilePath = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbPatternDescription = new System.Windows.Forms.TextBox();
            this.lbUserDefinitionSampleResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbUserDefinition = new System.Windows.Forms.TextBox();
            this.rbUserDefinition = new System.Windows.Forms.RadioButton();
            this.tbAnotherFolder = new System.Windows.Forms.TextBox();
            this.tbExtension = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbAnotherFolder = new System.Windows.Forms.RadioButton();
            this.rbReplaceExtension = new System.Windows.Forms.RadioButton();
            this.cbEnableBackup = new System.Windows.Forms.CheckBox();
            this.tabView = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFailureColor = new System.Windows.Forms.Button();
            this.btnSuccessColor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangeFont = new System.Windows.Forms.Button();
            this.lbFontDescription = new System.Windows.Forms.Label();
            this.lbFontSample = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackColorAfter = new System.Windows.Forms.Button();
            this.btnBackColorBefore = new System.Windows.Forms.Button();
            this.btnMarkerColor = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEOF = new System.Windows.Forms.CheckBox();
            this.cbSpace = new System.Windows.Forms.CheckBox();
            this.cbFullWidthSpace = new System.Windows.Forms.CheckBox();
            this.cbTab = new System.Windows.Forms.CheckBox();
            this.cbNewline = new System.Windows.Forms.CheckBox();
            this.tabNotice = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbInformBeforeTextEmpty = new System.Windows.Forms.CheckBox();
            this.cbInformAfterReplace = new System.Windows.Forms.CheckBox();
            this.cbInformBeforeReplace = new System.Windows.Forms.CheckBox();
            this.cbInformAfterTextEmpty = new System.Windows.Forms.CheckBox();
            this.cbInformBeforeSearch = new System.Windows.Forms.CheckBox();
            this.cbInformAfterSearch = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNotifyOtherException = new System.Windows.Forms.CheckBox();
            this.cbNotifyUnauthorizedAccessException = new System.Windows.Forms.CheckBox();
            this.cbNotifyIOException = new System.Windows.Forms.CheckBox();
            this.cbNotifyPathTooLongException = new System.Windows.Forms.CheckBox();
            this.cbNotifyDirectoryNotFoundException = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBackup.SuspendLayout();
            this.gbAppend.SuspendLayout();
            this.gbFilePath.SuspendLayout();
            this.tabView.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabNotice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(235, 387);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(316, 387);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.MaxSize = 16;
            this.fontDialog.MinSize = 8;
            this.fontDialog.ShowEffects = false;
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.gbAppend);
            this.tabBackup.Controls.Add(this.gbFilePath);
            this.tabBackup.Controls.Add(this.cbEnableBackup);
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(5);
            this.tabBackup.Size = new System.Drawing.Size(382, 349);
            this.tabBackup.TabIndex = 1;
            this.tabBackup.Text = "バックアップ";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // gbAppend
            // 
            this.gbAppend.Controls.Add(this.rbAppend);
            this.gbAppend.Controls.Add(this.rbOverWrite);
            this.gbAppend.Location = new System.Drawing.Point(9, 33);
            this.gbAppend.Name = "gbAppend";
            this.gbAppend.Size = new System.Drawing.Size(364, 48);
            this.gbAppend.TabIndex = 1;
            this.gbAppend.TabStop = false;
            this.gbAppend.Text = "保存方式";
            // 
            // rbAppend
            // 
            this.rbAppend.AutoSize = true;
            this.rbAppend.Location = new System.Drawing.Point(23, 18);
            this.rbAppend.Name = "rbAppend";
            this.rbAppend.Size = new System.Drawing.Size(71, 16);
            this.rbAppend.TabIndex = 0;
            this.rbAppend.TabStop = true;
            this.rbAppend.Text = "追記方式";
            this.rbAppend.UseVisualStyleBackColor = true;
            // 
            // rbOverWrite
            // 
            this.rbOverWrite.AutoSize = true;
            this.rbOverWrite.Location = new System.Drawing.Point(172, 18);
            this.rbOverWrite.Name = "rbOverWrite";
            this.rbOverWrite.Size = new System.Drawing.Size(80, 16);
            this.rbOverWrite.TabIndex = 0;
            this.rbOverWrite.TabStop = true;
            this.rbOverWrite.Text = "上書き方式";
            this.rbOverWrite.UseVisualStyleBackColor = true;
            // 
            // gbFilePath
            // 
            this.gbFilePath.Controls.Add(this.label14);
            this.gbFilePath.Controls.Add(this.tbPatternDescription);
            this.gbFilePath.Controls.Add(this.lbUserDefinitionSampleResult);
            this.gbFilePath.Controls.Add(this.label7);
            this.gbFilePath.Controls.Add(this.tbUserDefinition);
            this.gbFilePath.Controls.Add(this.rbUserDefinition);
            this.gbFilePath.Controls.Add(this.tbAnotherFolder);
            this.gbFilePath.Controls.Add(this.tbExtension);
            this.gbFilePath.Controls.Add(this.label13);
            this.gbFilePath.Controls.Add(this.label6);
            this.gbFilePath.Controls.Add(this.rbAnotherFolder);
            this.gbFilePath.Controls.Add(this.rbReplaceExtension);
            this.gbFilePath.Enabled = false;
            this.gbFilePath.Location = new System.Drawing.Point(8, 88);
            this.gbFilePath.Name = "gbFilePath";
            this.gbFilePath.Padding = new System.Windows.Forms.Padding(5);
            this.gbFilePath.Size = new System.Drawing.Size(365, 254);
            this.gbFilePath.TabIndex = 0;
            this.gbFilePath.TabStop = false;
            this.gbFilePath.Text = "ファイル名/保存場所";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "\\sample.txt";
            // 
            // tbPatternDescription
            // 
            this.tbPatternDescription.Location = new System.Drawing.Point(42, 175);
            this.tbPatternDescription.Multiline = true;
            this.tbPatternDescription.Name = "tbPatternDescription";
            this.tbPatternDescription.ReadOnly = true;
            this.tbPatternDescription.Size = new System.Drawing.Size(285, 71);
            this.tbPatternDescription.TabIndex = 8;
            this.tbPatternDescription.Text = "%F : ファイル名 (拡張子と . を含まない)\r\n%E : 拡張子 ( . を含まない)\r\n%Y : 年 (4 桁)\r\n%y %M %D %H %m %S :" +
    " 年 月 日 時 分 秒 (各 2 桁)\r\n%% : パーセント記号 (%)";
            // 
            // lbUserDefinitionSampleResult
            // 
            this.lbUserDefinitionSampleResult.AutoSize = true;
            this.lbUserDefinitionSampleResult.Location = new System.Drawing.Point(169, 157);
            this.lbUserDefinitionSampleResult.Name = "lbUserDefinitionSampleResult";
            this.lbUserDefinitionSampleResult.Size = new System.Drawing.Size(57, 12);
            this.lbUserDefinitionSampleResult.TabIndex = 7;
            this.lbUserDefinitionSampleResult.Text = "sample.txt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "サンプル: sample.txt  ->";
            // 
            // tbUserDefinition
            // 
            this.tbUserDefinition.Location = new System.Drawing.Point(42, 134);
            this.tbUserDefinition.Name = "tbUserDefinition";
            this.tbUserDefinition.Size = new System.Drawing.Size(285, 19);
            this.tbUserDefinition.TabIndex = 5;
            this.tbUserDefinition.Text = "%F.bak";
            this.tbUserDefinition.TextChanged += new System.EventHandler(this.tbUserDefinition_TextChanged);
            // 
            // rbUserDefinition
            // 
            this.rbUserDefinition.AutoSize = true;
            this.rbUserDefinition.Location = new System.Drawing.Point(24, 111);
            this.rbUserDefinition.Name = "rbUserDefinition";
            this.rbUserDefinition.Size = new System.Drawing.Size(91, 16);
            this.rbUserDefinition.TabIndex = 4;
            this.rbUserDefinition.TabStop = true;
            this.rbUserDefinition.Text = "ユーザー定義 ";
            this.rbUserDefinition.UseVisualStyleBackColor = true;
            this.rbUserDefinition.CheckedChanged += new System.EventHandler(this.tabBackup_CheckedChanged);
            // 
            // tbAnotherFolder
            // 
            this.tbAnotherFolder.Location = new System.Drawing.Point(163, 84);
            this.tbAnotherFolder.Name = "tbAnotherFolder";
            this.tbAnotherFolder.Size = new System.Drawing.Size(98, 19);
            this.tbAnotherFolder.TabIndex = 3;
            this.tbAnotherFolder.Text = "backup";
            // 
            // tbExtension
            // 
            this.tbExtension.Location = new System.Drawing.Point(131, 37);
            this.tbExtension.Name = "tbExtension";
            this.tbExtension.Size = new System.Drawing.Size(82, 19);
            this.tbExtension.TabIndex = 3;
            this.tbExtension.Text = "bak";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "サンプル: (元のフォルダ)\\";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "サンプル: sample.";
            // 
            // rbAnotherFolder
            // 
            this.rbAnotherFolder.AutoSize = true;
            this.rbAnotherFolder.Location = new System.Drawing.Point(24, 63);
            this.rbAnotherFolder.Name = "rbAnotherFolder";
            this.rbAnotherFolder.Size = new System.Drawing.Size(132, 16);
            this.rbAnotherFolder.TabIndex = 1;
            this.rbAnotherFolder.TabStop = true;
            this.rbAnotherFolder.Text = "次のフォルダに保存する";
            this.rbAnotherFolder.UseVisualStyleBackColor = true;
            this.rbAnotherFolder.CheckedChanged += new System.EventHandler(this.tabBackup_CheckedChanged);
            // 
            // rbReplaceExtension
            // 
            this.rbReplaceExtension.AutoSize = true;
            this.rbReplaceExtension.Location = new System.Drawing.Point(24, 18);
            this.rbReplaceExtension.Name = "rbReplaceExtension";
            this.rbReplaceExtension.Size = new System.Drawing.Size(111, 16);
            this.rbReplaceExtension.TabIndex = 1;
            this.rbReplaceExtension.TabStop = true;
            this.rbReplaceExtension.Text = "拡張子を変更する";
            this.rbReplaceExtension.UseVisualStyleBackColor = true;
            this.rbReplaceExtension.CheckedChanged += new System.EventHandler(this.tabBackup_CheckedChanged);
            // 
            // cbEnableBackup
            // 
            this.cbEnableBackup.AutoSize = true;
            this.cbEnableBackup.Location = new System.Drawing.Point(9, 11);
            this.cbEnableBackup.Name = "cbEnableBackup";
            this.cbEnableBackup.Size = new System.Drawing.Size(160, 16);
            this.cbEnableBackup.TabIndex = 0;
            this.cbEnableBackup.Text = "バックアップファイルを作成する";
            this.cbEnableBackup.UseVisualStyleBackColor = true;
            this.cbEnableBackup.CheckedChanged += new System.EventHandler(this.tabBackup_CheckedChanged);
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.groupBox5);
            this.tabView.Controls.Add(this.groupBox3);
            this.tabView.Controls.Add(this.groupBox2);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(5);
            this.tabView.Size = new System.Drawing.Size(382, 349);
            this.tabView.TabIndex = 2;
            this.tabView.Text = "表示";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.btnFailureColor);
            this.groupBox5.Controls.Add(this.btnSuccessColor);
            this.groupBox5.Location = new System.Drawing.Point(9, 164);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(365, 52);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "リストボックス";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(232, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "置換失敗";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "置換成功";
            // 
            // btnFailureColor
            // 
            this.btnFailureColor.BackColor = System.Drawing.Color.Transparent;
            this.btnFailureColor.Location = new System.Drawing.Point(178, 18);
            this.btnFailureColor.Name = "btnFailureColor";
            this.btnFailureColor.Size = new System.Drawing.Size(48, 20);
            this.btnFailureColor.TabIndex = 0;
            this.btnFailureColor.UseVisualStyleBackColor = false;
            this.btnFailureColor.Click += new System.EventHandler(this.btnFailureColor_Click);
            // 
            // btnSuccessColor
            // 
            this.btnSuccessColor.BackColor = System.Drawing.Color.Transparent;
            this.btnSuccessColor.Location = new System.Drawing.Point(9, 18);
            this.btnSuccessColor.Name = "btnSuccessColor";
            this.btnSuccessColor.Size = new System.Drawing.Size(48, 20);
            this.btnSuccessColor.TabIndex = 0;
            this.btnSuccessColor.UseVisualStyleBackColor = false;
            this.btnSuccessColor.Click += new System.EventHandler(this.btnSuccessColor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangeFont);
            this.groupBox3.Controls.Add(this.lbFontDescription);
            this.groupBox3.Controls.Add(this.lbFontSample);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnBackColorAfter);
            this.groupBox3.Controls.Add(this.btnBackColorBefore);
            this.groupBox3.Controls.Add(this.btnMarkerColor);
            this.groupBox3.Controls.Add(this.btnForeColor);
            this.groupBox3.Location = new System.Drawing.Point(9, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 138);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "テキストボックス";
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Location = new System.Drawing.Point(191, 92);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(93, 23);
            this.btnChangeFont.TabIndex = 4;
            this.btnChangeFont.Text = "フォントの変更";
            this.btnChangeFont.UseVisualStyleBackColor = true;
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // lbFontDescription
            // 
            this.lbFontDescription.AutoSize = true;
            this.lbFontDescription.Location = new System.Drawing.Point(192, 72);
            this.lbFontDescription.Name = "lbFontDescription";
            this.lbFontDescription.Size = new System.Drawing.Size(87, 12);
            this.lbFontDescription.TabIndex = 3;
            this.lbFontDescription.Text = "MSゴシック (9 pt)";
            // 
            // lbFontSample
            // 
            this.lbFontSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFontSample.Location = new System.Drawing.Point(191, 22);
            this.lbFontSample.Name = "lbFontSample";
            this.lbFontSample.Size = new System.Drawing.Size(151, 42);
            this.lbFontSample.TabIndex = 2;
            this.lbFontSample.Text = "あア亜Abc123";
            this.lbFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFontSample.FontChanged += new System.EventHandler(this.lbFontSample_FontChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "背景 [置換後]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "編集記号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "背景 [置換前]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文字色";
            // 
            // btnBackColorAfter
            // 
            this.btnBackColorAfter.BackColor = System.Drawing.Color.Transparent;
            this.btnBackColorAfter.Location = new System.Drawing.Point(8, 97);
            this.btnBackColorAfter.Name = "btnBackColorAfter";
            this.btnBackColorAfter.Size = new System.Drawing.Size(48, 20);
            this.btnBackColorAfter.TabIndex = 0;
            this.btnBackColorAfter.UseVisualStyleBackColor = false;
            this.btnBackColorAfter.Click += new System.EventHandler(this.btnBackColorAfter_Click);
            // 
            // btnBackColorBefore
            // 
            this.btnBackColorBefore.BackColor = System.Drawing.Color.Transparent;
            this.btnBackColorBefore.Location = new System.Drawing.Point(8, 71);
            this.btnBackColorBefore.Name = "btnBackColorBefore";
            this.btnBackColorBefore.Size = new System.Drawing.Size(48, 20);
            this.btnBackColorBefore.TabIndex = 0;
            this.btnBackColorBefore.UseVisualStyleBackColor = false;
            this.btnBackColorBefore.Click += new System.EventHandler(this.btnBackColorBefore_Click);
            // 
            // btnMarkerColor
            // 
            this.btnMarkerColor.BackColor = System.Drawing.Color.Transparent;
            this.btnMarkerColor.Location = new System.Drawing.Point(7, 45);
            this.btnMarkerColor.Name = "btnMarkerColor";
            this.btnMarkerColor.Size = new System.Drawing.Size(48, 20);
            this.btnMarkerColor.TabIndex = 0;
            this.btnMarkerColor.UseVisualStyleBackColor = false;
            this.btnMarkerColor.Click += new System.EventHandler(this.btnMarkerColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.BackColor = System.Drawing.Color.Transparent;
            this.btnForeColor.Location = new System.Drawing.Point(7, 19);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(48, 20);
            this.btnForeColor.TabIndex = 0;
            this.btnForeColor.UseVisualStyleBackColor = false;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEOF);
            this.groupBox2.Controls.Add(this.cbSpace);
            this.groupBox2.Controls.Add(this.cbFullWidthSpace);
            this.groupBox2.Controls.Add(this.cbTab);
            this.groupBox2.Controls.Add(this.cbNewline);
            this.groupBox2.Location = new System.Drawing.Point(9, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(366, 98);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "編集記号";
            // 
            // cbEOF
            // 
            this.cbEOF.AutoSize = true;
            this.cbEOF.Location = new System.Drawing.Point(177, 44);
            this.cbEOF.Name = "cbEOF";
            this.cbEOF.Size = new System.Drawing.Size(94, 16);
            this.cbEOF.TabIndex = 4;
            this.cbEOF.Text = "文字列の終端";
            this.cbEOF.UseVisualStyleBackColor = true;
            // 
            // cbSpace
            // 
            this.cbSpace.AutoSize = true;
            this.cbSpace.Location = new System.Drawing.Point(16, 22);
            this.cbSpace.Name = "cbSpace";
            this.cbSpace.Size = new System.Drawing.Size(86, 16);
            this.cbSpace.TabIndex = 3;
            this.cbSpace.Text = "半角スペース";
            this.cbSpace.UseVisualStyleBackColor = true;
            // 
            // cbFullWidthSpace
            // 
            this.cbFullWidthSpace.AutoSize = true;
            this.cbFullWidthSpace.Location = new System.Drawing.Point(16, 44);
            this.cbFullWidthSpace.Name = "cbFullWidthSpace";
            this.cbFullWidthSpace.Size = new System.Drawing.Size(86, 16);
            this.cbFullWidthSpace.TabIndex = 2;
            this.cbFullWidthSpace.Text = "全角スペース";
            this.cbFullWidthSpace.UseVisualStyleBackColor = true;
            // 
            // cbTab
            // 
            this.cbTab.AutoSize = true;
            this.cbTab.Location = new System.Drawing.Point(16, 66);
            this.cbTab.Name = "cbTab";
            this.cbTab.Size = new System.Drawing.Size(41, 16);
            this.cbTab.TabIndex = 1;
            this.cbTab.Text = "タブ";
            this.cbTab.UseVisualStyleBackColor = true;
            // 
            // cbNewline
            // 
            this.cbNewline.AutoSize = true;
            this.cbNewline.Location = new System.Drawing.Point(177, 22);
            this.cbNewline.Name = "cbNewline";
            this.cbNewline.Size = new System.Drawing.Size(72, 16);
            this.cbNewline.TabIndex = 0;
            this.cbNewline.Text = "段落記号";
            this.cbNewline.UseVisualStyleBackColor = true;
            // 
            // tabNotice
            // 
            this.tabNotice.Controls.Add(this.groupBox4);
            this.tabNotice.Controls.Add(this.groupBox1);
            this.tabNotice.Location = new System.Drawing.Point(4, 22);
            this.tabNotice.Name = "tabNotice";
            this.tabNotice.Padding = new System.Windows.Forms.Padding(5);
            this.tabNotice.Size = new System.Drawing.Size(382, 349);
            this.tabNotice.TabIndex = 0;
            this.tabNotice.Text = "通知";
            this.tabNotice.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cbInformBeforeTextEmpty);
            this.groupBox4.Controls.Add(this.cbInformAfterReplace);
            this.groupBox4.Controls.Add(this.cbInformBeforeReplace);
            this.groupBox4.Controls.Add(this.cbInformAfterTextEmpty);
            this.groupBox4.Controls.Add(this.cbInformBeforeSearch);
            this.groupBox4.Controls.Add(this.cbInformAfterSearch);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(366, 151);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "確認メッセージ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "次のようなとき、メッセージボックスを表示します。";
            // 
            // cbInformBeforeTextEmpty
            // 
            this.cbInformBeforeTextEmpty.AutoSize = true;
            this.cbInformBeforeTextEmpty.Location = new System.Drawing.Point(15, 65);
            this.cbInformBeforeTextEmpty.Name = "cbInformBeforeTextEmpty";
            this.cbInformBeforeTextEmpty.Size = new System.Drawing.Size(293, 16);
            this.cbInformBeforeTextEmpty.TabIndex = 1;
            this.cbInformBeforeTextEmpty.Text = "[置換前] のテキストが空のまま検索を開始しようとしたとき";
            this.cbInformBeforeTextEmpty.UseVisualStyleBackColor = true;
            // 
            // cbInformAfterReplace
            // 
            this.cbInformAfterReplace.AutoSize = true;
            this.cbInformAfterReplace.Location = new System.Drawing.Point(167, 97);
            this.cbInformAfterReplace.Name = "cbInformAfterReplace";
            this.cbInformAfterReplace.Size = new System.Drawing.Size(117, 16);
            this.cbInformAfterReplace.TabIndex = 4;
            this.cbInformAfterReplace.Text = "置換が終了したとき";
            this.cbInformAfterReplace.UseVisualStyleBackColor = true;
            // 
            // cbInformBeforeReplace
            // 
            this.cbInformBeforeReplace.AutoSize = true;
            this.cbInformBeforeReplace.Location = new System.Drawing.Point(15, 97);
            this.cbInformBeforeReplace.Name = "cbInformBeforeReplace";
            this.cbInformBeforeReplace.Size = new System.Drawing.Size(117, 16);
            this.cbInformBeforeReplace.TabIndex = 3;
            this.cbInformBeforeReplace.Text = "置換を開始するとき";
            this.cbInformBeforeReplace.UseVisualStyleBackColor = true;
            // 
            // cbInformAfterTextEmpty
            // 
            this.cbInformAfterTextEmpty.AutoSize = true;
            this.cbInformAfterTextEmpty.Location = new System.Drawing.Point(15, 119);
            this.cbInformAfterTextEmpty.Name = "cbInformAfterTextEmpty";
            this.cbInformAfterTextEmpty.Size = new System.Drawing.Size(293, 16);
            this.cbInformAfterTextEmpty.TabIndex = 2;
            this.cbInformAfterTextEmpty.Text = "[置換後] のテキストが空のまま置換を開始しようとしたとき";
            this.cbInformAfterTextEmpty.UseVisualStyleBackColor = true;
            // 
            // cbInformBeforeSearch
            // 
            this.cbInformBeforeSearch.AutoSize = true;
            this.cbInformBeforeSearch.Location = new System.Drawing.Point(15, 43);
            this.cbInformBeforeSearch.Name = "cbInformBeforeSearch";
            this.cbInformBeforeSearch.Size = new System.Drawing.Size(117, 16);
            this.cbInformBeforeSearch.TabIndex = 2;
            this.cbInformBeforeSearch.Text = "検索を開始するとき";
            this.cbInformBeforeSearch.UseVisualStyleBackColor = true;
            // 
            // cbInformAfterSearch
            // 
            this.cbInformAfterSearch.AutoSize = true;
            this.cbInformAfterSearch.Location = new System.Drawing.Point(167, 43);
            this.cbInformAfterSearch.Name = "cbInformAfterSearch";
            this.cbInformAfterSearch.Size = new System.Drawing.Size(117, 16);
            this.cbInformAfterSearch.TabIndex = 2;
            this.cbInformAfterSearch.Text = "検索が終了したとき";
            this.cbInformAfterSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbNotifyOtherException);
            this.groupBox1.Controls.Add(this.cbNotifyUnauthorizedAccessException);
            this.groupBox1.Controls.Add(this.cbNotifyIOException);
            this.groupBox1.Controls.Add(this.cbNotifyPathTooLongException);
            this.groupBox1.Controls.Add(this.cbNotifyDirectoryNotFoundException);
            this.groupBox1.Location = new System.Drawing.Point(8, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(366, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "エラー通知";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "次のエラーが発生したとき、詳細を表示します。";
            // 
            // cbNotifyOtherException
            // 
            this.cbNotifyOtherException.AutoSize = true;
            this.cbNotifyOtherException.Location = new System.Drawing.Point(15, 129);
            this.cbNotifyOtherException.Name = "cbNotifyOtherException";
            this.cbNotifyOtherException.Size = new System.Drawing.Size(92, 16);
            this.cbNotifyOtherException.TabIndex = 5;
            this.cbNotifyOtherException.Text = "その他のエラー";
            this.cbNotifyOtherException.UseVisualStyleBackColor = true;
            // 
            // cbNotifyUnauthorizedAccessException
            // 
            this.cbNotifyUnauthorizedAccessException.AutoSize = true;
            this.cbNotifyUnauthorizedAccessException.Location = new System.Drawing.Point(15, 41);
            this.cbNotifyUnauthorizedAccessException.Name = "cbNotifyUnauthorizedAccessException";
            this.cbNotifyUnauthorizedAccessException.Size = new System.Drawing.Size(114, 16);
            this.cbNotifyUnauthorizedAccessException.TabIndex = 1;
            this.cbNotifyUnauthorizedAccessException.Text = "アクセス権限がない";
            this.cbNotifyUnauthorizedAccessException.UseVisualStyleBackColor = true;
            // 
            // cbNotifyIOException
            // 
            this.cbNotifyIOException.AutoSize = true;
            this.cbNotifyIOException.Location = new System.Drawing.Point(15, 107);
            this.cbNotifyIOException.Name = "cbNotifyIOException";
            this.cbNotifyIOException.Size = new System.Drawing.Size(128, 16);
            this.cbNotifyIOException.TabIndex = 4;
            this.cbNotifyIOException.Text = "その他の入出力エラー";
            this.cbNotifyIOException.UseVisualStyleBackColor = true;
            // 
            // cbNotifyPathTooLongException
            // 
            this.cbNotifyPathTooLongException.AutoSize = true;
            this.cbNotifyPathTooLongException.Location = new System.Drawing.Point(15, 85);
            this.cbNotifyPathTooLongException.Name = "cbNotifyPathTooLongException";
            this.cbNotifyPathTooLongException.Size = new System.Drawing.Size(94, 16);
            this.cbNotifyPathTooLongException.TabIndex = 3;
            this.cbNotifyPathTooLongException.Text = "パスが長すぎる";
            this.cbNotifyPathTooLongException.UseVisualStyleBackColor = true;
            // 
            // cbNotifyDirectoryNotFoundException
            // 
            this.cbNotifyDirectoryNotFoundException.AutoSize = true;
            this.cbNotifyDirectoryNotFoundException.Location = new System.Drawing.Point(15, 63);
            this.cbNotifyDirectoryNotFoundException.Name = "cbNotifyDirectoryNotFoundException";
            this.cbNotifyDirectoryNotFoundException.Size = new System.Drawing.Size(122, 16);
            this.cbNotifyDirectoryNotFoundException.TabIndex = 2;
            this.cbNotifyDirectoryNotFoundException.Text = "フォルダが存在しない";
            this.cbNotifyDirectoryNotFoundException.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabView);
            this.tabControl.Controls.Add(this.tabNotice);
            this.tabControl.Controls.Add(this.tabBackup);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(5, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(390, 375);
            this.tabControl.TabIndex = 0;
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 40);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オプション";
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.gbAppend.ResumeLayout(false);
            this.gbAppend.PerformLayout();
            this.gbFilePath.ResumeLayout(false);
            this.gbFilePath.PerformLayout();
            this.tabView.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabNotice.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.GroupBox gbFilePath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbPatternDescription;
        private System.Windows.Forms.Label lbUserDefinitionSampleResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbUserDefinition;
        private System.Windows.Forms.RadioButton rbUserDefinition;
        private System.Windows.Forms.TextBox tbAnotherFolder;
        private System.Windows.Forms.TextBox tbExtension;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbAnotherFolder;
        private System.Windows.Forms.RadioButton rbReplaceExtension;
        private System.Windows.Forms.CheckBox cbEnableBackup;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFailureColor;
        private System.Windows.Forms.Button btnSuccessColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChangeFont;
        private System.Windows.Forms.Label lbFontDescription;
        private System.Windows.Forms.Label lbFontSample;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackColorAfter;
        private System.Windows.Forms.Button btnBackColorBefore;
        private System.Windows.Forms.Button btnMarkerColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEOF;
        private System.Windows.Forms.CheckBox cbSpace;
        private System.Windows.Forms.CheckBox cbFullWidthSpace;
        private System.Windows.Forms.CheckBox cbTab;
        private System.Windows.Forms.CheckBox cbNewline;
        private System.Windows.Forms.TabPage tabNotice;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbInformBeforeTextEmpty;
        private System.Windows.Forms.CheckBox cbInformAfterReplace;
        private System.Windows.Forms.CheckBox cbInformBeforeReplace;
        private System.Windows.Forms.CheckBox cbInformAfterTextEmpty;
        private System.Windows.Forms.CheckBox cbInformAfterSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbNotifyOtherException;
        private System.Windows.Forms.CheckBox cbNotifyUnauthorizedAccessException;
        private System.Windows.Forms.CheckBox cbNotifyIOException;
        private System.Windows.Forms.CheckBox cbNotifyPathTooLongException;
        private System.Windows.Forms.CheckBox cbNotifyDirectoryNotFoundException;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.CheckBox cbInformBeforeSearch;
        private System.Windows.Forms.GroupBox gbAppend;
        private System.Windows.Forms.RadioButton rbAppend;
        private System.Windows.Forms.RadioButton rbOverWrite;
    }
}