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
    public partial class CountryDialogue : Form
    {
        public CountryDialogue()
        {
            InitializeComponent();
        }
        public string CountryName
        {
            get
            {
                return textCountryName.Text;
            }
            set
            {
                textCountryName.Text = value;
            }
        }
        public long ZipCodeStart
        {
            get
            {
                return long.Parse(textZipCodeStart.Text);
            }
            set
            {
                textZipCodeStart.Text = value.ToString();
            }
        }
        public long ZipCodeEnd
        {
            get
            {
                return long.Parse(textZipCodeEnd.Text);
            }
            set
            {
                textZipCodeEnd.Text = value.ToString();
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
