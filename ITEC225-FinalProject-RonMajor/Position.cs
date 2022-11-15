using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal class Position: IPosition
    {
        public int PosNum { get; set; } //implement bits of the interface.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Enum PosType { get; set; }
        public Enum SubType { get; set; }

        public Position()
        {

        }
    }
}
