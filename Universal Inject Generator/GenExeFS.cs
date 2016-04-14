using System;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class GenExeFs
    {
        public static void GenexeFs(MainForm mainForm)
        {
            try
            {
                File.Copy(Variables.WPath[2] + "/" + "hs_exefs" + "/" + "banner.bnr",
                    Variables.WPath[2] + "/" + "inject_exefs" + "/" + "banner.bnr", true);

                //Generate No Banner Exefs
                using (Process genExefs = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -c -z -t exefs -f " + Variables.WPath[2] + "/" + "inject_no_banner_exefs.bin" +
                            " --exefs-dir " + Variables.WPath[2] + "/" + "inject_exefs" +
                            " --header " + Variables.WPath[2] + "/" + "inject_exefs.bin"
                    }
                })
                {
                    genExefs.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    genExefs.Start();

                    genExefs.BeginOutputReadLine();

                    genExefs.WaitForExit();
                    genExefs.Close();
                }
                GenRomFs.GenRomfs(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}