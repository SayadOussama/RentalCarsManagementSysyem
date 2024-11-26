namespace RentalCars
{
    partial class MainFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDateAndTime = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExsit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newReservationCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationCarManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carTypeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCarTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagementUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDateAndTime);
            this.panel1.Controls.Add(this.lblCurrentUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnExsit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 76);
            this.panel1.TabIndex = 1;
            // 
            // lblDateAndTime
            // 
            this.lblDateAndTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAndTime.ForeColor = System.Drawing.Color.Black;
            this.lblDateAndTime.Location = new System.Drawing.Point(313, 25);
            this.lblDateAndTime.Name = "lblDateAndTime";
            this.lblDateAndTime.Size = new System.Drawing.Size(1006, 39);
            this.lblDateAndTime.TabIndex = 75;
            this.lblDateAndTime.Text = "??????";
            this.lblDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDateAndTime.Click += new System.EventHandler(this.lblDateAndTime_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentUser.Location = new System.Drawing.Point(238, 25);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(60, 22);
            this.lblCurrentUser.TabIndex = 6;
            this.lblCurrentUser.Text = "?????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(174, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "User :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentalCars.Properties.Resources.car_12689282;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnExsit
            // 
            this.btnExsit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExsit.Image = global::RentalCars.Properties.Resources.TurnOff;
            this.btnExsit.Location = new System.Drawing.Point(1029, 0);
            this.btnExsit.Name = "btnExsit";
            this.btnExsit.Size = new System.Drawing.Size(90, 76);
            this.btnExsit.TabIndex = 0;
            this.btnExsit.UseVisualStyleBackColor = true;
            this.btnExsit.Click += new System.EventHandler(this.btnExsit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationToolStripMenuItem,
            this.carsContainerToolStripMenuItem,
            this.carTypesToolStripMenuItem,
            this.clientTypeToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.usersToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 76);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 72);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reservationToolStripMenuItem
            // 
            this.reservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newReservationCarToolStripMenuItem,
            this.reservationCarManagmentToolStripMenuItem});
            this.reservationToolStripMenuItem.Image = global::RentalCars.Properties.Resources.car_key;
            this.reservationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reservationToolStripMenuItem.Name = "reservationToolStripMenuItem";
            this.reservationToolStripMenuItem.Size = new System.Drawing.Size(176, 68);
            this.reservationToolStripMenuItem.Text = "Reservation";
            // 
            // newReservationCarToolStripMenuItem
            // 
            this.newReservationCarToolStripMenuItem.Image = global::RentalCars.Properties.Resources.New_ReservationCar;
            this.newReservationCarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newReservationCarToolStripMenuItem.Name = "newReservationCarToolStripMenuItem";
            this.newReservationCarToolStripMenuItem.Size = new System.Drawing.Size(364, 70);
            this.newReservationCarToolStripMenuItem.Text = "New Reservation Car";
            this.newReservationCarToolStripMenuItem.Click += new System.EventHandler(this.newReservationCarToolStripMenuItem_Click);
            // 
            // reservationCarManagmentToolStripMenuItem
            // 
            this.reservationCarManagmentToolStripMenuItem.Image = global::RentalCars.Properties.Resources.car_managment_Context_menu;
            this.reservationCarManagmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reservationCarManagmentToolStripMenuItem.Name = "reservationCarManagmentToolStripMenuItem";
            this.reservationCarManagmentToolStripMenuItem.Size = new System.Drawing.Size(364, 70);
            this.reservationCarManagmentToolStripMenuItem.Text = "Reservation Car Management";
            this.reservationCarManagmentToolStripMenuItem.Click += new System.EventHandler(this.reservationCarManagmentToolStripMenuItem_Click);
            // 
            // carsContainerToolStripMenuItem
            // 
            this.carsContainerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carsManagmentToolStripMenuItem,
            this.findCarToolStripMenuItem,
            this.addNewCarToolStripMenuItem});
            this.carsContainerToolStripMenuItem.Image = global::RentalCars.Properties.Resources.CarContainer;
            this.carsContainerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.carsContainerToolStripMenuItem.Name = "carsContainerToolStripMenuItem";
            this.carsContainerToolStripMenuItem.Size = new System.Drawing.Size(201, 68);
            this.carsContainerToolStripMenuItem.Text = "Cars Container";
            // 
            // carsManagmentToolStripMenuItem
            // 
            this.carsManagmentToolStripMenuItem.Image = global::RentalCars.Properties.Resources.CarManagment;
            this.carsManagmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.carsManagmentToolStripMenuItem.Name = "carsManagmentToolStripMenuItem";
            this.carsManagmentToolStripMenuItem.Size = new System.Drawing.Size(269, 70);
            this.carsManagmentToolStripMenuItem.Text = "Cars Managment";
            this.carsManagmentToolStripMenuItem.Click += new System.EventHandler(this.carsManagmentToolStripMenuItem_Click);
            // 
            // findCarToolStripMenuItem
            // 
            this.findCarToolStripMenuItem.Image = global::RentalCars.Properties.Resources.FindCar;
            this.findCarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findCarToolStripMenuItem.Name = "findCarToolStripMenuItem";
            this.findCarToolStripMenuItem.Size = new System.Drawing.Size(269, 70);
            this.findCarToolStripMenuItem.Text = "Find Car";
            this.findCarToolStripMenuItem.Click += new System.EventHandler(this.findCarToolStripMenuItem_Click);
            // 
            // addNewCarToolStripMenuItem
            // 
            this.addNewCarToolStripMenuItem.Image = global::RentalCars.Properties.Resources.AddNewCar;
            this.addNewCarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewCarToolStripMenuItem.Name = "addNewCarToolStripMenuItem";
            this.addNewCarToolStripMenuItem.Size = new System.Drawing.Size(269, 70);
            this.addNewCarToolStripMenuItem.Text = "Add New Car";
            this.addNewCarToolStripMenuItem.Click += new System.EventHandler(this.addNewCarToolStripMenuItem_Click);
            // 
            // carTypesToolStripMenuItem
            // 
            this.carTypesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carTypeManagementToolStripMenuItem,
            this.AddCarTypeToolStripMenuItem});
            this.carTypesToolStripMenuItem.Image = global::RentalCars.Properties.Resources.CarTypes;
            this.carTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.carTypesToolStripMenuItem.Name = "carTypesToolStripMenuItem";
            this.carTypesToolStripMenuItem.Size = new System.Drawing.Size(161, 68);
            this.carTypesToolStripMenuItem.Text = "Car Types";
            // 
            // carTypeManagementToolStripMenuItem
            // 
            this.carTypeManagementToolStripMenuItem.Image = global::RentalCars.Properties.Resources.CarTypeManagment;
            this.carTypeManagementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.carTypeManagementToolStripMenuItem.Name = "carTypeManagementToolStripMenuItem";
            this.carTypeManagementToolStripMenuItem.Size = new System.Drawing.Size(316, 70);
            this.carTypeManagementToolStripMenuItem.Text = "Car Type Management ";
            this.carTypeManagementToolStripMenuItem.Click += new System.EventHandler(this.carTypeManagementToolStripMenuItem_Click);
            // 
            // AddCarTypeToolStripMenuItem
            // 
            this.AddCarTypeToolStripMenuItem.Image = global::RentalCars.Properties.Resources.AddnewCarType;
            this.AddCarTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCarTypeToolStripMenuItem.Name = "AddCarTypeToolStripMenuItem";
            this.AddCarTypeToolStripMenuItem.Size = new System.Drawing.Size(316, 70);
            this.AddCarTypeToolStripMenuItem.Text = "Add New Car Type";
            this.AddCarTypeToolStripMenuItem.Click += new System.EventHandler(this.AddCarTypeToolStripMenuItem_Click);
            // 
            // clientTypeToolStripMenuItem
            // 
            this.clientTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managementClientToolStripMenuItem,
            this.addNewClientToolStripMenuItem,
            this.findClientToolStripMenuItem});
            this.clientTypeToolStripMenuItem.Image = global::RentalCars.Properties.Resources.client;
            this.clientTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientTypeToolStripMenuItem.Name = "clientTypeToolStripMenuItem";
            this.clientTypeToolStripMenuItem.Size = new System.Drawing.Size(139, 68);
            this.clientTypeToolStripMenuItem.Text = "Clients";
            // 
            // managementClientToolStripMenuItem
            // 
            this.managementClientToolStripMenuItem.Image = global::RentalCars.Properties.Resources.ClientManagment;
            this.managementClientToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.managementClientToolStripMenuItem.Name = "managementClientToolStripMenuItem";
            this.managementClientToolStripMenuItem.Size = new System.Drawing.Size(287, 70);
            this.managementClientToolStripMenuItem.Text = "Clients Managment";
            this.managementClientToolStripMenuItem.Click += new System.EventHandler(this.managementClientToolStripMenuItem_Click);
            // 
            // addNewClientToolStripMenuItem
            // 
            this.addNewClientToolStripMenuItem.Image = global::RentalCars.Properties.Resources.AddNewClient;
            this.addNewClientToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewClientToolStripMenuItem.Name = "addNewClientToolStripMenuItem";
            this.addNewClientToolStripMenuItem.Size = new System.Drawing.Size(287, 70);
            this.addNewClientToolStripMenuItem.Text = "Add new Client";
            this.addNewClientToolStripMenuItem.Click += new System.EventHandler(this.addNewClientToolStripMenuItem_Click);
            // 
            // findClientToolStripMenuItem
            // 
            this.findClientToolStripMenuItem.Image = global::RentalCars.Properties.Resources.FindCLient;
            this.findClientToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findClientToolStripMenuItem.Name = "findClientToolStripMenuItem";
            this.findClientToolStripMenuItem.Size = new System.Drawing.Size(287, 70);
            this.findClientToolStripMenuItem.Text = "Find Client";
            this.findClientToolStripMenuItem.Click += new System.EventHandler(this.findClientToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::RentalCars.Properties.Resources.RentalCarsshbord;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(246, 68);
            this.usersToolStripMenuItem.Text = "Dashbord Rental Car";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagementUserToolStripMenuItem,
            this.AddUserToolStripMenuItem});
            this.usersToolStripMenuItem1.Image = global::RentalCars.Properties.Resources.user_gear;
            this.usersToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(129, 68);
            this.usersToolStripMenuItem1.Text = "Users";
            // 
            // ManagementUserToolStripMenuItem
            // 
            this.ManagementUserToolStripMenuItem.Image = global::RentalCars.Properties.Resources.Users_Management;
            this.ManagementUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManagementUserToolStripMenuItem.Name = "ManagementUserToolStripMenuItem";
            this.ManagementUserToolStripMenuItem.Size = new System.Drawing.Size(279, 70);
            this.ManagementUserToolStripMenuItem.Text = "User Management";
            this.ManagementUserToolStripMenuItem.Click += new System.EventHandler(this.ManagementUserToolStripMenuItem_Click);
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Image = global::RentalCars.Properties.Resources.Add_New_User;
            this.AddUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(279, 70);
            this.AddUserToolStripMenuItem.Text = "Add User";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 302);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::RentalCars.Properties.Resources.Newnew;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1119, 302);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFrom";
            this.Text = "MainFrom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateAndTime;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExsit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carsContainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carsManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carTypeManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddCarTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newReservationCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationCarManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManagementUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUserToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
    }
}

