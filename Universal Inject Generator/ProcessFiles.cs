using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Syncfusion.Windows.Forms;
using static Universal_Inject_Generator.Variables;

namespace Universal_Inject_Generator
{
    public class ProcessFiles
    {
        //Initial content processing
        public static void Processfiles(MainForm mainForm)
        {
            try
            {
                string[] cia = Directory.GetFiles(WPath[0], "*.cia");

                File.Copy(WPath[0] + "/" + "hs.app", WPath[2] + "/" + "hs.app");

                foreach (Process ctx in cia.Select(file => new Process
                {
                    StartInfo =
                    {
                        FileName = WPath[1] + "/" + Tools[1],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments = @" -x --contents work\ciacnt " + file
                    }
                }))
                {
                    ctx.OutputDataReceived += (o, args) => SortOutputHandler(o, args, mainForm);
                    ctx.Start();

                    ctx.BeginOutputReadLine();

                    ctx.WaitForExit();
                    ctx.Close();
                }

                //Rename extracted content to inject.app
                //Delete the extracted content
                string[] ciacnt = Directory.GetFiles(WPath[2], "ciacnt.0000.*");
                foreach (string Out in ciacnt)
                {
                    File.Copy(Out, WPath[2] + "/" + "inject.app", true);
                    File.Delete(Out);
                }
                ExtractFiles.Extractfiles(mainForm);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(mainForm, exception.Message);
            }
        }
    }
}