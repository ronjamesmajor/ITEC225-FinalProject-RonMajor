using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ChadProgram
{
    public static class HashHelper
    {
        public static string GetMD5Hash(string str)
        {
            string ret;
            //now use MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes(str); //new byte array called input is ascii encoded string.
                byte[] output = md5.ComputeHash(input); //new output array uses input to compute the hash.
                ret = Convert.ToHexString(output);
            }

            return ret;
        }
    }
}
