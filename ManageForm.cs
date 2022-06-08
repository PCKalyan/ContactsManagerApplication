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
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountryForm c=new CountryForm();
            c.ShowDialog();

        }

        private void stateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateFrom s = new StateFrom();
            s.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm u = new UserForm();
            u.ShowDialog();
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
