using System;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class GenRomFs
    {
        public static void GenRomfs(MainForm mainForm)
        {
            try
            {
                Directory.CreateDirectory(Variables.WPath[2] + "/" + "dummy_romfs");

                File.Copy(Variables.WPath[1] + "/" + "dummy.bin",
                    Variables.WPath[2] + "/" + "dummy_romfs" + "/" + "dummy.bin", true);

                //Generate dummy Romfs
                using (Process genRomfs = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -c -t romfs -f " + Variables.WPath[2] + "/" + "dummy_romfs.bin" +
                            " --romfs-dir " + Variables.WPath[2] + "/" + "dummy_romfs"
                    }
                })
                {
                    genRomfs.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    genRomfs.Start();

                    genRomfs.BeginOutputReadLine();

                    genRomfs.WaitForExit();
                    genRomfs.Close();
                }

                if (!File.Exists(Variables.WPath[2] + "/" + "inject_romfs.bin"))
                {
                    File.Copy(Variables.WPath[2] + "/" + "dummy_romfs.bin", Variables.WPath[2] + "/" + "inject_romfs.bin", true);
                    File.Delete(Variables.WPath[2] + "/" + "dummy_romfs.bin");
                }
                MergeExh.MergeExheader(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}