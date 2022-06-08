using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ContactsManagerApplication
{
    internal class UserBO
    {

        public void InsertUser(User objUser)
        {
            objUser.Validate();
            UserDB.ManageUser(objUser, ActionType.Add);
        }
        public void InsertUser(string userName, String password, String fristName, String lastName, String emailId, String phoneNo, bool isActive)
        {
            User objUser = new User(userName, password, fristName, lastName, emailId, phoneNo, isActive);
            InsertUser(objUser);
        }
        public void UpdateUser(User objUser)
        {
            objUser.Validate();
            UserDB.ManageUser(objUser, ActionType.Modify);
        }
        public void UpdateUser(int pkuserId, string userName, String password, String fristName, String lastName, String emailId, String phoneNo, bool isActive)
        {
            User objUser = new User(pkuserId, userName, password, fristName, lastName, emailId, phoneNo, isActive);
            UpdateUser(objUser);
        }
        public void DeleteUser(int UserId)
        {
            User objUser = new User() { PKUserId = UserId };
            UserDB.ManageUser(objUser, ActionType.Delete);
        }
        public DataSet GetAllUsers()
        {
            return UserDB.GetAllUsers();
        }
        public User GetUserDetails(int UserId)
        {
            User objUser = UserDB.GetUserDetails(UserId);
            return objUser;
        }

    }
}
