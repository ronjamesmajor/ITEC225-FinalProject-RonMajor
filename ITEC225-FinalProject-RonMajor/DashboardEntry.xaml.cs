using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for DashboardEntry.xaml
    /// </summary>
    public partial class DashboardEntry : UserControl, IRequestForm//inherit from User Control and also from IRequestForm.
    {
        #region Properties
        enum Process {Draft, SubDelegated, Director, Approved, Submitted, Complete}
        Process ProcessState = new();

        public string FormName { get; set; }
        public string DelegateLabel { get; set; }
        public int OrderNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
    }
}
