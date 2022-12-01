using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        internal bool update= false;
        internal Position thisPosition;

        public PositionWindow()
        {
            InitializeComponent();
            BindSources();
        }

        public PositionWindow(Position thisPos) //overloaded constructor because updates!
        {
            InitializeComponent();
            BindSources();
            txtPosiNum.Text = thisPos.PosNum.ToString();
            cmbPositionType.SelectedItem = thisPos.PositionType;
            cmbSubtype.SelectedItem = thisPos.SubType;
            cmbDirectorate.SelectedItem = thisPos.Directorate;
            dtpStart.SelectedDate = thisPos.StartDate;
            dtpEnd.SelectedDate = thisPos.EndDate;
            cmbLocation.SelectedValue = thisPos.OfficeLocation;
            thisPosition = thisPos;
            update = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!update)
            if (dtpStart.SelectedDate != DateTime.MinValue) //don't allow saving for no date selected.
            {

                Position p = new Position(int.Parse(txtPosiNum.Text), (DateTime)dtpStart.SelectedDate)
                {
                    StartDate = (DateTime)dtpStart.SelectedDate,
                    EndDate = (DateTime)dtpStart.SelectedDate,
                    Directorate = cmbDirectorate.Text,
                    PositionType = (PositionType)cmbPositionType.SelectedValue,
                    SubType = (SubType)cmbPositionType.SelectedValue,
                    OfficeLocation = cmbLocation.Text,

                };
                this.Close();
            }
            if (update)
                DataHelper.UpdatePosition(thisPosition,this);
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

        private void BindSources()
        {
            cmbPositionType.ItemsSource = Enum.GetValues(typeof(PositionType)); //bind the combo box to the enum values.
            cmbSubtype.ItemsSource = Enum.GetValues(typeof(SubType));
            cmbDirectorate.ItemsSource = DataHelper.directorates;
            cmbLocation.ItemsSource = DataHelper.locations;
        }
    }
}
