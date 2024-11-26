using BusinessLayer;
using RentalCars.GlobalClasses;
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

namespace RentalCars.CarsContainer
{
    public partial class frmAddNewUpdateCar : Form
    {
        string _ColorString = "";
        clsCarTypes _CarType;
        clsCarsContainer _CarContainer;
        int _CarID = -1;
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int CarID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public frmAddNewUpdateCar()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddNewUpdateCar(int CarID)
        {
            InitializeComponent();
            _CarID = CarID;
            Mode = enMode.Update;
        }
        private void _FillCarType()
        {
            DataTable dtCarType = clsCarTypes.GetAllByCarType();
            foreach (DataRow Row in dtCarType.Rows)
            {

                cbCarType.Items.Add(Row["TypeName"]);
            }
        }
        private void _FillColors()
        {
            DataTable dtColors = clsColor.GetAllColors();
            foreach (DataRow Row in dtColors.Rows)
            {

                cbColor.Items.Add(Row["Color"]);
            }
        }
        private void _ResetDefaultValue()
        {
            _FillCarType();
            _FillColors();

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Car";
                _CarContainer = new clsCarsContainer();
                

            }
            else
            {
                lblTitle.Text = "Update Car ";

            }

            rbYas.Enabled = true;

            txtCarName.Text = "";
            txtCarModel.Text = "";
            txtCarDorrs.Text = "";
            txtEngineModel.Text = "";
            txtPlateNumber.Text = "";
            txtCurrentKLMT.Text = "";
            txtRentalCarPrice.Text = "";
            cbCarType.SelectedIndex = cbCarType.FindString("Sedan Cars");
            cbColor.SelectedIndex = cbColor.FindString("White");





        }
        void FillPanelColor(string colorselected)
        {
            switch (colorselected)
            {
                case "Red":
                    panel1.BackColor = Color.Red; break;
                case "Gray":
                    panel1.BackColor = Color.Gray; break;
                case "Blue":
                    panel1.BackColor = Color.Blue; break;
                case "Orange":
                    panel1.BackColor = Color.Orange; break;
                case "White":
                    panel1.BackColor = Color.White; break;
                case "Beige":
                    panel1.BackColor = Color.Beige; break;
                case "Purple":
                    panel1.BackColor = Color.Purple; break;
                case "Black":
                    panel1.BackColor = Color.Black; break;

            }

        }
        private void _LoadData()
        {
            _CarContainer = clsCarsContainer.GetCarInfoByCarID(_CarID);
            if (_CarContainer == null)
            {
                MessageBox.Show("Car Not Exist with This ID " + _CarID + " Is Not Find ");
                this.Close();
                return;
            }
            txtCarName.Text = _CarContainer.CarName;
            txtCarModel.Text = _CarContainer.CarModel;
            txtCurrentKLMT.Text = _CarContainer.CurrentKLMT.ToString();
            txtEngineModel.Text = _CarContainer.EngineModel;
            txtPlateNumber.Text = _CarContainer.CarPlateNumber;
            txtCarDorrs.Text = _CarContainer.DoorsNumber.ToString();
            txtRentalCarPrice.Text = _CarContainer.RentalCarPrice.ToString();
            cbColor.SelectedIndex = cbColor.FindString(_CarContainer.Color.Trim());
            FillPanelColor(_CarContainer.Color.Trim());
            cbCarType.SelectedIndex = cbCarType.FindString(_CarContainer._CarTypeInfo.TypeName.Trim());




            llRemoveImage.Visible = (pbCar.ImageLocation != null);

            if (_CarContainer.IsAvalible)
                rbYas.Checked = true;
            else
                rbNo.Enabled = true;


            if (_CarContainer.ImagePath != null)
            {
                pbCar.ImageLocation = _CarContainer.ImagePath;
            }
            llRemoveImage.Visible = (_CarContainer.ImagePath != null);




        }
        private void frmAddNewUpdateCar_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (Mode == enMode.Update)
                _LoadData();
        }
        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbColor.Text.Trim())
            {
                case "Red":
                    panel1.BackColor = Color.Red; break;
                case "Gray":
                    panel1.BackColor = Color.Gray; break;
                case "Blue":
                    panel1.BackColor = Color.Blue; break;
                case "Orange":
                    panel1.BackColor = Color.Orange; break;
                case "White":
                    panel1.BackColor = Color.White; break;
                case "Beige":
                    panel1.BackColor = Color.Beige; break;
                case "Purple":
                    panel1.BackColor = Color.Purple; break;
                case "Black":
                    panel1.BackColor = Color.Black; break;

            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbCar.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbCar.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void txtCurrentKLMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRentalCarPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCarDorrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private bool _HandlePersonImage()
        {
            if (_CarContainer.ImagePath != pbCar.ImageLocation)
            {
                //Delete Process
                if (_CarContainer.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_CarContainer.ImagePath);
                    }
                    catch (IOException)
                    {
                        //Colud Not  the File  Delete
                    }
                }
                if (pbCar.ImageLocation != null)
                {
                    string SourceImageFile = pbCar.ImageLocation.ToString();
                    //will Change ImageLcationName to GUID and copy to Directory 
                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        //replace the current image name = to new Name with Guid 
                        pbCar.ImageLocation = SourceImageFile;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed Are Not Valide ! Put the Mous in the Red Icon(s) to see the error notice ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;

            int CarType = clsCarTypes.GetCarTypeInfoByTypeName(cbCarType.Text.Trim()).CarTypeID;
            _CarContainer.CarName = txtCarName.Text;
            _CarContainer.CarType = CarType;
            _CarContainer.CarModel = txtCarModel.Text;
            _CarContainer.EngineModel = txtEngineModel.Text;
            _CarContainer.CarPlateNumber = txtPlateNumber.Text;
            _CarContainer.DoorsNumber = int.Parse(txtCarDorrs.Text);
            _CarContainer.RentalCarPrice = decimal.Parse(txtRentalCarPrice.Text);
            _CarContainer.CurrentKLMT = int.Parse(txtCurrentKLMT.Text);
            _CarContainer.Color = cbColor.Text;
            _CarContainer.CreatedByUserID = 5;
            if (rbYas.Checked)
                _CarContainer.IsAvalible = true;
            else _CarContainer.IsAvalible = false;
            _CarContainer.ImagePath = pbCar.ImageLocation;
            if (_CarContainer.Save())
            {
                DataBack?.Invoke(this, _CarContainer.CarID);
                if (Mode == enMode.Update)
                {
                    lblCarID.Text = _CarContainer.CarID.ToString();
                    MessageBox.Show("Car Updated  Succefully with ID " + _CarContainer.CarID, "Car Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblCarID.Text = _CarContainer.CarID.ToString();
                    MessageBox.Show("Car added Succefully with ID " + _CarContainer.CarID, "Car Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTitle.Text = "Update Car";
                }
            }
        }

        private void txtCarName_Validating(object sender, CancelEventArgs e)
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

        private void pbCar_Validating(object sender, CancelEventArgs e)
        {
            if (pbCar.ImageLocation != null)
            {
                e.Cancel = true;
                errorProvider1.SetError(pbCar, "Select Car Picture !");
            }
            else
            {
                errorProvider1.SetError(pbCar, null);
            }
        }

        private void txtPlateNumber_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPlateNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlateNumber, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPlateNumber, null);
            }
            //Make Sure NationalNo Not Use it 
            //if we are in Update Mode               if we are in add  New Mode will Check is have person with National No
            if (
                ((Mode == enMode.AddNew) == (clsCarsContainer.IsCarExistByCarPlateNumber(txtPlateNumber.Text.Trim()))) ||
                //((Mode == enMode.Update) && (txtPlateNumber.Text.Trim() == _CarContainer.CarPlateNumber)) ||

                ((Mode == enMode.Update) && (!clsCarsContainer.IsCarExistByCarPlateNumber(txtPlateNumber.Text.Trim()) == (txtPlateNumber.Text.Trim() == _CarContainer.CarPlateNumber))))



            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlateNumber, "Plate Number Is Allready Exist ");
            }
            else
            {

                errorProvider1.SetError(txtPlateNumber, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
