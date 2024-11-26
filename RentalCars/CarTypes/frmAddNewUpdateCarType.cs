using BusinessLayer;
using RentalCars.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.CarTypes
{
    public partial class frmAddNewUpdateCarType : Form
    {
        clsCarTypes _CarType;
        int _CarTypeID = -1;
        enum enMode { AddNew=1, Update=2};
        enMode Mode = enMode.AddNew;



        public frmAddNewUpdateCarType()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddNewUpdateCarType(int CarTypeID)
        {
            InitializeComponent();
            _CarTypeID = CarTypeID;
            Mode = enMode.Update;
        }
     
        void _ReserDefaultForm()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Car Type";
                _CarType = new clsCarTypes();
            }
            else {

                lblTitle.Text = "Update Car Type";


            }
        }
        void _LoadData()
        {
            _CarType = clsCarTypes.GetCarTypeInfoByID(_CarTypeID);
            if (_CarType == null)
            {
                MessageBox.Show("Car Type Not Exist With ID "+_CarTypeID+" ","Not Exist",MessageBoxButtons.OK,MessageBoxIcon.Error);    
                return;

            }
            lblCarTypeID.Text = _CarType.CarTypeID.ToString();
            txtTypeName.Text = _CarType.TypeName.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtTypeName.Text == string.Empty)
            {
                MessageBox.Show("Type Name Section Is Empty ", "Enter Type Name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _CarType.TypeName = txtTypeName.Text;
            _CarType.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if(_CarType.Save())
            {
                MessageBox.Show("Car Type Added Successful with ID " + _CarType.CarTypeID + " ", "Car Type Added ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCarTypeID.Text= _CarType.CarTypeID.ToString();
                lblTitle.Text = "Update Car Type ";
            }
        }

        private void frmAddNewUpdateCarType_Load(object sender, EventArgs e)
        {
            _ReserDefaultForm();
            if (Mode == enMode.Update)
                _LoadData();


        }
    }
}
