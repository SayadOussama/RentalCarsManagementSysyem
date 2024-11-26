using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.Clients.Controls
{
    public partial class ctrlFindClientInfo : UserControl

    { 
            // Define a custom event handler delegate with parameters
            public event Action<int> onClientSelected;
            // Create a protected method to raise the event with a parameter
            protected virtual void ClientSelected(int ClientID)
            {
                Action<int> handler = onClientSelected;
                if (handler != null)
                {
                    handler(ClientID); // Raise the event with the parameter
                }
            }
            private bool _gbFilterEnabled = true;
            public bool FilterEnabled
            {
                get { return _gbFilterEnabled; }
                set
                {
                    value = _gbFilterEnabled;
                    gbFilters.Enabled = value;
                }
            }
            int _ClientID = -1;
            public int ClientID
            {
                get { return _ClientID; }
            }
            clsClients _ClinetInfo;
            clsPerson _PersonID;
            public clsClients ClinetInfo { get { return _ClinetInfo; } }
            public ctrlFindClientInfo()
            {
                InitializeComponent();
            }
        private void FindNow()
        {
            //Way 1 :
            //If the You Load Data = send Data By prameters
            switch (cbFilterBy.Text)
            {
                case "Client ID":
                    FillClientSection(int.Parse(txtFilterValue.Text));

                    break;

                case "Person ID":

                    FillClientSection(int.Parse(txtFilterValue.Text));
                    break;

                default:
                    break;
            }
            //Way 2 :
            //Notes:
            // If the User Want To Use THe Control From the Form 


            if (onClientSelected != null && FilterEnabled)
                // Raise the event with a parameter
                onClientSelected(this.ClientID);
        }
        void FillClientSection(int ID)
        {

            switch (cbFilterBy.Text)
            {
                case "Client ID":
                    {
                        _ClinetInfo = clsClients.GetClientInfoByClientID(ID);

                        if (_ClinetInfo == null)
                        {
                            MessageBox.Show("Client Not Exist  with  ID " + ID, "Client Not Exist ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctrlPersonCard1.LoadPersonInfo(_ClinetInfo.PersonID);
                        break;

                    }
                case "Person ID":
                    {
                        _ClinetInfo = clsClients.GetClientInfoByPersonID(ID);
                        if (_ClinetInfo == null)
                        {
                            MessageBox.Show("Client Not Exist  with  ID " + ID, "Client Not Exist ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));



                        break;
                    }
                default:
                    break;
            }

            lblClintID.Text = _ClinetInfo.ClientID.ToString();
            lblVehicalLicensenNum.Text = _ClinetInfo.VehicalLicenseNumber.ToString();
            lblExpirationLicenseDate.Text = _ClinetInfo.LicenseExpirationDate.ToShortDateString();






        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                //that Mean Press ENTER in Key Board
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Client ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlFindClientInfo_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
            btnAddNewAccount.Enabled = true;
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }
        public void LoadAccountInfoClientID(int ClientID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ClientID.ToString();
            FillClientSection(ClientID);

        }
        public void LoadAccountInfoByPersonID(int PersonID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 2;
            txtFilterValue.Text = PersonID.ToString();
            FillClientSection(PersonID);

        }

        private void llblEditClientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtFilterValue.Text == string.Empty.Trim())
            {
                MessageBox.Show("Should Select Client ID First", "Select Client Id ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmAddNewUpdateClient frm = new frmAddNewUpdateClient(_ClinetInfo.ClientID);
                frm.ShowDialog();
                FillClientSection(_ClinetInfo.ClientID);
            }
        }
        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateClient frm = new frmAddNewUpdateClient();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
        private void DataBackEvent(object sender, int ClientID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ClientID.ToString();
            FillClientSection(ClientID);
        }
    }
    }
