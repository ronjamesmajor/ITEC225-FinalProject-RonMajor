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
using System.Drawing;
using Color = System.Drawing.Color;

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
            //add dashboard entry.
            DashboardEntry db1 = new DashboardEntry();
            stpDashboard.Children.Add(db1);
        }

        private void btnNewRequest_Click(object sender, RoutedEventArgs e)
        {
            RequestWindow rw = new RequestWindow();
            rw.ShowDialog();
        }

        private void btnNewCandidate_Click(object sender, RoutedEventArgs e)
        {
            CandidateWindow cw = new CandidateWindow();
            cw.ShowDialog();
        }

        private void btnNewPosition_Click(object sender, RoutedEventArgs e)
        {
            PositionWindow pw = new PositionWindow();
            pw.ShowDialog();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //save data.
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            //load data.
        }

    }
}
