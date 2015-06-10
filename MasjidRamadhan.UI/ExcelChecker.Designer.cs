namespace MasjidRamadhan.UI
{
    partial class ExcelChecker
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.sheetLabel = new System.Windows.Forms.Label();
            this.sheetTextBox = new System.Windows.Forms.TextBox();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.rangeTextBox = new System.Windows.Forms.TextBox();
            this.validDgv = new System.Windows.Forms.DataGridView();
            this.colnamesTextBox = new System.Windows.Forms.TextBox();
            this.errorDgv = new System.Windows.Forms.DataGridView();
            this.colnamesLabel = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearTextBox = new System.Windows.Forms.NumericUpDown();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.validDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(12, 15);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(23, 13);
            this.fileLabel.TabIndex = 0;
            this.fileLabel.Text = "File";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(57, 12);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(121, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(184, 11);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 20);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // sheetLabel
            // 
            this.sheetLabel.AutoSize = true;
            this.sheetLabel.Location = new System.Drawing.Point(12, 41);
            this.sheetLabel.Name = "sheetLabel";
            this.sheetLabel.Size = new System.Drawing.Size(35, 13);
            this.sheetLabel.TabIndex = 3;
            this.sheetLabel.Text = "Sheet";
            // 
            // sheetTextBox
            // 
            this.sheetTextBox.Location = new System.Drawing.Point(57, 38);
            this.sheetTextBox.Name = "sheetTextBox";
            this.sheetTextBox.Size = new System.Drawing.Size(155, 20);
            this.sheetTextBox.TabIndex = 4;
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(12, 67);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(39, 13);
            this.rangeLabel.TabIndex = 5;
            this.rangeLabel.Text = "Range";
            // 
            // rangeTextBox
            // 
            this.rangeTextBox.Location = new System.Drawing.Point(57, 64);
            this.rangeTextBox.Name = "rangeTextBox";
            this.rangeTextBox.Size = new System.Drawing.Size(155, 20);
            this.rangeTextBox.TabIndex = 6;
            // 
            // validDgv
            // 
            this.validDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.validDgv.Location = new System.Drawing.Point(218, 12);
            this.validDgv.Name = "validDgv";
            this.validDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.validDgv.Size = new System.Drawing.Size(454, 250);
            this.validDgv.TabIndex = 13;
            // 
            // colnamesTextBox
            // 
            this.colnamesTextBox.Location = new System.Drawing.Point(57, 90);
            this.colnamesTextBox.Multiline = true;
            this.colnamesTextBox.Name = "colnamesTextBox";
            this.colnamesTextBox.Size = new System.Drawing.Size(155, 143);
            this.colnamesTextBox.TabIndex = 7;
            this.colnamesTextBox.WordWrap = false;
            // 
            // errorDgv
            // 
            this.errorDgv.AllowUserToAddRows = false;
            this.errorDgv.AllowUserToDeleteRows = false;
            this.errorDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorDgv.Location = new System.Drawing.Point(218, 268);
            this.errorDgv.Name = "errorDgv";
            this.errorDgv.ReadOnly = true;
            this.errorDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.errorDgv.Size = new System.Drawing.Size(454, 255);
            this.errorDgv.TabIndex = 14;
            // 
            // colnamesLabel
            // 
            this.colnamesLabel.AutoSize = true;
            this.colnamesLabel.Location = new System.Drawing.Point(12, 93);
            this.colnamesLabel.Name = "colnamesLabel";
            this.colnamesLabel.Size = new System.Drawing.Size(27, 13);
            this.colnamesLabel.TabIndex = 10;
            this.colnamesLabel.Text = "Cols";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(57, 323);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 11;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "Januari",
            "Februari",
            "Maret",
            "April",
            "Mei",
            "Juni",
            "Agustus",
            "September",
            "Oktober",
            "November",
            "Desember"});
            this.monthComboBox.Location = new System.Drawing.Point(57, 241);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(121, 21);
            this.monthComboBox.TabIndex = 8;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearTextBox.Location = new System.Drawing.Point(57, 268);
            this.yearTextBox.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.yearTextBox.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(84, 20);
            this.yearTextBox.TabIndex = 9;
            this.yearTextBox.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(12, 244);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(37, 13);
            this.monthLabel.TabIndex = 14;
            this.monthLabel.Text = "Month";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(12, 270);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 13);
            this.yearLabel.TabIndex = 15;
            this.yearLabel.Text = "Year";
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(57, 352);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 12;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(57, 294);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // ExcelChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 535);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.colnamesLabel);
            this.Controls.Add(this.errorDgv);
            this.Controls.Add(this.colnamesTextBox);
            this.Controls.Add(this.validDgv);
            this.Controls.Add(this.rangeTextBox);
            this.Controls.Add(this.rangeLabel);
            this.Controls.Add(this.sheetTextBox);
            this.Controls.Add(this.sheetLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.fileLabel);
            this.Name = "ExcelChecker";
            this.Text = "Excel Checker";
            ((System.ComponentModel.ISupportInitialize)(this.validDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label sheetLabel;
        private System.Windows.Forms.TextBox sheetTextBox;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.TextBox rangeTextBox;
        private System.Windows.Forms.DataGridView validDgv;
        private System.Windows.Forms.TextBox colnamesTextBox;
        private System.Windows.Forms.DataGridView errorDgv;
        private System.Windows.Forms.Label colnamesLabel;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.NumericUpDown yearTextBox;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button loadButton;
    }
}