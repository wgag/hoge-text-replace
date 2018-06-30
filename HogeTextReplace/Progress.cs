using System;

namespace HogeTextReplace
{
    public class Progress
    {
        /// <summary>
        /// Make a new instance.
        /// </summary>
        public Progress()
        {
            Clear();
        }

        public void Clear()
        {
            this.Canceled = false;
            this.ErrorDescription = string.Empty;
            this.ErrorOccured = false;
            this.ErrorLog = string.Empty;

            ProgressUpdated = null;
        }
        
        public string ErrorDescription { get; set; }
        public string ErrorLog { get; set; }
        public bool Canceled { get; set; }

        /// <summary>
        /// Gets and sets whether UnauthorizedAccessException is reported.
        /// </summary>
        static public bool NotifyUnauthorizedAccessException { get; set; }

        /// <summary>
        /// Gets and sets whether IOException is reported.
        /// </summary>
        static public bool NotifyIOException { get; set; }

        /// <summary>
        /// Gets and sets whether PathTooLongException is reported.
        /// </summary>
        static public bool NotifyPathTooLongException { get; set; }
        
        /// <summary>
        /// Gets and sets whether DirectoryNotFoundException is reported.
        /// </summary>
        static public bool NotifyDirectoryNotFoundException { get; set; }
        
        /// <summary>
        /// Gets and sets whether other exceptions are reported.
        /// </summary>
        static public bool NotifyOtherException { get; set; }

        bool _ErrorOccured = false;

        /// <summary>
        /// Gets and sets whether an error occured.
        /// </summary>
        public bool ErrorOccured
        {
            get
            {
                if (_ErrorOccured) { return true; }
                else { return !string.IsNullOrEmpty(ErrorLog); }
            }
            set
            {
                _ErrorOccured = value;
            }
        }

        // System.ComponentModel.BackgroundWorker.ReportProgress is the model
        public delegate void ProgressUpdatedEventHandler(int percentage, object state);
       
        public event ProgressUpdatedEventHandler ProgressUpdated;

        /// <summary>
        /// Determines whether the current operation has been canceled.
        /// </summary>
        /// <exception cref="System.OperationCanceledException"></exception>
        public void CheckCanceledOrNot()
        {
            if (Canceled)
            {
                throw new OperationCanceledException("ユーザーにより処理が中断されました。");
            }
        }

        /// <summary>
        /// Reports an error; adds the specified message to the error log.
        /// </summary>
        /// <param name="message"></param>
        public void ReportError(string message)
        {
            if (!this.ErrorLog.Contains(message))
            {
                this.ErrorLog += message + Environment.NewLine + Environment.NewLine;
            }
        }

        /// <summary>
        /// Reports an error; adds the exception message to the error log.
        /// </summary>
        /// <param name="exception"></param>
        public void ReportError(Exception exception)
        {
            ReportError(exception, string.Empty);
        }

        /// <summary>
        /// Reports an error; adds the exception message and the specified sub message to the error log.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="subMessage"></param>
        public void ReportError(Exception exception, string subMessage)
        {
            string description = subMessage + exception.Message + Environment.NewLine;

            if (exception.GetType() == typeof(System.IO.PathTooLongException))
            {
                if (NotifyPathTooLongException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
            else if (exception.GetType() == typeof(System.IO.DirectoryNotFoundException))
            {
                if (NotifyDirectoryNotFoundException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
            else if (exception.GetType() == typeof(UnauthorizedAccessException))
            {
                if (NotifyUnauthorizedAccessException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
            else if (exception.GetType() == typeof(System.IO.DirectoryNotFoundException))
            {
                if (NotifyDirectoryNotFoundException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
            else if (exception.GetType() == typeof(System.IO.IOException))
            {
                if (NotifyIOException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
            else // exception.GetType() == typeof(Exception)
            {
                if (NotifyOtherException)
                {
                    if (!ErrorLog.Contains(exception.Message))
                    {
                        ErrorLog += description;
                    }
                }
                return;
            }
        }
        
        /// <summary>
        /// Report the current progress with percentage and message.
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="message"></param>
        public void ReportProgress(int percentage, string message)
        {
            OnProgressUpdated(percentage, (object) message);
        }

        public void OnProgressUpdated(int percentage, object state)
        {
            if (this.ProgressUpdated != null)
            {
                this.ProgressUpdated(percentage, state);
            }
        }
    }
}
