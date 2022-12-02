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
using System.Runtime.CompilerServices;

namespace ITEC225_FinalProject_RonMajor
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        internal static User CurrentUser { get; set; }
        AppTiming timing = new(); //new instance of timing, which just runs in the background.

        public MainWindow()
        {
            InitializeComponent();
            DataHelper.LoadData(); //load data from JSON
            LoadingLabels(); //load the labels to inform user what's going on.
            Instance = this; //make this window the static ''main window''
            DataHelper.AppStart(); //init all elements and fill the dashboard.
            AppTiming.SendTime += AppTiming_SendTime; //shoehorn in a delegate for the time.
        }

        private void AppTiming_SendTime(string message)
        {
            txtTimeBox.Content = message;
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
            if (DataHelper.SaveData())
                lblDataSaved.Opacity = 100;
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadingLabels();
        }

        private void Staffing_Request_Builder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataHelper.SaveData(); //save data when the app is closing.
        }

        private void btnNewPSC_Click(object sender, RoutedEventArgs e)
        {
            PSCRequestWindow rw = new PSCRequestWindow();
            rw.ShowDialog();
        }

        private void LoadingLabels()
        {
            List<string> data = DataHelper.LoadData();
            lblDataLoaded.Opacity = double.Parse(data[0]);
            lblDataLoaded.Content = data[1];
        }
    }
}
