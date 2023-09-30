using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SJ2GraphicsSettings
{
    public class Utils
    {
        public static string BoolToSJ2Format(bool value)
        {
            // jezeli bool = true
            if (value)
            {
                return "YES";
            } else
            {
                // jezeli nie rowna sie true
                return "NO";
            }
        }
        public static bool SJ2FormatToBool(string value)
        {
            if(value == "YES")
            {
                return true;
            } else
            {
                return false;
            }
        }
        public static void SaveConfig(string path, string H, string W, bool FullScreen,bool vsync, string colordepth, string materialquality,string shadowsquality)
        {
            string towrite = $@"RESOLUTION {W} {H}
COLORDEPTH {colordepth}
FULLSCREEN {BoolToSJ2Format(FullScreen)}
VSYNC {BoolToSJ2Format(vsync)}
MATERIAL_QUALITY {materialquality}
SHADOWS {shadowsquality}";
            try
            {
                System.IO.File.WriteAllText(path, towrite);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Coś poszło nie tak");
            }
        }
        
    }
}
