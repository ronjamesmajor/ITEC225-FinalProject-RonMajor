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
using System.Drawing;
using Color = System.Drawing.Color;
using System.Runtime.CompilerServices;

namespace ITEC225_FinalProject_RonMajor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        AppTiming timing = new(); //new instance of timing, which just runs in the background.

        public MainWindow()
        {
            InitializeComponent();
            Instance = this; //make this window the static ''main window''
            PositionElement.InitializeElements(); //init elements
            CandidateElement.InitializeElements();
            DataHelper.FillElements(); //fill elements into stackpanels on main window.
        }

        private void btnNewRequest_Click(object sender, RoutedEventArgs e)
        {
            RequestWindow rw = new RequestWindow();
            rw.ShowDialog();
        }

        private void btnNewCandidate_Click(object sender, RoutedEventArgs e)
        {
            CandidateWindow cw = new CandidateWindow();
            cw.ShowDialog();
        }

        private void btnNewPosition_Click(object sender, RoutedEventArgs e)
        {
            PositionWindow pw = new PositionWindow();
            pw.ShowDialog();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            if (DataHelper.SaveData())
                lblDataSaved.Opacity = 100;
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
           List<string> data = DataHelper.LoadData();
            lblDataLoaded.Opacity = double.Parse(data[0]);
            lblDataLoaded.Content = data[1];
        }

    }
}
