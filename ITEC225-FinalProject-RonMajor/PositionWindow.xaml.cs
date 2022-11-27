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
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Position p = new Position(int.Parse(txtPosiNum.Text), (DateTime)dtpStart.SelectedDate);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // use regex to make sure wpf textbox is number. https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
