using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class RebuildHs
    {
        //Rebuild HS Inject App - No Banner
        public static void RebuildHnS_1(MainForm mainForm)
        {
            try
            {
                string[] files =
                    Directory.GetFiles(Variables.WPath[0], "*.cia").Select(Path.GetFileNameWithoutExtension).ToArray();

                if (File.Exists(Variables.WPath[2] + "/" + "hs_logo.bin"))
                {
                    foreach (Process rebuildHnS in files.Select(file => new Process
                    {
                        StartInfo =
                        {
                            FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            Arguments =
                                @" -c -t cxi -f " + file + "_inject_no_banner.app" +
                                " --header " + Variables.WPath[2] + "/" + "hs_hdr.bin" +
                                " --exh " + Variables.WPath[2] + "/" + "merge_exhdr.bin" +
                                " --plain " + Variables.WPath[2] + "/" + "hs_plain.bin" +
                                " --logo " + Variables.WPath[2] + "/" + "hs_logo.bin" +
                                " --exefs " + Variables.WPath[2] + "/" + "hs_mod_exefs.bin" +
                                " --romfs " + Variables.WPath[2] + "/" + "inject_romfs.bin"
                        }
                    }))
                    {
                        rebuildHnS.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                        rebuildHnS.Start();

                        rebuildHnS.BeginOutputReadLine();

                        rebuildHnS.WaitForExit();
                        rebuildHnS.Close();
                    }
                }
                else
                {
                    foreach (Process rebuildHnS in files.Select(file => new Process
                    {
                        StartInfo =
                        {
                            FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            Arguments =
                                @" -c -t cxi -f " + file + "_inject_no_banner.app" +
                                " --header " + Variables.WPath[2] + "/" + "hs_hdr.bin" +
                                " --exh " + Variables.WPath[2] + "/" + "merge_exhdr.bin" +
                                " --plain " + Variables.WPath[2] + "/" + "hs_plain.bin" +
                                " --exefs " + Variables.WPath[2] + "/" + "hs_mod_exefs.bin" +
                                " --romfs " + Variables.WPath[2] + "/" + "inject_romfs.bin"
                        }
                    }))
                    {
                        rebuildHnS.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                        rebuildHnS.Start();

                        rebuildHnS.BeginOutputReadLine();

                        rebuildHnS.WaitForExit();
                        rebuildHnS.Close();
                    }
                }
                RebuildHnS_2(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.ToString());
            }
        }

        //Rebuild HS Inject App - No Banner
        public static void RebuildHnS_2(MainForm mainForm)
        {
            try
            {
                string[] files =
                    Directory.GetFiles(Variables.WPath[0], "*.cia").Select(Path.GetFileNameWithoutExtension).ToArray();

                if (File.Exists(Variables.WPath[2] + "/" + "hs_logo.bin"))
                {
                    foreach (string file in files)
                    {
                        //Rebuild ?? banner 1
                        using (Process rebuildHnS = new Process
                        {
                            StartInfo =
                            {
                                FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                Arguments =
                                    @" -c -t cxi -f " + file + "_inject_with_banner.app" +
                                    " --header " + Variables.WPath[2] + "/" + "hs_hdr.bin" +
                                    " --exh " + Variables.WPath[2] + "/" + "merge_exhdr.bin" +
                                    " --plain " + Variables.WPath[2] + "/" + "hs_plain.bin" +
                                    " --logo " + Variables.WPath[2] + "/" + "hs_logo.bin" +
                                    " --exefs " + Variables.WPath[2] + "/" + "hs_mod_banner_exefs.bin" +
                                    " --romfs " + Variables.WPath[2] + "/" + "inject_romfs.bin"
                            }
                        })
                        {
                            rebuildHnS.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                            rebuildHnS.Start();

                            rebuildHnS.BeginOutputReadLine();

                            rebuildHnS.WaitForExit();
                            rebuildHnS.Close();
                        }
                    }
                }
                else
                {
                    foreach (string file in files)
                    {
                        //Rebuild ?? banner 2
                        using (Process rebuildHnS = new Process
                        {
                            StartInfo =
                            {
                                FileName = Variables.WPath[1] + "/" + Variables.Tools[0],
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                Arguments =
                                    @" -c -t cxi -f " + file + "_inject_with_banner.app" +
                                    " --header " + Variables.WPath[2] + "/" + "hs_hdr.bin" +
                                    " --exh " + Variables.WPath[2] + "/" + "merge_exhdr.bin" +
                                    " --plain " + Variables.WPath[2] + "/" + "hs_plain.bin" +
                                    " --exefs " + Variables.WPath[2] + "/" + "hs_mod_banner_exefs.bin" +
                                    " --romfs " + Variables.WPath[2] + "/" + "inject_romfs.bin"
                            }
                        })
                        {
                            rebuildHnS.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                            rebuildHnS.Start();

                            rebuildHnS.BeginOutputReadLine();

                            rebuildHnS.WaitForExit();
                            rebuildHnS.Close();
                        }
                    }
                }
                //Reset after process complete.
                Variables.CompleteProgress(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}