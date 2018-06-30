using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace utils
{
    /// <summary>
    /// Represents a list view for text files.
    /// </summary>
    public class FileListView : ListView
    {
        /// <summary>
        /// Initializes a new instance of the FileListView class.
        /// </summary>
        public FileListView()
        {
            ListValid = false;
            AzukiBefore = null;
            AzukiAfter = null;
            RegexEnabled = false;
            RegexOptions = RegexOptions.None;

            InitializeComponents();
            InitializeContextMenu();
        }

        public ColumnHeader ClmnName { get { return columns[ClmnNameNumber]; } set { columns[ClmnNameNumber] = value; } }
        public ColumnHeader ClmnCode { get { return columns[ClmnCodeNumber]; } set { columns[ClmnCodeNumber] = value; } }
        public ColumnHeader ClmnPath { get { return columns[ClmnPathNumber]; } set { columns[ClmnPathNumber] = value; } }

        public const int ClmnNameNumber = 0;
        public const int ClmnCodeNumber = 1;
        public const int ClmnPathNumber = 2;

        ColumnHeader[] columns = new ColumnHeader[3];

        public AzukiTextBox AzukiBefore { get; set; }
        public AzukiTextBox AzukiAfter { get; set; }
        public bool RegexEnabled { get; set; }
        public RegexOptions RegexOptions { get; set; }

        public Form OwnerForm { get; set; }

        public delegate void ListValidityChangedEventHandler();

        /// <summary>
        /// Occurs when the value of the ListValidity property changes.
        /// </summary>
        public event ListValidityChangedEventHandler ListValidityChanged;

        public static Color SuccessBackColor { get { return _successBackColor; } set { _successBackColor = value; } }
        static Color _successBackColor = Color.FromArgb(0xaa, 0xcc, 0xff);
        
        
        public static Color FailureBackColor { get { return _failureBackColor; } set { _failureBackColor = value; } }
        static Color _failureBackColor = Color.FromArgb(0xff, 0xcc, 0xaa);

        bool _ListValid = false;

        Color backColorWhenInvalid = Color.FromArgb(0xf7, 0xf7, 0xf7);
        Color foreColorWhenInvalid = SystemColors.GrayText;

        /// <summary>
        /// Gets or sets whether the current file list is valid.
        /// </summary>
        public bool ListValid
        {
            get
            {
                return _ListValid;
            }
            set
            {
                _ListValid = value;

                if (_ListValid)
                {
                    Color backColor = SystemColors.Window;
                    Color foreColor = SystemColors.WindowText;
                    this.BackColor = backColor;
                    this.ForeColor = foreColor;


                    bool flag = this.Items.Count > 0 && this.Items[0].BackColor == backColorWhenInvalid;

                    foreach (ListViewItem item in this.Items)
                    {
                        item.ForeColor = foreColor;

                        if (flag) { item.BackColor = backColor; }
                    }
                }
                else
                {
                    Color backColor = backColorWhenInvalid;
                    Color foreColor = foreColorWhenInvalid;

                    this.BackColor = backColor;
                    this.ForeColor = foreColor;

                    foreach (ListViewItem item in this.Items)
                    {
                        item.BackColor = backColor;
                        item.ForeColor = foreColor;
                    }
                }

                OnListValidityChanged();
            }
        }

        public void AddNewItem(string name, string enc, string path)
        {
            this.Items.Add(new ListViewItem(new string[] { name, enc, path }));
        }

        void OnListValidityChanged()
        {
            if (this.ListValidityChanged != null)
            {
                this.ListValidityChanged();
            }
        }

        void InitializeComponents()
        {
            //
            // clmn...
            //
            columns[ClmnNameNumber] = new ColumnHeader();
            columns[ClmnNameNumber].Text = "ファイル名";

            columns[ClmnCodeNumber] = new ColumnHeader();
            columns[ClmnCodeNumber].Text = "文字コード";

            columns[ClmnPathNumber] = new ColumnHeader();
            columns[ClmnPathNumber].Text = "パス";

            //
            // FileListView
            //
            this.FullRowSelect = true;
            this.GridLines = true;
            this.Sorting = SortOrder.None;
            this.View = View.Details;
            this.CheckBoxes = true;
            this.ShowItemToolTips = true;
            this.DoubleBuffered = true;
            this.Columns.AddRange(columns);
            this.ColumnClick += new ColumnClickEventHandler(FileListView_ColumnClick);
            
            this.MouseDoubleClick += new MouseEventHandler(FileListView_MouseDoubleClick);

            //clmnCode.Width = 0;
        }

       
        public class ListViewItemComparer : IComparer
        {
            public int Column;
            public SortOrder Sorting;

            public ListViewItemComparer()
            {
                Column = ClmnNameNumber;
                Sorting = SortOrder.Ascending;
            }
      
            public int Compare(object x, object y)
            {
                if (this.Sorting == SortOrder.None)
                {
                    return 0;
                }

                ListViewItem itemx = x as ListViewItem;
                ListViewItem itemy = y as ListViewItem;

                int result = string.Compare(
                    itemx.SubItems[Column].Text,
                    itemy.SubItems[Column].Text);

                if (this.Sorting == SortOrder.Ascending)
                {
                    return result;
                }
                else  // this.Sorting == SortOrder.Descending
                {
                    return -result;
                }
            }
        }

        void FileListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.Sorting = (this.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            this.ListViewItemSorter = new FileListView.ListViewItemComparer()
            {
                Column = e.Column,
                Sorting = this.Sorting,
            };
            this.Sort();
        }

        #region Context Menu

        void InitializeContextMenu()
        {
            contextMenu = new ContextMenu();

            miPreview = new MenuItem("プレビュー(&P)", Preview);
            miOpen = new MenuItem("開く(&O)", Open); 
            miOpenFolder = new MenuItem("フォルダを開く(&F)", OpenFolder);
            contextMenu.MenuItems.AddRange(new MenuItem[]
            {
                miPreview, miOpen, miOpenFolder,
            });
            this.ContextMenu = contextMenu;

            contextMenu.Popup += (object sender, EventArgs eventArgs) =>
            {
                bool enabled = this.SelectedItems.Count > 0 && ListValid; 
                miPreview.Enabled =
                    miOpen.Enabled = 
                    miOpenFolder.Enabled = enabled;
            };
        }

        MenuItem miPreview;
        MenuItem miOpen;
        MenuItem miOpenFolder;
        ContextMenu contextMenu;

        #endregion

        private void Open(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in this.SelectedItems)
                {
                    string path = item.SubItems[ClmnPathNumber].Text;
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Preview(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in this.SelectedItems)
                {
                    string path = item.SubItems[ClmnPathNumber].Text;
                    JpnEncoding jEnc = JpnEncoding.NameToJpnEncoding(item.SubItems[ClmnCodeNumber].Text);

                    PreviewForm form = new PreviewForm(path, jEnc, AzukiBefore, AzukiAfter, RegexEnabled, RegexOptions);

                    if (OwnerForm != null)
                    {
                        form.Owner = this.OwnerForm;
                        form.Icon = this.OwnerForm.Icon;
                        form.ShowIcon = true;
                    }
                    form.Show(this);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OpenFolder(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in this.SelectedItems)
                {
                    string filePath = item.SubItems[ClmnPathNumber].Text;

                    string dirPath = Path.GetDirectoryName(filePath);
                    System.Diagnostics.Process.Start(dirPath);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        void FileListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.SelectedItems.Count > 0 && ListValid)
            {
                this.SelectedItems[0].Checked = !this.SelectedItems[0].Checked;
                
                Preview(sender, e);
            }
        }
    }
}
