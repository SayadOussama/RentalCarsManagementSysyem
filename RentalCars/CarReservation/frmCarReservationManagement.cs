using BusinessLayer;
using RentalCars.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.CarReservation
{
    public partial class frmCarReservationManagement : Form
    {
        public static DataTable _dtAllReservationCar;
        public frmCarReservationManagement()
        {
            InitializeComponent();
        }

        private void frmCarReservationManagement_Load(object sender, EventArgs e)
        {
            _dtAllReservationCar = clsReservationCars.GerAllReservationList();
            dgvReservation.DataSource = _dtAllReservationCar;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvReservation.RowCount.ToString();
            if (dgvReservation.Rows.Count > 0)
            {
                dgvReservation.Columns[0].HeaderText = "Reservation ID";
                dgvReservation.Columns[0].Width = 50;

                dgvReservation.Columns[1].HeaderText = "Car Selected ID";
                dgvReservation.Columns[1].Width = 70;

                dgvReservation.Columns[2].HeaderText = "Client ID";
                dgvReservation.Columns[2].Width = 50;

                dgvReservation.Columns[3].HeaderText = "Full Name";
                dgvReservation.Columns[3].Width = 200;


                dgvReservation.Columns[4].HeaderText = "Reservation Date";
                dgvReservation.Columns[4].Width = 100;

                dgvReservation.Columns[5].HeaderText = "Date To Check Out";
                dgvReservation.Columns[5].Width = 100;

                dgvReservation.Columns[6].HeaderText = "Date To Check In";
                dgvReservation.Columns[6].Width = 100;

                dgvReservation.Columns[7].HeaderText = "KLMT Spend";
                dgvReservation.Columns[7].Width = 80;

                dgvReservation.Columns[8].HeaderText = "Total Rental Fee";
                dgvReservation.Columns[8].Width = 80;

                dgvReservation.Columns[9].HeaderText = "Damage Cost Fee";
                dgvReservation.Columns[9].Width = 80;

                dgvReservation.Columns[10].HeaderText = "Car Is Return";
                dgvReservation.Columns[10].Width = 50;

                dgvReservation.Columns[11].HeaderText = "CreatedByUser";
                dgvReservation.Columns[11].Width = 50;


            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Car Is Return")
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
                
                case "Reservation ID":
                    FilterColumn = "ReservationID";
                    break;
                case "Car Selected ID":
                    FilterColumn = "CarSelectedID";
                    break;
                case "Client ID":
                    FilterColumn = "ClientID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Car Is Return":
                    FilterColumn = "CarIsReturn";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            //FilterColumn == "ReservationID" || FilterColumn == "CarSelectedID" || FilterColumn == "ClientID" || FilterColumn == "CarIsReturn"
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllReservationCar.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllReservationCar.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName")
                //in this case we deal with numbers not string.
                _dtAllReservationCar.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllReservationCar.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllReservationCar.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueSelected = cbIsActive.Text;
            string FilterColumn = "CarIsReturn";
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
                _dtAllReservationCar.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllReservationCar.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, ValueSelected);

            lblRecordsCount.Text = _dtAllReservationCar.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Full Name")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            frmCarReservationSection frm = new frmCarReservationSection();
            frm.ShowDialog();
            frmCarReservationManagement_Load(null, null);     


         }

        private void UpdateReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReservationID = (int)dgvReservation.CurrentRow.Cells[0].Value;
            clsReservationCars Reservationinfo = clsReservationCars.GetReservationCarInfoByID(ReservationID);
            if (Reservationinfo != null)
            {

                frmCarReservationSection frm = new frmCarReservationSection(ReservationID);
                frm.ShowDialog();
                frmCarReservationManagement_Load(null, null);
            }
            else
                MessageBox.Show("Reservation with ID " + ReservationID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        //private void deleteReservationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmCarReservationSection frm = new frmCarReservationSection();
        //    frm.ShowDialog();
        //    frmCarReservationManagement_Load(null, null);
        //}
    }
}