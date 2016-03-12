using System;
using System.Windows.Forms;

namespace Universal_Inject_Generator
{
    internal static class Program
    {
        //public static Splash SplashForm;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
