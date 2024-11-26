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

namespace RentalCars.CarTypes
{
    public partial class frmCarTypesManagement : Form
    {
        clsCarTypes _CarTypes;
        public static DataTable _dtAllCars;
        public frmCarTypesManagement()
        {
            InitializeComponent();
        }

        private void frmCarTypesManagement_Load(object sender, EventArgs e)
        {
            _dtAllCars = clsCarTypes.GetAllByCarType();
            dgvCarTypes.DataSource = _dtAllCars;

            lblRecordsCount.Text = dgvCarTypes.RowCount.ToString();
            if (dgvCarTypes.Rows.Count > 0)
            {
                dgvCarTypes.Columns[0].HeaderText = "Car Type ID";
                dgvCarTypes.Columns[0].Width = 50;

                dgvCarTypes.Columns[1].HeaderText = "Car Type Name";
                dgvCarTypes.Columns[1].Width = 150;

                dgvCarTypes.Columns[2].HeaderText = "Created By User";
                dgvCarTypes.Columns[2].Width = 80;
            }
        }

        private void addNewCarTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateCarType frm = new frmAddNewUpdateCarType();
            frm.ShowDialog();
            frmCarTypesManagement_Load(null, null);
        }

        private void updateCarTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CarTypeID = (int)dgvCarTypes.CurrentRow.Cells[0].Value;
             _CarTypes   =   clsCarTypes.GetCarTypeInfoByID(CarTypeID);
            if (_CarTypes != null) {
                frmAddNewUpdateCarType frm = new frmAddNewUpdateCarType(CarTypeID);
                frm.ShowDialog();
                frmCarTypesManagement_Load(null, null);

            }
            else
            {
                MessageBox.Show("Car Type with ID "+ CarTypeID+" Not Exist","Car Type Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                return;
            }
           
        }
    }
}
