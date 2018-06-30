using System;
using System.IO;

namespace HogeTextReplace
{
    public class BackupArgs
    {
        public BackupMode Mode { get; set; }
        public bool Enabled { get; set; }
        public bool AppendMode { get; set; }

        public string ReplaceExtensionText { get; set; } // e.g., "bak"
        public string AnotherFolderText { get; set; } // e.g., "backup"
        public string UserDefinedText { get; set; } // e.g., "%F.%E~"

        public string TextAsUserDefined()
        {
            if (!Enabled)
            {
                return string.Empty;
            }
            else if (Mode == BackupMode.ReplaceExtension)
            {
                return "%F." + ReplaceExtensionText;
            }
            else if (Mode == BackupMode.SubFolder)
            {
                return AnotherFolderText + @"\%F.%E";
            }
            else
            {
                return UserDefinedText;
            }
        }

        public static string UserDefinedBackupFileName(string path, string pattern)
        {
            // %F : File name (does not include extension and dot)
            // %E : Extension (does not include dot)
            // %Y : Year (four digits)
            // %y %M %D %H %m %S : year Month Day Hour minute Second (two digits each)
            // %% : percent sign (%)

            string directory = Path.GetDirectoryName(path);
            if (directory[directory.Length - 1] != '\\')
            {
                directory = directory + @"\";
            }
            string fullFileName = Path.GetFileName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            if (!string.IsNullOrEmpty(extension))
            {
                extension = extension.Remove(0, 1); // remove dot
            }

            DateTime dtNow = DateTime.Now;
            string yearFourDigits = dtNow.ToString("yyyy");
            string yearTwoDigits = dtNow.ToString("yy");
            string month = dtNow.ToString("MM");
            string day = dtNow.ToString("dd");
            string hour = dtNow.ToString("HH");
            string minute = dtNow.ToString("mm");
            string second = dtNow.ToString("ss");

            pattern = pattern.Replace("%%", @"<\?>");
            pattern = pattern.Replace("%F", fileName);
            pattern = pattern.Replace("%E", extension);
            pattern = pattern.Replace("%Y", yearFourDigits);
            pattern = pattern.Replace("%y", yearTwoDigits);
            pattern = pattern.Replace("%M", month);
            pattern = pattern.Replace("%D", day);
            pattern = pattern.Replace("%H", hour);
            pattern = pattern.Replace("%m", minute);
            pattern = pattern.Replace("%S", second);
            pattern = pattern.Replace(@"<\?>", "%");

            return directory + pattern;
        }
    }
}

