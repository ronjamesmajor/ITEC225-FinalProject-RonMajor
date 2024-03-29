﻿using System;
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
    /// Interaction logic for RequestElement.xaml
    /// </summary>
    public partial class RequestElement : UserControl
    {
        Request ThisRequest { get; set; }
        public static List<RequestElement> relements = new();

        public RequestElement(Request req)
        {
            InitializeComponent();
            ThisRequest = req;
            lblRefNum.Content = req.ReferenceNumber;
            lblCandidate.Content = $"{req.Candidate.LastName}, {req.Candidate.FirstName}";
            lblApprovalOrder.Content = req.approval;
            lblPosition.Content = req.Position.PositionType;
            var bc = new BrushConverter(); //convert color from hex.
            if(req.approval == ApprovalOrder.Complete)
            {
                this.Background = (Brush)bc.ConvertFrom("#82A44B");
                imgDelete.Visibility = Visibility.Hidden;
            }
        }

        public static void InitializeElements()
        {
            relements.Clear();

            foreach (Request r in FormTemplate.requests) //foreach candidate,
            {
                if(r.approval != ApprovalOrder.Deleted)
                RequestElement.relements.Add(new RequestElement(r)); //add a new element to the elements list.
            }

            for (int i = 0; i < DataHelper.controlElements.Count; i++)
            {
                if(DataHelper.controlElements[i] is RequestElement)
                {
                    DataHelper.controlElements.RemoveAt(i);
                }
            }

            foreach (RequestElement r in RequestElement.relements)
                DataHelper.controlElements.Add(r);
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void imgDelete_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Are you sure you wish to Delete this Request?","Confirm Deletion",MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            DataHelper.DeleteRequest(ThisRequest);
        }

        private void Rectangle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ApprovalWindow aw = new(ThisRequest);//show the window to control this request.
            aw.Show();
        }
    }
}
