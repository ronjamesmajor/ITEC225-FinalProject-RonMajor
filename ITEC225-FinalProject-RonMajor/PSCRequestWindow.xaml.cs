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
    /// Interaction logic for PSCRequestWindow.xaml
    /// </summary>
    public partial class PSCRequestWindow : Window
    {
        public PSCRequestWindow()
        {
            InitializeComponent();
            BindSources();
        }

        private void BindSources()
        {
            cmbCandidate.ItemsSource = FormTemplate.candidates;
            cmbCandidate.DisplayMemberPath = "DisplayName";
            cmbPosition.ItemsSource = FormTemplate.positions;
            cmbPosition.DisplayMemberPath = "DisplayName";
            cmbBilingual.ItemsSource = DataHelper.bilinguals;
            cmbLanguageProfile.ItemsSource = DataHelper.languages;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool checker;
            if (rdoYes.IsChecked == true)
                checker = true;
            else checker = false;
            PriorityClearanceRequest request = new PriorityClearanceRequest((Candidate)cmbCandidate.SelectedItem, (Position)cmbPosition.SelectedItem, txtPriorityNumber.Text, txtRationale.Text)
            {
                ApprovalRequired = checker, //prefilling values right now, rather than in constructor.
                BilingualPosition = cmbBilingual.SelectedItem.ToString(),
                LanguageProfile = cmbLanguageProfile.SelectedItem.ToString(),
                PriorityNumber = int.Parse(txtPriorityNumber.Text),
                PriorityRationale = txtRationale.Text,
            };
            FormTemplate.pscrequests.Add(request);
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
            this.Close();
        }


    }
}
