namespace utils
{
    partial class PreviewForm
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
            Sgry.Azuki.FontInfo fontInfo3 = new Sgry.Azuki.FontInfo();
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBefore = new System.Windows.Forms.TabPage();
            this.azukiBefore = new utils.AzukiTextBox();
            this.tabAfter = new System.Windows.Forms.TabPage();
            this.azukiAfter = new utils.AzukiTextBox();
            this.tabControl.SuspendLayout();
            this.tabBefore.SuspendLayout();
            this.tabAfter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBefore);
            this.tabControl.Controls.Add(this.tabAfter);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(421, 279);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabBefore
            // 
            this.tabBefore.Controls.Add(this.azukiBefore);
            this.tabBefore.Location = new System.Drawing.Point(4, 22);
            this.tabBefore.Name = "tabBefore";
            this.tabBefore.Size = new System.Drawing.Size(413, 253);
            this.tabBefore.TabIndex = 0;
            this.tabBefore.Text = "置換前";
            this.tabBefore.Enter += new System.EventHandler(this.tabBefore_Enter_1);
            // 
            // azukiBefore
            // 
            this.azukiBefore.BackColor = System.Drawing.SystemColors.Window;
            this.azukiBefore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.azukiBefore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azukiBefore.DrawingOption = ((Sgry.Azuki.DrawingOption) (((Sgry.Azuki.DrawingOption.DrawsTab | Sgry.Azuki.DrawingOption.DrawsEol)
                        | Sgry.Azuki.DrawingOption.ShowsLineNumber)));
            this.azukiBefore.DrawsFullWidthSpace = false;
            this.azukiBefore.FirstVisibleLine = 0;
            this.azukiBefore.Font = new System.Drawing.Font("MS Gothic", 9F);
            fontInfo3.Name = "MS Gothic";
            fontInfo3.Size = 9;
            fontInfo3.Style = System.Drawing.FontStyle.Regular;
            this.azukiBefore.FontInfo = fontInfo3;
            this.azukiBefore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.azukiBefore.HighlightsCurrentLine = false;
            this.azukiBefore.IsReadOnly = true;
            this.azukiBefore.Location = new System.Drawing.Point(0, 0);
            this.azukiBefore.MarkerColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (127)))), ((int) (((byte) (127)))));
            this.azukiBefore.Name = "azukiBefore";
            this.azukiBefore.NewlineChars = "\r\n";
            this.azukiBefore.ScrollsBeyondLastLine = false;
            this.azukiBefore.ShowsDirtBar = false;
            this.azukiBefore.Size = new System.Drawing.Size(413, 253);
            this.azukiBefore.TabIndex = 3;
            this.azukiBefore.TabWidth = 4;
            this.azukiBefore.ViewWidth = 4128;
            // 
            // tabAfter
            // 
            this.tabAfter.Controls.Add(this.azukiAfter);
            this.tabAfter.Location = new System.Drawing.Point(4, 22);
            this.tabAfter.Name = "tabAfter";
            this.tabAfter.Size = new System.Drawing.Size(413, 253);
            this.tabAfter.TabIndex = 1;
            this.tabAfter.Text = "置換後";
            this.tabAfter.UseVisualStyleBackColor = true;
            // 
            // azukiAfter
            // 
            this.azukiAfter.BackColor = System.Drawing.SystemColors.Window;
            this.azukiAfter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.azukiAfter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azukiAfter.DrawingOption = ((Sgry.Azuki.DrawingOption) (((Sgry.Azuki.DrawingOption.DrawsTab | Sgry.Azuki.DrawingOption.DrawsEol)
                        | Sgry.Azuki.DrawingOption.ShowsLineNumber)));
            this.azukiAfter.DrawsFullWidthSpace = false;
            this.azukiAfter.FirstVisibleLine = 0;
            this.azukiAfter.Font = new System.Drawing.Font("MS Gothic", 9F);
            fontInfo1.Name = "MS Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azukiAfter.FontInfo = fontInfo1;
            this.azukiAfter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.azukiAfter.HighlightsCurrentLine = false;
            this.azukiAfter.IsReadOnly = true;
            this.azukiAfter.Location = new System.Drawing.Point(0, 0);
            this.azukiAfter.MarkerColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (127)))), ((int) (((byte) (127)))));
            this.azukiAfter.Name = "azukiAfter";
            this.azukiAfter.NewlineChars = "\r\n";
            this.azukiAfter.ScrollsBeyondLastLine = false;
            this.azukiAfter.ShowsDirtBar = false;
            this.azukiAfter.Size = new System.Drawing.Size(413, 253);
            this.azukiAfter.TabIndex = 0;
            this.azukiAfter.TabWidth = 4;
            this.azukiAfter.ViewWidth = 4128;
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(421, 279);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(280, 200);
            this.Name = "PreviewForm";
            this.ShowIcon = false;
            this.Text = "PreviewForm";
            this.tabControl.ResumeLayout(false);
            this.tabBefore.ResumeLayout(false);
            this.tabAfter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private utils.AzukiTextBox azukiBefore;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBefore;
        private System.Windows.Forms.TabPage tabAfter;
        private AzukiTextBox azukiAfter;
    }
}