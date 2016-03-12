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
                File.Copy(Variables.WPath[2] + "/" + "inject_exefs" + "/" + "code.bin",
                    Variables.WPath[2] + "/" + "hs_exefs" + "/" + "code.bin", true);

                //Generate New Exefs
                using (Process genExefs = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -c -z -t exefs -f " + Variables.WPath[2] + "/" + "hs_mod_exefs.bin" +
                            " --exefs-dir " + Variables.WPath[2] + "/" + "hs_exefs" +
                            " --header " + Variables.WPath[2] + "/" + "hs_exefs.bin"
                    }
                })
                {
                    genExefs.Start();
                    genExefs.WaitForExit();
                    genExefs.Close();
                }

                File.Copy(Variables.WPath[2] + "/" + "inject_exefs" + "/" + "banner.bnr",
                    Variables.WPath[2] + "/" + "hs_exefs" + "/" + "banner.bnr", true);

                File.Copy(Variables.WPath[2] + "/" + "inject_exefs" + "/" + "icon.icn",
                    Variables.WPath[2] + "/" + "hs_exefs" + "/" + "icon.icn", true);

                using (Process genExefs = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -c -z -t exefs -f " + Variables.WPath[2] + "/" + "hs_mod_banner_exefs.bin" +
                            " --exefs-dir " + Variables.WPath[2] + "/" + "hs_exefs" +
                            " --header " + Variables.WPath[2] + "/" + "hs_exefs.bin"
                    }
                })
                {
                    genExefs.Start();
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