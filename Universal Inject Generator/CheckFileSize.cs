using System;
using System.IO;

//NOT USED YET
//==========================================================================================

namespace Universal_Inject_Generator
{
    public class CheckFileSize
    {
        //hs.app
        //_inject_no_banner.app
        //_inject_with_banner.app

        //FileInfo file = new FileInfo("hs.app");
        //MessageBoxAdv.Show(this, CheckFileSize.FormatByteSize(file), @"Error!");
        public static void SizeCheck(MainForm mainForm)
        {
            FileInfo fileInfo = new FileInfo("hs.app");

            string info = "";

            info += "File: " + Path.GetFileName(fileInfo.ToString());
            info += Environment.NewLine;
            info += "File Size: " + GetFileSize((int) fileInfo.Length);

            mainForm.textBoxExt1.Text = info;
            //mainForm.label1.Text = info;
        }

        private static string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = $"{byteCount/1073741824.0:##.##}" + " GB";
            else if (byteCount >= 1048576.0)
                size = $"{byteCount/1048576.0:##.##}" + " MB";
            else if (byteCount >= 1024.0)
                size = $"{byteCount/1024.0:##.##}" + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount + " Bytes";

            return size;
        }
    }
}