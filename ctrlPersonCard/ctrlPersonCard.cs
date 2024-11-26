using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ctrlPersonCard.Properties;
using BusinessLayer;
using System.IO;

namespace ctrlPersonCard
{
    public partial class ctrlPersonCard: UserControl
    {
        private clsPerson  _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }

        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.GetPersonInfoByPersonID(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No person With PersonID " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.GetPersonInfoByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No person With NationalNo " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[?????]";
            lblNationalNo.Text = "[?????]";
            lblFullName.Text = "[?????]";
            lblGendor.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblAddress.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblCountry.Text = "[?????]";
            pbPersonImage.Image = Resources.ctrlMale_512;

        }
        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNO;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.PhoneNumber;
            lblGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _Person.BirthDay.ToShortDateString();
            lblCountry.Text = _Person._CountryInfo.CountryName;
            lblAddress.Text = _Person.address;
            _LoadPersonImage();


        }
        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pbPersonImage.Image = Resources.ctrlMale_512;

            else
                pbPersonImage.Image = Resources.ctrlFemale_512;

            if (_Person.ImagePath != "")
            {
                string ImagePath = _Person.ImagePath;
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
