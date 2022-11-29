using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        public PositionWindow()
        {
            InitializeComponent();
            cmbPositionType.ItemsSource = Enum.GetValues(typeof(PositionType)); //bind the combo box to the enum values.
            cmbSubtype.ItemsSource = Enum.GetValues(typeof(SubType));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Position p = new Position(int.Parse(txtPosiNum.Text), (DateTime)dtpStart.SelectedDate)
            {
                StartDate = (DateTime)dtpStart.SelectedDate,
                EndDate = (DateTime)dtpStart.SelectedDate,
                PositionType = (PositionType)cmbPositionType.SelectedValue,
                SubType = (SubType)cmbPositionType.SelectedValue,
                OfficeLocation = cmbLocation.SelectedValue.ToString()

            };

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // use regex to make sure wpf textbox is number. https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
