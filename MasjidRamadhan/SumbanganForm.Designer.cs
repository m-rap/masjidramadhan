namespace MasjidRamadhan
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
            this.sumbanganDgv = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sumbanganDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // sumbanganDgv
            // 
            this.sumbanganDgv.AllowUserToAddRows = false;
            this.sumbanganDgv.AllowUserToDeleteRows = false;
            this.sumbanganDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sumbanganDgv.Location = new System.Drawing.Point(12, 12);
            this.sumbanganDgv.Name = "sumbanganDgv";
            this.sumbanganDgv.ReadOnly = true;
            this.sumbanganDgv.Size = new System.Drawing.Size(536, 213);
            this.sumbanganDgv.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 231);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Tambah";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // SumbanganForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 266);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sumbanganDgv);
            this.Name = "SumbanganForm";
            this.Text = "SumbanganForm";
            this.Load += new System.EventHandler(this.SumbanganForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sumbanganDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sumbanganDgv;
        private System.Windows.Forms.Button addButton;
    }
}