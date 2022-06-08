using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace ContactsManagerApplication
{
    internal class CountryBO
    {
        public void InsertCountry(Country objCountry)
        {
            objCountry.Validate();
            ContryDB.ManageCountry(objCountry, ActionType.Add);
        }
        public void InsertCountry(string countryName, long zipCodeState, long zipCodeEnd, bool isActive)
        {
            Country objCountry = new Country(countryName, zipCodeState, zipCodeEnd, isActive);
            InsertCountry(objCountry);
        }
        public void UpdateCountry(Country objCountry)
        {
            objCountry.Validate();
            ContryDB.ManageCountry(objCountry, ActionType.Modify);
        }
        public void UpdateCountry(int PkCountryId, string countryName, long zipCodeState, long zipCodeEnd, bool isActive)
        {
            Country objCountry = new Country(PkCountryId, countryName, zipCodeState, zipCodeEnd, isActive);
            UpdateCountry(objCountry);
        }
        public void DeleteCountry(int countryId)
        {
            Country objCountry = new Country() { PKCountryId = countryId };
            ContryDB.ManageCountry(objCountry, ActionType.Delete);
        }
        public DataSet GetAllCountries()
        {
            return ContryDB.GetAllCountries();
        }
        public Country GetCountyDetails(int countryId)
        {
            Country objCountry = ContryDB.GetCountyDetails(countryId);
            return objCountry;
        }
    }
}
