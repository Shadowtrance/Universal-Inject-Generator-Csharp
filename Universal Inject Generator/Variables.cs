using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Universal_Inject_Generator.Properties;

namespace Universal_Inject_Generator
{
    public class Variables
    {
        //==========================================================================================

        #region Global Variables

        public static IntPtr MainForm { get; set; }

        public static string CurDir = Directory.GetCurrentDirectory();

        public static readonly string[] WPath = {"input", "tools", "work"}; // 0 - 2.

        public static string[] Tools =
        {
            "3dstool.exe", "ctrtool.exe", "MergeExHeader.exe", "ignore_3dstool.txt", "dummy.bin", "log.txt"
        }; // 0 - 5.

        //log files 0 - 1
        public static string[] Logs = {"log.txt", "log_done.txt"};

        //cia file check.
        public static FileInfo[] Cia = new DirectoryInfo(CurDir).GetFiles().Where(s => Regex.IsMatch(s.Name, @"\.(cia)$")).ToArray();

        #endregion

        //==========================================================================================

        #region Message Box Design Setup

        public static void MessageBoxSetup()
        {
            MetroStyleColorTable metroColorTable = new MetroStyleColorTable();
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            MessageBoxAdv.MetroColorTable = metroColorTable;
            metroColorTable.BackColor = Color.SteelBlue;
            metroColorTable.CaptionBarColor = Color.SteelBlue;
            metroColorTable.BorderColor = Color.DeepSkyBlue;
        }

        #endregion

        //==========================================================================================

        #region Create Directories, Copy Tools, Copy Cia/s

        //Create all our directories if they don't exist already.
        public static void CreateDirs()
        {
            if (Directory.Exists(WPath[0]) || Directory.Exists(WPath[1])) return;
            foreach (string dir in WPath)
            {
                Directory.CreateDirectory(dir);
            }
        }

        //Copy all our tools from embedded resources to tools folder if they don't already exist.
        public static void CopyTools()
        {
            //3dstool.exe
            if (!File.Exists(WPath[1] + "/" + Tools[0]))
                File.WriteAllBytes(WPath[1] + "/" + Tools[0], Resources._3dstool);

            //ctrtool.exe
            if (!File.Exists(WPath[1] + "/" + Tools[1]))
                File.WriteAllBytes(WPath[1] + "/" + Tools[1], Resources.ctrtool);

            //MergeExheader.exe
            if (!File.Exists(WPath[1] + "/" + Tools[2]))
                File.WriteAllBytes(WPath[1] + "/" + Tools[2], Resources.MergeExHeader);

            //ignore_3dstool.txt
            if (!File.Exists(CurDir + "/" + Tools[3]))
                File.WriteAllText(WPath[1] + "/" + Tools[3], Resources.ignore_3dstool);

            //dummy.bin
            if (!File.Exists(CurDir + "/" + Tools[4])) File.WriteAllBytes(WPath[1] + "/" + Tools[4], Resources.dummy);
        }

        //Copy cia files from root directory to input directory on startup.
        public static void CopyCia()
        {
            foreach (FileInfo file in Cia)
            {
                string destfile = WPath[0] + "/" + Path.GetFileName(file.ToString());

                File.Copy(file.ToString(), destfile, true);
            }
        }

        //Check if directory is empty or not.
        public static bool IsDirEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        #endregion

        //==========================================================================================

        #region Textbox Control

        //Handle console redirection.
        public static void SortOutputHandler(object sender, DataReceivedEventArgs e, MainForm mainForm)
        {
            Trace.WriteLine(e.Data);
            mainForm.BeginInvoke(new MethodInvoker(() => AppendTextBox(e.Data, mainForm)));
        }

        //Handle console redirection.
        public static void AppendTextBox(string value, MainForm mainForm)
        {
            if (mainForm.textBoxExt1.InvokeRequired)
            {
                mainForm.textBoxExt1.BeginInvoke(new Action<string, MainForm>(AppendTextBox), value);
                return;
            }
            mainForm.textBoxExt1.Text += value + Environment.NewLine;
        }

        #endregion

        //==========================================================================================

        public static void CompleteProgress(MainForm mainForm)
        {
            //Reset after process complete.
            //=================================================
            mainForm.buttonAdv1.BackColor = Color.Aqua;
            mainForm.buttonAdv1.Text = @"DONE!";

            MessageBoxAdv.Show(mainForm, @"Work Complete!", @"DONE!");
            File.Copy(Logs[0], Logs[1], true);

            mainForm.Reset(mainForm);

            File.Delete(Logs[0]);

            mainForm.buttonAdv1.Enabled = true;
            mainForm.buttonAdv2.Enabled = true;
        }
    }
}