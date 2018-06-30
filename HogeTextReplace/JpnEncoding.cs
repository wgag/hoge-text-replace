// Wrapper class for nkf32.dll
// nkf32.dll is developed by VA007219
// http://hp.vector.co.jp/authors/VA007219/

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace utils
{
    /// <summary>
    /// Represents character encoding and provides methods that handle mainly Japanese encoding.
    /// </summary>
    public class JpnEncoding
    {
        /// <summary>
        /// Gets the number 0-6 associated with the current encoding.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets the name of the current encoding.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets an Encoding object for the current encoding.
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Use static members instead of directly using this constructor for making instances.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="encoding"></param>
        private JpnEncoding(int number, string name, Encoding encoding)
        {
            Number = number;
            Name = name;
            Encoding = encoding;
        }

        const string sAutoDetection = "自動判別";
        const string sShift_JIS = "Shift_JIS";
        const string sEUC_JP = "EUC-JP";
        const string sISO_2022_JP = "ISO-2022-JP";
        const string sUTF_8 = "UTF-8";
        const string sUTF_16LE = "Unicode";
        const string sUTF_16BE = "Unicode BE";

        const int nAutoDetection = 0;
        const int nShift_JIS = 1;
        const int nEUC_JP = 2;
        const int nISO_2022_JP = 3;
        const int nUTF_8 = 4;
        const int nUTF_16LE = 5;
        const int nUTF_16BE = 6;

        /// <summary>
        /// Gets the max number used in the Number property.
        /// </summary>
        public static int MaxNumber { get { return 6; } }

        /// <summary>
        /// Gets an JpnEncoding instance for auto-detect.
        /// </summary>
        public static JpnEncoding AutoDetection
        {
            get { return new JpnEncoding(nAutoDetection, sAutoDetection, null); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the Shift_JIS encoding.
        /// </summary>
        public static JpnEncoding Shift_JIS
        {
            get { return new JpnEncoding(nShift_JIS, sShift_JIS, Encoding.GetEncoding(932)); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the EUC-JP encoding.
        /// </summary>
        public static JpnEncoding EUC_JP
        {
            get { return new JpnEncoding(nEUC_JP, sEUC_JP, Encoding.GetEncoding(51932)); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the ISO-2022-JP encoding.
        /// </summary>
        public static JpnEncoding ISO_2022_JP
        {
            get { return new JpnEncoding(nISO_2022_JP, sISO_2022_JP, Encoding.GetEncoding(50222)); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the UTF-8 encoding.
        /// </summary>
        public static JpnEncoding UTF_8
        {
            get { return new JpnEncoding(nUTF_8, sUTF_8, Encoding.GetEncoding(65001)); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the UTF-16 Little Endian encoding.
        /// </summary>
        public static JpnEncoding UTF_16LE
        {
            get { return new JpnEncoding(nUTF_16LE, sUTF_16LE, Encoding.GetEncoding(1200)); }
        }

        /// <summary>
        /// Gets an JpnEncoding instance for the UTF-16 Big Endian encoding.
        /// </summary>
        public static JpnEncoding UTF_16BE
        {
            get { return new JpnEncoding(nUTF_16BE, sUTF_16BE, Encoding.GetEncoding(1201)); }
        }

        /// <summary>
        /// Gets a JpnEncoding object associated with the number 0-6.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static JpnEncoding NumberToJpnEncoding(int number)
        {
            JpnEncoding jpnEncoding;
            switch (number)
            {
                case nShift_JIS:
                    jpnEncoding = JpnEncoding.Shift_JIS;
                    break;
                case nEUC_JP:
                    jpnEncoding = JpnEncoding.EUC_JP;
                    break;
                case nISO_2022_JP:
                    jpnEncoding = JpnEncoding.ISO_2022_JP;
                    break;
                case nUTF_8:
                    jpnEncoding = JpnEncoding.UTF_8;
                    break;
                case nUTF_16LE:
                    jpnEncoding = JpnEncoding.UTF_16LE;
                    break;
                case nUTF_16BE:
                    jpnEncoding = JpnEncoding.UTF_16BE;
                    break;
                case nAutoDetection:
                default:
                    jpnEncoding = JpnEncoding.AutoDetection;
                    break;
            }
            return jpnEncoding;
        }

        /// <summary>
        /// Gets a JpnEncoding object from its name.
        /// If the specified name was not found, JpnEncoding.AutoDetection is returned.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static JpnEncoding NameToJpnEncoding(string name)
        {
            JpnEncoding jpnEncoding;
            switch (name)
            {
                case sShift_JIS:
                    jpnEncoding = JpnEncoding.Shift_JIS;
                    break;
                case sEUC_JP:
                    jpnEncoding = JpnEncoding.EUC_JP;
                    break;
                case sISO_2022_JP:
                    jpnEncoding = JpnEncoding.ISO_2022_JP;
                    break;
                case sUTF_8:
                    jpnEncoding = JpnEncoding.UTF_8;
                    break;
                case sUTF_16LE:
                    jpnEncoding = JpnEncoding.UTF_16LE;
                    break;
                case sUTF_16BE:
                    jpnEncoding = JpnEncoding.UTF_16BE;
                    break;
                case sAutoDetection:
                default:
                    jpnEncoding = JpnEncoding.AutoDetection;
                    break;
            }
            return jpnEncoding;
        }

        /// <summary>
        /// Gets the version of NKF.
        /// </summary>
        /// <param name="verStr"></param>
        [DllImport("nkf32.dll")]
        static extern void GetNkfVersion(StringBuilder verStr);

        /// <summary>
        /// Sets options to NKF.
        /// </summary>
        /// <param name="optStr">The option string. For example, specify "-Sj" to suppose input Shift_JIS and output in JIS.</param>
        [DllImport("nkf32.dll")]
        static extern int SetNkfOption(string optStr);

        /// <summary>
        /// Converts the string.
        /// </summary>
        /// <param name="outStr"></param>
        /// <param name="inStr"></param>
        [DllImport("nkf32.dll")]
        unsafe static extern void NkfConvert(StringBuilder outStr, char* inStr);

        /// <summary>
        /// Gets the encoding of the previous conversion. 0: Sjift_JIS, 1: EUC, 2: ISO-2022-JP, 3: UTF-8, 4: UTF-16LE, 5: UTF-16BE.
        /// </summary>
        /// <returns></returns>
        [DllImport("nkf32.dll")]
        static extern int NkfGetKanjiCode();

        /// <summary>
        /// Detect an encoding used in the specified text file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="defaultEnc"></param>
        /// <returns></returns>
        public static JpnEncoding DetectEncoding(string path, JpnEncoding defaultEnc)
        {
            StringBuilder strBldr = new StringBuilder();
            int nEnc;

            try
            {
                byte[] bytes;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }

                // set the conversion option
                // see the 'nkf.doc' or http://manpages.ubuntu.com/manpages/natty/ja/man1/nkf.1.html
                // -g  output the result of auto detection
                // -t  do nothing
                SetNkfOption("-gt");

                unsafe
                {
                    fixed (byte* pbs = bytes)
                    {
                        char* pchar = (char*) pbs;
                        NkfConvert(strBldr, pchar); // 3. convert
                    }
                }

                nEnc = NkfGetKanjiCode(); // 7. get the encoding
                nEnc += 1;

                if (nEnc == nISO_2022_JP) // // ISO-2022-JP or ASCII
                {
                    nEnc = -1; // suppose ASCII
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        if (bytes[i] == 0x1b) // ISO-2022-JP uses the character ESC (0x1B)
                        {
                            nEnc = nISO_2022_JP; // ISO-2022-JP
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            JpnEncoding jEnc;
            switch (nEnc)
            {
                case -1: // ASCII
                    jEnc = JpnEncoding.Shift_JIS;
                    break;
                case nShift_JIS: // Shift_JIS
                    jEnc = JpnEncoding.Shift_JIS;
                    break;
                case nEUC_JP: // EUC
                    jEnc = JpnEncoding.EUC_JP;
                    break;
                case nISO_2022_JP: // ISO_2022_JP
                    jEnc = JpnEncoding.ISO_2022_JP;
                    break;
                case nUTF_8: // UTF-8
                    jEnc = JpnEncoding.UTF_8;
                    break;
                case nUTF_16LE: // UTF-16LE
                    jEnc = JpnEncoding.UTF_16LE;
                    break;
                case nUTF_16BE: // UTF-16BE
                    jEnc = JpnEncoding.UTF_16BE;
                    break;
                default:
                    jEnc = defaultEnc;
                    break;
            }
            return jEnc;
        }
    }
}
