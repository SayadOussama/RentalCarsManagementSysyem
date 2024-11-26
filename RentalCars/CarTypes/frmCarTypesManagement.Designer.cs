namespace RentalCars.CarTypes
{
    partial class frmCarTypesManagement
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
            this.dgvCarTypes = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewCarTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCarTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCarTypes
            // 
            this.dgvCarTypes.AllowUserToAddRows = false;
            this.dgvCarTypes.AllowUserToDeleteRows = false;
            this.dgvCarTypes.AllowUserToOrderColumns = true;
            this.dgvCarTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCarTypes.Location = new System.Drawing.Point(138, 232);
            this.dgvCarTypes.Name = "dgvCarTypes";
            this.dgvCarTypes.ReadOnly = true;
            this.dgvCarTypes.RowHeadersWidth = 51;
            this.dgvCarTypes.RowTemplate.Height = 24;
            this.dgvCarTypes.Size = new System.Drawing.Size(722, 299);
            this.dgvCarTypes.TabIndex = 149;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(134, 545);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(29, 20);
            this.lblRecordsCount.TabIndex = 152;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 151;
            this.label2.Text = "# Records:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentalCars.Properties.Resources.Car_Type_New;
            this.pictureBox1.Location = new System.Drawing.Point(-301, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1576, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 154;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(58, -7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(852, 59);
            this.lblTitle.TabIndex = 153;
            this.lblTitle.Text = "Car Type Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCarTypeToolStripMenuItem,
            this.updateCarTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(255, 80);
            // 
            // addNewCarTypeToolStripMenuItem
            // 
            this.addNewCarTypeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewCarTypeToolStripMenuItem.Image = global::RentalCars.Properties.Resources.CarDetails;
            this.addNewCarTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewCarTypeToolStripMenuItem.Name = "addNewCarTypeToolStripMenuItem";
            this.addNewCarTypeToolStripMenuItem.Size = new System.Drawing.Size(254, 38);
            this.addNewCarTypeToolStripMenuItem.Text = "Add New Car Type";
            this.addNewCarTypeToolStripMenuItem.Click += new System.EventHandler(this.addNewCarTypeToolStripMenuItem_Click);
            // 
            // updateCarTypeToolStripMenuItem
            // 
            this.updateCarTypeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCarTypeToolStripMenuItem.Image = global::RentalCars.Properties.Resources.update_Reservation;
            this.updateCarTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateCarTypeToolStripMenuItem.Name = "updateCarTypeToolStripMenuItem";
            this.updateCarTypeToolStripMenuItem.Size = new System.Drawing.Size(254, 38);
            this.updateCarTypeToolStripMenuItem.Text = "Update Car Type";
            this.updateCarTypeToolStripMenuItem.Click += new System.EventHandler(this.updateCarTypeToolStripMenuItem_Click);
            // 
            // frmCarTypesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 574);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCarTypes);
            this.Name = "frmCarTypesManagement";
            this.Text = "frmCarTypesManagement";
            this.Load += new System.EventHandler(this.frmCarTypesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarTypes;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewCarTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCarTypeToolStripMenuItem;
    }
}