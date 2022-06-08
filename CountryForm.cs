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
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
        }
        CountryBO objcountrybo=new CountryBO();
        private void BindDatatoGrid()
        {
            DataSet ds = objcountrybo.GetAllCountries();
            DataTable dt = ds.Tables["Country"];
            gvCountry.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gvCountry.ReadOnly = true;
            gvCountry.AllowUserToAddRows = false;
            gvCountry.AllowUserToDeleteRows = false;
            gvCountry.AutoGenerateColumns = false;
            gvCountry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvCountry.MultiSelect = false;
            BindDatatoGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CountryDialogue dlgCountry = new CountryDialogue();
            if (dlgCountry.ShowDialog() == DialogResult.OK)
            {
                Country country = new Country(dlgCountry.CountryName, dlgCountry.ZipCodeStart, dlgCountry.ZipCodeEnd, dlgCountry.IsActive);
                objcountrybo.InsertCountry(country);
                BindDatatoGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvCountry.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Country to be edited");
                return;
            }
            int CountryId = (int)gvCountry.SelectedRows[0].Cells[0].Value;
            Country objCountry = objcountrybo.GetCountyDetails(CountryId);
            CountryDialogue dlgCountry = new CountryDialogue();
            dlgCountry.CountryName = objCountry.CountryName;
            dlgCountry.ZipCodeStart = objCountry.ZipCodeStart;
            dlgCountry.ZipCodeEnd = objCountry.ZipCodeEnd;
            dlgCountry.IsActive = objCountry.IsActive;
            if (dlgCountry.ShowDialog() == DialogResult.OK)
            {
                objCountry.CountryName = dlgCountry.CountryName;
                objCountry.ZipCodeStart = dlgCountry.ZipCodeStart;
                objCountry.ZipCodeEnd = dlgCountry.ZipCodeEnd;
                objCountry.IsActive = dlgCountry.IsActive;
                objcountrybo.UpdateCountry(objCountry);
                BindDatatoGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure", "Delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvCountry.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Country to be deleted");
                    return;
                }
                int CountryId = (int)gvCountry.SelectedRows[0].Cells[0].Value;
                objcountrybo.DeleteCountry(CountryId);
                BindDatatoGrid();
            }
        }
    }
}
