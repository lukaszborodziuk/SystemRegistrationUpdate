using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRegistration.DataClass
{
    class MessagesData
    {
        private string _msgdata;
        private string _msgvalid;
        private string _logvalid;

        public string MsgEmpty
        {
            get
            {
                return _msgdata = "Please Complete the data";
            }
            set
            {
                if (value != null)
                {
                    _msgdata = value;
                }
               
            }
        }
        public string MsgValidEmail
        {
            get
            {
                return _msgvalid = "It's not address email";
            }
            set
            {
                if (value != null)
                {
                    _msgvalid = value;
                }
            }
        }
        public string LoginValid
        {
            get
            {
                return _logvalid = "Login or password is incorrect";
            }
            set
            {
                if (value != null)
                {
                    _logvalid = value;
                }
            }
        }
    }
}
