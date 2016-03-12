using System;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Forms;
using static Universal_Inject_Generator.Variables;

namespace Universal_Inject_Generator
{
    public class GenRomFs
    {
        public static void GenRomfs(MainForm mainForm)
        {
            try
            {
                Directory.CreateDirectory(WPath[2] + "/" + "dummy_romfs");

                File.Copy(WPath[1] + "/" + "dummy.bin", WPath[2] + "/" + "dummy_romfs" + "/" + "dummy.bin", true);

                //Generate new Romfs
                using (Process genRomfs = new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -c -t romfs -f " + WPath[2] + "/" + "dummy_romfs.bin" +
                            " --romfs-dir " + WPath[2] + "/" + "dummy_romfs"
                    }
                })
                {
                    genRomfs.Start();
                    genRomfs.WaitForExit();
                    genRomfs.Close();
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