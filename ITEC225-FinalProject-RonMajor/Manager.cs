using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal class Manager : Administrator
    {

        public Manager():base()
        {
            accessLevel = AccessLevel.Manager;
            abilityLevel = AbilityLevel.Add;
        }
    }
}
