using BusinessLayer;
using RentalCars.GlobalClasses;
using RentalCars.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.Clients
{
    public partial class frmAddNewUpdateClient : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        clsPerson _Person;
        clsClients _Client;
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enGender { Male = 0, Female = 1 }
        public enMode Mode = enMode.AddNew;
        int _PersonID = -1;

        int _ClientID = -1;
        public frmAddNewUpdateClient()
        {
            InitializeComponent();
        }
        public frmAddNewUpdateClient(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
            Mode = enMode.Update;
        }
        private void _FillContriesInComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            foreach (DataRow Row in dtCountries.Rows)
            {

                cbCountry.Items.Add(Row["CountryName"]);
            }
        }
        private void _ResetDefaultValue()
        {

            _FillContriesInComboBox();

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Subscriber";

                _Person = new clsPerson();
                _Client = new clsClients();

            }
            else
            {
                lblTitle.Text = "Update Subscriber";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtVehicalLicenseNumber.Text = "";
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-16);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            dtpLicenseExpirationDate.MinDate = DateTime.Now;
            dtpLicenseExpirationDate.Value = DateTime.Now;
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);



        }
        private void _LoadData()
        {
            _Client = clsClients.GetClientInfoByClientID(_ClientID);

            if (_Client == null)
            {
                MessageBox.Show("the Account ID you Choosing " + _ClientID + " Is Not Find ");
                this.Close();
                return;
            }
            _Person = clsPerson.GetPersonInfoByPersonID(_Client.PersonID);
            txtFirstName.Text = _Client._PersonInfo.FirstName;
            txtLastName.Text = _Client._PersonInfo.LastName;
            txtNationalNo.Text = _Client._PersonInfo.NationalNO;
            txtEmail.Text = _Client._PersonInfo.Email;
            txtAddress.Text = _Client._PersonInfo.address;
            txtPhone.Text = _Client._PersonInfo.PhoneNumber;
            dtpDateOfBirth.Value = _Client._PersonInfo.BirthDay;
            if (_Client._PersonInfo.Gender == 0)
                rbMale.Enabled = true;
            else
            {
                rbFemale.Checked = true;

            }
            cbCountry.SelectedIndex = cbCountry.FindString(_Client._PersonInfo._CountryInfo.CountryName);

            if (_Client._PersonInfo.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _Client._PersonInfo.ImagePath;
            }
            llRemoveImage.Visible = (_Client._PersonInfo.ImagePath != null);

            lblClintID.Text = _Client.ClientID.ToString();
            txtVehicalLicenseNumber.Text = _Client.VehicalLicenseNumber.ToString();

            dtpLicenseExpirationDate.Value = _Client.LicenseExpirationDate;



        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void validateEmptyTextBox(object sender, CancelEventArgs e)
        {
            //will appling for all Text box we Have in this from 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //if txt is Empty
            if (txtEmail.Text.Trim() == "")
                return;

            //get validation 
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            //Make Sure NationalNo Not Use it 
            //if we are in Update Mode               if we are in add  New Mode will Check is have person with National No
            if (txtNationalNo.Text.Trim() != _Person.NationalNO && clsPerson.IsPersonExistByNationalNo(txtNationalNo.Text.Trim()))

            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National No Is Allready Exist ");
            }
            else
            {

                errorProvider1.SetError(txtNationalNo, null);
            }
        }
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                //Delete Process
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        //Colud Not  the File  Delete
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    //will Change ImageLcationName to GUID and copy to Directory 
                    if (Util.CreateFolderIfDoesNotExist(ref SourceImageFile))
                    {
                        //replace the current image name = to new Name with Guid 
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Error Copy Image File ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            // if image source  == Image Path or Is Null
            return true;
        }

        private void frmAddNewUpdateClient_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed Are Not Valide ! Put the Mous in the Red Icon(s) to see the error notice ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;
            int CountryID = clsCountries.FindCountryInfoByCountryName(cbCountry.Text).CountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNO = txtNationalNo.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.address = txtAddress.Text.Trim();
            _Person.BirthDay = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _Person.Gender = (byte)enGender.Male;
            else
                _Person.Gender = (byte)enGender.Female;
            _Person.NationalCountryID = CountryID;
            if (_Person.Save())
            {

                _Client.PersonID = _Person.PersonID;

            }
            if (dtpLicenseExpirationDate.Value <= DateTime.Now)
            {
                MessageBox.Show("License Expiration Date Is AllRready Expired Please ReNew Your Vichcal License", "License Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Client.LicenseExpirationDate = dtpLicenseExpirationDate.Value;
            _Client.VehicalLicenseNumber = int.Parse(txtVehicalLicenseNumber.Text.Trim());
            _Client.AccountCreationDate = DateTime.Now;
            _Client.CreatedByUserID = 5;
            if (_Client.Save())
                if (Mode == enMode.AddNew)
                {
                    DataBack?.Invoke(this, _Client.ClientID);
                    MessageBox.Show("New Client  Added Successfuly with ClientID " + _Client.ClientID, "Added New Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Update Client Successfuly with ClientID " + _Client.ClientID, "Update Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblClintID.Text = _Client.ClientID.ToString();
            lblPersonID.Text = _Client.PersonID.ToString();

            lblTitle.Text = "Update Client";
        }

        private void txtVehicalLicenseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
