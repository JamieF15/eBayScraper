
namespace eBayScraper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchBx = new System.Windows.Forms.TextBox();
            this.resultsBx = new System.Windows.Forms.TextBox();
            this.helpPicbx = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).BeginInit();
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
            this.resultsBx.Location = new System.Drawing.Point(84, 155);
            this.resultsBx.Multiline = true;
            this.resultsBx.Name = "resultsBx";
            this.resultsBx.ReadOnly = true;
            this.resultsBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsBx.Size = new System.Drawing.Size(630, 354);
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(84, 123);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 33);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "ID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(190, 123);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 33);
            this.textBox4.TabIndex = 5;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(813, 521);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.helpPicbx);
            this.Controls.Add(this.resultsBx);
            this.Controls.Add(this.searchBx);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.helpPicbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBx;
        private System.Windows.Forms.PictureBox helpPicbx;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button goBtn;
        public System.Windows.Forms.TextBox resultsBx;
    }
}

