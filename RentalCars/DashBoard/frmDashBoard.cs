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

namespace RentalCars.DashBoard
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            lblTotalCars.Text = clsDashBoard.GetTotalOfCars().ToString();
            lblCarsIsAvailable.Text = clsDashBoard.GetTotalOfCarsAvailable().ToString();
            lblNotAvialable.Text= clsDashBoard.GetTotalOfCarsNotAvailable().ToString();
            lblTotalClients.Text = clsDashBoard.GetTotalOfClients().ToString();
        }
    }
}
