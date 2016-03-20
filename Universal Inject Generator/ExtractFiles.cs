using System;
using System.Diagnostics;
using Syncfusion.Windows.Forms;

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
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -x -f " + Variables.WPath[2] + "/" + "hs.app" +
                            " --header " + Variables.WPath[2] + "/" + "hs_hdr.bin" +
                            " --exh " + Variables.WPath[2] + "/" + "hs_exhdr.bin" +
                            " --plain " + Variables.WPath[2] + "/" + "hs_plain.bin" +
                            " --logo " + Variables.WPath[2] + "/" + "hs_logo.bin" +
                            " --exefs " + Variables.WPath[2] + "/" + "hs_exefs.bin" +
                            " --romfs " + Variables.WPath[2] + "/" + "hs_romfs.bin"
                    }
                })
                {
                    extract.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    extract.Start();

                    extract.BeginOutputReadLine();

                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract inject.app
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -x -f " + Variables.WPath[2] + "/" + "inject.app" +
                            " --exh " + Variables.WPath[2] + "/" + "inject_exhdr.bin" +
                            " --exefs " + Variables.WPath[2] + "/" + "inject_exefs.bin"
                    }
                })
                {
                    extract.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    extract.Start();

                    extract.BeginOutputReadLine();

                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract hs.app exefs
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -x -f " + Variables.WPath[2] + "/" + "hs_exefs.bin" +
                            " --exefs-dir " + Variables.WPath[2] + "/" + "hs_exefs"
                    }
                })
                {
                    extract.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    extract.Start();

                    extract.BeginOutputReadLine();

                    extract.WaitForExit();
                    extract.Close();
                }

                //Extract inject.app exefs
                using (Process extract = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            @" -x -f " + Variables.WPath[2] + "/" + "inject_exefs.bin" +
                            " --exefs-dir " + Variables.WPath[2] + "/" + "inject_exefs"
                    }
                })
                {
                    extract.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    extract.Start();

                    extract.BeginOutputReadLine();

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