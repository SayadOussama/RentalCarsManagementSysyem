using BusinessLayer;
using RentalCars.CarReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.CarsContainer
{

    public partial class frmCarMangement : Form
    {
        public static DataTable _dtAllCars;
        public frmCarMangement()
        {
            InitializeComponent();
        }

        private void frmCarMangement_Load(object sender, EventArgs e)
        {
            _dtAllCars = clsCarsContainer.GetCarContainerList();
            dgvCarList.DataSource = _dtAllCars;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvCarList.RowCount.ToString();
            if (dgvCarList.Rows.Count > 0)
            {
                dgvCarList.Columns[0].HeaderText = "Car ID";
                dgvCarList.Columns[0].Width = 50;

                dgvCarList.Columns[1].HeaderText = "Car Name";
                dgvCarList.Columns[1].Width = 70;

                dgvCarList.Columns[2].HeaderText = "Car Model";
                dgvCarList.Columns[2].Width = 250;

                dgvCarList.Columns[3].HeaderText = "Engine Model";
                dgvCarList.Columns[3].Width = 300;


                dgvCarList.Columns[4].HeaderText = "Type Name";
                dgvCarList.Columns[4].Width = 80;

                dgvCarList.Columns[5].HeaderText = "Car Plate Number";
                dgvCarList.Columns[5].Width = 150;

                dgvCarList.Columns[6].HeaderText = "Color";
                dgvCarList.Columns[6].Width = 50;

                dgvCarList.Columns[7].HeaderText = "Doors Number";
                dgvCarList.Columns[7].Width = 50;

                dgvCarList.Columns[8].HeaderText = "Is Available";
                dgvCarList.Columns[8].Width = 50;

                dgvCarList.Columns[9].HeaderText = "Current KLMT";
                dgvCarList.Columns[9].Width = 50;

                dgvCarList.Columns[10].HeaderText = "Client Taken ID";
                dgvCarList.Columns[10].Width = 50;

                dgvCarList.Columns[11].HeaderText = "CreatedByUser";
                dgvCarList.Columns[11].Width = 50;


            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Available")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;


            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Car ID":
                    FilterColumn = "CarID";
                    break;
                case "Car Name":
                    FilterColumn = "CarName";
                    break;
                case "Car Model":
                    FilterColumn = "CarModel";
                    break;
                case "Engine Model":
                    FilterColumn = "EngineModel";
                    break;
                case "Type Name":
                    FilterColumn = "TypeName";
                    break;

                case "Car Plate Number":
                    FilterColumn = "CarPlateNumber";
                    break;

                case "Color":
                    FilterColumn = "Color";
                    break;


                case "Doors Number":
                    FilterColumn = "DoorsNumber";
                    break;

                case "Is Available":
                    FilterColumn = "IsAvailable";
                    break;
                case "Current KLMT":
                    FilterColumn = "CurrentKLMT";
                    break;
                case "Client Taken ID":
                    FilterColumn = "ClientTakenID";
                    break;
                case "Created By User":
                    FilterColumn = "CreatedByUser";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllCars.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllCars.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "CarID" || FilterColumn == "DoorsNumber" || FilterColumn == "CurrentKLMT" || FilterColumn == "ClientTakenID")
                //in this case we deal with numbers not string.
                _dtAllCars.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllCars.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllCars.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueSelected = cbIsActive.Text;
            string FilterColumn = "IsAvailable";
            switch (ValueSelected)
            {
                case "All":
                    break;
                case "Yes":
                    ValueSelected = "Yas";
                    break;
                case "No":
                    ValueSelected = "No";
                    break;
            }

            if (ValueSelected == "All")
                _dtAllCars.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllCars.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, ValueSelected);

            lblRecordsCount.Text = _dtAllCars.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Car ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void carDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CarID = (int)dgvCarList.CurrentRow.Cells[0].Value;
            clsCarsContainer CarInfo = clsCarsContainer.GetCarInfoByCarID(CarID);
            if (CarInfo != null)
            {
                frmFindCar frm = new frmFindCar(CarInfo.CarID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Car with ID " + CarID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CarID = (int)dgvCarList.CurrentRow.Cells[0].Value;
            clsCarsContainer CarInfo = clsCarsContainer.GetCarInfoByCarID(CarID);
            if (CarInfo != null)
            {
                frmAddNewUpdateCar frm = new frmAddNewUpdateCar(CarInfo.CarID);
                frm.ShowDialog();
                frmCarMangement_Load(null, null);
            }
            else
                MessageBox.Show("Car with ID " + CarID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CarID = (int)dgvCarList.CurrentRow.Cells[0].Value;
            clsCarsContainer CarInfo = clsCarsContainer.GetCarInfoByCarID(CarID);
            if (CarInfo != null)
            {
                if (CarInfo.ClientTakenID != -1 && !CarInfo.IsAvalible)
                {
                    MessageBox.Show("Car with ID " + CarID + " is AllReady Taken by Client ID " + CarInfo.ClientTakenID, "Car Taken ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to Delete this Car With ID [" + CarID.ToString() + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (CarInfo.DeleteCarInfo())
                        MessageBox.Show("Car Account Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCarMangement_Load(null, null);
                }
                else
                    MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                MessageBox.Show("Car with ID " + CarID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSubscriber_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateCar frm = new frmAddNewUpdateCar();
            frm.ShowDialog();
            frmCarMangement_Load(null, null);

        }

        private void selectForReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CarID = (int)dgvCarList.CurrentRow.Cells[0].Value;
            clsCarsContainer CarInfo = clsCarsContainer.GetCarInfoByCarID(CarID);
            if (CarInfo != null)
            {
                frmCarReservationSection frm = new frmCarReservationSection(CarID, true);
                frm.ShowDialog();
                frmCarMangement_Load(null, null);
            }
        }
    }
}