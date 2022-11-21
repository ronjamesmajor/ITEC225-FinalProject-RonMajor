using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    
    internal class Administrator: User
    {
        public Administrator() : base() //inherit base constructor level because Admin inherits all permissions and rights of 'user'.
        {

        }
    }
}
