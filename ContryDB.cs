using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerApplication
{
    internal class ContryDB
    {

        public static void ManageCountry(Country objCountryData, ActionType action)
        {
            string spName = "spManageCountry";
            SqlParameter pActionType = new SqlParameter("@ActionType", SqlDbType.TinyInt);
            SqlParameter pCountryId = new SqlParameter("@PKCountryId", SqlDbType.Int);
            SqlParameter pCountryName = new SqlParameter("@CountryName", SqlDbType.VarChar, 50);
            SqlParameter pZipCodeStart = new SqlParameter("@ZipCodeStart", SqlDbType.Int);
            SqlParameter pZipCodeEnd = new SqlParameter("@ZipCodeEnd", SqlDbType.Int);
            SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit);
            pActionType.Value = action;
            if (action == ActionType.Add)
                pCountryId.Direction = ParameterDirection.Output;
            else
                pCountryId.Direction = ParameterDirection.Input;
                pCountryId.Value = objCountryData.PKCountryId;
            if ((action == ActionType.Add) || (action == ActionType.Modify))
            {
                pCountryName.Value = objCountryData.CountryName;
                pZipCodeStart.Value = objCountryData.ZipCodeStart;
                pZipCodeEnd.Value = objCountryData.ZipCodeEnd;
                pIsActive.Value = objCountryData.IsActive;
            }
            SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.StoredProcedure, spName,pActionType, pCountryId, pCountryName, pZipCodeStart, pZipCodeEnd, pIsActive);
            if (action == ActionType.Add)
                objCountryData.PKCountryId = Convert.ToInt32(pCountryId.Value);
        }
        public static DataSet GetAllCountries()
        {
    
            string spName = "spGetAllCountries";
            SqlParameter pCountryId = new SqlParameter("@CountryId", SqlDbType.Int);
            pCountryId.Value = -1;
            DataSet ds = SqlHelper.ExecuteDataset(Helper.ConnectionString, CommandType.StoredProcedure,spName, pCountryId);
            ds.Tables[0].TableName = "Country";
            return ds;
        }
       
        public static Country GetCountyDetails(int pkID)
        {
            string spName = "spGetAllCountries";
            SqlParameter pCountryId = new SqlParameter("@CountryId", SqlDbType.Int);
            pCountryId.Value = pkID;
            SqlDataReader drRow = SqlHelper.ExecuteReader(Helper.ConnectionString,CommandType.StoredProcedure, spName, pCountryId);
            Country objCountry = null;
            if (drRow.HasRows)
            {
                drRow.Read();
                int id = drRow.GetInt32(drRow.GetOrdinal("PKCountryId"));
                string name = drRow.GetString(drRow.GetOrdinal("CountryName"));
                long CodeStart = drRow.GetInt64(drRow.GetOrdinal("ZipCodeStart"));
                long CodeEnd = drRow.GetInt64(drRow.GetOrdinal("ZipCodeEnd"));
                bool isActive = drRow.GetBoolean(drRow.GetOrdinal("IsActive"));
                objCountry = new Country(id, name, CodeStart, CodeEnd, isActive);
            }
            drRow.Close();
            return objCountry;
        }

    }
}

