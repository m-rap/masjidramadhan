namespace MasjidRamadhan.UI
{
    partial class PengeluaranForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.alamatTextBox = new System.Windows.Forms.TextBox();
            this.tokoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.BarangColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatuanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubtotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(64, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tanggal:";
            // 
            // alamatTextBox
            // 
            this.alamatTextBox.Location = new System.Drawing.Point(344, 38);
            this.alamatTextBox.Name = "alamatTextBox";
            this.alamatTextBox.Size = new System.Drawing.Size(253, 20);
            this.alamatTextBox.TabIndex = 12;
            // 
            // tokoTextBox
            // 
            this.tokoTextBox.Location = new System.Drawing.Point(64, 38);
            this.tokoTextBox.Name = "tokoTextBox";
            this.tokoTextBox.Size = new System.Drawing.Size(229, 20);
            this.tokoTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Alamat:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Toko:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BarangColumn,
            this.SatuanColumn,
            this.JumlahColumn,
            this.HargaColumn,
            this.SubtotalColumn});
            this.dataGridView1.Location = new System.Drawing.Point(15, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(582, 217);
            this.dataGridView1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Daftar Barang:";
            // 
            // BarangColumn
            // 
            this.BarangColumn.HeaderText = "Nama Barang";
            this.BarangColumn.Name = "BarangColumn";
            this.BarangColumn.Width = 150;
            // 
            // SatuanColumn
            // 
            this.SatuanColumn.HeaderText = "Satuan";
            this.SatuanColumn.Name = "SatuanColumn";
            this.SatuanColumn.Width = 50;
            // 
            // JumlahColumn
            // 
            this.JumlahColumn.HeaderText = "Jumlah Satuan";
            this.JumlahColumn.Name = "JumlahColumn";
            this.JumlahColumn.Width = 50;
            // 
            // HargaColumn
            // 
            this.HargaColumn.HeaderText = "Harga Satuan";
            this.HargaColumn.Name = "HargaColumn";
            // 
            // SubtotalColumn
            // 
            this.SubtotalColumn.HeaderText = "Harga Subtotal";
            this.SubtotalColumn.Name = "SubtotalColumn";
            this.SubtotalColumn.Width = 150;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(397, 306);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(441, 332);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Simpan";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(522, 332);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Batal";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PengeluaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 367);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.alamatTextBox);
            this.Controls.Add(this.tokoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PengeluaranForm";
            this.Text = "PengeluaranForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alamatTextBox;
        private System.Windows.Forms.TextBox tokoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatuanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtotalColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}