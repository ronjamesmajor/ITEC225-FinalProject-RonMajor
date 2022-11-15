using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public class Candidate : ICandidate
    {
        #region Properties
        public int EmployeeNum { get; set; } //Use all properties of interface.
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        #endregion

        public Candidate()
        {
        }
    }
}
