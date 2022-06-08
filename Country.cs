using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerApplication
{
    internal class Country
    {

        public Country()
        {
        }
        public Country(int pckcountryId, string countryName, long zipCodeStart, long zipCodeEnd, bool isActive)
        : this(countryName, zipCodeStart, zipCodeEnd, isActive)
        {
            PKCountryId = pckcountryId;
        }
        public Country(string countryName, long zipCodeStart, long zipCodeEnd, bool isActive)

        {
            this.CountryName = countryName;
            this.ZipCodeStart = zipCodeStart;
            this.ZipCodeEnd = zipCodeEnd;
            this.IsActive = isActive;
        }
        private string _validation = "";
        public void Validate()
        {
            if (!string.IsNullOrEmpty(_validation))
                throw new ApplicationException(_validation);
        }
        
        public int PKCountryId
        { get; set; }
        private string _CountryName;
        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }
        private long _ZipCodeStart;
        public long ZipCodeStart
        {
            get
            {
                return _ZipCodeStart;
            }
            set
            {
                _ZipCodeStart = value;
            }
        }
        private long _ZipCodeEnd;
        public long ZipCodeEnd
        {
            get
            {
                return _ZipCodeEnd;
            }
            set
            {
                _ZipCodeEnd = value;
            }
        }
        private bool _IsActive;

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

    }
}
