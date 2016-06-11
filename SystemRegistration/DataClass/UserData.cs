using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemRegistration.DataClass;
using SystemRegistration.Model;
using SystemRegistration.Properties;

namespace SystemRegistration
{
   public class UserData
    {
        private string _name, _surname, _nick, _email, _password, _pass_repeat, _datebirth, _typeaccount;
        private List<User> _users;

        public string Name
        {
            get {return _name;}
            set {_name = value;}
        }
        
        public string Surname
        {
            get {return _surname;}
            set {_surname = value;}
        }

        public string Nick
        {
            get {return _nick;}
            set {_nick = value;}
        }

        public string Email
        {
            get {return _email;}
            set {_email = value;}
        }
        public string Password
        {
            get {return _password;}
            set {_password = value;}
        }
        public string PassRepeat
        {
            get {return _pass_repeat;}
            set {_pass_repeat = value;}
        }

        public string DateBirth
        {
            get { return _datebirth; }
            set {_datebirth = value;}
        }

        public string TypeAccount
        {
            get {return _typeaccount;}
            set {_typeaccount = value;}
        }

        public List<User> Users
        {
            get {return _users;}
            set {_users = value;}
        }

        public static UserData userData = new UserData();

    }
}
