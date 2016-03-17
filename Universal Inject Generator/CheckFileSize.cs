
//NOT USED YET
//==========================================================================================

namespace Universal_Inject_Generator
{
    /// <summary>
    /// http://www.somacon.com/p576.php
    /// http://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net/11124118#11124118
    /// </summary>
    public class CheckFileSize
    {
        // Returns the human-readable file size for an arbitrary, 64-bit file size 
        // The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
        public static string GetBytesReadable(long i)
        {
            // Get absolute value
            long absoluteI = i < 0 ? -i : i;
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absoluteI >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = i >> 50;
            }
            else if (absoluteI >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = i >> 40;
            }
            else if (absoluteI >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = i >> 30;
            }
            else if (absoluteI >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = i >> 20;
            }
            else if (absoluteI >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = i >> 10;
            }
            else if (absoluteI >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = readable / 1024;
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }
    }
}
