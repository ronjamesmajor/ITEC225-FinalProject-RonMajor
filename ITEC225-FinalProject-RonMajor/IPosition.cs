using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal interface IPosition
    {
        #region Properties
        public int PosNum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Enum PosType { get; set; }
        public Enum SubType { get; set; }
        #endregion

    }
}
