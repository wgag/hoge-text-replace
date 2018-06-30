using System;
using System.Drawing;
using System.Windows.Forms;

namespace HogeTextReplace
{
    class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // pictureBox1
            //
            pbIcon = new PictureBox()
            {
                Location = new Point(20, 30),
                SizeMode = PictureBoxSizeMode.AutoSize,
            };
            Icon original = global::HogeTextReplace.Properties.Resources.ProgramIcon;
            pbIcon.Image = new Icon(original, 48, 48).ToBitmap();
            //
            // label1
            //
            string sVersion = string.Format("{0}.{1}.{2}", Program.VersionMajor, Program.VersionMinor, Program.VersionBuild);
            label1 = new Label()
            {
                Location = new Point(80, 30),
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft,
                Text = Program.Title + " " + sVersion,
            };
            //
            // label2
            //
            label2 = new Label()
            {
                Location = new Point(80, 50),
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft,
                Text = Program.Copyright,
            };
            //
            // label1
            //
            llbURL = new LinkLabel()
            {
                Location = new Point(80, 70),
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft,
                Text = "http://northcol.org/",
            };
            llbURL.LinkClicked += delegate(object sender, LinkLabelLinkClickedEventArgs eventArgs)
            {
                llbURL.LinkVisited = true;
                System.Diagnostics.Process.Start("http://northcol.org/");
            };
            //
            // buttonOK
            //
            btnOK = new Button()
            {
                Text = "OK",
                Top = 100,
            };
            btnOK.DialogResult = DialogResult.OK;
            btnOK.MouseEnter += (object sender, EventArgs eventArgs) =>
            {
                btnOK.Text = "Hoge";
            };
            btnOK.MouseLeave += (object sender, EventArgs eventArgs) =>
            {
                btnOK.Text = "OK";
            };
            //
            // AboutDialog
            //
            this.ClientSize = new Size(300, 140);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Controls.AddRange(new Control[]
            {
                btnOK, label1, label2, llbURL,
                pbIcon, 
            });
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.AcceptButton = btnOK;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "バージョン情報";
            //
            // Layout
            //
            btnOK.Left = (this.ClientSize.Width - btnOK.Width) / 2;

            ResumeLayout();
        }

        PictureBox pbIcon;
        Label label1;
        Label label2;
        LinkLabel llbURL;
        Button btnOK;
    }
}
