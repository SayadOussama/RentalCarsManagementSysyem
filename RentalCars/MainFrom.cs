using RentalCars.CarReservation;
using RentalCars.CarsContainer;
using RentalCars.CarTypes;
using RentalCars.Clients;
using RentalCars.DashBoard;
using RentalCars.GlobalClasses;
using RentalCars.Login;
using RentalCars.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars
{
    public partial class MainFrom : Form
    {
        frmLogin _LogFrom;
        public MainFrom(frmLogin frm)
        {
            InitializeComponent();
            _LogFrom = frm;
        }

        private void btnExsit_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LogFrom.Show();
            this.Close();
        }

        private void managementClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientManagement frm = new frmClientManagement();
            frm.ShowDialog();

        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateClient frm = new frmAddNewUpdateClient();
            frm.ShowDialog();

        }

        private void findClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindClient frm = new frmFindClient();
            frm.ShowDialog();
        }

        private void findCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindCar frm = new frmFindCar();
            frm.ShowDialog();
        }

        private void carsManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarMangement frm = new frmCarMangement();
            frm.ShowDialog();
        }

        private void addNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateCar frm = new frmAddNewUpdateCar();
            frm.ShowDialog();
        }

        private void newReservationCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarReservationSection frm = new frmCarReservationSection();
            frm.ShowDialog();
        }

        private void reservationCarManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCarReservationManagement frm =new frmCarReservationManagement();
            frm.ShowDialog();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateUser frm = new frmAddNewUpdateUser();    
            frm.ShowDialog();
        }

        private void ManagementUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersManagement frm = new frmUsersManagement();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashBoard frm = new frmDashBoard();
            frm.ShowDialog();
        }

        private void AddCarTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateCarType frm = new frmAddNewUpdateCarType();
            frm.ShowDialog();
        }

        private void carTypeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarTypesManagement frm = new frmCarTypesManagement();
            frm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblDateAndTime.Refresh();
        }

        private void lblDateAndTime_Click(object sender, EventArgs e)
        {

        }
    }
}
