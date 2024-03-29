﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public enum VisibilityLevel { Admin, Manager, HR, Client }

    internal interface ICandidate
    {

        #region Properties
        public int EmployeeNum { get; set; } //Interface defines all of candidates public properties.
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string ContactPhone {get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public VisibilityLevel VisLevel { get; set; }
        #endregion
    }
}
