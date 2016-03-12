using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public partial class MainForm : MetroForm
    {
        //==========================================================================================

        #region Setup

        //==========================================================================================

        public MainForm()
        {
            Thread splashThread = new Thread(Splash);
            splashThread.Start();

            InitializeComponent();
            Variables.MessageBoxSetup();


            if (!File.Exists("hs.app") || Variables.Files.Length == 0)
            {
                MessageBoxAdv.Show(this,
                    @"hs.app is missing... and/or cia file(s) are missing..." + Variables.Nline + Variables.Nline +
                    @"Please place hs.app and cia files(s) in this folder and restart the program...",
                    @"File(s) Missing!");

                Environment.Exit(0);
            }
            else
            {
                try
                {
                    Thread.Sleep(2000);

                    Variables.CreateDirs();
                    Variables.CopyTools();
                    buttonAdv1.BackColor = Color.Yellow;
                    textBoxExt1.BackColor = Color.LightSkyBlue;
                    File.Copy("hs.app", Variables.WPath[0] + "/" + "hs.app", true);
                    Variables.CopyCia();

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBoxAdv.Show(this, @"Error" + ex, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            splashThread.Abort();
        }

        //Load the splash screen
        public void Splash()
        {
            Application.Run(new Splash());
        }

        //Exit Button.
        private void buttonAdv2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //error.txt
            if (File.Exists(Variables.Logs[1])) File.Delete(Variables.Logs[1]);
        }

        //Cleanup on exit.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult response = MessageBoxAdv.Show(this, @"Are you sure you want to Exit?", @"Exit",
                MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                //input directory
                if (Directory.Exists(Variables.WPath[0]) && !Variables.IsDirEmpty(Variables.WPath[0]))
                    Directory.Delete(Variables.WPath[0], true);

                //tools directory
                if (Directory.Exists(Variables.WPath[1]) && !Variables.IsDirEmpty(Variables.WPath[1]))
                    Directory.Delete(Variables.WPath[1], true);

                //work directory
                if (Directory.Exists(Variables.WPath[2]) || !Variables.IsDirEmpty(Variables.WPath[2]))
                    Directory.Delete(Variables.WPath[2], true);

                //log.txt
                if (File.Exists(Variables.Logs[0])) File.Delete(Variables.Logs[0]);
            }
            if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //Console output text scroll to bottom.
        public void textBoxExt1_TextChanged(object sender, EventArgs e)
        {
            textBoxExt1.SelectionStart = textBoxExt1.Text.Length;
            textBoxExt1.ScrollToCaret();
            File.WriteAllText(Variables.Logs[0], textBoxExt1.Text);
        }

        #endregion

        //==========================================================================================

        #region Process Command (GO Button) / Reset

        //GO! button.
        private void buttonAdv1_Click(object sender, EventArgs e)
        {
            try
            {
                if (EncCheck.CheckEncrypted(this))
                {
                    buttonAdv1.Enabled = false;
                    buttonAdv2.Enabled = false;
                    buttonAdv1.BackColor = Color.LimeGreen;
                    buttonAdv1.Text = @"Decrypted";
                    ProcessFiles.Processfiles(this);
                }
                else
                {
                    buttonAdv1.BackColor = Color.Red;
                    buttonAdv1.Text = @"Encrypted";
                    Reset(this);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, @"Error: " + ex, @"Error!");
            }
        }

        //Reset when finished
        public void Reset(MainForm form)
        {
            buttonAdv1.BackColor = Color.Yellow;
            buttonAdv1.Text = @"GO!";
            textBoxExt1.Clear();
        }

        #endregion

        //==========================================================================================
    }
}