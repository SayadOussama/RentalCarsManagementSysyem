using BusinessLayer;
using RentalCars.Clients.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RentalCars.CarReservation
{
    public partial class frmCarReservationSection : Form
    {
        clsReservationCars _ReservationCar;
        clsClients _Client;
        clsCarsContainer _CarSelected;
        int _ReservationID = -1;
        int _CarID = -1;
        int _ClientID = -1;
        bool _IsCarSelected = false;
        
        public enum enMode { AddNew = 1, Update = 2 }

        public enMode Mode;
        public frmCarReservationSection()
        {
            InitializeComponent();
            Mode = enMode.AddNew;   
        }
        public frmCarReservationSection(int ReservationCarID )
        {
            InitializeComponent();
            Mode = enMode.Update;
            _ReservationID = ReservationCarID;
        }
        public frmCarReservationSection(int CarSelectedId , bool CarIsSelected = true)
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            _CarID = CarSelectedId;
            _IsCarSelected= CarIsSelected;
        }

        private void txtRentalCarFees_Validating(object sender, CancelEventArgs e)
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
        private void _ResetDefaultValue()
        {
            

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = " New Reservation Car";
                _CarSelected = new clsCarsContainer();
                _ReservationCar = new clsReservationCars();

            }
            else
            {
                lblTitle.Text = "Update Reservation Car";

            }
            dtpCheckOutDate.Value= DateTime.Now;
            dtpCheckIn.Value = DateTime.Now.AddDays(30);
            txtNote.Text = "None";
            txtDamageCostfees.Text = "0";
            txtKLMTSpend.Text = "0";







        }
        private void _ResetDefaultValuewithCarSelected(int CarID)
        {


            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = " New Reservation Car";
                _CarSelected = clsCarsContainer.GetCarInfoByCarID(CarID);
                _ReservationCar = new clsReservationCars();

            }
            else
            {
                lblTitle.Text = "Update Reservation Car";

            }
            ctrlCarInfoWithFilter1.LoadCarInfo(CarID);
            dtpCheckOutDate.Value = DateTime.Now;
            dtpCheckIn.Value = DateTime.Now.AddDays(30);
            txtNote.Text = "None";
            txtDamageCostfees.Text = "0";
            txtKLMTSpend.Text = "0";







        }
        private void _LoadData()
        {
            _ReservationCar = clsReservationCars.GetReservationCarInfoByID(_ReservationID);
            if (_ReservationCar == null)
            {
                MessageBox.Show("Reservation Not Exist  " + _ReservationID + " Is Not Find ");
                this.Close();
                return;
            }
            ctrlFindClientInfo1.LoadAccountInfoClientID(_ReservationCar.ClientID);
             ctrlCarInfoWithFilter1.LoadCarInfo(_ReservationCar.CarSelectedID);
            _Client = ctrlFindClientInfo1.ClinetInfo;
            _CarSelected  = ctrlCarInfoWithFilter1.SelectedCarInfo;
            lblReservationID.Text = _ReservationCar.ReservationID.ToString();
            dtpCheckIn.Value = _ReservationCar.DateToCheckIn;
            dtpCheckOutDate.Value = _ReservationCar.DateToCheckOut;
            txtRentalCarFees.Text = _ReservationCar.TotalRentalFee.ToString();
            txtDamageCostfees.Text =_ReservationCar.DamageCostfee.ToString();
            txtKLMTSpend.Text = _ReservationCar.KLMTSpend.ToString();
            txtNote.Text= _ReservationCar.Note.ToString();
            if (_ReservationCar.CarIsReturn)
            {
                btnCarReturn.Enabled = false;
                btnRservation.Enabled = false;
            }


        }
            private void txtRentalCarFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDamageCostfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKLMTSpend_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRservation_Click(object sender, EventArgs e)
        {
            if(ctrlFindClientInfo1.ClinetInfo == null) { 
                MessageBox.Show("You Need To Select Client First  ", "Client Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrlFindClientInfo1.ClinetInfo.LicenseExpirationDate <= DateTime.Now)
            {
                MessageBox.Show("License Was Expiraed "+ ctrlFindClientInfo1.ClinetInfo.LicenseExpirationDate.ToShortDateString() + " Client Need To Renew the Vehicle License  ", "License Was Expiraed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrlCarInfoWithFilter1.SelectedCarInfo == null)
            {
                MessageBox.Show("Car Not Selected You Need To select A car  ", "Car Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ctrlCarInfoWithFilter1.SelectedCarInfo.IsAvalible)
            {
                MessageBox.Show("Car Not Avalible  ", "Car Not Avalible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Mode == enMode.AddNew) { 
                _CarSelected = ctrlCarInfoWithFilter1.SelectedCarInfo;
               _Client = ctrlFindClientInfo1.ClinetInfo;
            }
            _ReservationCar.CarSelectedID = ctrlCarInfoWithFilter1.SelectedCarInfo.CarID;
            _ReservationCar.ClientID = ctrlFindClientInfo1.ClinetInfo.ClientID;
            _ReservationCar.ReservationDate = DateTime.Now;
            _ReservationCar.DateToCheckOut = dtpCheckOutDate.Value;
            _ReservationCar.DateToCheckIn = dtpCheckIn.Value;
            _ReservationCar.KLMTSpend =  int.Parse(txtKLMTSpend.Text.Trim());
            _ReservationCar.TotalRentalFee = decimal.Parse(txtRentalCarFees.Text.Trim());
            _ReservationCar.DamageCostfee = decimal.Parse(txtDamageCostfees.Text.Trim());
            _ReservationCar.Note  = txtNote.Text.Trim();
            _ReservationCar.CreatedByUserID = 5;
            if (_ReservationCar.Save())
            {
                _CarSelected.IsAvalible = false;
                _CarSelected.ClientTakenID = _Client.ClientID;
               if (_CarSelected.Save()){
                    MessageBox.Show("Car with ID "+_CarSelected.CarID+ " Reserved to Client With ID "+_Client.ClientID , "Reservation Done ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblReservationID.Text = _ReservationCar.ReservationID.ToString();
                    ctrlCarInfoWithFilter1.LoadCarInfo(_CarSelected.CarID);
                    lblTitle.Text = "Update Reservation Car";
                }
            }
        }

        private void frmCarReservationSection_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if(_IsCarSelected == true &&  _CarID != -1 && Mode == enMode.AddNew)
                _ResetDefaultValuewithCarSelected(_CarID);

            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnCarReturn_Click(object sender, EventArgs e)
        {
            //Note 
            //after you Click return btn you need to click to reservation btn to save the addintial info Like CrrentKLMT CheckIn car ect
            if(Mode == enMode.Update)
            {
                _CarSelected.CurrentKLMT += int.Parse(txtKLMTSpend.Text);
                _CarSelected.IsAvalible = true;
                _ReservationCar.KLMTSpend = int.Parse(txtKLMTSpend.Text);
                _ReservationCar.CarIsReturn = true;

                _CarSelected.ClientTakenID = -1;
                if (_ReservationCar.Save() && _CarSelected.Save()) { 
                MessageBox.Show("Car with " + _CarSelected.CarID + " return to Container", "Car Return", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRservation.Enabled = false;
                btnCarReturn.Enabled = false;
                }
                else
                    MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
