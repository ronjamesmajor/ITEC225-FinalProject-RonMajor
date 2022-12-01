using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class ApprovalWindow : Window
    {
        public static Request approvalRequest { get; set; } //new request.

        public ApprovalWindow(Request request) //approval window takes a request.
        {
            approvalRequest = request;
            InitializeComponent();
            if (request is PriorityClearanceRequest)
            {
                this.Height = 710;
                lblPriNum.Visibility = Visibility.Visible;
                lblRationale.Visibility = Visibility.Visible;
                txtPriNum.Visibility = Visibility.Visible;
                txtRationale.Visibility = Visibility.Visible;
            }
            else this.Height = 510;
            BindSources();
            DataHelper.SetupRequestTable(approvalRequest, this); //send this window and request.
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           //savedata
            this.Close();
        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BindSources()
        {
            cmbPositionType.ItemsSource = Enum.GetValues(typeof(PositionType)); //bind the combo box to the enum values.
            cmbSubtype.ItemsSource = Enum.GetValues(typeof(SubType));
            cmbDirectorate.ItemsSource = DataHelper.directorates;
            cmbLocation.ItemsSource = DataHelper.locations;

        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            DataHelper.AdvanceRequest(approvalRequest);
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            DataHelper.RejectRequest(approvalRequest);
        }
    }
}
