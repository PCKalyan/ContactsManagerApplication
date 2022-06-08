using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ContactsManagerApplication
{
    internal class StateBO
    {
        public void InsertState(State objState)
        {
            objState.Validate();
            StateDB.ManageState(objState, ActionType.Add);
        }
        public void InsertState(int fkcountryid,string stateName, bool isactive)
        {
            State objState = new State(fkcountryid,stateName, isactive);
            InsertState(objState);
        }
        public void UpdateState(State objState)
        {
            objState.Validate();
            StateDB.ManageState(objState, ActionType.Modify);
        }
        public void UpdateState(int pkstateId,int fkCountryId, string stateName, bool isActive)
        {
            State objState = new State(pkstateId,stateName, isActive);
            UpdateState(objState);
        }
        public void DeleteState(int StateId)
        {
            State objState = new State() { PKStateId = StateId };
            StateDB.ManageState(objState, ActionType.Delete);
        }
        public DataSet GetAllStates()
        {
            return StateDB.GetAllStates();
        }
        public State GetStateDetails(int StateId)
        {
            State objState = StateDB.GetStateDetails(StateId);
            return objState;
        }
    }
}
