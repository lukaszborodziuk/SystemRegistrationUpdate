using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using SystemRegistration.Model;
using SystemRegistration.DataClass;

namespace SystemRegistration
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void logBt_Click(object sender, RoutedEventArgs e)
        {
            UserData userData = new UserData();
            MessagesData messagesData = new MessagesData();
            SetupData(userData);

            using (registerDbEntities db = new registerDbEntities())
            {
                if (NotEmpty(userData))
                {
                    if (LoginValid(userData , db))
                    {
                        OpenProfile();
                    }
                    else
                    {
                        msg.Content = messagesData.LoginValid;  
                    }
                }
                else
                {
                    msg.Content = messagesData.MsgEmpty;
                }
            }
        }

        private void SetupData(UserData userData)
        {
            userData.Nick = nickTxt.Text;
            userData.Password = passTxt.Password;
            ProfileData.Name = nickTxt.Text;
        }

        private void OpenProfile()
        {
            Profile winProfile = new Profile();
            winProfile.WindowState = WindowState.Maximized;
            winProfile.Show();
            this.Close();
        }

        private bool NotEmpty(UserData userData)
        {
            if (userData.Nick !="" && userData.Password !="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool LoginValid(UserData userData , registerDbEntities db)
        {
            var User = db.Users.FirstOrDefault(u => u.nick.Equals(userData.Nick));

            if (User != null)
            {
                if (userData.Nick == User.nick && userData.Password == User.password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }  
        }
    }
}