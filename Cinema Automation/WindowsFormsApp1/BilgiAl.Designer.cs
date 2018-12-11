namespace WindowsFormsApp1
{
    partial class BilgiAl
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.button17 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.comboBox11);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.dataGridView4);
            this.groupBox5.Controls.Add(this.button17);
            this.groupBox5.Controls.Add(this.button15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.button16);
            this.groupBox5.Location = new System.Drawing.Point(12, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1005, 224);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bilgi Al";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(388, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 17);
            this.label24.TabIndex = 19;
            this.label24.Text = "Şehir Seçiniz:";
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(484, 13);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(121, 24);
            this.comboBox11.TabIndex = 18;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(35, 115);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(240, 17);
            this.label23.TabIndex = 17;
            this.label23.Text = "Şehre Göre Satılan Bilet Sayısını Gör";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(352, 47);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(317, 150);
            this.dataGridView4.TabIndex = 12;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(100, 135);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(95, 53);
            this.button17.TabIndex = 16;
            this.button17.Text = "Bilet Sayısı";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button15.Font = new System.Drawing.Font("Imprint MT Shadow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.DarkOrange;
            this.button15.Location = new System.Drawing.Point(87, 38);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(123, 41);
            this.button15.TabIndex = 11;
            this.button15.Text = "Sinema Gör";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(746, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Tüm Şehirlerdeki Sinemaları Gör";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Highlight;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(45, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Seçili Şehirdeki Siinemaları Gör";
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button16.Font = new System.Drawing.Font("Imprint MT Shadow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.DarkOrange;
            this.button16.Location = new System.Drawing.Point(790, 115);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(126, 44);
            this.button16.TabIndex = 14;
            this.button16.Text = "Sinema Gör";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // BilgiAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 309);
            this.Controls.Add(this.groupBox5);
            this.Name = "BilgiAl";
            this.Text = "BilgiAl";
            this.Load += new System.EventHandler(this.BilgiAl_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button16;
    }
}