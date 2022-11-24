﻿using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Label = System.Windows.Controls.Label;

namespace ITEC225_FinalProject_RonMajor
{
    public class AppTiming
    {
        #region Static
        public static DispatcherTimer t1 = new(); //wpf uses dispatcher timer. part of threading.
        #endregion

        public AppTiming()
        {
            t1.Interval = new TimeSpan(0,0,1); //1 second timer.
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void T1_Tick(object? sender, EventArgs e)
        {
            if(MainWindow.Instance != null && MainWindow.Instance.lblDataSaved.Opacity > 0) //mainwindow is null when that window hasn't spawned yet.
            FadeLabel(MainWindow.Instance.lblDataSaved); //fade this label out.
        }

        private void FadeLabel(Label label)
        {
            if(label.Opacity > 0)
                label.Opacity -= 5;
            if (label.Opacity < 0)
                label.Opacity = 0;
        }
    }
}