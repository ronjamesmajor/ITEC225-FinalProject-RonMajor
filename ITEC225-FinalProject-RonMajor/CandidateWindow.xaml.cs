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
    /// <summary>
    /// Interaction logic for CandidateWindow.xaml
    /// </summary>
    public partial class CandidateWindow : Window
    {
        public CandidateWindow()
        {
            InitializeComponent();
        }

        public CandidateWindow(Candidate thisCand) //overload poly. for edits.
        {
            InitializeComponent();
            txtFirst.Text = thisCand.FirstName;
            txtLast.Text = thisCand.LastName;
            txtEmplNum.Text = thisCand.EmployeeNum.ToString();
            txtDepartment.Text = thisCand.Department;
            txtOfficeLocation.Text = thisCand.OfficeLocation;
            txtPhone.Text = thisCand.ContactPhone;
            txtEmail.Text = thisCand.ContactEmail;
            txtAddress.Text = thisCand.ContactAddress;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Candidate cand = new Candidate(int.Parse(txtEmplNum.Text), txtLast.Text, txtFirst.Text)
            {
                Department = txtDepartment.Text,
                OfficeLocation = txtOfficeLocation.Text,
                ContactPhone = txtPhone.Text,
                ContactAddress = txtAddress.Text,
                ContactEmail = txtEmail.Text,

            }; //new, prefill data.
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            e.Text.Trim();
        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //close window if not saving
        }
    }
}
