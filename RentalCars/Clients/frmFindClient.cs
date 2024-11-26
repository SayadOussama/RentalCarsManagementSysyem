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
    public partial class frmFindClient : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int ClientID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        int _ClientID = -1;
        public frmFindClient()
        {
            InitializeComponent();
        }
        public frmFindClient(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Trigger the event to send data back to the caller form.
            DataBack?.Invoke(this, ctrlFindClientInfo1.ClientID);
        }

        private void frmFindClient_Load(object sender, EventArgs e)
        {
            if (_ClientID != -1)
            {
                ctrlFindClientInfo1.LoadAccountInfoClientID(_ClientID);
            }
        }
    }
}
