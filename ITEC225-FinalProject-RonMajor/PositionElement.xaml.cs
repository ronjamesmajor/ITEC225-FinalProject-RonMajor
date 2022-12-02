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
    /// Interaction logic for PositionElement.xaml
    /// </summary>
    public partial class PositionElement : UserControl
    {
        Position ThisPositon { get; set; } //set properties for the control.
        public static List<PositionElement> elements = new();

        public PositionElement(Position posi)
        {
            InitializeComponent();
            ThisPositon = posi;
            lblPosNum.Content = ThisPositon.PosNum;
            lblStartDate.Content = ThisPositon.StartDate;
            lblPosType.Content = ThisPositon.PositionType;
            lblSubType.Content = ThisPositon.SubType;
        }

        public static void InitializeElements() //initialize the elements.
        {
            elements.Clear();
            foreach (Position p in FormTemplate.positions) //foreach position,
                PositionElement.elements.Add(new PositionElement(p)); //add a new element to the elements list.

            foreach (PositionElement p in PositionElement.elements)  //add all these elements to running list of
                DataHelper.controlElements.Add(p);                  //all elements
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void imgDelete_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Delete this Position?", "Confirm Deletion", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                DataHelper.DeletePosition(ThisPositon);
        }

        private void Rectangle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PositionWindow pw = new(ThisPositon); //overload polymorphism to use for updates.
            pw.Show();
        }
    }
}
