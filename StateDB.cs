using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ContactsManagerApplication
{
    internal class StateDB
    {
        public static void ManageState(State objStateData, ActionType action)
        {
            string spName = "spManageState";
            SqlParameter pActionType = new SqlParameter("@ActionType", SqlDbType.TinyInt);
            SqlParameter pStateId = new SqlParameter("@PKStateId", SqlDbType.Int);
            SqlParameter pfkCountryId = new SqlParameter("@FKCountryId", SqlDbType.Int);
            SqlParameter pStateName = new SqlParameter("@StateName", SqlDbType.VarChar, 50);
            SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit);

            pActionType.Value = action;
            if (action == ActionType.Add)
                pStateId.Direction = ParameterDirection.Output;
            else
                pStateId.Direction = ParameterDirection.Input;
            pStateId.Value = objStateData.PKStateId;
            if ((action == ActionType.Add) || (action == ActionType.Modify))
            {
                pStateName.Value = objStateData.StateName;
                pIsActive.Value = objStateData.IsActive;
                pfkCountryId.Value = objStateData.FKCountryId;
            }
            SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.StoredProcedure, spName, pActionType, pStateId, pfkCountryId, pStateName, pIsActive);
            if (action == ActionType.Add)
                objStateData.PKStateId = Convert.ToInt32(pStateId.Value);
        }
        public static DataSet GetAllStates()
        {
            string spName = "spGetAllStates";
            SqlParameter pStateId = new SqlParameter("@StateId", SqlDbType.Int);
            pStateId.Value = -1;
            DataSet ds = SqlHelper.ExecuteDataset(Helper.ConnectionString, CommandType.StoredProcedure, spName, pStateId);
            ds.Tables[0].TableName = "State";
            return ds;
        }
        public static State GetStateDetails(int pkID)
        {
            string spName = "spGetAllStates";
            SqlParameter pStateId = new SqlParameter("@StateId", SqlDbType.Int);
            pStateId.Value = pkID;
            SqlDataReader drRow = SqlHelper.ExecuteReader(Helper.ConnectionString, CommandType.StoredProcedure, spName, pStateId);
            State objState = null;
            if (drRow.HasRows)
            {
                drRow.Read();
                int id = drRow.GetInt32(drRow.GetOrdinal("PKStateId"));
                string name = drRow.GetString(drRow.GetOrdinal("StateName"));
                bool isActive = drRow.GetBoolean(drRow.GetOrdinal("IsActive"));
                objState = new State(id, name, isActive);
            }
            drRow.Close();
            return objState;
        }
        private List<string> str;
        public List<string> GetList()
        {
            return str;
        }
        public void GetChbCountryName()
        {
            SqlConnection conn = new SqlConnection(Helper.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * From Country";
            conn.Open();
            SqlDataReader dr = command.ExecuteReader();
            str = new List<string>();
            int CN = dr.GetOrdinal("CountryName");
            while (dr.Read())
            {
                str.Add(dr.GetString(CN));
            }
            dr.Close();
            conn.Close();
        }
        public int GetFKCountryId(string CountryName)
        {
            string spName = "spGetCountryIdByitsName";
            SqlParameter pCountry = new SqlParameter("@Countryname", SqlDbType.VarChar, 50);
            pCountry.Value = CountryName;
            SqlDataReader drRow = SqlHelper.ExecuteReader(Helper.ConnectionString, CommandType.StoredProcedure, spName, pCountry);
            drRow.Read();
            int FKCountryId = drRow.GetInt32(drRow.GetOrdinal("PKCountryId"));
            return FKCountryId;
        }
    }
}
