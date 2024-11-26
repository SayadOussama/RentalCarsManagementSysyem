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

namespace RentalCars.Users
{

    public partial class frmUserDetails : Form
    {
        private clsUsers _User;
        private int _UserID = -1;
        public int UserID { get { return _UserID; } }
        public frmUserDetails()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.GetFindUserInfoByUserID(_UserID);
            if (_User == null)
            {

                MessageBox.Show("No User with UserID = " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlUserCard1.LoadUserInfo(UserID);
        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
