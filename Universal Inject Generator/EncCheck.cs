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

            /*
                        0004001000020300 JPN v0        o3ds     =       3D 05 FA 0A
                        0004001000020300 JPN v1024     o3ds     =       14 05 6B D8
                        0004001000020300 JPN v2050     o3ds     =       8C 97 E8 0D

                        0004001000021300 USA v0        o3ds     =       F9 1E 99 BD
                        0004001000021300 USA v1026     o3ds     =       D8 EA BA 6D
                        0004001000021300 USA v2051     o3ds     =       55 F2 A8 1F

                        0004001000022300 EUR v0        o3ds     =       EE D7 A0 A3
                        0004001000022300 EUR v1024     o3ds     =       1F 61 5A 32
                        0004001000022300 EUR v2050     o3ds     =       3D 63 C2 E7
                        0004001000022300 EUR v3077     o3ds     =       1C 86 0C 39

                        0004001000026300 CHN v5        o3ds     =       F0 81 15 2B
                        0004001000027300 KOR v2        o3ds     =       3E E2 2D CE
                        0004001000028300 TWN v5        o3ds     =       5B 2F 0E 6F

                        0004001020020300 JPN v2        n3ds     =       B2 50 58 9C
                        0004001020020300 JPN v17       n3ds     =       C9 44 C5 DC

                        0004001020021300 USA v1        n3ds     =       1B E0 38 06

                        0004001020022300 EUR v1        n3ds     =       C4 BE 3D 55
            */

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
