using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ContactsManagerApplication
{
    public partial class StateFrom : Form
    {
        StateBO objStatebo=new StateBO();
        public StateFrom()
        {
            InitializeComponent();
        }
        private void BindDatatoGrid()
        {
            DataSet ds = objStatebo.GetAllStates();
            DataTable dt = ds.Tables["State"];
            gvState.DataSource = dt;
        }
        private void StateFrom_Load(object sender, EventArgs e)
        {
            gvState.ReadOnly = true;
            gvState.AllowUserToAddRows = false;
            gvState.AllowUserToDeleteRows = false;
            gvState.AutoGenerateColumns = false;
            gvState.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvState.MultiSelect = false;
            BindDatatoGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StateDialogue dlgState = new StateDialogue();
            if (dlgState.ShowDialog() == DialogResult.OK)
            {
                State state = new State(dlgState.FKCountryId,dlgState.StateName, dlgState.IsActive);
                objStatebo.InsertState(state);
                BindDatatoGrid();
            }
        }

        private void gvState_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvState.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a State to be edited");
                return;
            }

            int StateId = (int)gvState.SelectedRows[0].Cells[0].Value;
            State objState = objStatebo.GetStateDetails(StateId);
            StateDialogue dlgState = new StateDialogue();
            dlgState.StateName = objState.StateName;
            dlgState.FKCountryId = objState.FKCountryId;  
            dlgState.IsActive = objState.IsActive;
            if (dlgState.ShowDialog() == DialogResult.OK)
            {
                objState.PKStateId = StateId;
                objState.StateName = dlgState.StateName;
                objState.FKCountryId = dlgState.FKCountryId;
                objState.IsActive = dlgState.IsActive;
                objStatebo.UpdateState(objState);
                BindDatatoGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure", "Delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvState.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a State to be deleted");
                    return;
                }
                int StateId = (int)gvState.SelectedRows[0].Cells[0].Value;
                objStatebo.DeleteState(StateId);
                BindDatatoGrid();
            }
        }
    }
}
