using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal class HR: Manager
    {
        public HR():base()
        {
            accessLevel = AccessLevel.HR;
            abilityLevel = AbilityLevel.ReadEdit;
        }
    }
}
