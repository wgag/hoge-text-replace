// Wrapper class for Azuki
// Azuki is developed by YAMAMOTO Suguru
// http://azuki.sourceforge.jp/

using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using Sgry.Azuki;
using Sgry.Azuki.WinForms;

namespace utils
{
    /// <summary>
    /// Reprents a text box control based on AzukiControl.
    /// </summary>
    public class AzukiTextBox : AzukiControl  // , ICloneable
    {

        #region Public Properties
        /// <summary>
        /// Get or sets the color for markers such as EOF or Whitespace.
        /// </summary>
        public Color MarkerColor
        {
            get { return ColorScheme.EolColor; }
            set
            {
                this.ColorScheme.EolColor = 
                this.ColorScheme.EofColor = 
                this.ColorScheme.WhiteSpaceColor = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                this.ColorScheme.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this.ColorScheme.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the newline chars: "\r\n", "\n", or "\r".
        /// </summary>
        public string NewlineChars
        {
            get { return this.Document.EolCode; }
            set { this.Document.EolCode = value; }
        }

        #endregion

        private const int WM_CHAR = 0x0102;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SETTEXT = 0x000C;
        private const int WM_PASTE = 0x0302;

        //[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //protected override void  WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //       case WM_PASTE:
        //            {
        //                MessageBox.Show("paste");
        //                flgPaste++;
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    base.WndProc(ref m);
        //}

        //public object Clone()
        //{
        //    AzukiTextBox azuki = new AzukiTextBox();

        //    azuki.Font = (Font) this.Font.Clone();
        //    azuki.Document.Text = (string) this.Document.Text.Clone();
        //    azuki.MarkerColor = this.MarkerColor;
        //    azuki.Text = (string) this.Text.Clone();

        //    return azuki;
        //    //return MemberwiseClone();
        //}

        /// <summary>
        /// Determines whether newline chars should be updated by the UpdateNewlineChars method.
        /// </summary>
        /// <returns></returns>
        public bool NeedToUpdateNewlineChars()
        {
            if (NewlineChars == "\r")
            {
                return Text.Contains("\n");
            }
            else if (NewlineChars == "\n")
            {
                return Text.Contains("\r");
            }
            else  // if NewlineChar == "\r\n"
            {
                return Regex.IsMatch(@"\r[^\n]{1}", Text, RegexOptions.Singleline) ||
                    Regex.IsMatch(@"[^\r]{1}\n", Text, RegexOptions.Singleline) ||
                    Text.StartsWith("\n") ||
                    Text.EndsWith("\r");
            }
        }

        /// <summary>
        /// Updates newline in the text to the one specified in the NewlineChars property.
        /// </summary>
        public void UpdateNewlineChars()
        {
            string text = this.Text.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", NewlineChars);

            if (string.Compare(this.Text, text) != 0)
            {
                this.Text = text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the AzukiTextBox class.
        /// </summary>
        public AzukiTextBox()
        {
            InitializeComponents();
            InitializeContextMenu();

            Sgry.Azuki.UserPref.CopyLineWhenNoSelection = false;
        }

      
        private void InitializeComponents()
        {
            //
            // Color
            //
            this.MarkerColor = Color.FromArgb(0x7F, 0x7F, 0x7F);
            this.ForeColor = SystemColors.WindowText;
            this.BackColor = SystemColors.Window;
            this.ColorScheme.SelectionBack = SystemColors.Highlight;
            this.ColorScheme.SelectionFore = SystemColors.HighlightText;
            this.ColorScheme.MatchedBracketBack = Color.Transparent; 
            this.ColorScheme.MatchedBracketFore = Color.Transparent;

            this.HighlightsMatchedBracket = false; 

            //
            // Generic
            //
            this.TabWidth = 4;
            this.BorderStyle = BorderStyle.None;
            this.Font = new Font("ＭＳ ゴシック", 9);
            this.AcceptsTab = true;
            this.AcceptsReturn = true;
            this.Dock = DockStyle.Fill;

            this.ScrollsBeyondLastLine = false; 

            //
            // DrawingOption
            //

            this.DrawsEolCode = true;
            this.DrawsEofMark = false;
            this.DrawsSpace = false;
            this.DrawsFullWidthSpace = false;
            this.HighlightsCurrentLine = false;
            this.ShowsLineNumber = false;
            this.ShowsHRuler = false;
            this.ShowsHScrollBar = true;
            this.ShowsDirtBar = false;

        }

        #region Context Menu

        private void InitializeContextMenu()
        {
            contextMenu = new System.Windows.Forms.ContextMenu();

            miUndo = new MenuItem("元に戻す(&U)", DoUndo, Shortcut.CtrlZ);
            miRedo = new MenuItem("やり直し(&R)", DoRedo, Shortcut.CtrlY);
            miCut = new MenuItem("切り取り(&T)", DoCut, Shortcut.CtrlX);
            miCopy = new MenuItem("コピー(&C)", DoCopy, Shortcut.CtrlC);
            miPaste = new MenuItem("貼り付け(&P)", DoPaste, Shortcut.CtrlV);
            miSelectAll = new MenuItem("すべて選択(&A)", DoSelectAll, Shortcut.CtrlA);

            contextMenu.MenuItems.AddRange(new MenuItem[]
            {
                miUndo, miRedo, new MenuItem("-"),
                miCut, miCopy, miPaste, new MenuItem("-"),
                miSelectAll
            });
            contextMenu.Popup += (object sender, EventArgs eventArgs) =>
            {
                miUndo.Enabled = CanUndo && !IsReadOnly;
                miRedo.Enabled = CanRedo && !IsReadOnly;
                miCut.Enabled = CanCut && !IsReadOnly;
                miCopy.Enabled = CanCopy;
                miPaste.Enabled = CanPaste && !IsReadOnly;
                miSelectAll.Enabled = CanSelect;
            };

            this.ContextMenu = contextMenu;
        }

        MenuItem miUndo;
        MenuItem miRedo;
        MenuItem miCut;
        MenuItem miCopy;
        MenuItem miPaste;
        MenuItem miSelectAll;
        ContextMenu contextMenu;

        #endregion

        void DoUndo(object sender, EventArgs e)
        {
            Undo();
        }

        void DoRedo(object sender, EventArgs e)
        {
            Redo();
        }

        void DoCut(object sender, EventArgs e)
        {
            Cut();
        }

        void DoCopy(object sender, EventArgs e)
        {
            Copy();
        }

        void DoPaste(object sender, EventArgs e)
        {
            Paste();
        }

        void DoSelectAll(object sender, EventArgs e)
        {
            SelectAll();
        }
    }
}
