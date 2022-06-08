using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ContactsManagerApplication
{
    internal class UserDB
    {
        public static void ManageUser(User objUserData, ActionType action)
        {
            string spName = "spManageUser";
            SqlParameter pActionType = new SqlParameter("@ActionType", SqlDbType.TinyInt);
            SqlParameter pPKUserId = new SqlParameter("@PKUserId", SqlDbType.Int);
            SqlParameter pUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            SqlParameter pFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
            SqlParameter pLastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
            SqlParameter pEmailId = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
            SqlParameter pPhoneNo = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 50);
            SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit);
            pActionType.Value = action;
            if (action == ActionType.Add)
                pPKUserId.Direction = ParameterDirection.Output;
            else
                pPKUserId.Direction = ParameterDirection.Input;
                pPKUserId.Value = objUserData.PKUserId;
            if ((action == ActionType.Add) || (action == ActionType.Modify))
            {
                pUserName.Value = objUserData.UserName;
                pPassword.Value = objUserData.Password;
                pFirstName.Value = objUserData.FristName;
                pLastName.Value = objUserData.LastName;
                pEmailId.Value = objUserData.EmailId;
                pPhoneNo.Value = objUserData.PhoneNo;
                pIsActive.Value = objUserData.IsActive;
            }
            SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.StoredProcedure, spName, pActionType, pPKUserId, pUserName, pPassword, pFirstName, pLastName, pEmailId, pPhoneNo,pIsActive);
            if (action == ActionType.Add)
                objUserData.PKUserId = Convert.ToInt32(pPKUserId.Value);
        }
        public static DataSet GetAllUsers()
        {

            string spName = "spGetAllUsers";
            SqlParameter pPKUserId = new SqlParameter("@UserId", SqlDbType.Int);
            pPKUserId.Value = -1;
            DataSet ds = SqlHelper.ExecuteDataset(Helper.ConnectionString, CommandType.StoredProcedure, spName, pPKUserId);
            ds.Tables[0].TableName = "Userdetails";
            return ds;
        }

        public static User GetUserDetails(int pkID)
        {
            string spName = "spGetAllUsers";
            SqlParameter pPKUserId = new SqlParameter("@UserId", SqlDbType.Int);
            pPKUserId.Value = pkID;
            SqlDataReader drRow = SqlHelper.ExecuteReader(Helper.ConnectionString, CommandType.StoredProcedure, spName, pPKUserId);
            User objuser = null;
            if (drRow.HasRows)
            {
                drRow.Read();
                int id = drRow.GetInt32(drRow.GetOrdinal("PKUserId"));
                string UserName = drRow.GetString(drRow.GetOrdinal("UserName"));
                string Password = drRow.GetString(drRow.GetOrdinal("Password"));
                string FirstName = drRow.GetString(drRow.GetOrdinal("FirstName"));
                string LastName = drRow.GetString(drRow.GetOrdinal("LastName"));
                string EmailId = drRow.GetString(drRow.GetOrdinal("EmailId"));
                string PhoneNo = drRow.GetString(drRow.GetOrdinal("PhoneNo"));
                bool isActive = drRow.GetBoolean(drRow.GetOrdinal("IsActive"));
                objuser = new User(id, UserName, Password, FirstName,LastName, EmailId, PhoneNo, isActive);
            }
            drRow.Close();
            return objuser;
        }
    }
}
