using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace HogeTextReplace
{
    /// <summary>
    /// Defines the base for descended classes which represent an INI file.
    /// </summary>
    public abstract class IniBase
    {
        /// <summary>
        /// The path to the INI file, which is initialized in the constructor.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instnace of the class from the specified file name.
        /// </summary>
        /// <param name="filename">The file name which does not include the absolute path to its folder.</param>
        public IniBase(string filename)
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), filename);
        }

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        private extern static int GetPrivateProfileString(
            String lpSectName,
            String lpKeyName,
            String lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            String lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA")]
        private extern static int WritePrivateProfileString(
            String lpSectName,
            String lpKeyName,
            String lpValue,
            String lpFileName);

        /// <summary>
        /// Loads the INI file.
        /// </summary>
        public abstract void LoadIni();

        /// <summary>
        /// Saves the INI file.
        /// </summary>
        public abstract void SaveIni();

        /// <summary>
        /// Gets the string value of the specified section and key from the INI file.
        /// </summary>
        /// <param name="section">The section string.</param>
        /// <param name="key">The key string.</param>
        /// <param name="defaultValue">The default value which will be returned when the required value does not exist.</param>
        /// <param name="size">The max length of the value.</param>
        /// <returns>The value string.</returns>
        protected string GetProperty(string section, string key, string defaultValue, int size = 1024)
        {
            StringBuilder strBldr = new StringBuilder(size);
            GetPrivateProfileString(section, key, defaultValue, strBldr, size, path);
            return strBldr.ToString();
        }

        /// <summary>
        /// Writes the section, key and its value in the INI file.
        /// </summary>
        /// <param name="section">The section string.</param>
        /// <param name="key">The key string.</param>
        /// <param name="value">The value string.</param>
        protected void SetProperty(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }
    }
}
