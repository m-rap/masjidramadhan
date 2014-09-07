namespace MasjidRamadhan
{
    partial class Form1
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
            this.webBrowser_besar = new System.Windows.Forms.WebBrowser();
            this.timer_panelBesar = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.webBrowser_bawah1 = new System.Windows.Forms.WebBrowser();
            this.webBrowser_bawah2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser_bawah3 = new System.Windows.Forms.WebBrowser();
            this.webBrowser_bawah4 = new System.Windows.Forms.WebBrowser();
            this.webBrowser_bawah5 = new System.Windows.Forms.WebBrowser();
            this.panel_video = new System.Windows.Forms.Panel();
            this.panel2 = new MasjidRamadhan.DoubleBufferedPanel(this.components);
            this.label_berjalan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_teksBerjalan = new System.Windows.Forms.Timer(this.components);
            this.timer_panelBawah1 = new System.Windows.Forms.Timer(this.components);
            this.timer_panelBawah2 = new System.Windows.Forms.Timer(this.components);
            this.timer_panelBawah3 = new System.Windows.Forms.Timer(this.components);
            this.timer_panelBawah4 = new System.Windows.Forms.Timer(this.components);
            this.timer_panelBawah5 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser_besar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.webBrowser_besar, 3);
            this.webBrowser_besar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_besar.Location = new System.Drawing.Point(3, 3);
            this.webBrowser_besar.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_besar.Name = "webBrowser_besar";
            this.tableLayoutPanel1.SetRowSpan(this.webBrowser_besar, 2);
            this.webBrowser_besar.ScrollBarsEnabled = false;
            this.webBrowser_besar.Size = new System.Drawing.Size(393, 276);
            this.webBrowser_besar.TabIndex = 2;
            // 
            // timer_panelBesar
            // 
            this.timer_panelBesar.Interval = 5000;
            this.timer_panelBesar.Tick += new System.EventHandler(this.timer_panelBesar_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_besar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_bawah1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_bawah2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_bawah3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_bawah4, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_bawah5, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel_video, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 464);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // webBrowser_bawah1
            // 
            this.webBrowser_bawah1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_bawah1.Location = new System.Drawing.Point(3, 325);
            this.webBrowser_bawah1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_bawah1.Name = "webBrowser_bawah1";
            this.webBrowser_bawah1.ScrollBarsEnabled = false;
            this.webBrowser_bawah1.Size = new System.Drawing.Size(127, 136);
            this.webBrowser_bawah1.TabIndex = 4;
            // 
            // webBrowser_bawah2
            // 
            this.webBrowser_bawah2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_bawah2.Location = new System.Drawing.Point(136, 325);
            this.webBrowser_bawah2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_bawah2.Name = "webBrowser_bawah2";
            this.webBrowser_bawah2.ScrollBarsEnabled = false;
            this.webBrowser_bawah2.Size = new System.Drawing.Size(127, 136);
            this.webBrowser_bawah2.TabIndex = 5;
            // 
            // webBrowser_bawah3
            // 
            this.webBrowser_bawah3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_bawah3.Location = new System.Drawing.Point(269, 325);
            this.webBrowser_bawah3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_bawah3.Name = "webBrowser_bawah3";
            this.webBrowser_bawah3.ScrollBarsEnabled = false;
            this.webBrowser_bawah3.Size = new System.Drawing.Size(127, 136);
            this.webBrowser_bawah3.TabIndex = 6;
            // 
            // webBrowser_bawah4
            // 
            this.webBrowser_bawah4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_bawah4.Location = new System.Drawing.Point(402, 325);
            this.webBrowser_bawah4.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_bawah4.Name = "webBrowser_bawah4";
            this.webBrowser_bawah4.ScrollBarsEnabled = false;
            this.webBrowser_bawah4.Size = new System.Drawing.Size(127, 136);
            this.webBrowser_bawah4.TabIndex = 7;
            // 
            // webBrowser_bawah5
            // 
            this.webBrowser_bawah5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_bawah5.Location = new System.Drawing.Point(535, 325);
            this.webBrowser_bawah5.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_bawah5.Name = "webBrowser_bawah5";
            this.webBrowser_bawah5.ScrollBarsEnabled = false;
            this.webBrowser_bawah5.Size = new System.Drawing.Size(131, 136);
            this.webBrowser_bawah5.TabIndex = 8;
            // 
            // panel_video
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_video, 2);
            this.panel_video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_video.Location = new System.Drawing.Point(402, 3);
            this.panel_video.Name = "panel_video";
            this.panel_video.Size = new System.Drawing.Size(264, 135);
            this.panel_video.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.label_berjalan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 34);
            this.panel2.TabIndex = 11;
            // 
            // label_berjalan
            // 
            this.label_berjalan.AutoSize = true;
            this.label_berjalan.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_berjalan.Location = new System.Drawing.Point(590, 4);
            this.label_berjalan.Name = "label_berjalan";
            this.label_berjalan.Size = new System.Drawing.Size(65, 26);
            this.label_berjalan.TabIndex = 10;
            this.label_berjalan.Text = "label1";
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MasjidRamadhan.Properties.Resources.panel_kanan;
            this.pictureBox1.Location = new System.Drawing.Point(402, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // timer_teksBerjalan
            // 
            this.timer_teksBerjalan.Interval = 50;
            this.timer_teksBerjalan.Tick += new System.EventHandler(this.timer_teksBerjalan_Tick);
            // 
            // timer_panelBawah1
            // 
            this.timer_panelBawah1.Interval = 5000;
            this.timer_panelBawah1.Tick += new System.EventHandler(this.timer_panelBawah1_Tick);
            // 
            // timer_panelBawah2
            // 
            this.timer_panelBawah2.Interval = 5000;
            this.timer_panelBawah2.Tick += new System.EventHandler(this.timer_panelBawah2_Tick);
            // 
            // timer_panelBawah3
            // 
            this.timer_panelBawah3.Interval = 5000;
            this.timer_panelBawah3.Tick += new System.EventHandler(this.timer_panelBawah3_Tick);
            // 
            // timer_panelBawah4
            // 
            this.timer_panelBawah4.Interval = 5000;
            this.timer_panelBawah4.Tick += new System.EventHandler(this.timer_panelBawah4_Tick);
            // 
            // timer_panelBawah5
            // 
            this.timer_panelBawah5.Interval = 5000;
            this.timer_panelBawah5.Tick += new System.EventHandler(this.timer_panelBawah5_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_besar;
        private System.Windows.Forms.Timer timer_panelBesar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser webBrowser_bawah1;
        private System.Windows.Forms.WebBrowser webBrowser_bawah2;
        private System.Windows.Forms.WebBrowser webBrowser_bawah3;
        private System.Windows.Forms.WebBrowser webBrowser_bawah4;
        private System.Windows.Forms.WebBrowser webBrowser_bawah5;
        private System.Windows.Forms.Panel panel_video;
        private System.Windows.Forms.Timer timer_teksBerjalan;
        private DoubleBufferedPanel panel2;
        private System.Windows.Forms.Label label_berjalan;
        private System.Windows.Forms.Timer timer_panelBawah1;
        private System.Windows.Forms.Timer timer_panelBawah2;
        private System.Windows.Forms.Timer timer_panelBawah3;
        private System.Windows.Forms.Timer timer_panelBawah4;
        private System.Windows.Forms.Timer timer_panelBawah5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

