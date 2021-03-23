
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
            this.tbsearch = new System.Windows.Forms.TextBox();
            this.tbresult = new System.Windows.Forms.TextBox();
            this.helpPicbx = new System.Windows.Forms.PictureBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.tbstatus = new System.Windows.Forms.TextBox();
            this.checkboxpnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbauctionandbuy = new System.Windows.Forms.RadioButton();
            this.rbbuyitnow = new System.Windows.Forms.RadioButton();
            this.rbauctiononly = new System.Windows.Forms.RadioButton();
            this.exportbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rbfreeandpaid = new System.Windows.Forms.RadioButton();
            this.rbpaidonly = new System.Windows.Forms.RadioButton();
            this.rbfreeonly = new System.Windows.Forms.RadioButton();
            this.minPricebar = new System.Windows.Forms.TrackBar();
            this.tbMinPrice = new System.Windows.Forms.TextBox();
            this.tbMaxPrice = new System.Windows.Forms.TextBox();
            this.maxPricebar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rbanyprice = new System.Windows.Forms.RadioButton();
            this.rbpricedefined = new System.Windows.Forms.RadioButton();
            this.resetbtn = new System.Windows.Forms.Button();
            this.lMaxPrice = new System.Windows.Forms.Label();
            this.lMinPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).BeginInit();
            this.checkboxpnl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minPricebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPricebar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(166, 21);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Size = new System.Drawing.Size(489, 23);
            this.tbsearch.TabIndex = 0;
            this.tbsearch.Click += new System.EventHandler(this.tbsearch_Click);
            this.tbsearch.Leave += new System.EventHandler(this.tbsearch_Leave);
            // 
            // tbresult
            // 
            this.tbresult.BackColor = System.Drawing.Color.White;
            this.tbresult.Location = new System.Drawing.Point(22, 95);
            this.tbresult.Multiline = true;
            this.tbresult.Name = "tbresult";
            this.tbresult.ReadOnly = true;
            this.tbresult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbresult.Size = new System.Drawing.Size(634, 395);
            this.tbresult.TabIndex = 1;
            this.tbresult.WordWrap = false;
            // 
            // helpPicbx
            // 
            this.helpPicbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpPicbx.BackgroundImage")));
            this.helpPicbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPicbx.Location = new System.Drawing.Point(785, 8);
            this.helpPicbx.Name = "helpPicbx";
            this.helpPicbx.Size = new System.Drawing.Size(64, 66);
            this.helpPicbx.TabIndex = 3;
            this.helpPicbx.TabStop = false;
            this.helpPicbx.Click += new System.EventHandler(this.helpPicbx_Click);
            this.helpPicbx.MouseEnter += new System.EventHandler(this.helpPicbx_MouseEnter);
            this.helpPicbx.MouseLeave += new System.EventHandler(this.helpPicbx_MouseLeave);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(687, 392);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(162, 25);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Search";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // tbstatus
            // 
            this.tbstatus.Location = new System.Drawing.Point(22, 65);
            this.tbstatus.Name = "tbstatus";
            this.tbstatus.ReadOnly = true;
            this.tbstatus.Size = new System.Drawing.Size(331, 23);
            this.tbstatus.TabIndex = 4;
            this.tbstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkboxpnl
            // 
            this.checkboxpnl.BackColor = System.Drawing.Color.White;
            this.checkboxpnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkboxpnl.Controls.Add(this.label1);
            this.checkboxpnl.Controls.Add(this.rbauctionandbuy);
            this.checkboxpnl.Controls.Add(this.rbbuyitnow);
            this.checkboxpnl.Controls.Add(this.rbauctiononly);
            this.checkboxpnl.Location = new System.Drawing.Point(673, 95);
            this.checkboxpnl.Name = "checkboxpnl";
            this.checkboxpnl.Size = new System.Drawing.Size(187, 102);
            this.checkboxpnl.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter by Buying Format";
            // 
            // rbauctionandbuy
            // 
            this.rbauctionandbuy.AutoSize = true;
            this.rbauctionandbuy.Checked = true;
            this.rbauctionandbuy.Location = new System.Drawing.Point(5, 24);
            this.rbauctionandbuy.Name = "rbauctionandbuy";
            this.rbauctionandbuy.Size = new System.Drawing.Size(151, 19);
            this.rbauctionandbuy.TabIndex = 9;
            this.rbauctionandbuy.TabStop = true;
            this.rbauctionandbuy.Text = "Auction and Buy It Now";
            this.rbauctionandbuy.UseVisualStyleBackColor = true;
            // 
            // rbbuyitnow
            // 
            this.rbbuyitnow.AutoSize = true;
            this.rbbuyitnow.Location = new System.Drawing.Point(5, 74);
            this.rbbuyitnow.Name = "rbbuyitnow";
            this.rbbuyitnow.Size = new System.Drawing.Size(111, 19);
            this.rbbuyitnow.TabIndex = 8;
            this.rbbuyitnow.Text = "Buy It Now Only";
            this.rbbuyitnow.UseVisualStyleBackColor = true;
            // 
            // rbauctiononly
            // 
            this.rbauctiononly.AutoSize = true;
            this.rbauctiononly.Location = new System.Drawing.Point(5, 49);
            this.rbauctiononly.Name = "rbauctiononly";
            this.rbauctiononly.Size = new System.Drawing.Size(95, 19);
            this.rbauctiononly.TabIndex = 7;
            this.rbauctiononly.Text = "Auction Only";
            this.rbauctiononly.UseVisualStyleBackColor = true;
            // 
            // exportbtn
            // 
            this.exportbtn.Location = new System.Drawing.Point(687, 423);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(162, 25);
            this.exportbtn.TabIndex = 8;
            this.exportbtn.Text = "Export";
            this.exportbtn.UseVisualStyleBackColor = true;
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbfreeandpaid);
            this.panel1.Controls.Add(this.rbpaidonly);
            this.panel1.Controls.Add(this.rbfreeonly);
            this.panel1.Location = new System.Drawing.Point(673, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 102);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter by Shipping Type";
            // 
            // rbfreeandpaid
            // 
            this.rbfreeandpaid.AutoSize = true;
            this.rbfreeandpaid.Checked = true;
            this.rbfreeandpaid.Location = new System.Drawing.Point(5, 26);
            this.rbfreeandpaid.Name = "rbfreeandpaid";
            this.rbfreeandpaid.Size = new System.Drawing.Size(96, 19);
            this.rbfreeandpaid.TabIndex = 9;
            this.rbfreeandpaid.TabStop = true;
            this.rbfreeandpaid.Text = "Free and Paid";
            this.rbfreeandpaid.UseVisualStyleBackColor = true;
            // 
            // rbpaidonly
            // 
            this.rbpaidonly.AutoSize = true;
            this.rbpaidonly.Location = new System.Drawing.Point(5, 76);
            this.rbpaidonly.Name = "rbpaidonly";
            this.rbpaidonly.Size = new System.Drawing.Size(76, 19);
            this.rbpaidonly.TabIndex = 8;
            this.rbpaidonly.Text = "Paid Only";
            this.rbpaidonly.UseVisualStyleBackColor = true;
            // 
            // rbfreeonly
            // 
            this.rbfreeonly.AutoSize = true;
            this.rbfreeonly.Location = new System.Drawing.Point(5, 51);
            this.rbfreeonly.Name = "rbfreeonly";
            this.rbfreeonly.Size = new System.Drawing.Size(75, 19);
            this.rbfreeonly.TabIndex = 7;
            this.rbfreeonly.Text = "Free Only";
            this.rbfreeonly.UseVisualStyleBackColor = true;
            // 
            // minPricebar
            // 
            this.minPricebar.Location = new System.Drawing.Point(25, 430);
            this.minPricebar.Maximum = 9999;
            this.minPricebar.Name = "minPricebar";
            this.minPricebar.Size = new System.Drawing.Size(422, 45);
            this.minPricebar.TabIndex = 11;
            this.minPricebar.TickFrequency = 9999;
            this.minPricebar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.minPricebar.ValueChanged += new System.EventHandler(this.minPricebar_ValueChanged);
            // 
            // tbMinPrice
            // 
            this.tbMinPrice.Location = new System.Drawing.Point(785, 354);
            this.tbMinPrice.Name = "tbMinPrice";
            this.tbMinPrice.Size = new System.Drawing.Size(78, 23);
            this.tbMinPrice.TabIndex = 13;
            // 
            // tbMaxPrice
            // 
            this.tbMaxPrice.Location = new System.Drawing.Point(785, 325);
            this.tbMaxPrice.Name = "tbMaxPrice";
            this.tbMaxPrice.Size = new System.Drawing.Size(78, 23);
            this.tbMaxPrice.TabIndex = 14;
            // 
            // maxPricebar
            // 
            this.maxPricebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxPricebar.LargeChange = 1;
            this.maxPricebar.Location = new System.Drawing.Point(39, 442);
            this.maxPricebar.Maximum = 10000;
            this.maxPricebar.Minimum = 1;
            this.maxPricebar.Name = "maxPricebar";
            this.maxPricebar.Size = new System.Drawing.Size(422, 45);
            this.maxPricebar.TabIndex = 15;
            this.maxPricebar.TickFrequency = 10;
            this.maxPricebar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.maxPricebar.Value = 9999;
            this.maxPricebar.ValueChanged += new System.EventHandler(this.maxPricebar_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbanyprice);
            this.panel2.Controls.Add(this.rbpricedefined);
            this.panel2.Location = new System.Drawing.Point(70, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 69);
            this.panel2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Price Range";
            // 
            // rbanyprice
            // 
            this.rbanyprice.AutoSize = true;
            this.rbanyprice.Checked = true;
            this.rbanyprice.Location = new System.Drawing.Point(5, 20);
            this.rbanyprice.Name = "rbanyprice";
            this.rbanyprice.Size = new System.Drawing.Size(46, 19);
            this.rbanyprice.TabIndex = 9;
            this.rbanyprice.TabStop = true;
            this.rbanyprice.Text = "Any";
            this.rbanyprice.UseVisualStyleBackColor = true;
            // 
            // rbpricedefined
            // 
            this.rbpricedefined.AutoSize = true;
            this.rbpricedefined.Location = new System.Drawing.Point(5, 45);
            this.rbpricedefined.Name = "rbpricedefined";
            this.rbpricedefined.Size = new System.Drawing.Size(101, 19);
            this.rbpricedefined.TabIndex = 7;
            this.rbpricedefined.Text = "Defined Below";
            this.rbpricedefined.UseVisualStyleBackColor = true;
            // 
            // resetbtn
            // 
            this.resetbtn.Location = new System.Drawing.Point(687, 454);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(162, 25);
            this.resetbtn.TabIndex = 16;
            this.resetbtn.Text = "Reset Filters";
            this.resetbtn.UseVisualStyleBackColor = true;
            this.resetbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // lMaxPrice
            // 
            this.lMaxPrice.AutoSize = true;
            this.lMaxPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lMaxPrice.ForeColor = System.Drawing.Color.White;
            this.lMaxPrice.Location = new System.Drawing.Point(664, 325);
            this.lMaxPrice.Name = "lMaxPrice";
            this.lMaxPrice.Size = new System.Drawing.Size(114, 20);
            this.lMaxPrice.TabIndex = 17;
            this.lMaxPrice.Text = "Maximum Price:";
            // 
            // lMinPrice
            // 
            this.lMinPrice.AutoSize = true;
            this.lMinPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lMinPrice.ForeColor = System.Drawing.Color.White;
            this.lMinPrice.Location = new System.Drawing.Point(664, 357);
            this.lMinPrice.Name = "lMinPrice";
            this.lMinPrice.Size = new System.Drawing.Size(111, 20);
            this.lMinPrice.TabIndex = 18;
            this.lMinPrice.Text = "Minimum Price:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(875, 499);
            this.Controls.Add(this.lMinPrice);
            this.Controls.Add(this.lMaxPrice);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.maxPricebar);
            this.Controls.Add(this.tbMaxPrice);
            this.Controls.Add(this.tbMinPrice);
            this.Controls.Add(this.minPricebar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exportbtn);
            this.Controls.Add(this.checkboxpnl);
            this.Controls.Add(this.tbstatus);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.helpPicbx);
            this.Controls.Add(this.tbresult);
            this.Controls.Add(this.tbsearch);
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

        private System.Windows.Forms.TextBox tbsearch;
        private System.Windows.Forms.PictureBox helpPicbx;
        private System.Windows.Forms.Button goBtn;
        public System.Windows.Forms.TextBox tbresult;
        private System.Windows.Forms.TextBox tbstatus;
        private System.Windows.Forms.Panel checkboxpnl;
        private System.Windows.Forms.RadioButton rbauctiononly;
        private System.Windows.Forms.RadioButton rbbuyitnow;
        private System.Windows.Forms.RadioButton rbauctionandbuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exportbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbfreeandpaid;
        private System.Windows.Forms.RadioButton rbpaidonly;
        private System.Windows.Forms.RadioButton rbfreeonly;
        private System.Windows.Forms.TrackBar minPricebar;
        private System.Windows.Forms.TextBox tbMinPrice;
        private System.Windows.Forms.TextBox tbMaxPrice;
        private System.Windows.Forms.TrackBar maxPricebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbanyprice;
        private System.Windows.Forms.RadioButton rbpricedefined;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Label lMaxPrice;
        private System.Windows.Forms.Label lMinPrice;
    }
}

