using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemRegistration;
using SystemRegistration.DataClass;
using SystemRegistration.Model;

namespace SystemRegistration
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regBt_Click(object sender, RoutedEventArgs e)
        {
            msg.Content = string.Empty;
            UserData userData = new UserData();
            MessagesData messagesData = new MessagesData();
            SetupData(userData);
            DownloadData(userData);

            using (registerDbEntities db = new registerDbEntities())
            {
                if (NotEmpty(userData))
                {
                    AddUser(userData);
                    CheckUser(userData, db , messagesData);
                }
                else
                {
                    msg.Content = messagesData.MsgEmpty;
                }
            }

        }

        private void CheckUser( UserData ud,  registerDbEntities db , MessagesData messagesData)
        {
            foreach (User _user in ud.Users)
            {
                if (_user != null)
                {
                    if (!Validation(ud))
                    {
                        msg.Content = messagesData.MsgEmpty;
                    }
                    else
                    {
                        if (IsValid(ud.Email))
                        {
                            if (ud.Password == ud.PassRepeat)
                            {
                                DbUpdate(_user, ud ,db);
                            }
                        }
                        else
                        {
                            msg.Content = messagesData.MsgValidEmail;
                        }
                    }
                }
            }
        }

        private void DbUpdate(User _user, UserData ud , registerDbEntities db)
        {
            _user.name = ud.Name;
            _user.surname = ud.Surname;
            _user.nick = ud.Nick;
            _user.email = ud.Email;
            _user.password = ud.Password;
            _user.pass_repeat = ud.PassRepeat;
            _user.data_birth = Convert.ToDateTime(ud.DateBirth);
            db.Users.Add(_user);
            db.SaveChanges();
        }

        private void AddUser(UserData ud)
        {
            ud.Users = new List<User>();
            ud.Users.Add(new User()
            {
                name = ud.Name,
                surname = ud.Surname,
                nick = ud.Nick,
                email = ud.Email,
                data_birth = Convert.ToDateTime(ud.DateBirth),
                password = ud.Password,
                pass_repeat = ud.PassRepeat
            });
        }

        private void logBt_Click(object sender, RoutedEventArgs e)
        {
            Login logWindow = new Login();
            logWindow.WindowState = WindowState.Maximized;
            logWindow.Show();
            this.Close();
        }

        private void Register_Initialized(object sender, EventArgs e)
        {
            Register.WindowState = WindowState.Maximized;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool Validation(UserData ud)
        {
            if(ud.Name == nameTxt.Text||ud.Surname == surnameTxt.Text||ud.Nick == nickTxt.Text||ud.Email == emailTxt.Text||ud.DateBirth == dataBox.Text||ud.Password == passbox.Password||ud.PassRepeat == rPassbox.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        private bool NotEmpty(UserData ud)
        {
            if (ud.Name !=string.Empty||ud.Surname!= string.Empty || ud.Nick!= string.Empty || ud.Email!= string.Empty || ud.DateBirth!= string.Empty || ud.PassRepeat!= string.Empty || ud.PassRepeat!= string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetupData(UserData ud)
        {
            ud.Name = nameTxt.Text;
            ud.Surname = surnameTxt.Text;
            ud.Nick = nickTxt.Text;
            ud.Email = emailTxt.Text;
            ud.Password = passbox.Password;
            ud.PassRepeat = rPassbox.Password;
            ud.DateBirth = dataBox.Text;
            ud.TypeAccount = accountSelect.Text;
        }

        private void DownloadData(UserData ud)
        {
            ProfileData.Name = ud.Nick;
            ProfileData.Account = ud.TypeAccount;
            SaveData sd = new SaveData();
            sd.DataToSave(ud, "registerData.xml");
        }
        
    } 
}
