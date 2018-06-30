using System;
using System.Drawing;
using System.Windows.Forms;

namespace HogeTextReplace
{
    class ErrorDialog : Form
    {
        public ErrorDialog(Progress progress)
        {
            this.InitializeComponent();
            this.Text = "エラー";
            label1.Text = progress.ErrorDescription;
            System.Media.SystemSounds.Hand.Play();
        }
      
        void InitializeComponent()
        {
            //
            // label1
            //
            label1 = new Label()
            {
                Location = new Point(60, 20),
                AutoSize = true,
            };
            //
            // textBox
            //
            textBox = new TextBox()
            {
                Size = new Size(380, 170),
                Location = new Point(5, 60),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                ReadOnly = true,
            };
            //
            // btnOK
            //
            btnOK = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(160, 240),
            };

            //
            // ErrorDialog
            //
            this.Size = new Size(400, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "エラー";
            this.AcceptButton = btnOK;
            this.Controls.AddRange(new Control[]
            {
                btnOK,textBox, label1
            });
        }

        Button btnOK;
        TextBox textBox;
        Label label1;
     
        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            base.OnPaint(eventArgs);
            Graphics g = eventArgs.Graphics;
            g.DrawIcon(SystemIcons.Hand, 15, 10);
        }

        protected override void OnLoad(EventArgs eventArgs)
        {
            base.OnLoad(eventArgs);
        }
    }
}
