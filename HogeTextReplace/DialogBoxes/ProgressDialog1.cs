using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace HogeReplacer
{
    class ProgressArgs
    {
        // System.ComponentModel.BackgroundWorker.ReportProgress is the model
        public delegate void ReportProgressEventHandler(int pct, object state);
        public event ReportProgressEventHandler ReportProgressEvent;

        public ProgressArgs()
        {
            StateMessage = "";
        }
        public string StateMessage { get; set; }

        public void ReportProgress(int pct, string message)
        {
            StateMessage = (string)message;
            Percentage = pct;
            ReportProgressEvent(pct, (object)message);
        }
        public int Percentage { get; set; }
    }

    class ProgressDialog1 : Form
    {

        public ProgressDialog1(BackgroundWorker _bgWorker, ErrorArgs _errArgs)
        {
            bgWorker = _bgWorker;
            errArgs = _errArgs;
            this.Initialize();
        }

        BackgroundWorker bgWorker;
        ErrorArgs errArgs;

        void Initialize()
        {
            //
            // bgWorker
            //
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            //
            // label
            //
            label.Location = new Point(20, 16);
            label.Size = new Size(190, 50);
            label.Text = "処理中...";
            //
            // buttonCancel
            //
            buttonCancel.Text = "キャンセル";
            buttonCancel.Location = new Point(80, 80);
            buttonCancel.Click += buttonCancel_Click;
            //
            // ProgressDialog
            //
            this.Size = new Size(240, 140);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "処理中...";
            this.Controls.AddRange(new Control[]
            {
                buttonCancel,  label
            });
            this.ResumeLayout();
        }

        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label.Text = e.UserState as string;
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                this.DialogResult = DialogResult.None;
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }


        void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = false;
            errArgs.Cancel = true;  // substitute for CancelAsync()
            label.Text = "処理を中止しています...";
        }


        Button buttonCancel = new Button();
        Label label = new Label();


        protected override void OnPaint(PaintEventArgs eArgs)
        {
            base.OnPaint(eArgs);

        }


        // invalidate the red close button
        protected override CreateParams CreateParams
        {
            [System.Security.Permissions.SecurityPermission(
                System.Security.Permissions.SecurityAction.LinkDemand,
                Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }

    }
}
