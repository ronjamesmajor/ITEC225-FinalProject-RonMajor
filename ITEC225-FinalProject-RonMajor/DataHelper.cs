using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient; //use sql client.

namespace ITEC225_FinalProject_RonMajor
{
    public class DataHelper
    {

        #region Methods
        public void InitLogin()//init the local files and deserialize to create a datastore.
        {
            if (File.Exists("userlogins.JSON"))
            {
            string json = File.ReadAllText("userlogins.JSON");//deserialize.
            FormTemplate.users = JsonSerializer.Deserialize<List<User>>(json); //create a list of users.
            }
        }

        public void CreateDataStore() //create data store simply writes out Users to JSON.
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(FormTemplate.users,options);
            File.WriteAllText("userLogins.JSON", json);
        }

        public void CreateUser(LoginWindow loginWindow) //Create a new user, and add them to the list.
        {
            User tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
            CreateDataStore(); //then writes users out to json.
            MainWindow mw = new(); //and opens a new window.
            mw.Show();
            loginWindow.Close();
        }

        public void TestLogin(LoginWindow loginWindow) //test login to see if it exists.
        {
            if(FormTemplate.users.Count > 0)
            {
                foreach(User user in FormTemplate.users)
                {
                    if (user.Username == loginWindow.txtUsrname.Text)
                    {
                        MessageBox.Show("User login exists.");
                    }
                }
            }
        }

        public void ConfirmLogin(LoginWindow loginWindow)// Check for valid credentials, and notify.
        {
            if (FormTemplate.users.Count > 0)//if list is not empty
            {
                foreach (User user in FormTemplate.users)
                {
                    if (user.Username == loginWindow.txtUsrname.Text && user.Password == loginWindow.pwdPassbox.Password)
                    {
                        MessageBox.Show("Login Successful.");
                        MainWindow mw = new MainWindow();
                        loginWindow.Close();
                        mw.Show();
                    }
                    else MessageBox.Show("Login not successful.");
                }
            }
            else MessageBox.Show("No datastore present.");
        }
        #endregion
    }
}
