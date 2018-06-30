using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sgry.Azuki;
using System.IO;
using System.Text.RegularExpressions;

namespace utils
{
    public partial class PreviewForm : Form
    {
        public static int DefaultWidth { get { return defaultWidth; } set { defaultWidth = value; } }
        static int defaultWidth = 600;

        public static int DefaultHeight { get { return defaultHeight; } set { defaultHeight = value; } }
        static int defaultHeight = 400;

        public PreviewForm(string path, JpnEncoding encoding, AzukiTextBox azukiBefore, AzukiTextBox azukiAfter, bool regex = false, RegexOptions regexOptions = RegexOptions.None)
        {
            InitializeComponent();

            this.Width = DefaultWidth;
            this.Height = DefaultHeight;

            this.Text = string.Format("{0} [{1}]", path, encoding.Name);
            
            this.azukiBefore.Font = azukiBefore.Font;
            this.azukiBefore.MarkerColor = azukiBefore.MarkerColor;
            this.azukiBefore.DrawingOption = azukiBefore.DrawingOption;
            this.azukiBefore.ColorScheme.SetColor(CharClass.Keyword, azukiBefore.ForeColor, Color.FromArgb(0xff, 0xff, 0x22));
           
            OpenFile(path, encoding);

            if (!string.IsNullOrEmpty(azukiBefore.Text))
            {
                this.azukiBefore.Document.Highlighter = new WordHighlighter(azukiBefore.Text, CharClass.Keyword, regex, regexOptions);
            }
           
            this.azukiAfter.Font = azukiAfter.Font;
            this.azukiAfter.MarkerColor = azukiAfter.MarkerColor;
            this.azukiAfter.DrawingOption = azukiAfter.DrawingOption;

            if (!string.IsNullOrEmpty(azukiBefore.Text))
            {
                if (regex)
                {
                    Regex re = new Regex(azukiBefore.Text, regexOptions);
                    this.azukiAfter.Text = re.Replace(this.azukiBefore.Text, azukiAfter.Text);
                }
                else
                {
                    this.azukiAfter.Text = this.azukiBefore.Text.Replace(azukiBefore.Text, azukiAfter.Text);
                }
            }
            else
            {
                this.azukiAfter.Text = this.azukiBefore.Text;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DefaultWidth = this.Width;
            DefaultHeight = this.Height;
            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tabControl.SelectedIndex = 0;
        }

        private void OpenFile(string path, JpnEncoding encoding)
        {
            try
            {
                JpnEncoding jEnc = encoding;
                if (jEnc == null)
                {
                    jEnc = JpnEncoding.DetectEncoding(path, JpnEncoding.Shift_JIS);
                }

                using (StreamReader sr = new StreamReader(path, jEnc.Encoding))
                {
                    azukiBefore.Text = sr.ReadToEnd();
                }

                azukiBefore.ScrollToCaret();
                azukiBefore.Document.ClearHistory();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tabBefore_Enter(object sender, EventArgs e)
        {
            azukiBefore.Focus();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null)
            {
                return;
            }
            tabControl.SelectedTab.Controls[0].Focus();
        }

        private void tabBefore_Enter_1(object sender, EventArgs e)
        {
            tabControl_SelectedIndexChanged(sender, e);
        }
    }
}
