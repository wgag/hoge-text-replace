// Copyright (c) 2012-2018 wgag. All rights reserved.

using System;
using System.Reflection;
using System.Windows.Forms;

namespace HogeTextReplace
{
    class Program
    {
        public static string Title { get; set; }
        public static string Copyright { get; set; }
        public static int VersionMajor { get; set; }
        public static int VersionMinor { get; set; }
        public static int VersionBuild { get; set; }

        static Program()
        {
            Title = ((AssemblyTitleAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute))).Title;
            Copyright = ((AssemblyCopyrightAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute))).Copyright;

            VersionMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
            VersionMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
            VersionBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            if (!System.IO.File.Exists("Azuki.dll"))
            {
                MessageBox.Show("Azuki.dll が存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists("nkf32.dll"))
            {
                MessageBox.Show("nkf32.dll が存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
