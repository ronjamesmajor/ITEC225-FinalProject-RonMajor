﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient; //use sql client.

namespace ITEC225_FinalProject_RonMajor
{
    public class DataHelper
    {
        #region Static
        public static List<UserControl> controlElements = new(); //new static list of all user controls.
        #endregion

        #region Methods
        public void InitLogin()//init the local files and deserialize to create a datastore.
        {
            if (File.Exists("userlogins.JSON"))
            {
                string json = File.ReadAllText("userlogins.JSON");//deserialize.
                FormTemplate.users = JsonSerializer.Deserialize<List<User>>(json); //create a list of users.
            }
            CleanUpUserist();//clean up the lists.
        }

        public void CreateDataStore() //create data store simply writes out Users to JSON.
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(FormTemplate.users, options);
            File.WriteAllText("userLogins.JSON", json);
        }

        public void CreateUser(LoginWindow loginWindow, AccessLevel accessLevel) //Create a new user, and add them to the list.
        {
            User tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
            tmp.accessLevel = accessLevel;
            tmp.abilityLevel = MatchAccessLevel(accessLevel);
            FormTemplate.users.Add(tmp);
            CreateDataStore(); //then writes users out to json.
            MainWindow mw = new(); //and opens a new window.
            mw.Show();
            loginWindow.Close();
        }

        public void TestLogin(LoginWindow loginWindow) //test login to see if it exists.
        {
            if (FormTemplate.users.Count > 0)
            {
                foreach (User user in FormTemplate.users)
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
            bool nouser = false;
            if (FormTemplate.users.Count > 0)//if list is not empty
            {
                for (int i = 0; i < FormTemplate.users.Count; i++)
                {
                    nouser = false;
                    if (FormTemplate.users[i].Username == loginWindow.txtUsrname.Text)
                    {

                        if (FormTemplate.users[i].Username == loginWindow.txtUsrname.Text && FormTemplate.users[i].Password == loginWindow.pwdPassbox.Password)
                        {
                            MessageBox.Show("Login Successful.");
                            MainWindow mw = new MainWindow();
                            loginWindow.Close();
                            mw.Show();
                            break;
                        }
                        else MessageBox.Show("Login not successful.");
                    }
                    else nouser = true;
                }
                if (nouser) MessageBox.Show("No such username.");
            }
            else MessageBox.Show("No datastore present.");
        }

        public AccessLevel TestUserRoles(LoginWindow loginWindow)
        {

            if (loginWindow.rdoAdmin.IsChecked == true)
            {
                if (loginWindow.txtToken.Text.Length == 8 && loginWindow.txtToken.Text.Contains("axd"))
                    return AccessLevel.Admin;
            }
            if (loginWindow.rdoManager.IsChecked == true)
            {
                if (loginWindow.txtToken.Text.Length == 7 && loginWindow.txtToken.Text.Contains("mxn"))
                    return AccessLevel.Manager;
            }
            if (loginWindow.rdoHR.IsChecked == true)
            {
                if (loginWindow.txtToken.Text.Length == 6 && loginWindow.txtToken.Text.Contains("hxr"))
                    return AccessLevel.HR;
            }
            if (loginWindow.rdoUser.IsChecked == true)
            {
                if (loginWindow.txtToken.Text.Length == 5 && loginWindow.txtToken.Text.Contains("uxr"))
                    return AccessLevel.Client;
            }
            return AccessLevel.Client; //could also be updated to accesslevel.denied
        }

        private AbilityLevel MatchAccessLevel(AccessLevel accessLevel)
        {
            if (accessLevel == AccessLevel.Admin)
                return AbilityLevel.Delete;
            if (accessLevel == AccessLevel.Manager)
                return AbilityLevel.Delete;
            if (accessLevel == AccessLevel.HR)
                return AbilityLevel.ReadEdit;
            if (accessLevel == AccessLevel.Client)
                return AbilityLevel.Add;
            return AbilityLevel.Read;
        }

        private void CleanUpUserist()
        {
            foreach (User usr in FormTemplate.users)
            {
                if (usr.accessLevel == AccessLevel.Admin)
                {
                    Administrator tmp = new(usr.Username, usr.Password);
                    FormTemplate.administrators.Add(tmp);
                }
                if (usr.accessLevel == AccessLevel.Manager)
                {
                    Manager tmp = new(usr.Username, usr.Password);
                    FormTemplate.managers.Add(tmp);
                }
                if (usr.accessLevel == AccessLevel.HR)
                {
                    HR tmp = new(usr.Username, usr.Password);
                    FormTemplate.hRs.Add(tmp);
                }
                if (usr.accessLevel == AccessLevel.Client)
                {
                    Client tmp = new(usr.Username, usr.Password);
                    FormTemplate.clients.Add(tmp);
                }
            }
            FormTemplate.users.Clear();

            foreach (Client ad in FormTemplate.clients)
                FormTemplate.users.Add(ad);
            foreach (HR ad in FormTemplate.hRs)
                FormTemplate.users.Add(ad);
            foreach (Manager ad in FormTemplate.managers)
                FormTemplate.users.Add(ad);
            foreach (Administrator ad in FormTemplate.administrators)
                FormTemplate.users.Add(ad);

        }

        public static bool SaveData() // save working data.
        {
            bool dataSaved = false;
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize(FormTemplate.candidates, options);
                File.WriteAllText("candidates.JSON", json);

                string json2 = System.Text.Json.JsonSerializer.Serialize(FormTemplate.positions, options);
                File.WriteAllText("positions.JSON", json);

                string json3 = System.Text.Json.JsonSerializer.Serialize(FormTemplate.requests, options);
                File.WriteAllText("requests.JSON", json);
                return dataSaved = true;
            }
            catch
            {
                return dataSaved;
            }
        }

        public void LoadData()//Load local files and deserialize to create datastores.
        {
            if (File.Exists("candidates.JSON"))
            {
                string json = File.ReadAllText("candidates.JSON");//deserialize.
                FormTemplate.candidates = JsonSerializer.Deserialize<List<Candidate>>(json); //create a list of users.
            }

            if (File.Exists("positions.JSON"))
            {
                string json = File.ReadAllText("positions.JSON");//deserialize.
                FormTemplate.positions = JsonSerializer.Deserialize<List<Position>>(json); //create a list of users.
            }

            if (File.Exists("requests.JSON"))
            {
                string json = File.ReadAllText("requests.JSON");//deserialize.
                FormTemplate.requests = JsonSerializer.Deserialize<List<Request>>(json); //create a list of users.
            }
        }

        internal static void FillElements()
        {
            foreach (PositionElement el in PositionElement.elements)//foreach element in the list
                MainWindow.Instance.stpDashboard.Children.Add(el);//add it to the stack panel inside of dashboard.

            //same for candidates
            //same for requests

            //same for total dashboard.
            //foreach usercontrol in datahelper.controlElements
            //mainwindow instance stpsomething.children.add(usercontrol)

        }
        #endregion
    }
}
