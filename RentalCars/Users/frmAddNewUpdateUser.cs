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

namespace RentalCars.Users
{
    public partial class frmAddNewUpdateUser : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 1, Update = 2 }
        public enum enGender { Male = 0, Female = 1 }
        private enMode Mode = enMode.AddNew;
        int _PersonID = -1;
        clsPerson _Person;
        clsUsers _User;
        int _UserID = -1;


        public frmAddNewUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddNewUpdateUser(int userID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _UserID = userID;
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
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
                _User = new clsUsers();
            }
            else
            {
                lblTitle.Text = "Update Person";
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
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            tpLoginInfo.Enabled = false;

        }
        private void _LoadData()
        {
            _User = clsUsers.GetFindUserInfoByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("the Person ID you Chooseing " + _PersonID + " Is Not Find ");
                this.Close();
                return;
            }

            _Person = clsPerson.GetPersonInfoByPersonID(_User.PersonID);

            txtFirstName.Text = _User._PersonInfo.FirstName;
            txtLastName.Text = _User._PersonInfo.LastName;
            txtNationalNo.Text = _User._PersonInfo.NationalNO;
            txtEmail.Text = _User._PersonInfo.Email;
            txtAddress.Text = _User._PersonInfo.address;
            txtPhone.Text = _User._PersonInfo.PhoneNumber;
            dtpDateOfBirth.Value = _User._PersonInfo.BirthDay;
            if (_User._PersonInfo.Gender == 0)
                rbMale.Enabled = true;
            else
                rbFemale.Enabled = true;
            cbCountry.SelectedIndex = cbCountry.FindString(_User._PersonInfo._CountryInfo.CountryName);

            if (_User._PersonInfo.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _User._PersonInfo.ImagePath;
            }
            llRemoveImage.Visible = (_User._PersonInfo.ImagePath != null);
            //Load User Info
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName.ToString();
            txtPassword.Text = _User.PassWord;
            txtConfirmPassword.Text = _User.PassWord;
            if (_User.IsActive)
                chkIsActive.Checked = true;
            else chkIsActive.Checked = false;

        }

        private void frmAddNewUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();


            if (Mode == enMode.Update)
                _LoadData();
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
                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
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

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                HandlePersonInfo();



                //show Login Info Tab

                return;
            }
            //in case is AddNew Mode 
            HandlePersonInfo();
        }
        void HandlePersonInfo()
        {

            if (!_HandlePersonImage())
                return;


            int CountryID = clsCountries.FindCountryInfoByCountryName(cbCountry.Text).CountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNO = txtNationalNo.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.address = txtAddress.Text.Trim();

            if (rbMale.Checked)
                _Person.Gender = (byte)enGender.Male;
            else
                _Person.Gender = (byte)enGender.Female;
            _Person.NationalCountryID = CountryID;
            _Person.BirthDay = dtpDateOfBirth.Value;
            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";
            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();

                if (Mode == enMode.AddNew)
                    MessageBox.Show("Person Added Successfully with ID :" + _Person.PersonID.ToString(), "Add Person Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Person Successfully with ID :" + _Person.PersonID.ToString(), "Update Person Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                btnSave.Enabled = true;
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
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

        private void Email_Validating(object sender, CancelEventArgs e)
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

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "UserName Field cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
            if ( Mode ==enMode.AddNew &&   clsUsers.IsUserExistByUserName(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "UserName All Ready Use it Try Another UserName ");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Field cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Field cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;


            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Must Be the Same");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.PersonID = _Person.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.PassWord = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                Mode = enMode.Update;
                lblTitle.Text = "Update User";


                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }
    }
}
