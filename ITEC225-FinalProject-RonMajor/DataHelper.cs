using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ITEC225_FinalProject_RonMajor
{
    public class DataHelper
    {
        #region Fields
        #endregion

        #region Static
        public static List<UserControl> controlElements = new(); //new static list of all user controls.
        public static int counter = 0;
        public static string opacity, content;
        #endregion

        #region Properties
        //create all the collections to bind for data.
        public static ObservableCollection<string> directorates = new ObservableCollection<string>() { "BOP", "BSI", "BSIM", "SABR" };
        public static ObservableCollection<string> locations = new ObservableCollection<string>() { "NCR", "AB", "BC", "MB", "NB", "BL", "NS", "ON", "PEI", "QC", "SK", "CANADA" };
        public static ObservableCollection<string> bilinguals = new ObservableCollection<string>() { "Bilingual Imperative", "English Imperative", "French Imperative", "N/A" };
        public static ObservableCollection<string> languages = new ObservableCollection<string>() { "AAA", "ABA", "English Only", "French Only", "N/A" };

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
            if (accessLevel == AccessLevel.Admin)
            {
                Administrator tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
                FormTemplate.users.Add(tmp);
            }
            if (accessLevel == AccessLevel.Manager)
            {
                Manager tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
                FormTemplate.users.Add(tmp);
            }
            if (accessLevel == AccessLevel.HR)
            {
                HR tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
                FormTemplate.users.Add(tmp);
            }
            if (accessLevel == AccessLevel.Client)
            {
                Client tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
                FormTemplate.users.Add(tmp);
            }
            if (accessLevel == null)
            {
                Client tmp = new(loginWindow.txtUsrname.Text, loginWindow.pwdPassbox.Password);
                FormTemplate.users.Add(tmp);
            }
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
                            MainWindow.CurrentUser = FormTemplate.users[i];
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
                File.WriteAllText("positions.JSON", json2);

                string json3 = System.Text.Json.JsonSerializer.Serialize(FormTemplate.requests, options);
                File.WriteAllText("requests.JSON", json3);
                return dataSaved = true;
            }
            catch
            {
                return dataSaved;
            }
        }

        public static bool UpdatePosition(Position position, PositionWindow thisWindow) // save working data.
        {
            bool dataSaved = false;
            try
            {
                foreach (Position p in FormTemplate.positions)
                {
                    if (p.PosNum == position.PosNum)
                    {
                        p.StartDate = (DateTime)thisWindow.dtpStart.SelectedDate;
                        p.EndDate = (DateTime)thisWindow.dtpStart.SelectedDate;
                        p.Directorate = ((ComboBoxItem)thisWindow.cmbLocation.SelectedItem).Content.ToString();
                        p.PositionType = (PositionType)thisWindow.cmbPositionType.SelectedValue;
                        p.SubType = (SubType)thisWindow.cmbPositionType.SelectedValue;
                        p.OfficeLocation = ((ComboBoxItem)thisWindow.cmbLocation.SelectedItem).Content.ToString();
                        dataSaved = true;
                    }
                }
                return dataSaved;
            }
            catch
            {
                return dataSaved;
            }
        }

        public static List<string> LoadData()//Load local files and deserialize to create datastores.
        {
            List<string> labelProps = new();


            if (File.Exists("candidates.JSON"))
            {
                string json = File.ReadAllText("candidates.JSON");//deserialize.

                FormTemplate.candidates = JsonSerializer.Deserialize<List<Candidate>>(json); //List of Candidates
                counter += 5;
            }

            if (File.Exists("positions.JSON"))
            {
                string json = File.ReadAllText("positions.JSON");//deserialize.
                FormTemplate.positions = JsonSerializer.Deserialize<List<Position>>(json); //List of Positions.
                counter += 7;
            }

            if (File.Exists("requests.JSON"))
            {
                string json = File.ReadAllText("requests.JSON");//deserialize.
                FormTemplate.requests = JsonSerializer.Deserialize<List<Request>>(json); //List of Requests.
                counter += 9;
            }
            switch (counter)
            {
                case 0:
                    opacity = 100.ToString();
                    content = "No data to Load";
                    break;
                case 5:
                    opacity = 100.ToString();
                    content = "Candidates Loaded Successfully";
                    break;
                case 7:
                    opacity = 100.ToString();
                    content = "Positions Loaded Successfully";
                    break;
                case 9:
                    opacity = 100.ToString();
                    content = "Requests Loaded Successfully";
                    break;
                case 12:
                    opacity = 100.ToString();
                    content = "Candidates and Positions Loaded Successfully";
                    break;
                case 14:
                    opacity = 100.ToString();
                    content = "Candidates and Requests Loaded Successfully";
                    break;
                case 17:
                    opacity = 100.ToString();
                    content = "Positions and Requests Loaded Successfully";
                    break;
                case 21:
                    opacity = 100.ToString();
                    content = "All Data Loaded Successfully";
                    break;
            }
            labelProps.Add(opacity);
            labelProps.Add(content);
            return labelProps;
        }

        internal static void FillElements()
        {
            foreach (PositionElement el in PositionElement.elements)//foreach element in the list
            {
                MainWindow.Instance.stpPositions.Children.Clear();
                if (MainWindow.Instance.stpPositions.Children.Count < PositionElement.elements.Count)
                    MainWindow.Instance.stpPositions.Children.Add(el);//add it to the stack panel inside of dashboard.
            }

            foreach (RequestElement rel in RequestElement.relements)
            {
                MainWindow.Instance.stpStaffingRequests.Children.Clear();//wipe and refresh to get latest info.
                if (MainWindow.Instance.stpStaffingRequests.Children.Count < RequestElement.relements.Count)
                    MainWindow.Instance.stpStaffingRequests.Children.Add(rel);
            }

            foreach (CandidateElement cel in CandidateElement.celements)
            {
                MainWindow.Instance.stpCandidates.Children.Clear();
                if (MainWindow.Instance.stpCandidates.Children.Count < CandidateElement.celements.Count)
                    MainWindow.Instance.stpCandidates.Children.Add(cel);
            }
        }

        public static void AppStart()
        {
            PositionElement.InitializeElements(); //init elements
            CandidateElement.InitializeElements();
            RequestElement.InitializeElements();
            FillElements(); //fill elements into stackpanels on main window.
        }

        public static void SetupRequestTable(Request request, ApprovalWindow approvalWindow)
        {
            approvalWindow.cmbPositionType.ItemsSource = Enum.GetValues(typeof(PositionType)); //bind the combo box to the enum values.
            approvalWindow.cmbSubtype.ItemsSource = Enum.GetValues(typeof(SubType));
            string start = request.Position.StartDate.Date.ToShortDateString();
            string end = request.Position.EndDate.Date.ToShortDateString();
            //administrators, and managers can advance requests. Edits have a chain of custody.
            if (MainWindow.CurrentUser is Administrator)
            {
                //do edits and allow adding and deleting.
                //can't be done with 'foreach control c in usercontrols' because wpf doesn't use usercontrols.
                approvalWindow.txtFirst.IsReadOnly = false;
                approvalWindow.txtLast.IsReadOnly = false;
                approvalWindow.txtDepartment.IsReadOnly = false;
                approvalWindow.txtEmail.IsReadOnly = false;
                approvalWindow.txtAddress.IsReadOnly = false;
                approvalWindow.txtPhone.IsReadOnly = false;
                approvalWindow.txtOfficeLocation.IsReadOnly = false;
                approvalWindow.txtEmplNum.IsReadOnly = false;
                approvalWindow.txtPosiNum.IsReadOnly = false;
                approvalWindow.btnSave.Visibility = Visibility.Visible;
                approvalWindow.btnApprove.Visibility = Visibility.Visible;
                approvalWindow.btnReject.Visibility = Visibility.Visible;
                approvalWindow.cmbDirectorate.IsReadOnly = false;
                approvalWindow.cmbLocation.IsReadOnly = false;
                approvalWindow.cmbPositionType.IsReadOnly = false;
                approvalWindow.cmbSubtype.IsReadOnly = false;
                approvalWindow.dtpStart.Visibility = Visibility.Visible;
                //start backing empty.
                approvalWindow.dtpEnd.Visibility = Visibility.Visible;
                //end backing empty.

            }
            else if (MainWindow.CurrentUser is Manager) //this allows chain of custody - two people must make edits to one request.
            {
                //management can edit position information but not personal information.
                approvalWindow.txtFirst.IsReadOnly = true;
                approvalWindow.txtLast.IsReadOnly = true;
                approvalWindow.txtDepartment.IsReadOnly = false;
                approvalWindow.txtEmail.IsReadOnly = true;
                approvalWindow.txtAddress.IsReadOnly = true;
                approvalWindow.txtPhone.IsReadOnly = true;
                approvalWindow.txtOfficeLocation.IsReadOnly = true;
                approvalWindow.txtEmplNum.IsReadOnly = true;
                approvalWindow.txtPosiNum.IsReadOnly = false;
                approvalWindow.btnSave.Visibility = Visibility.Visible;
                approvalWindow.btnApprove.Visibility = Visibility.Visible;
                approvalWindow.btnReject.Visibility = Visibility.Visible;
                approvalWindow.cmbDirectorate.IsReadOnly = false;
                approvalWindow.cmbLocation.IsReadOnly = false;
                approvalWindow.cmbPositionType.IsReadOnly = false;
                approvalWindow.cmbSubtype.IsReadOnly = false;
                approvalWindow.dtpStart.Visibility = Visibility.Visible;
                approvalWindow.dtpEnd.Visibility = Visibility.Visible;

            }
            else if (MainWindow.CurrentUser is HR)
            {

                //HR can edit personal information but not position information.
                approvalWindow.txtFirst.IsReadOnly = false;
                approvalWindow.txtLast.IsReadOnly = false;
                approvalWindow.txtDepartment.IsReadOnly = false;
                approvalWindow.txtEmail.IsReadOnly = false;
                approvalWindow.txtAddress.IsReadOnly = false;
                approvalWindow.txtPhone.IsReadOnly = false;
                approvalWindow.txtOfficeLocation.IsReadOnly = false;
                approvalWindow.txtEmplNum.IsReadOnly = false;
                approvalWindow.txtPosiNum.IsReadOnly = true;
                approvalWindow.btnSave.Visibility = Visibility.Visible;
                approvalWindow.btnApprove.Visibility = Visibility.Hidden;
                approvalWindow.btnReject.Visibility = Visibility.Hidden;
                approvalWindow.cmbDirectorate.IsReadOnly = true;
                approvalWindow.cmbLocation.IsReadOnly = true;
                approvalWindow.cmbPositionType.IsReadOnly = true;
                approvalWindow.cmbSubtype.IsReadOnly = true;
                approvalWindow.dtpStart.Visibility = Visibility.Hidden;
                //start backing.
                approvalWindow.txtStartBacking.Text = start;
                approvalWindow.dtpEnd.Visibility = Visibility.Hidden;
                //end backing.
                approvalWindow.txtStartBacking.Text = end;
            }
            else if (MainWindow.CurrentUser is Client)
            {
                //don't allow editing.
                approvalWindow.btnSave.Visibility = Visibility.Hidden;

                approvalWindow.dtpStart.Visibility = Visibility.Hidden;
                //start backing.
                approvalWindow.txtStartBacking.Text = start;
                approvalWindow.dtpEnd.Visibility = Visibility.Hidden;
                //end backing.
                approvalWindow.txtEndBacking.Text = end;

                approvalWindow.btnSave.Visibility = Visibility.Hidden;
                approvalWindow.btnApprove.Visibility = Visibility.Hidden;
                approvalWindow.btnReject.Visibility = Visibility.Hidden;
            }

            //fill the tables
            //Candidate
            approvalWindow.txtFirst.Text = request.Candidate.FirstName;
            approvalWindow.txtLast.Text = request.Candidate.LastName;
            approvalWindow.txtDepartment.Text = request.Candidate.Department;
            approvalWindow.txtEmail.Text = request.Candidate.ContactEmail;
            approvalWindow.txtAddress.Text = request.Candidate.ContactAddress;
            approvalWindow.txtPhone.Text = request.Candidate.ContactPhone;
            approvalWindow.txtOfficeLocation.Text = request.Candidate.OfficeLocation;
            approvalWindow.txtEmplNum.Text = request.Candidate.EmployeeNum.ToString();
            //Request
            approvalWindow.dtpStart.SelectedDate = request.Position.StartDate;
            //approvalWindow.txtStartBacking.Text = start;
            approvalWindow.dtpEnd.SelectedDate = request.Position.EndDate;
            //approvalWindow.txtEndBacking.Text = end;
            approvalWindow.cmbLocation.SelectedValue = request.Position.OfficeLocation;
            approvalWindow.txtPosiNum.Text = request.Position.PosNum.ToString();
            approvalWindow.cmbDirectorate.SelectedValue = request.Position.Directorate;
            approvalWindow.cmbPositionType.SelectedValue = request.Position.PositionType;
            approvalWindow.cmbSubtype.SelectedValue = request.Position.SubType;


        }

        public static void AdvanceRequest(Request request)
        {
            if (request.approval < ApprovalOrder.Complete)
                request.approval += 1; //advance the request.
            RequestElement.InitializeElements();
        }

        public static void RejectRequest(Request request)
        {
            if (request.approval > ApprovalOrder.Draft)
                request.approval -= 1;
            RequestElement.InitializeElements();
        }

        public static void DeleteRequest(Request request)
        {
            request.approval = ApprovalOrder.Deleted;
            RequestElement.InitializeElements();
        }
        #endregion
    }
}
