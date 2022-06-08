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
    public partial class StateDialogue : Form
    {
        public StateDialogue()
        {
            InitializeComponent();
        }
        public string CountryName
        {
            get
            {
                return ChbCountries.Text;
            }
            set
            {
                ChbCountries.Text = value;
            }
        }
        public string StateName
        {
            get
            {
                return ChbStates.Text;
            }
            set
            {
                ChbStates.Text = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return chbIsactive.Checked;
            }
            set
            {
                chbIsactive.Checked = value;
            }
        }



        StateDB SDB = new StateDB();
        private void StateDialogue_Load(object sender, EventArgs e)
        {
            
            SDB.GetChbCountryName();
            List<string> CalledList = SDB.GetList();
            foreach(var item in CalledList)
            {
                ChbCountries.Items.Add(item);
            }
           

            
        }
        public int FKCountryId;
        
        private void ChbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

            FKCountryId = SDB.GetFKCountryId(ChbCountries.Text);


            switch (ChbCountries.Text)
            {
                case "India":
                    ChbStates.Items.Clear();
                    ChbStates.Items.Add("Andhra Pradesh");
                    ChbStates.Items.Add("Arunachal Pradesh");
                    ChbStates.Items.Add("Assam");
                    ChbStates.Items.Add("Bihar");
                    ChbStates.Items.Add("Chhattisgarh");
                    ChbStates.Items.Add("Goa");
                    ChbStates.Items.Add("Gujarat");
                    ChbStates.Items.Add("Haryana");
                    ChbStates.Items.Add("Himachal Pradesh");
                    ChbStates.Items.Add("Jharkhand");
                    ChbStates.Items.Add("Karnataka");
                    ChbStates.Items.Add("Kerala");
                    ChbStates.Items.Add("Madhya Pradesh");
                    ChbStates.Items.Add("Maharashtra");
                    ChbStates.Items.Add("Manipur");
                    ChbStates.Items.Add("Meghalaya");
                    ChbStates.Items.Add("Mizoram");
                    ChbStates.Items.Add("Nagaland");
                    ChbStates.Items.Add("Odisha");
                    ChbStates.Items.Add("Punjab");
                    ChbStates.Items.Add("Rajasthan");
                    ChbStates.Items.Add("Sikkim");
                    ChbStates.Items.Add("Tamil Nadu");
                    ChbStates.Items.Add("Telangana");
                    ChbStates.Items.Add("Tripura");
                    ChbStates.Items.Add("Uttar Pradesh");
                    ChbStates.Items.Add("Uttarakhand");
                    ChbStates.Items.Add("West Bengal");
                    break;
                case "America":
                    ChbStates.Items.Add("Alabama");
                    ChbStates.Items.Add("Alaska");
                    ChbStates.Items.Add("Arizona");
                    ChbStates.Items.Add("Arkansas");
                    ChbStates.Items.Add("California");
                    ChbStates.Items.Add("Colorado");
                    ChbStates.Items.Add("Connecticut");
                    ChbStates.Items.Add("Delaware");
                    ChbStates.Items.Add("Florida");
                    ChbStates.Items.Add("Georgia");
                    ChbStates.Items.Add("Hawaii");
                    ChbStates.Items.Add("Idaho");
                    ChbStates.Items.Add("Illinois");
                    ChbStates.Items.Add("Indiana");
                    ChbStates.Items.Add("Iowa");
                    ChbStates.Items.Add("Kansas");
                    ChbStates.Items.Add("Kentucky");
                    ChbStates.Items.Add("Louisiana");
                    ChbStates.Items.Add("Maine");
                    ChbStates.Items.Add("Maryland");
                    ChbStates.Items.Add("Massachusetts");
                    ChbStates.Items.Add("Michigan");
                    ChbStates.Items.Add("Minnesota");
                    ChbStates.Items.Add("Mississippi");
                    ChbStates.Items.Add("Missouri");
                    ChbStates.Items.Add("Montana");
                    ChbStates.Items.Add("Nebraska");
                    ChbStates.Items.Add("Nevada");
                    ChbStates.Items.Add("New Hampshire");
                    ChbStates.Items.Add("New Jersey");
                    ChbStates.Items.Add("New Mexico");
                    ChbStates.Items.Add("New York");
                    ChbStates.Items.Add("North Carolina");
                    ChbStates.Items.Add("North Dakota");
                    ChbStates.Items.Add("Ohio");
                    ChbStates.Items.Add("Oklahoma");
                    ChbStates.Items.Add("Oregon");
                    ChbStates.Items.Add("Pennsylvania");
                    ChbStates.Items.Add("Rhode Island");
                    ChbStates.Items.Add("South Carolina");
                    ChbStates.Items.Add("South Dakota");
                    ChbStates.Items.Add("Virginia");
                    ChbStates.Items.Add("Washington");
                    ChbStates.Items.Add("Wisconsin");
                    ChbStates.Items.Add("Wyoming");
                    break;
                case "Italy":
                    ChbStates.Items.Add("Vatican");
                    ChbStates.Items.Add("San Marino");
                    break;
                case "Germany":
                    ChbStates.Items.Add("Berlin");
                    ChbStates.Items.Add("Hamburg");
                    ChbStates.Items.Add("Bremen");
                    break;

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
