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

namespace RentalCars.CarsContainer.Controls
{
    public partial class ctrlCarInfo : UserControl
    {
        private int _CarID = -1;
        // Define a custom event handler delegate with parameters
        public event Action<int> onCarSelected;
        // Create a protected method to raise the event with a parameter
        public int CarID { get { return _CarID; } }
        clsCarsContainer _CarContainer;
        public clsCarsContainer CarContainer { get { return _CarContainer; } }
        protected virtual void ClientSelected(int CarID)
        {
            Action<int> handler = onCarSelected;
            if (handler != null)
            {
                handler(CarID); // Raise the event with the parameter
            }
        }
        public ctrlCarInfo()
        {
            InitializeComponent();
        }

        void FillPanelColor(string colorselected)
        {
            switch (colorselected)
            {
                case "Red":
                    panel1.BackColor = Color.Red; break;
                case "Gray":
                    panel1.BackColor = Color.Gray; break;
                case "Blue":
                    panel1.BackColor = Color.Blue; break;
                case "Orange":
                    panel1.BackColor = Color.Orange; break;
                case "White":
                    panel1.BackColor = Color.White; break;
                case "Beige":
                    panel1.BackColor = Color.Beige; break;
                case "Purple":
                    panel1.BackColor = Color.Purple; break;
                case "Black":
                    panel1.BackColor = Color.Black; break;

            }

        }
        private void LoadData()
        {
            lblCarID.Text = _CarContainer.CarID.ToString();
            lblCarName.Text = _CarContainer.CarName.ToString();
            lblCarModel.Text = _CarContainer.CarModel.ToString();
            lblEngineModel.Text = _CarContainer.EngineModel;
            pbCar.ImageLocation = _CarContainer.ImagePath;
            lblCarType.Text = _CarContainer._CarTypeInfo.TypeName;
            lblDoosNumber.Text = _CarContainer.DoorsNumber.ToString();
            lblPlateNumber.Text = _CarContainer.CarPlateNumber.ToString();
            lblRentalPrice.Text = _CarContainer.RentalCarPrice.ToString();
            lblCarColor.Text = _CarContainer.Color;
            FillPanelColor(_CarContainer.Color.Trim());
            if (_CarContainer.IsAvalible)

                lblIsAvailabel.Text = "Yas";
            else
                lblIsAvailabel.Text = "No";
            if (_CarContainer.ClientTakenID == -1)
                lblClientName.Text = "Car Not Taken";
            else
            {
                lblClientName.Text = _CarContainer._TakenClientInfo._PersonInfo.FullName;
            }
            lblCurrentKLMT.Text = _CarContainer.CurrentKLMT.ToString();
        }
        private void ResetCarInfo()
        {
            lblCarID.Text = "[????????]";
            lblCarName.Text = "[?????????]";
            lblCarModel.Text = "[????????]";
            lblEngineModel.Text = "[????????]";
            lblCarType.Text = "[????????]";
            lblDoosNumber.Text = "[???????]";
            lblPlateNumber.Text = "[???????]";
            lblRentalPrice.Text = "[????????]";
            lblCarColor.Text = "[?????????]";
            lblClientName.Text = "[????????]";
            lblCurrentKLMT.Text = "[???????]";
            lblIsAvailabel.Text = "[????]";
        }


        public void _LoadCarDataInfo(int CarID)
        {
            _CarID = CarID;
            if (clsCarsContainer.GetCarInfoByCarID(CarID) != null)
            {
                _CarContainer = clsCarsContainer.GetCarInfoByCarID(CarID);
                LoadData();
            }
            else
            {
                MessageBox.Show("Car with ID " + CarID.ToString() + " Not Exist", "Car Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void llEditCarInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CarContainer == null)
            {
                MessageBox.Show("You Need To Select the Car ID First ", "Car ID Not Selected ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddNewUpdateCar frm = new frmAddNewUpdateCar(_CarContainer.CarID);
            frm.DataBack += ReloadData;
            frm.ShowDialog();
        }
        private void ReloadData(object sender, int CarID)
        {//get Refrach
            _LoadCarDataInfo(CarID);
        }

        private void llClientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_CarContainer.ClientTakenID == -1 )
                MessageBox.Show("Car Not Taken  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (clsClients.GetClientInfoByClientID(_CarContainer.ClientTakenID) == null)
            {
                MessageBox.Show("Client Taken Not Exist with" + _CarContainer.ClientTakenID.ToString() + "Is Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmAddNewUpdateClient frm = new frmAddNewUpdateClient(_CarContainer.ClientTakenID);
                frm.ShowDialog();
                //refrch page 
                _LoadCarDataInfo(_CarID);
            }
        }
    }
}
