using System;
using System.IO;
using System.Linq;
using Syncfusion.Windows.Forms;

namespace Universal_Inject_Generator
{
    public class EncCheck
    {
        //==========================================================================================

        #region Encryption Check

        //Check if file is encrypted (it shouldn't be, but just incase).
        public static bool CheckEncrypted(MainForm mainForm)
        {
            bool result = false;

            string value = null;
            const string ncch = "4E434348";

            #region Encrypted file values where NCCH should be. (starting at offset 100)

            #region OLD 3DS
            /*
                //OLD 3DS

                    //0004001000020300 JPN

                        v0        =       3D 05 FA 0A
                        v1024     =       14 05 6B D8
                        v2050     =       8C 97 E8 0D

                    //0004001000021300 USA

                        v0        =       F9 1E 99 BD
                        v1026     =       D8 EA BA 6D
                        v2051     =       55 F2 A8 1F

                    //0004001000022300 EUR

                        v0        =       EE D7 A0 A3
                        v1024     =       1F 61 5A 32
                        v2050     =       3D 63 C2 E7
                        v3077     =       1C 86 0C 39

                    //0004001000026300 CHN

                        v5        =       F0 81 15 2B

                    //0004001000027300 KOR

                        v2        =       3E E2 2D CE

                    //0004001000028300 TWN

                        v5        =       5B 2F 0E 6F
            */
            #endregion

            #region NEW 3DS
            /*
                //NEW 3DS

                    //0004001020020300 JPN

                        v2        =       B2 50 58 9C
                        v17       =       C9 44 C5 DC

                    //0004001020021300 USA

                        v1        =       1B E0 38 06

                    //0004001020022300 EUR

                        v1        =       C4 BE 3D 55
            */
            #endregion

            #endregion

            string file = Variables.WPath[0] + "/" + "hs.app";

            try
            {
                using (BinaryReader br = new BinaryReader(File.OpenRead(file)))
                {
                    for (int i = 0x00000100; i <= 0x00000103; i++)
                    {
                        br.BaseStream.Position = i;
                        value += br.ReadByte().ToString("X2");
                    }

                    if (value == ncch)
                    {
                        result = true;
                        Variables.AppendTextBox(
                            @"Correct value found..." + " " + value + " = " + HexStringToString(ncch) + Environment.NewLine +
                            Environment.NewLine,
                            mainForm);

                        MessageBoxAdv.Show(mainForm,
                            @"Correct value found..." + " " + value + " = " + HexStringToString(ncch) + Environment.NewLine +
                            Environment.NewLine +
                            "hs.app is decrypted, click OK to continue...", @"GOOD!");
                    }
                    if (value != ncch)
                    {
                        result = false;
                        Variables.AppendTextBox(
                            @"Wrong value found..." + " " + value + " = " + HexStringToString(value) + Environment.NewLine +
                            Environment.NewLine +
                            "Expected value: = " + ncch + " " + HexStringToString(ncch), mainForm);

                        MessageBoxAdv.Show(mainForm,
                            @"Wrong value found..." + " " + value + " = " + HexStringToString(value) + Environment.NewLine +
                            Environment.NewLine +
                            "hs.app is still encrypted!" +
                            Environment.NewLine + Environment.NewLine + "Expected value: " + ncch + " = " +
                            HexStringToString(ncch), @"ERROR!");

                        File.Copy("log.txt", "error.txt", true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(mainForm, @"Error: " + ex, @"Error!");
            }
            return result;
        }

        /// <summary>
        ///     Convert hex values to readable text.
        ///     <see cref="HexText" />
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static string HexStringToString(string hexString)
        {
            return
                string.Join("",
                    hexString.ToCharArray()
                        .SelectPair((ch1, ch2) => ch1.ToString() + ch2)
                        .Select(hexChar => (char) Convert.ToByte(hexChar, 16)));
        }

        #endregion

        //==========================================================================================
    }
}
