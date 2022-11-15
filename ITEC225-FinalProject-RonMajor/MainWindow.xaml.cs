using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DashBoardTab.Content = Application.LoadComponent(new Uri("DashBoard.xaml", UriKind.Relative));
        }

        private void btnNewRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewCandidate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewPosition_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
