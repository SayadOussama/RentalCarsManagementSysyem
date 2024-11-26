namespace RentalCars.CarReservation
{
    partial class frmCarReservationSection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKLMTSpend = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDamageCostfees = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRentalCarFees = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReservationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCarReturn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRservation = new System.Windows.Forms.Button();
            this.ctrlCarInfoWithFilter1 = new RentalCars.CarsContainer.Controls.ctrlCarInfoWithFilter();
            this.ctrlFindClientInfo1 = new RentalCars.Clients.Controls.ctrlFindClientInfo();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtKLMTSpend);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDamageCostfees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRentalCarFees);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpCheckOutDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpCheckIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblReservationID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1347, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 1055);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservation Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(122, 868);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(266, 36);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "New Reservation ";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(0, 609);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(466, 194);
            this.txtNote.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 581);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Note :";
            // 
            // txtKLMTSpend
            // 
            this.txtKLMTSpend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKLMTSpend.Location = new System.Drawing.Point(14, 536);
            this.txtKLMTSpend.Name = "txtKLMTSpend";
            this.txtKLMTSpend.Size = new System.Drawing.Size(327, 30);
            this.txtKLMTSpend.TabIndex = 13;
            this.txtKLMTSpend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKLMTSpend_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "KLMTSpend";
            // 
            // txtDamageCostfees
            // 
            this.txtDamageCostfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamageCostfees.Location = new System.Drawing.Point(15, 437);
            this.txtDamageCostfees.Name = "txtDamageCostfees";
            this.txtDamageCostfees.Size = new System.Drawing.Size(327, 30);
            this.txtDamageCostfees.TabIndex = 11;
            this.txtDamageCostfees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDamageCostfees_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Damage Cost Fees";
            // 
            // txtRentalCarFees
            // 
            this.txtRentalCarFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRentalCarFees.Location = new System.Drawing.Point(20, 331);
            this.txtRentalCarFees.Name = "txtRentalCarFees";
            this.txtRentalCarFees.Size = new System.Drawing.Size(327, 30);
            this.txtRentalCarFees.TabIndex = 9;
            this.txtRentalCarFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRentalCarFees_KeyPress);
            this.txtRentalCarFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtRentalCarFees_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rental Car Fees";
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOutDate.Location = new System.Drawing.Point(15, 128);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(237, 34);
            this.dtpCheckOutDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Check Out Date:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(15, 227);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(237, 34);
            this.dtpCheckIn.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Car Return Date:";
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationID.Location = new System.Drawing.Point(171, 45);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(60, 25);
            this.lblReservationID.TabIndex = 1;
            this.lblReservationID.Text = "????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCarReturn
            // 
            this.btnCarReturn.Image = global::RentalCars.Properties.Resources.btnCarReturn;
            this.btnCarReturn.Location = new System.Drawing.Point(954, 969);
            this.btnCarReturn.Name = "btnCarReturn";
            this.btnCarReturn.Size = new System.Drawing.Size(180, 77);
            this.btnCarReturn.TabIndex = 5;
            this.btnCarReturn.UseVisualStyleBackColor = true;
            this.btnCarReturn.Click += new System.EventHandler(this.btnCarReturn_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RentalCars.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1140, 969);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 77);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRservation
            // 
            this.btnRservation.Image = global::RentalCars.Properties.Resources.GetReservation;
            this.btnRservation.Location = new System.Drawing.Point(1326, 969);
            this.btnRservation.Name = "btnRservation";
            this.btnRservation.Size = new System.Drawing.Size(180, 77);
            this.btnRservation.TabIndex = 3;
            this.btnRservation.UseVisualStyleBackColor = true;
            this.btnRservation.Click += new System.EventHandler(this.btnRservation_Click);
            // 
            // ctrlCarInfoWithFilter1
            // 
            this.ctrlCarInfoWithFilter1.FilterEnabled = true;
            this.ctrlCarInfoWithFilter1.Location = new System.Drawing.Point(91, 395);
            this.ctrlCarInfoWithFilter1.Name = "ctrlCarInfoWithFilter1";
            this.ctrlCarInfoWithFilter1.Size = new System.Drawing.Size(1256, 568);
            this.ctrlCarInfoWithFilter1.TabIndex = 1;
            // 
            // ctrlFindClientInfo1
            // 
            this.ctrlFindClientInfo1.FilterEnabled = true;
            this.ctrlFindClientInfo1.Location = new System.Drawing.Point(85, 12);
            this.ctrlFindClientInfo1.Name = "ctrlFindClientInfo1";
            this.ctrlFindClientInfo1.Size = new System.Drawing.Size(1256, 397);
            this.ctrlFindClientInfo1.TabIndex = 0;
            // 
            // frmCarReservationSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 1055);
            this.Controls.Add(this.btnCarReturn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRservation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlCarInfoWithFilter1);
            this.Controls.Add(this.ctrlFindClientInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCarReservationSection";
            this.Text = "frmCarReservationSection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCarReservationSection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Clients.Controls.ctrlFindClientInfo ctrlFindClientInfo1;
        private CarsContainer.Controls.ctrlCarInfoWithFilter ctrlCarInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReservationID;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKLMTSpend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDamageCostfees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRentalCarFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRservation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCarReturn;
        private System.Windows.Forms.Label lblTitle;
    }
}