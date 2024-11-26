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

namespace RentalCars.CarsContainer.Controls
{
    public partial class ctrlCarInfoWithFilter : UserControl
    {
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public int CarID
        {
            get { return ctrlCarInfo1.CarContainer.CarID; }
        }
        
        public clsCarsContainer SelectedCarInfo
        {
            get { return ctrlCarInfo1.CarContainer; }
        }
        public ctrlCarInfoWithFilter()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            //Way 1 :
            //If the You Load Data = send Data By prameters
            switch (cbFilterBy.Text)
            {
                case "Car ID":
                    ctrlCarInfo1._LoadCarDataInfo(int.Parse(txtFilterValue.Text));

                    break;
                default:
                    break;
            }
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                //that Mean Press ENTER in Key Board
                btnFind.PerformClick();
            }
            if (cbFilterBy.Text == "Car ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlCarInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
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

        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateCar frm = new frmAddNewUpdateCar();
            frm.DataBack += LoadNewCarInfo;
            frm.ShowDialog();
        }
        private  void LoadNewCarInfo(object sender, int CarID)
        {
            ctrlCarInfo1._LoadCarDataInfo(CarID);
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ctrlCarInfo1.CarID.ToString();
            _FilterEnabled = false;


        }
       public  void LoadCarInfo(int CarID)
        {
            ctrlCarInfo1._LoadCarDataInfo(CarID);
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ctrlCarInfo1.CarID.ToString();
            _FilterEnabled = false;
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
    }
}
