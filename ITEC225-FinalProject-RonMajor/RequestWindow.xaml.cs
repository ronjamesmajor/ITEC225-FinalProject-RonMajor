using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
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
    /// Interaction logic for RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        public RequestWindow()
        {
            InitializeComponent();
            BindSources();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool checker;
            if (rdoYes.IsChecked == true)
                checker = true;
            else checker = false;
            Request request = new Request((Candidate)cmbCandidate.SelectedItem, (Position)cmbPosition.SelectedItem)
            {
                ApprovalRequired = checker, //prefilling values right now, rather than in constructor.
                BilingualPosition = cmbBilingual.SelectedItem.ToString(),
                LanguageProfile = cmbLanguageProfile.SelectedItem.ToString()
            };
        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
