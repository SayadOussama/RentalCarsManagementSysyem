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

namespace RentalCars.Clients
{
    public partial class frmClientManagement : Form
    {
        private static DataTable _dtAllClients;
        private clsPerson _PersonInfo;
        public frmClientManagement()
        {
            InitializeComponent();
        }

        private void frmClientManagement_Load(object sender, EventArgs e)
        {
            _dtAllClients = clsClients.GetAllClients();
            dgvClients.DataSource = _dtAllClients;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();
            if (dgvClients.Rows.Count > 0)
            {
                dgvClients.Columns[0].HeaderText = "Client ID";
                dgvClients.Columns[0].Width = 50;

                dgvClients.Columns[1].HeaderText = "Full Name";
                dgvClients.Columns[1].Width = 200;

                dgvClients.Columns[2].HeaderText = "Gender";
                dgvClients.Columns[2].Width = 50;

                dgvClients.Columns[3].HeaderText = "Vehical License Number";
                dgvClients.Columns[3].Width = 150;


                dgvClients.Columns[4].HeaderText = "License Expiration Date";
                dgvClients.Columns[4].Width = 200;

                dgvClients.Columns[5].HeaderText = "Account Creation Date";
                dgvClients.Columns[5].Width = 200;

                dgvClients.Columns[6].HeaderText = "Created by User";
                dgvClients.Columns[6].Width = 150;

            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Gender")
            {
                txtFilterValue.Visible = false;
                cbGender.Visible = true;
                cbGender.Focus();
                cbGender.SelectedIndex = 0;


            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbGender.Visible = false;
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

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueSelected = cbGender.Text;
            string FilterColumn = "Gender";
            switch (ValueSelected)
            {
                case "All":
                    break;
                case "Male":
                    ValueSelected = "Male";
                    break;
                case "Female":
                    ValueSelected = "Female";
                    break;
            }

            if (ValueSelected == "All")
                _dtAllClients.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, ValueSelected);

            lblRecordsCount.Text = _dtAllClients.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Client ID":
                    FilterColumn = "ClientID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Vehical License Number":
                    FilterColumn = "VehicalLicenseNumber";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllClients.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllClients.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName")
                //in this case we deal with numbers not string.
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllClients.Rows.Count.ToString();
        }

        private void btnAddSubscriber_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateClient frm = new frmAddNewUpdateClient();
            frm.ShowDialog();
            frmClientManagement_Load(null, null);
        }

        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            clsClients Client = clsClients.GetClientInfoByClientID(ClientID);
            if (Client != null)
            {
                PersonID = Client.PersonID;
                _PersonInfo = clsPerson.GetPersonInfoByPersonID(PersonID);

                if (Client.DeleteClientID())
                {
                    if (_PersonInfo.DeletePersonByPersonID(PersonID))
                    {
                        MessageBox.Show("Client With ID " + Client.ClientID + " Delete Successfuly ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmClientManagement_Load(null, null);
                    }
                    else
                        MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Client with ID " + ClientID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            clsClients Client = clsClients.GetClientInfoByClientID(ClientID);
            if (Client != null)
            {

                frmFindClient frm = new frmFindClient(ClientID);
                frm.ShowDialog();

            }
            else
                MessageBox.Show("Client with ID " + ClientID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            clsClients Client = clsClients.GetClientInfoByClientID(ClientID);
            if (Client != null)
            {

                frmAddNewUpdateClient frm = new frmAddNewUpdateClient(ClientID);
                frm.ShowDialog();
                frmClientManagement_Load(null, null);
            }
            else
                MessageBox.Show("Client with ID " + ClientID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}