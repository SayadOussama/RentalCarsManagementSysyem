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

namespace RentalCars.CarsContainer
{
    public partial class frmFindCar : Form
    {
        int _CarID = -1;  
        public frmFindCar()
        {
            InitializeComponent();
        }
        public frmFindCar(int CarID)
        {
            InitializeComponent();
            _CarID = CarID;
        }
        private void ctrlCarInfoWithFilter1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindCar_Load(object sender, EventArgs e)
        {
            if (_CarID != -1)
                ctrlCarInfoWithFilter1.LoadCarInfo(_CarID);
        }
    }
}
