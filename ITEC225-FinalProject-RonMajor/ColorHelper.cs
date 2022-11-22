using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public static class ColorHelper
    {

        public static Color HexToColor(string hexString)
        {
            Color thisColor = new Color();
            thisColor = ColorTranslator.FromHtml(hexString);
            return thisColor;
        }

        public static System.Windows.Media.SolidColorBrush ToBrush(this System.Drawing.Color color)
        {
            return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        }
    }
}
