using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public enum PositionType { Acting, Term, Casual, Permanent }
    public enum SubType { Less4, Over4, Initial, Extension }

    internal interface IPosition
    {
        #region Properties
        public int PosNum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PositionType PositionType { get; set; }
        public SubType SubType { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        #endregion

    }
}
