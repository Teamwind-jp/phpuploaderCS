namespace phpuploaderCS
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.ComboBox2 = new System.Windows.Forms.ComboBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtPsw = new System.Windows.Forms.TextBox();
			this.lblmsg = new System.Windows.Forms.Label();
			this.TextBox6 = new System.Windows.Forms.TextBox();
			this.TextBox5 = new System.Windows.Forms.TextBox();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(213, 266);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(38, 12);
			this.Label7.TabIndex = 53;
			this.Label7.Text = "MByte";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(26, 266);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(45, 12);
			this.Label6.TabIndex = 52;
			this.Label6.Text = "cut size";
			// 
			// ComboBox2
			// 
			this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ComboBox2.FormattingEnabled = true;
			this.ComboBox2.Location = new System.Drawing.Point(86, 257);
			this.ComboBox2.Name = "ComboBox2";
			this.ComboBox2.Size = new System.Drawing.Size(121, 27);
			this.ComboBox2.TabIndex = 51;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(26, 298);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(43, 12);
			this.Label5.TabIndex = 50;
			this.Label5.Text = "zip psw";
			// 
			// txtPsw
			// 
			this.txtPsw.AllowDrop = true;
			this.txtPsw.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtPsw.Location = new System.Drawing.Point(86, 290);
			this.txtPsw.Margin = new System.Windows.Forms.Padding(4);
			this.txtPsw.MaxLength = 100;
			this.txtPsw.Name = "txtPsw";
			this.txtPsw.Size = new System.Drawing.Size(392, 23);
			this.txtPsw.TabIndex = 49;
			this.txtPsw.Tag = "1";
			// 
			// lblmsg
			// 
			this.lblmsg.Location = new System.Drawing.Point(29, 372);
			this.lblmsg.Name = "lblmsg";
			this.lblmsg.Size = new System.Drawing.Size(449, 21);
			this.lblmsg.TabIndex = 48;
			this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TextBox6
			// 
			this.TextBox6.AllowDrop = true;
			this.TextBox6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TextBox6.Location = new System.Drawing.Point(24, 222);
			this.TextBox6.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox6.MaxLength = 1024;
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.Size = new System.Drawing.Size(454, 23);
			this.TextBox6.TabIndex = 47;
			this.TextBox6.Tag = "1";
			// 
			// TextBox5
			// 
			this.TextBox5.AllowDrop = true;
			this.TextBox5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TextBox5.Location = new System.Drawing.Point(24, 191);
			this.TextBox5.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox5.MaxLength = 1024;
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.Size = new System.Drawing.Size(454, 23);
			this.TextBox5.TabIndex = 46;
			this.TextBox5.Tag = "1";
			// 
			// TextBox4
			// 
			this.TextBox4.AllowDrop = true;
			this.TextBox4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TextBox4.Location = new System.Drawing.Point(24, 160);
			this.TextBox4.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox4.MaxLength = 1024;
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.Size = new System.Drawing.Size(454, 23);
			this.TextBox4.TabIndex = 45;
			this.TextBox4.Tag = "1";
			// 
			// TextBox3
			// 
			this.TextBox3.AllowDrop = true;
			this.TextBox3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TextBox3.Location = new System.Drawing.Point(24, 129);
			this.TextBox3.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox3.MaxLength = 1024;
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(454, 23);
			this.TextBox3.TabIndex = 44;
			this.TextBox3.Tag = "1";
			// 
			// TextBox2
			// 
			this.TextBox2.AllowDrop = true;
			this.TextBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TextBox2.Location = new System.Drawing.Point(24, 98);
			this.TextBox2.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox2.MaxLength = 1024;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(454, 23);
			this.TextBox2.TabIndex = 43;
			this.TextBox2.Tag = "1";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(28, 82);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(104, 12);
			this.Label3.TabIndex = 42;
			this.Label3.Text = "drag backup folder ";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(26, 346);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(55, 12);
			this.Label2.TabIndex = 41;
			this.Label2.Text = "start hour";
			// 
			// ComboBox1
			// 
			this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "now"});
			this.ComboBox1.Location = new System.Drawing.Point(84, 337);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(121, 27);
			this.ComboBox1.TabIndex = 40;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(28, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(215, 12);
			this.Label1.TabIndex = 39;
			this.Label1.Text = "upload url 「http://hoge.com/receive.php」";
			// 
			// txtUrl
			// 
			this.txtUrl.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtUrl.Location = new System.Drawing.Point(24, 37);
			this.txtUrl.MaxLength = 1024;
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(454, 26);
			this.txtUrl.TabIndex = 38;
			// 
			// Button1
			// 
			this.Button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Button1.Location = new System.Drawing.Point(210, 334);
			this.Button1.Margin = new System.Windows.Forms.Padding(2);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(268, 31);
			this.Button1.TabIndex = 37;
			this.Button1.Text = "start";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 388);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.ComboBox2);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtPsw);
			this.Controls.Add(this.lblmsg);
			this.Controls.Add(this.TextBox6);
			this.Controls.Add(this.TextBox5);
			this.Controls.Add(this.TextBox4);
			this.Controls.Add(this.TextBox3);
			this.Controls.Add(this.TextBox2);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ComboBox1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.Button1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "zip uploader  (c)Teamwind jp ";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtPsw;
        internal System.Windows.Forms.Label lblmsg;
        internal System.Windows.Forms.TextBox TextBox6;
        internal System.Windows.Forms.TextBox TextBox5;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtUrl;
        internal System.Windows.Forms.Button Button1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

