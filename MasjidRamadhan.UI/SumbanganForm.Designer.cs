namespace MasjidRamadhan.UI
{
    partial class SumbanganForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namaTextBox = new System.Windows.Forms.TextBox();
            this.alamatTextBox = new System.Windows.Forms.TextBox();
            this.jumlahTextBox = new System.Windows.Forms.TextBox();
            this.keteranganTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.contohLabel = new System.Windows.Forms.Label();
            this.rpLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alamat";
            // 
            // namaTextBox
            // 
            this.namaTextBox.Location = new System.Drawing.Point(80, 38);
            this.namaTextBox.Name = "namaTextBox";
            this.namaTextBox.Size = new System.Drawing.Size(250, 20);
            this.namaTextBox.TabIndex = 2;
            // 
            // alamatTextBox
            // 
            this.alamatTextBox.Location = new System.Drawing.Point(381, 38);
            this.alamatTextBox.Name = "alamatTextBox";
            this.alamatTextBox.Size = new System.Drawing.Size(250, 20);
            this.alamatTextBox.TabIndex = 3;
            // 
            // jumlahTextBox
            // 
            this.jumlahTextBox.Location = new System.Drawing.Point(104, 64);
            this.jumlahTextBox.Name = "jumlahTextBox";
            this.jumlahTextBox.Size = new System.Drawing.Size(527, 20);
            this.jumlahTextBox.TabIndex = 4;
            this.jumlahTextBox.Text = "0";
            this.jumlahTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.jumlahTextBox_Validating);
            // 
            // keteranganTextBox
            // 
            this.keteranganTextBox.Location = new System.Drawing.Point(80, 148);
            this.keteranganTextBox.Name = "keteranganTextBox";
            this.keteranganTextBox.Size = new System.Drawing.Size(551, 20);
            this.keteranganTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jumlah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Keterangan";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(475, 174);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Simpan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tanggal";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(556, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Batal";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // contohLabel
            // 
            this.contohLabel.AutoSize = true;
            this.contohLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contohLabel.Location = new System.Drawing.Point(77, 87);
            this.contohLabel.Name = "contohLabel";
            this.contohLabel.Size = new System.Drawing.Size(61, 18);
            this.contohLabel.TabIndex = 13;
            this.contohLabel.Text = "Contoh:";
            // 
            // rpLabel
            // 
            this.rpLabel.AutoSize = true;
            this.rpLabel.Location = new System.Drawing.Point(77, 67);
            this.rpLabel.Name = "rpLabel";
            this.rpLabel.Size = new System.Drawing.Size(21, 13);
            this.rpLabel.TabIndex = 14;
            this.rpLabel.Text = "Rp";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SumbanganForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 209);
            this.Controls.Add(this.rpLabel);
            this.Controls.Add(this.contohLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keteranganTextBox);
            this.Controls.Add(this.jumlahTextBox);
            this.Controls.Add(this.alamatTextBox);
            this.Controls.Add(this.namaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SumbanganForm";
            this.Text = "Tambah Sumbangan";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox namaTextBox;
        private System.Windows.Forms.TextBox alamatTextBox;
        private System.Windows.Forms.TextBox jumlahTextBox;
        private System.Windows.Forms.TextBox keteranganTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label contohLabel;
        private System.Windows.Forms.Label rpLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}