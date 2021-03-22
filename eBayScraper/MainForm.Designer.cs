
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
            this.exportbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.freeAndPaidrb = new System.Windows.Forms.RadioButton();
            this.paidOnlyrb = new System.Windows.Forms.RadioButton();
            this.freeOnlyrb = new System.Windows.Forms.RadioButton();
            this.minPricebar = new System.Windows.Forms.TrackBar();
            this.minPricebx = new System.Windows.Forms.TextBox();
            this.maxPricebx = new System.Windows.Forms.TextBox();
            this.maxPricebar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.anypricerb = new System.Windows.Forms.RadioButton();
            this.definedPricerb = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).BeginInit();
            this.checkboxpnl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minPricebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPricebar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBx
            // 
            this.searchBx.Location = new System.Drawing.Point(167, 12);
            this.searchBx.Name = "searchBx";
            this.searchBx.Size = new System.Drawing.Size(489, 23);
            this.searchBx.TabIndex = 1;
            this.searchBx.Click += new System.EventHandler(this.searchBx_Click);
            this.searchBx.Leave += new System.EventHandler(this.searchBx_Leave);
            // 
            // resultsBx
            // 
            this.resultsBx.BackColor = System.Drawing.Color.White;
            this.resultsBx.Location = new System.Drawing.Point(22, 95);
            this.resultsBx.Multiline = true;
            this.resultsBx.Name = "resultsBx";
            this.resultsBx.ReadOnly = true;
            this.resultsBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsBx.Size = new System.Drawing.Size(634, 324);
            this.resultsBx.TabIndex = 1;
            // 
            // helpPicbx
            // 
            this.helpPicbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpPicbx.BackgroundImage")));
            this.helpPicbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPicbx.Location = new System.Drawing.Point(758, 12);
            this.helpPicbx.Name = "helpPicbx";
            this.helpPicbx.Size = new System.Drawing.Size(64, 63);
            this.helpPicbx.TabIndex = 3;
            this.helpPicbx.TabStop = false;
            this.helpPicbx.Click += new System.EventHandler(this.helpPicbx_Click);
            this.helpPicbx.MouseEnter += new System.EventHandler(this.helpPicbx_MouseEnter);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(676, 423);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(162, 25);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "SEARCH";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // statustxtbx
            // 
            this.statustxtbx.Location = new System.Drawing.Point(22, 65);
            this.statustxtbx.Name = "statustxtbx";
            this.statustxtbx.ReadOnly = true;
            this.statustxtbx.Size = new System.Drawing.Size(283, 23);
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
            this.checkboxpnl.Location = new System.Drawing.Point(676, 114);
            this.checkboxpnl.Name = "checkboxpnl";
            this.checkboxpnl.Size = new System.Drawing.Size(162, 106);
            this.checkboxpnl.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 3);
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
            this.buyNowOnlyrb.Size = new System.Drawing.Size(111, 19);
            this.buyNowOnlyrb.TabIndex = 8;
            this.buyNowOnlyrb.Text = "Buy It Now Only";
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
            // exportbtn
            // 
            this.exportbtn.Location = new System.Drawing.Point(676, 454);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(162, 25);
            this.exportbtn.TabIndex = 8;
            this.exportbtn.Text = "EXPORT";
            this.exportbtn.UseVisualStyleBackColor = true;
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.freeAndPaidrb);
            this.panel1.Controls.Add(this.paidOnlyrb);
            this.panel1.Controls.Add(this.freeOnlyrb);
            this.panel1.Location = new System.Drawing.Point(676, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 106);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter by Shipping Type";
            // 
            // freeAndPaidrb
            // 
            this.freeAndPaidrb.AutoSize = true;
            this.freeAndPaidrb.Checked = true;
            this.freeAndPaidrb.Location = new System.Drawing.Point(5, 26);
            this.freeAndPaidrb.Name = "freeAndPaidrb";
            this.freeAndPaidrb.Size = new System.Drawing.Size(96, 19);
            this.freeAndPaidrb.TabIndex = 9;
            this.freeAndPaidrb.TabStop = true;
            this.freeAndPaidrb.Text = "Free and Paid";
            this.freeAndPaidrb.UseVisualStyleBackColor = true;
            // 
            // paidOnlyrb
            // 
            this.paidOnlyrb.AutoSize = true;
            this.paidOnlyrb.Location = new System.Drawing.Point(5, 76);
            this.paidOnlyrb.Name = "paidOnlyrb";
            this.paidOnlyrb.Size = new System.Drawing.Size(76, 19);
            this.paidOnlyrb.TabIndex = 8;
            this.paidOnlyrb.Text = "Paid Only";
            this.paidOnlyrb.UseVisualStyleBackColor = true;
            // 
            // freeOnlyrb
            // 
            this.freeOnlyrb.AutoSize = true;
            this.freeOnlyrb.Location = new System.Drawing.Point(5, 51);
            this.freeOnlyrb.Name = "freeOnlyrb";
            this.freeOnlyrb.Size = new System.Drawing.Size(75, 19);
            this.freeOnlyrb.TabIndex = 7;
            this.freeOnlyrb.Text = "Free Only";
            this.freeOnlyrb.UseVisualStyleBackColor = true;
            // 
            // minPricebar
            // 
            this.minPricebar.Location = new System.Drawing.Point(22, 485);
            this.minPricebar.Maximum = 2000;
            this.minPricebar.Name = "minPricebar";
            this.minPricebar.Size = new System.Drawing.Size(422, 45);
            this.minPricebar.TabIndex = 11;
            this.minPricebar.TickFrequency = 60;
            this.minPricebar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.minPricebar.Scroll += new System.EventHandler(this.minPricebar_Scroll);
            // 
            // minPricebx
            // 
            this.minPricebx.Location = new System.Drawing.Point(22, 456);
            this.minPricebx.Name = "minPricebx";
            this.minPricebx.ReadOnly = true;
            this.minPricebx.Size = new System.Drawing.Size(161, 23);
            this.minPricebx.TabIndex = 13;
            // 
            // maxPricebx
            // 
            this.maxPricebx.Location = new System.Drawing.Point(450, 456);
            this.maxPricebx.Name = "maxPricebx";
            this.maxPricebx.ReadOnly = true;
            this.maxPricebx.Size = new System.Drawing.Size(161, 23);
            this.maxPricebx.TabIndex = 14;
            // 
            // maxPricebar
            // 
            this.maxPricebar.Location = new System.Drawing.Point(441, 485);
            this.maxPricebar.Maximum = 2000;
            this.maxPricebar.Name = "maxPricebar";
            this.maxPricebar.Size = new System.Drawing.Size(422, 45);
            this.maxPricebar.TabIndex = 15;
            this.maxPricebar.TickFrequency = 60;
            this.maxPricebar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.maxPricebar.Value = 2000;
            this.maxPricebar.Scroll += new System.EventHandler(this.maxPricebar_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.anypricerb);
            this.panel2.Controls.Add(this.definedPricerb);
            this.panel2.Location = new System.Drawing.Point(676, 338);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 81);
            this.panel2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(37, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Price Range";
            // 
            // anypricerb
            // 
            this.anypricerb.AutoSize = true;
            this.anypricerb.Checked = true;
            this.anypricerb.Location = new System.Drawing.Point(5, 26);
            this.anypricerb.Name = "anypricerb";
            this.anypricerb.Size = new System.Drawing.Size(46, 19);
            this.anypricerb.TabIndex = 9;
            this.anypricerb.TabStop = true;
            this.anypricerb.Text = "Any";
            this.anypricerb.UseVisualStyleBackColor = true;
            // 
            // definedPricerb
            // 
            this.definedPricerb.AutoSize = true;
            this.definedPricerb.Location = new System.Drawing.Point(5, 51);
            this.definedPricerb.Name = "definedPricerb";
            this.definedPricerb.Size = new System.Drawing.Size(101, 19);
            this.definedPricerb.TabIndex = 7;
            this.definedPricerb.Text = "Defined Below";
            this.definedPricerb.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(862, 541);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.maxPricebar);
            this.Controls.Add(this.maxPricebx);
            this.Controls.Add(this.minPricebx);
            this.Controls.Add(this.minPricebar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exportbtn);
            this.Controls.Add(this.checkboxpnl);
            this.Controls.Add(this.statustxtbx);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.helpPicbx);
            this.Controls.Add(this.resultsBx);
            this.Controls.Add(this.searchBx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eBay Scraper";
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).EndInit();
            this.checkboxpnl.ResumeLayout(false);
            this.checkboxpnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minPricebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPricebar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button exportbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton freeAndPaidrb;
        private System.Windows.Forms.RadioButton paidOnlyrb;
        private System.Windows.Forms.RadioButton freeOnlyrb;
        private System.Windows.Forms.TrackBar minPricebar;
        private System.Windows.Forms.TextBox minPricebx;
        private System.Windows.Forms.TextBox maxPricebx;
        private System.Windows.Forms.TrackBar maxPricebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton anypricerb;
        private System.Windows.Forms.RadioButton definedPricerb;
    }
}

