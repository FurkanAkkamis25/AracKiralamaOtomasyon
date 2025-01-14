namespace RentACar
{
    partial class kirala
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBoxFiyat = new System.Windows.Forms.TextBox();
            this.textBoxGunSayisi = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelAracBilgisi = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentACar.Properties.Resources.FURKAN_6_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 648);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(43, 102);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(570, 344);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // textBoxFiyat
            // 
            this.textBoxFiyat.Location = new System.Drawing.Point(753, 133);
            this.textBoxFiyat.Name = "textBoxFiyat";
            this.textBoxFiyat.Size = new System.Drawing.Size(133, 20);
            this.textBoxFiyat.TabIndex = 2;
            // 
            // textBoxGunSayisi
            // 
            this.textBoxGunSayisi.Location = new System.Drawing.Point(753, 189);
            this.textBoxGunSayisi.Name = "textBoxGunSayisi";
            this.textBoxGunSayisi.Size = new System.Drawing.Size(133, 20);
            this.textBoxGunSayisi.TabIndex = 3;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.Info;
            this.button13.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button13.Location = new System.Drawing.Point(970, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(54, 35);
            this.button13.TabIndex = 16;
            this.button13.Text = "X";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Honeydew;
            this.button2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button2.Location = new System.Drawing.Point(910, 600);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 34);
            this.button2.TabIndex = 17;
            this.button2.Text = "Ana Sayfa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelAracBilgisi
            // 
            this.labelAracBilgisi.AutoSize = true;
            this.labelAracBilgisi.Location = new System.Drawing.Point(686, 259);
            this.labelAracBilgisi.Name = "labelAracBilgisi";
            this.labelAracBilgisi.Size = new System.Drawing.Size(35, 13);
            this.labelAracBilgisi.TabIndex = 18;
            this.labelAracBilgisi.Text = "label1";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Honeydew;
            this.btnKaydet.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnKaydet.Location = new System.Drawing.Point(845, 285);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 34);
            this.btnKaydet.TabIndex = 19;
            this.btnKaydet.Text = "ONAYLA";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // kirala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 646);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.labelAracBilgisi);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBoxGunSayisi);
            this.Controls.Add(this.textBoxFiyat);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kirala";
            this.Text = "kirala";
            this.Load += new System.EventHandler(this.kirala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox textBoxFiyat;
        private System.Windows.Forms.TextBox textBoxGunSayisi;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelAracBilgisi;
        private System.Windows.Forms.Button btnKaydet;
    }
}