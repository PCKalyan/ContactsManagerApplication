using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerApplication
{
    internal class State
    {

        public State()
        {
        }
        public State(int pkstateId, int fkCountryId, string stateName, bool isActive)
        : this(fkCountryId, stateName, isActive)
        {
            PKStateId = pkstateId;
        }
        public State(int fkCountryId, string StateName, bool isActive)
        {
            this.FKCountryId = fkCountryId;
            this.StateName = StateName;
            this.IsActive = isActive;
        }
        private string _validation = "";
        public void Validate()
        {
            if (!string.IsNullOrEmpty(_validation))
                throw new ApplicationException(_validation);
        }
        public int FKCountryId
        {
        get;set;
        }
        public int PKStateId
        { get; set; }
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
        private string _StateName;
        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
    }
}
