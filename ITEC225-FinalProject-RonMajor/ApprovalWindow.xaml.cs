﻿using System;
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
    /// Interaction logic for ApprovalWindow.xaml
    /// </summary>
    public partial class ApprovalWindow : Window
    {
        public ApprovalWindow(Request request) //approval window takes a request.
        {
            InitializeComponent();
            DataHelper.SetupRequestTable(request,this); //send this window and request.
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //savedata
            this.Close();
        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}