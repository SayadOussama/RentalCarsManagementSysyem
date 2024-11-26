namespace RentalCars.CarsContainer
{
    partial class frmFindCar
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
            this.ctrlCarInfoWithFilter1 = new RentalCars.CarsContainer.Controls.ctrlCarInfoWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlCarInfoWithFilter1
            // 
            this.ctrlCarInfoWithFilter1.FilterEnabled = true;
            this.ctrlCarInfoWithFilter1.Location = new System.Drawing.Point(-9, 12);
            this.ctrlCarInfoWithFilter1.Name = "ctrlCarInfoWithFilter1";
            this.ctrlCarInfoWithFilter1.Size = new System.Drawing.Size(1344, 568);
            this.ctrlCarInfoWithFilter1.TabIndex = 0;
            this.ctrlCarInfoWithFilter1.Load += new System.EventHandler(this.ctrlCarInfoWithFilter1_Load);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::RentalCars.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1219, 588);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 135;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFindCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 626);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlCarInfoWithFilter1);
            this.Name = "frmFindCar";
            this.Text = "frmFindCar";
            this.Load += new System.EventHandler(this.frmFindCar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlCarInfoWithFilter ctrlCarInfoWithFilter1;
        private System.Windows.Forms.Button btnClose;
    }
}