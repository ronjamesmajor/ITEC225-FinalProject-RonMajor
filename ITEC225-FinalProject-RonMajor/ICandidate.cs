using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal interface ICandidate
    {
        #region Properties
        public int EmployeeNum { get; set; } //Interface defines all of candidates public properties.
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DoB { get; set; }
        public string Phone {get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        #endregion
    }
}
