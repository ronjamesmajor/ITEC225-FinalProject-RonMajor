using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal class Request: IRequestForm
    {
        public string? FormName { get; set; }
        public string? DelegateLabel { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int OrderNumber { get; set; }

        public Request()
        {

        }
    }
}
