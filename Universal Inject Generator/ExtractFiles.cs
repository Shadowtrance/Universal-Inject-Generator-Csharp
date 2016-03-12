using System;
using System.Diagnostics;
using Syncfusion.Windows.Forms;
using static Universal_Inject_Generator.Variables;

namespace Universal_Inject_Generator
{
    public class ExtractFiles
    {
        //Extract HS and Inject app
        public static void Extractfiles(MainForm mainForm)
        {
            try
            {
                //Extract hs.app
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -x -f " + WPath[2] + "/" + "hs.app" +
                            " --header " + WPath[2] + "/" + "hs_hdr.bin" +
                            " --exh " + WPath[2] + "/" + "hs_exhdr.bin" +
                            " --plain " + WPath[2] + "/" + "hs_plain.bin" +
                            " --logo " + WPath[2] + "/" + "hs_logo.bin" +
                            " --exefs " + WPath[2] + "/" + "hs_exefs.bin" +
                            " --romfs " + WPath[2] + "/" + "hs_romfs.bin"
                    }
                })
                {
                    extract.Start();
                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract inject.app
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -x -f " + WPath[2] + "/" + "inject.app" +
                            " --exh " + WPath[2] + "/" + "inject_exhdr.bin" +
                            " --exefs " + WPath[2] + "/" + "inject_exefs.bin"
                    }
                })
                {
                    extract.Start();
                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract hs.app exefs
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -x -f " + WPath[2] + "/" + "hs_exefs.bin" +
                            " --exefs-dir " + WPath[2] + "/" + "hs_exefs"
                    }
                })
                {
                    extract.Start();
                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract inject.app exefs
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            @" -x -f " + WPath[2] + "/" + "inject_exefs.bin" +
                            " --exefs-dir " + WPath[2] + "/" + "inject_exefs"
                    }
                })
                {
                    extract.Start();
                    extract.WaitForExit();
                    extract.Close();
                }
                GenExeFs.GenexeFs(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}