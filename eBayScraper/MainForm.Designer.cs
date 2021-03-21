
namespace eBayScraper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.searchBx = new System.Windows.Forms.TextBox();
            this.resultsBx = new System.Windows.Forms.TextBox();
            this.helpPicbx = new System.Windows.Forms.PictureBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.statustxtbx = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkboxpnl = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).BeginInit();
            this.checkboxpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBx
            // 
            this.searchBx.Location = new System.Drawing.Point(150, 12);
            this.searchBx.Name = "searchBx";
            this.searchBx.Size = new System.Drawing.Size(489, 23);
            this.searchBx.TabIndex = 1;
            this.searchBx.Click += new System.EventHandler(this.searchBx_Click);
            this.searchBx.Leave += new System.EventHandler(this.searchBx_Leave);
            // 
            // resultsBx
            // 
            this.resultsBx.BackColor = System.Drawing.Color.White;
            this.resultsBx.Location = new System.Drawing.Point(84, 114);
            this.resultsBx.Multiline = true;
            this.resultsBx.Name = "resultsBx";
            this.resultsBx.ReadOnly = true;
            this.resultsBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsBx.Size = new System.Drawing.Size(565, 395);
            this.resultsBx.TabIndex = 1;
            // 
            // helpPicbx
            // 
            this.helpPicbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpPicbx.BackgroundImage")));
            this.helpPicbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPicbx.Location = new System.Drawing.Point(717, 12);
            this.helpPicbx.Name = "helpPicbx";
            this.helpPicbx.Size = new System.Drawing.Size(80, 76);
            this.helpPicbx.TabIndex = 3;
            this.helpPicbx.TabStop = false;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(332, 41);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(127, 25);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "SEARCH";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // statustxtbx
            // 
            this.statustxtbx.Location = new System.Drawing.Point(84, 85);
            this.statustxtbx.Name = "statustxtbx";
            this.statustxtbx.ReadOnly = true;
            this.statustxtbx.Size = new System.Drawing.Size(221, 23);
            this.statustxtbx.TabIndex = 4;
            this.statustxtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Auction Only";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkboxpnl
            // 
            this.checkboxpnl.BackColor = System.Drawing.Color.White;
            this.checkboxpnl.Controls.Add(this.checkBox2);
            this.checkboxpnl.Controls.Add(this.checkBox1);
            this.checkboxpnl.Location = new System.Drawing.Point(679, 114);
            this.checkboxpnl.Name = "checkboxpnl";
            this.checkboxpnl.Size = new System.Drawing.Size(134, 157);
            this.checkboxpnl.TabIndex = 6;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 19);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(825, 521);
            this.Controls.Add(this.checkboxpnl);
            this.Controls.Add(this.statustxtbx);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.helpPicbx);
            this.Controls.Add(this.resultsBx);
            this.Controls.Add(this.searchBx);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eBay Scraper";
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).EndInit();
            this.checkboxpnl.ResumeLayout(false);
            this.checkboxpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBx;
        private System.Windows.Forms.PictureBox helpPicbx;
        private System.Windows.Forms.Button goBtn;
        public System.Windows.Forms.TextBox resultsBx;
        private System.Windows.Forms.TextBox statustxtbx;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel checkboxpnl;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

