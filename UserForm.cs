using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsManagerApplication
{
    public partial class UserForm : Form
    {
        UserBO objUserbo = new UserBO();
        public UserForm()
        {
            InitializeComponent();
        }
        private void BindDatatoGrid()
        {
            DataSet ds = objUserbo.GetAllUsers();
            DataTable dt = ds.Tables["Userdetails"];
            gvUser.DataSource = dt;
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            gvUser.ReadOnly = true;
            gvUser.AllowUserToAddRows = false;
            gvUser.AllowUserToDeleteRows = false;
            gvUser.AutoGenerateColumns = false;
            gvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvUser.MultiSelect = false;
            BindDatatoGrid();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            UserDialogue dlguser = new UserDialogue();
            if (dlguser.ShowDialog() == DialogResult.OK)
            {
                
                User user = new User(dlguser.Username,dlguser.Password,dlguser.FristName,dlguser.LastName,dlguser.EmailId,dlguser.PhoneNo,dlguser.IsActive);
                objUserbo.InsertUser(user);
                BindDatatoGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (gvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Country to be edited");
                return;
            }
            int UserId = (int)gvUser.SelectedRows[0].Cells[0].Value;
            User objUser = objUserbo.GetUserDetails(UserId);
            UserDialogue dlgUser = new UserDialogue();
            dlgUser.Username = objUser.UserName;
            dlgUser.Password = objUser.Password;
            dlgUser.FristName = objUser.FristName;
            dlgUser.LastName = objUser.LastName;
            dlgUser.EmailId = objUser.EmailId;
            dlgUser.PhoneNo = objUser.PhoneNo;
            dlgUser.IsActive = objUser.IsActive;
            if (dlgUser.ShowDialog() == DialogResult.OK)
            {
                objUser.UserName = dlgUser.Username;
                objUser.Password = dlgUser.Password;
                objUser.FristName = dlgUser.FristName;
                objUser.LastName = dlgUser.LastName;
                objUser.EmailId = dlgUser.EmailId;
                objUser.PhoneNo = dlgUser.PhoneNo;
                objUser.IsActive = dlgUser.IsActive;
                objUserbo.UpdateUser(objUser);
                BindDatatoGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure", "Delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvUser.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a State to be deleted");
                    return;
                }
                int UserId = (int)gvUser.SelectedRows[0].Cells[0].Value;
                objUserbo.DeleteUser(UserId);
                BindDatatoGrid();
            }
        }
    }
}
