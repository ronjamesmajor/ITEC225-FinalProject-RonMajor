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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page, IRequestForm //inherit from Page and also from IRequestForm.
    {
        #region Properties
        public string FormName { get; set; }
        public string DelegateLabel { get; set; }
        public int OrderNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        #region Constructor
        public DashBoard()
        {
            InitializeComponent();
            Width = this.Width;
            Height = this.Height;
        }
        #endregion

    }
}
