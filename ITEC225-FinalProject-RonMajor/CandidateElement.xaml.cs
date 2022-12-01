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
    /// Interaction logic for CandidateElement.xaml
    /// </summary>
    public partial class CandidateElement : UserControl
    {
        Candidate ThisCandidate { get; set; }
        public static List<CandidateElement> celements = new();

        public CandidateElement(Candidate cand)
        {
            InitializeComponent();
            ThisCandidate = cand;//make this candidate the passed value.
            lblEmpNum.Content = cand.EmployeeNum;
            lblEmpName.Content = $"{cand.LastName}, {cand.FirstName}";
            lblOfficeLoc.Content = cand.OfficeLocation;
        }
        public static void InitializeElements()
        {
            celements.Clear();

            foreach (Candidate c in FormTemplate.candidates) //foreach candidate,
                CandidateElement.celements.Add(new CandidateElement(c)); //add a new element to the elements list.

            foreach (CandidateElement c in CandidateElement.celements)
                DataHelper.controlElements.Add(c);                  
        }

        private void UserControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Rectangle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CandidateWindow cw = new CandidateWindow(ThisCandidate);
            cw.Show();
        }

        private void imgDelete_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Delete this Position?", "Confirm Deletion", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                DataHelper.DeleteCandidate(ThisCandidate);
        }
    }
}
