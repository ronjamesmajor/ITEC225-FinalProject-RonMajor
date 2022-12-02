using Microsoft.Data.SqlClient.DataClassification;
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
        static int dataRefreshTimer = 0;
        #endregion
        #region delegate
        public delegate void SendTimeEventHandler(string message); //new delegate to send time.
        public static event SendTimeEventHandler SendTime;
        #endregion
        public AppTiming()
        {
            t1.Interval = new TimeSpan(0, 0, 1); //1 second timer.
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void T1_Tick(object? sender, EventArgs e)
        {
            dataRefreshTimer++;
            SendTime?.Invoke(DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"));//invoke delegate to send time.

            if (MainWindow.Instance != null && MainWindow.Instance.lblDataSaved.Opacity > 0) //mainwindow is null when that window hasn't spawned yet.
                FadeLabel(MainWindow.Instance.lblDataSaved); //fade this label out.
            if (MainWindow.Instance != null && MainWindow.Instance.lblDataLoaded.Opacity > 0)
                FadeLabel(MainWindow.Instance.lblDataLoaded);

            if(dataRefreshTimer >= 15)
            {
                DataHelper.AppStart();
                dataRefreshTimer = 0;
            }

        }

        private void FadeLabel(Label label)
        {
            if (label.Opacity > 0)
                label.Opacity -= 10;
            if (label.Opacity < 0)
                label.Opacity = 0;
        }
    }
}
