using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerApplication
{
    internal class User
    {
        public User()
        {
        }
        public User(int pkuserId, string userName,String password,String fristName,String lastName,String emailId,String phoneNo, bool isActive)
        : this(userName, password, fristName, lastName, emailId, phoneNo, isActive)
        {
            PKUserId = pkuserId;
        }
        public User(string userName, String password, String fristName, String lastName, String emailId, String phoneNo, bool isActive)

        {
            this.UserName = userName;
            this.Password = password;
            this.FristName = fristName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
            this.IsActive = isActive;
        }
        private string _validation = "";
        public void Validate()
        {
            if (!string.IsNullOrEmpty(_validation))
                throw new ApplicationException(_validation);
        }

        public int PKUserId
        { get; set; }
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        private string _fristName;
        public string FristName
        {
            get
            {
                return _fristName;
            }
            set
            {
                _fristName = value;
            }
        }
        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        private string _emailId;
        public string EmailId
        {
            get
            {
                return _emailId;
            }
            set
            {
                _emailId = value;
            }
        }
        private string _phoneNo;
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                _phoneNo = value;
            }
        }
        private bool _isActive;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

    }
}
