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
    public partial class UserDialogue : Form
    {
        public UserDialogue()
        {
            InitializeComponent();
        }
        public string Username
        {
            get
            {
                return textUsername.Text;
            }
            set
            {
                textUsername.Text = value;
            }
        }
        public string EmailId
        {
            get
            {
                return textEmailid.Text;
            }
            set
            {
                textEmailid.Text = value;
            }
        }
        public string LastName
        {
            get
            {
                return textLastname.Text;
            }
            set
            {
                textLastname.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return textPassword.Text;
            }
            set
            {
                textPassword.Text = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return textPhonenumber.Text;
            }
            set
            {
                textPhonenumber.Text = value;
            }
        }
        public string FristName
        {
            get
            {
                return textFristname.Text;
            }
            set
            {
                textFristname.Text = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return chbisactive.Checked;
            }
            set
            {
                chbisactive.Checked = value;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
