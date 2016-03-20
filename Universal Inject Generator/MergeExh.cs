using System;
using System.Diagnostics;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class MergeExh
    {
        public static void MergeExheader(MainForm mainForm)
        {
            try
            {
                //Merge Exheader
                using (Process mergeExh = new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[2],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments =
                            Variables.WPath[2] + "/" + "inject_exhdr.bin " +
                            Variables.WPath[2] + "/" + "hs_exhdr.bin " +
                            Variables.WPath[2] + "/" + "merge_exhdr.bin"
                    }
                })
                {
                    mergeExh.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    mergeExh.Start();

                    mergeExh.BeginOutputReadLine();

                    mergeExh.WaitForExit();
                    mergeExh.Close();
                }
                RebuildHs.RebuildHnS_1(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}