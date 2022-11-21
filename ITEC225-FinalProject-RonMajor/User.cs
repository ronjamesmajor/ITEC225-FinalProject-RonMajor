using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public enum AccessLevel { Admin, Manager, HR, Client }
    public enum AbilityLevel { Delete, Add, ReadEdit, Read}

    internal class User
    {
        #region Properties
        public AccessLevel accessLevel { get; set; }
        public AbilityLevel abilityLevel { get; set; }
        #endregion

        #region Constructor
        public User()
        {
            accessLevel = AccessLevel.Admin;
            abilityLevel = AbilityLevel.Delete;
        }
        #endregion



    }
}
