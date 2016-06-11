using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace SystemRegistration
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;

            if (File.Exists("registerData.xml"))
            {
                UserData ud = ReadUser();
                SetupProfile(ud);
            }
        }

        private static UserData ReadUser()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            FileStream stream = new FileStream("registerData.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            UserData ud = (UserData)serializer.Deserialize(stream);
            return ud;
        }

        private void SetupProfile(UserData ud)
        {
            nameRead.Text = ud.Name;
            accountRead.Text = ud.TypeAccount;
        }
    }
}
