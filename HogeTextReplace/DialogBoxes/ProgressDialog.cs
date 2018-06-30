using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HogeTextReplace
{
    public enum ProgressDialogResult
    {
        None = 0,
        Success = 1,
        Failure = 2,
    }

    public partial class ProgressDialog : Form
    {

        #region Fields
        BackgroundWorker backgroundWorker;
        Progress progress { get; set; }
        #endregion

        #region Properties
        public ProgressDialogResult ProgressDialogResult { get; private set; }
        #endregion

        public ProgressDialog(BackgroundWorker worker, Progress progress)
        {
            this.progress = progress;
            backgroundWorker = worker;
            backgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            ProgressDialogResult = ProgressDialogResult.None;
            InitializeComponent();

            this.ProgressDialogResult = ProgressDialogResult.None;
        }

        public new ProgressDialogResult ShowDialog()
        {
            base.ShowDialog();
            return this.ProgressDialogResult;
        }

        public new ProgressDialogResult ShowDialog(IWin32Window owner)
        {
            base.ShowDialog(owner);
            return this.ProgressDialogResult;
        }

        // invalidate the close button
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

        #region Event Handlers

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.ProgressDialogResult == ProgressDialogResult.None)
            {
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs eventArgs)
        {
            label.Text = eventArgs.UserState as string;
            progressBar.Value = eventArgs.ProgressPercentage;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            label.Text = "処理中...";

            if (eventArgs.Error != null)
            {
                progress.ReportError(eventArgs.Error.Message);

                this.ProgressDialogResult = ProgressDialogResult.Failure;
            }
            else if (eventArgs.Cancelled)  // will not be used
            {
                this.ProgressDialogResult = ProgressDialogResult.Failure;
            }
            else
            {
                this.ProgressDialogResult = ProgressDialogResult.Success;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            this.progress.Canceled = true;

            // should not use backgroundWorker.CancelAsync
        }

        #endregion

    }
}
