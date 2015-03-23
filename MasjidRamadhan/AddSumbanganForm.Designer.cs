namespace MasjidRamadhan
{
    partial class AddSumbanganForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namaTextBox = new System.Windows.Forms.TextBox();
            this.alamatTextBox = new System.Windows.Forms.TextBox();
            this.jumlahTextBox = new System.Windows.Forms.TextBox();
            this.keteranganTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alamat";
            // 
            // namaTextBox
            // 
            this.namaTextBox.Location = new System.Drawing.Point(15, 25);
            this.namaTextBox.Name = "namaTextBox";
            this.namaTextBox.Size = new System.Drawing.Size(146, 20);
            this.namaTextBox.TabIndex = 2;
            // 
            // alamatTextBox
            // 
            this.alamatTextBox.Location = new System.Drawing.Point(167, 25);
            this.alamatTextBox.Name = "alamatTextBox";
            this.alamatTextBox.Size = new System.Drawing.Size(146, 20);
            this.alamatTextBox.TabIndex = 3;
            // 
            // jumlahTextBox
            // 
            this.jumlahTextBox.Location = new System.Drawing.Point(319, 25);
            this.jumlahTextBox.Name = "jumlahTextBox";
            this.jumlahTextBox.Size = new System.Drawing.Size(146, 20);
            this.jumlahTextBox.TabIndex = 4;
            // 
            // keteranganTextBox
            // 
            this.keteranganTextBox.Location = new System.Drawing.Point(471, 25);
            this.keteranganTextBox.Name = "keteranganTextBox";
            this.keteranganTextBox.Size = new System.Drawing.Size(146, 20);
            this.keteranganTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jumlah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Keterangan";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(542, 51);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Tambah";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // AddSumbanganForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 92);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keteranganTextBox);
            this.Controls.Add(this.jumlahTextBox);
            this.Controls.Add(this.alamatTextBox);
            this.Controls.Add(this.namaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddSumbanganForm";
            this.Text = "AddSumbanganForm";
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
        private System.Windows.Forms.Button addButton;
    }
}