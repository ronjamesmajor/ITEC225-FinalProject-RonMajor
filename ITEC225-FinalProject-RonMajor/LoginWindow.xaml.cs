using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            System.Drawing.Color colorString = ColorHelper.HexToColor("F8F2F5");
            System.Windows.Media.SolidColorBrush colorBrush  = ColorHelper.ToBrush(colorString);
            pwbPassword.Foreground = colorBrush;
        }

    }
}
