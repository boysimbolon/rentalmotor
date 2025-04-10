namespace rentalMotor
{
    partial class WFRentalMotor
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
            label1 = new Label();
            label2 = new Label();
            txtNama = new TextBox();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnReset = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            txtNoHp = new TextBox();
            label4 = new Label();
            txtLama = new TextBox();
            label3 = new Label();
            label5 = new Label();
            cmbMotor = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            cmbStatus = new ComboBox();
            dtTanggal = new DateTimePicker();
            btnMotor = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Nama Penyewa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(126, 21);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(220, 23);
            txtNama.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(126, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(589, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 32);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(479, 137);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 31);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ActiveCaption;
            btnUpdate.Location = new Point(589, 47);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 33);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Location = new Point(589, 86);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 34);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 191);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(652, 274);
            dataGridView1.TabIndex = 12;
            // 
            // txtNoHp
            // 
            txtNoHp.Location = new Point(126, 77);
            txtNoHp.Name = "txtNoHp";
            txtNoHp.Size = new Size(220, 23);
            txtNoHp.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 80);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 13;
            label4.Text = "No HP.";
            // 
            // txtLama
            // 
            txtLama.Location = new Point(465, 21);
            txtLama.Name = "txtLama";
            txtLama.Size = new Size(50, 23);
            txtLama.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(361, 27);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 15;
            label3.Text = "Lama Sewa (Jam)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 109);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 17;
            label5.Text = "Motor yang Disewa";
            // 
            // cmbMotor
            // 
            cmbMotor.FormattingEnabled = true;
            cmbMotor.Location = new Point(126, 105);
            cmbMotor.Name = "cmbMotor";
            cmbMotor.Size = new Size(220, 23);
            cmbMotor.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(361, 58);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 19;
            label6.Text = "Tanggal Sewa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(363, 89);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 21;
            label7.Text = "Status Sewa";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(465, 89);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(89, 23);
            cmbStatus.TabIndex = 22;
            // 
            // dtTanggal
            // 
            dtTanggal.Location = new Point(465, 60);
            dtTanggal.Name = "dtTanggal";
            dtTanggal.Size = new Size(70, 23);
            dtTanggal.TabIndex = 23;
            // 
            // btnMotor
            // 
            btnMotor.Location = new Point(573, 474);
            btnMotor.Name = "btnMotor";
            btnMotor.Size = new Size(91, 28);
            btnMotor.TabIndex = 24;
            btnMotor.Text = "Motor";
            btnMotor.UseVisualStyleBackColor = true;
            btnMotor.Click += btnMotor_Click;
            // 
            // WFRentalMotor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 511);
            Controls.Add(btnMotor);
            Controls.Add(dtTanggal);
            Controls.Add(cmbStatus);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbMotor);
            Controls.Add(label5);
            Controls.Add(txtLama);
            Controls.Add(label3);
            Controls.Add(txtNoHp);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(txtNama);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WFRentalMotor";
            Text = "WFRentalMotor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNama;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnReset;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private TextBox txtNoHp;
        private Label label4;
        private TextBox txtLama;
        private Label label3;
        private Label label5;
        private ComboBox cmbMotor;
        private Label label6;
        private Label label7;
        private ComboBox cmbStatus;
        private DateTimePicker dtTanggal;
        private Button btnMotor;
    }
}