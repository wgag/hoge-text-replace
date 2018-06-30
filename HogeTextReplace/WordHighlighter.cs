using System;
using System.Text.RegularExpressions;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace utils
{
    /// <summary>
    /// Highlighter for any strings.
    /// </summary>
    public class WordHighlighter : IHighlighter
    {
        Regex matchRegex;
        CharClass charClass;

        public bool CanUseHook { get { return false; } }
        public HighlightHook HookProc { get; set; }

        /// <summary>
        /// Adds words as CharClass.Heading1.
        /// </summary>
        public WordHighlighter(string text, CharClass charClass, bool regex = false, RegexOptions regexOptions = RegexOptions.None)
        {
            this.charClass = charClass;

            if (regex)
            { 
                matchRegex = new Regex(text, regexOptions);
            }
            else
            {
                string[] regexSpecialChars = new string[]
                {
                    @"\", "*", "+", ".", "?", "{", "}", "(", ")", "[", "]", "^", "$", "-", "|",
                };

                foreach (string escsq in regexSpecialChars)
                {
                    text = text.Replace(escsq, @"\" + escsq);
                }

                matchRegex = new Regex(text, RegexOptions.Singleline);
            }
        }

        #region Highlighting Logic

        /// <summary>
        /// Highlight whole document.
        /// </summary>
        /// <param name="doc">Document to highlight.</param>
        public void Highlight(Document doc)
        {
            int begin = 0;
            int end = doc.Length;
            Highlight(doc, ref begin, ref end);
        }

        /// <summary>
        /// Highlight document part.
        /// </summary>
        /// <param name="doc">Document to highlight.</param>
        /// <param name="dirtyBegin">Index to start highlighting. On return, start index of the range to be invalidated.</param>
        /// <param name="dirtyEnd">Index to end highlighting. On return, end index of the range to be invalidated.</param>
        public void Highlight(Document doc, ref int dirtyBegin, ref int dirtyEnd)
        {
            if (dirtyBegin < 0 || doc.Length < dirtyBegin)
                throw new ArgumentOutOfRangeException("dirtyBegin");
            if (dirtyEnd < 0 || doc.Length < dirtyEnd)
                throw new ArgumentOutOfRangeException("dirtyEnd");

            foreach (Match match in matchRegex.Matches(doc.Text))
            {
                int start = match.Index;
                int end = match.Index + match.Length - 1;

                for (int i = start; i <= end; i++)
                {
                    doc.SetCharClass(i, charClass);
                }
            }
        }

        #endregion
    }
}
