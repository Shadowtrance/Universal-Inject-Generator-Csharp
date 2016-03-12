using System;
using System.Diagnostics;
using Syncfusion.Windows.Forms;
using static Universal_Inject_Generator.Variables;

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
                        FileName = WPath[1] + "/" + Tools[2],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments =
                            WPath[2] + "/" + "inject_exhdr.bin " +
                            WPath[2] + "/" + "hs_exhdr.bin " +
                            WPath[2] + "/" + "merge_exhdr.bin"
                    }
                })
                {
                    mergeExh.Start();
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