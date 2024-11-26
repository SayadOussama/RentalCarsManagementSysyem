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
    public partial class ctrlUserCard : UserControl
    {
        private clsUsers _User;
        private int _UserID = -1;
        public int UserID { get { return _UserID; } }
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        private void _FileUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            //userControl11.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.IsActive)
                lblIsActive.Text = "Yas";
            else
                lblIsActive.Text = "No";
        }
        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            //   userControl11.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.GetFindUserInfoByUserID(_UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FileUserInfo();
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }

        private void LlblEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_User == null)
            {
                MessageBox.Show("No User Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
          
            frmAddNewUpdateUser frm = new frmAddNewUpdateUser(_User.UserID);
              frm.ShowDialog();
            _FileUserInfo();
            
        }
    }
}
