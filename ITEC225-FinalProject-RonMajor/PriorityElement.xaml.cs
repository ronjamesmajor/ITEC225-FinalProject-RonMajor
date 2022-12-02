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
using System.Xml.Linq;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for PriorityRequest.xaml
    /// </summary>
    public partial class PriorityElement : UserControl
    {
        PriorityClearanceRequest ThisRequest { get; set; }
        public static List<PriorityElement> pcelements = new();

        public PriorityElement(PriorityClearanceRequest req)
        {
            InitializeComponent();
            ThisRequest = req;
            lblRefNum.Content = req.ReferenceNumber.ToString();
            lblEmpNum.Content = req.Candidate.EmployeeNum.ToString();
            lblPriNum.Content = req.PriorityNumber;
            lblApprovalOrder.Content = req.approval;
        }

        public static void InitializeElements()
        {
            pcelements.Clear();

            foreach (PriorityClearanceRequest pc in FormTemplate.pscrequests) //foreach PC,
            {

                if (pc.approval != ApprovalOrder.Deleted)
                    PriorityElement.pcelements.Add(new PriorityElement((PriorityClearanceRequest)pc)); //add a new element to the elements list.

            }

            for (int i = 0; i < DataHelper.controlElements.Count; i++)
            {
                if (DataHelper.controlElements[i] is PriorityElement)
                {
                    DataHelper.controlElements.RemoveAt(i);
                }
            }

            foreach (PriorityElement pc in PriorityElement.pcelements)
                DataHelper.controlElements.Add(pc);
        }
        private void imgDelete_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Delete this Request?", "Confirm Deletion", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                DataHelper.DeleteRequest(ThisRequest);
        }

        private void Rectangle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ApprovalWindow aw = new(ThisRequest);//show the window to control this request.
            aw.Show();
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
