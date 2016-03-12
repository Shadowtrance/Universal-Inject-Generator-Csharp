using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class ProcessFiles
    {
        //Initial content processing
        public static void Processfiles(MainForm mainForm)
        {
            try
            {
                string[] cia = Directory.GetFiles(Variables.WPath[0], "*.cia");

                File.Copy(Variables.WPath[0] + "/" + "hs.app", Variables.WPath[2] + "/" + "hs.app");

                foreach (Process ctx in cia.Select(file => new Process
                {
                    StartInfo =
                    {
                        FileName = Variables.WPath[1] + "/" + Variables.Tools[1],
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments = @" -x --contents work\ciacnt " + file
                    }
                }))
                {
                    ctx.OutputDataReceived += (o, args) => Variables.SortOutputHandler(o, args, mainForm);
                    ctx.Start();

                    ctx.BeginOutputReadLine();

                    ctx.WaitForExit();
                    ctx.Close();
                }

                //Rename extracted content to inject.app
                //Delete the extracted content
                string[] ciacnt = Directory.GetFiles(Variables.WPath[2], "ciacnt.0000.*");
                foreach (string Out in ciacnt)
                {
                    File.Copy(Out, Variables.WPath[2] + "/" + "inject.app", false);
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