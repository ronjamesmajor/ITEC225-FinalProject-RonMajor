using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal interface IRequestForm
    {
        //Forms all will require these properties, names, labels, sizes and order number in menu.
        #region Properties 
        public string FormName { get; set; }
        public string DelegateLabel { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int OrderNumber { get; set; }

        public string MyProperty { get; set; }
        #endregion

    }
}
