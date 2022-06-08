using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ContactsManagerApplication
{
    public partial class LoginFrom : Form
    {
        public LoginFrom()
        {
            InitializeComponent();
        }

        private void labelRegisterhere_Click(object sender, EventArgs e)
        {
            UserForm UF = new UserForm();
            UF.btnAdd_Click(sender,e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            string sql = string.Format($"select Password from Userdetails where UserName ='{textUsername.Text}'");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() && dr["Password"].ToString() == textPassword.Text)
            {
                MessageBox.Show("VERIFIED");
                ManageForm MF= new ManageForm();
                MF.Show();
                LoginFrom b = new LoginFrom();
                b.Hide();
            }
            else
            {
                MessageBox.Show("INVALID LOGIN CREDITIONALS");
            }
            con.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginFrom_Load(object sender, EventArgs e)
        {

        }
    }
    }
