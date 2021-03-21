
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
            this.checkboxpnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.auctionAndBuyrb = new System.Windows.Forms.RadioButton();
            this.buyNowOnlyrb = new System.Windows.Forms.RadioButton();
            this.auctionOnlyrb = new System.Windows.Forms.RadioButton();
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
            this.helpPicbx.Click += new System.EventHandler(this.helpPicbx_Click);
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
            // checkboxpnl
            // 
            this.checkboxpnl.BackColor = System.Drawing.Color.White;
            this.checkboxpnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkboxpnl.Controls.Add(this.label1);
            this.checkboxpnl.Controls.Add(this.auctionAndBuyrb);
            this.checkboxpnl.Controls.Add(this.buyNowOnlyrb);
            this.checkboxpnl.Controls.Add(this.auctionOnlyrb);
            this.checkboxpnl.Location = new System.Drawing.Point(660, 114);
            this.checkboxpnl.Name = "checkboxpnl";
            this.checkboxpnl.Size = new System.Drawing.Size(162, 106);
            this.checkboxpnl.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter by Buying Format";
            // 
            // auctionAndBuyrb
            // 
            this.auctionAndBuyrb.AutoSize = true;
            this.auctionAndBuyrb.Checked = true;
            this.auctionAndBuyrb.Location = new System.Drawing.Point(5, 26);
            this.auctionAndBuyrb.Name = "auctionAndBuyrb";
            this.auctionAndBuyrb.Size = new System.Drawing.Size(151, 19);
            this.auctionAndBuyrb.TabIndex = 9;
            this.auctionAndBuyrb.TabStop = true;
            this.auctionAndBuyrb.Text = "Auction and Buy It Now";
            this.auctionAndBuyrb.UseVisualStyleBackColor = true;
            // 
            // buyNowOnlyrb
            // 
            this.buyNowOnlyrb.AutoSize = true;
            this.buyNowOnlyrb.Location = new System.Drawing.Point(5, 76);
            this.buyNowOnlyrb.Name = "buyNowOnlyrb";
            this.buyNowOnlyrb.Size = new System.Drawing.Size(101, 19);
            this.buyNowOnlyrb.TabIndex = 8;
            this.buyNowOnlyrb.Text = "Buy Now Only";
            this.buyNowOnlyrb.UseVisualStyleBackColor = true;
            // 
            // auctionOnlyrb
            // 
            this.auctionOnlyrb.AutoSize = true;
            this.auctionOnlyrb.Location = new System.Drawing.Point(5, 51);
            this.auctionOnlyrb.Name = "auctionOnlyrb";
            this.auctionOnlyrb.Size = new System.Drawing.Size(95, 19);
            this.auctionOnlyrb.TabIndex = 7;
            this.auctionOnlyrb.Text = "Auction Only";
            this.auctionOnlyrb.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(834, 521);
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
        private System.Windows.Forms.Panel checkboxpnl;
        private System.Windows.Forms.RadioButton auctionOnlyrb;
        private System.Windows.Forms.RadioButton buyNowOnlyrb;
        private System.Windows.Forms.RadioButton auctionAndBuyrb;
        private System.Windows.Forms.Label label1;
    }
}

