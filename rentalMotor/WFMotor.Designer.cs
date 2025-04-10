namespace rentalMotor
{
    partial class WFMotor
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
            ViewMotor = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnReset = new Button();
            btnSave = new Button();
            txtHargaSewa = new TextBox();
            txtPlatMotor = new TextBox();
            txtNamaMotor = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnRental = new Button();
            ((System.ComponentModel.ISupportInitialize)ViewMotor).BeginInit();
            SuspendLayout();
            // 
            // ViewMotor
            // 
            ViewMotor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewMotor.Location = new Point(12, 185);
            ViewMotor.Name = "ViewMotor";
            ViewMotor.Size = new Size(652, 274);
            ViewMotor.TabIndex = 23;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Location = new Point(555, 105);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 31);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ActiveCaption;
            btnUpdate.Location = new Point(555, 63);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 29);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(456, 146);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 20;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(555, 19);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 29);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtHargaSewa
            // 
            txtHargaSewa.Location = new Point(185, 105);
            txtHargaSewa.Name = "txtHargaSewa";
            txtHargaSewa.Size = new Size(346, 23);
            txtHargaSewa.TabIndex = 18;
            // 
            // txtPlatMotor
            // 
            txtPlatMotor.Location = new Point(185, 63);
            txtPlatMotor.Name = "txtPlatMotor";
            txtPlatMotor.Size = new Size(346, 23);
            txtPlatMotor.TabIndex = 17;
            // 
            // txtNamaMotor
            // 
            txtNamaMotor.Location = new Point(185, 21);
            txtNamaMotor.Name = "txtNamaMotor";
            txtNamaMotor.Size = new Size(346, 23);
            txtNamaMotor.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 105);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 15;
            label3.Text = "Harga Sewa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 63);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 14;
            label2.Text = "Plat Motor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 23);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 13;
            label1.Text = "Nama Kendaraan";
            // 
            // btnRental
            // 
            btnRental.Location = new Point(589, 469);
            btnRental.Name = "btnRental";
            btnRental.Size = new Size(75, 23);
            btnRental.TabIndex = 24;
            btnRental.Text = "Rentalan";
            btnRental.UseVisualStyleBackColor = true;
            btnRental.Click += btnRental_Click;
            // 
            // WFMotor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 504);
            Controls.Add(btnRental);
            Controls.Add(ViewMotor);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(txtHargaSewa);
            Controls.Add(txtPlatMotor);
            Controls.Add(txtNamaMotor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WFMotor";
            Text = "Motor";
            ((System.ComponentModel.ISupportInitialize)ViewMotor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ViewMotor;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnReset;
        private Button btnSave;
        private TextBox txtHargaSewa;
        private TextBox txtPlatMotor;
        private TextBox txtNamaMotor;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnRental;
    }
}