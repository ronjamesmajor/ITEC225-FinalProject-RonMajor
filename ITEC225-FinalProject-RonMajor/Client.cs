using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    internal class Client: HR
    {
        public Client() : base()
        {
            accessLevel = AccessLevel.Client;
            abilityLevel = AbilityLevel.Read;
        }
    }
}
