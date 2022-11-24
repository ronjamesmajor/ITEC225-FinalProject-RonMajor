using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DataHelper dataHelper = new();
        public LoginWindow()
        {
            InitializeComponent();
            dataHelper.InitLogin(); //do the login stuff.
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            dataHelper.ConfirmLogin(this); //confirm login.
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            UpdateContext(); //turn new user form on or off.
        }


        private void btnConfirmUser_Click(object sender, RoutedEventArgs e)
        {
            dataHelper.CreateUser(this);//create a new user.
        }

        private void UpdateContext()
        {
            if (txtToken.Visibility == Visibility.Hidden)
            {
                
                txtToken.Visibility = Visibility.Visible;
                rdoAdmin.Visibility = Visibility.Visible;
                rdoHR.Visibility = Visibility.Visible;
                rdoUser.Visibility = Visibility.Visible;
                rdoManager.Visibility = Visibility.Visible;
            } else 
            {
               
                txtToken.Visibility = Visibility.Hidden;
                rdoAdmin.Visibility = Visibility.Hidden;
                rdoHR.Visibility = Visibility.Hidden;
                rdoUser.Visibility = Visibility.Hidden;
                rdoManager.Visibility = Visibility.Hidden;
            }
        }
    }
}
