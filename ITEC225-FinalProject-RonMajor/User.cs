using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC225_FinalProject_RonMajor
{
    public enum AccessLevel { Admin, Manager, HR, Client }
    public enum AbilityLevel { Delete, Add, ReadEdit, Read}

    [Serializable]
    internal class User
    {
        #region Properties
        public AccessLevel accessLevel { get; set; }
        public AbilityLevel abilityLevel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructor
        public User(string username, string password)
        {
            accessLevel = AccessLevel.Admin; //in constructor, set access and ability levels, credentials,and add to list.
            abilityLevel = AbilityLevel.Delete;
            Username = username;
            Password = password;
            FormTemplate.users.Add(this);
        }
        #endregion



    }

    internal class Administrator : User
    {
        public Administrator(string username, string password) : base(username,password) //inherit base constructor level because Admin inherits all permissions and rights of 'user'.
        {

        }
    }

    internal class Manager : Administrator
    {

        public Manager(string username, string password) : base(username, password)
        {
            accessLevel = AccessLevel.Manager;
            abilityLevel = AbilityLevel.Add;
        }
    }

    internal class HR : Manager
    {
        public HR(string username, string password) : base(username, password)
        {
            accessLevel = AccessLevel.HR;
            abilityLevel = AbilityLevel.ReadEdit;
        }
    }

    internal class Client : HR
    {
        public Client(string username, string password) : base(username,password)
        {
            accessLevel = AccessLevel.Client;
            abilityLevel = AbilityLevel.Read;
        }
    }
}
