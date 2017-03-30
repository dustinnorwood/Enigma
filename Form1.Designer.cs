namespace Enigma
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
            this.plaintextBox = new System.Windows.Forms.TextBox();
            this.ciphertextBox = new System.Windows.Forms.TextBox();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.hashButton = new System.Windows.Forms.Button();
            this.hashBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.imButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.embedPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yBox = new System.Windows.Forms.TextBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.retrieveButton3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.embedButton3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.fileButton3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.embedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // plaintextBox
            // 
            this.plaintextBox.Location = new System.Drawing.Point(6, 6);
            this.plaintextBox.Multiline = true;
            this.plaintextBox.Name = "plaintextBox";
            this.plaintextBox.Size = new System.Drawing.Size(348, 425);
            this.plaintextBox.TabIndex = 0;
            // 
            // ciphertextBox
            // 
            this.ciphertextBox.Location = new System.Drawing.Point(381, 6);
            this.ciphertextBox.Multiline = true;
            this.ciphertextBox.Name = "ciphertextBox";
            this.ciphertextBox.Size = new System.Drawing.Size(348, 425);
            this.ciphertextBox.TabIndex = 1;
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(7, 438);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(347, 20);
            this.keyBox.TabIndex = 2;
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(381, 438);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(167, 23);
            this.encryptButton.TabIndex = 3;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(554, 438);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(175, 23);
            this.decryptButton.TabIndex = 4;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // hashButton
            // 
            this.hashButton.Location = new System.Drawing.Point(607, 468);
            this.hashButton.Name = "hashButton";
            this.hashButton.Size = new System.Drawing.Size(122, 23);
            this.hashButton.TabIndex = 5;
            this.hashButton.Text = "Generate SHA2 Hash";
            this.hashButton.UseVisualStyleBackColor = true;
            this.hashButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // hashBox
            // 
            this.hashBox.Location = new System.Drawing.Point(7, 468);
            this.hashBox.Name = "hashBox";
            this.hashBox.Size = new System.Drawing.Size(594, 20);
            this.hashBox.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.embedPage);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 524);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.plaintextBox);
            this.tabPage1.Controls.Add(this.hashBox);
            this.tabPage1.Controls.Add(this.ciphertextBox);
            this.tabPage1.Controls.Add(this.hashButton);
            this.tabPage1.Controls.Add(this.keyBox);
            this.tabPage1.Controls.Add(this.decryptButton);
            this.tabPage1.Controls.Add(this.encryptButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crypto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.imButton);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(735, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Image";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // imButton
            // 
            this.imButton.Location = new System.Drawing.Point(119, 469);
            this.imButton.Name = "imButton";
            this.imButton.Size = new System.Drawing.Size(97, 23);
            this.imButton.TabIndex = 2;
            this.imButton.Text = "Choose Image";
            this.imButton.UseVisualStyleBackColor = true;
            this.imButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(375, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(354, 455);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 455);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // embedPage
            // 
            this.embedPage.Controls.Add(this.label2);
            this.embedPage.Controls.Add(this.label1);
            this.embedPage.Controls.Add(this.yBox);
            this.embedPage.Controls.Add(this.xBox);
            this.embedPage.Controls.Add(this.retrieveButton3);
            this.embedPage.Controls.Add(this.comboBox1);
            this.embedPage.Controls.Add(this.embedButton3);
            this.embedPage.Controls.Add(this.textBox3);
            this.embedPage.Controls.Add(this.fileButton3);
            this.embedPage.Controls.Add(this.pictureBox3);
            this.embedPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.embedPage.Location = new System.Drawing.Point(4, 22);
            this.embedPage.Name = "embedPage";
            this.embedPage.Padding = new System.Windows.Forms.Padding(3);
            this.embedPage.Size = new System.Drawing.Size(735, 498);
            this.embedPage.TabIndex = 2;
            this.embedPage.Text = "Embed";
            this.embedPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            this.label1.Visible = false;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(364, 468);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(73, 20);
            this.yBox.TabIndex = 9;
            this.yBox.Visible = false;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(265, 468);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(73, 20);
            this.xBox.TabIndex = 8;
            this.xBox.Visible = false;
            // 
            // retrieveButton3
            // 
            this.retrieveButton3.Location = new System.Drawing.Point(581, 468);
            this.retrieveButton3.Name = "retrieveButton3";
            this.retrieveButton3.Size = new System.Drawing.Size(148, 23);
            this.retrieveButton3.TabIndex = 7;
            this.retrieveButton3.Text = "Retrieve Text From Image";
            this.retrieveButton3.UseVisualStyleBackColor = true;
            this.retrieveButton3.Click += new System.EventHandler(this.retrieveButton3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LR from T to B",
            "RL from T to B",
            "LR from B to T",
            "RL from B to T",
            "UD from L to R",
            "UD from R to L",
            "DU from L to R",
            "DU from R to L",
            "LRRL from T to B",
            "RLLR from T to B",
            "LRRL from B to T",
            "RLLR from B to T",
            "UDDU from L to R",
            "UDDU from R to L",
            "DUUD from L to R",
            "DUUD from R to L",
            "Spiral LCW",
            "Spiral LCCW",
            "Spiral RCW",
            "Spiral RCCW",
            "Spiral UCW",
            "Spiral UCCW",
            "Spiral DCW",
            "Spiral DCCW"});
            this.comboBox1.Location = new System.Drawing.Point(88, 469);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // embedButton3
            // 
            this.embedButton3.Location = new System.Drawing.Point(443, 469);
            this.embedButton3.Name = "embedButton3";
            this.embedButton3.Size = new System.Drawing.Size(132, 23);
            this.embedButton3.TabIndex = 5;
            this.embedButton3.Text = "Embed Text in Image";
            this.embedButton3.UseVisualStyleBackColor = true;
            this.embedButton3.Click += new System.EventHandler(this.embedButton3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(7, 6);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(351, 456);
            this.textBox3.TabIndex = 4;
            // 
            // fileButton3
            // 
            this.fileButton3.Location = new System.Drawing.Point(7, 468);
            this.fileButton3.Name = "fileButton3";
            this.fileButton3.Size = new System.Drawing.Size(75, 23);
            this.fileButton3.TabIndex = 3;
            this.fileButton3.Text = "Choose File";
            this.fileButton3.UseVisualStyleBackColor = true;
            this.fileButton3.Click += new System.EventHandler(this.fileButton3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(377, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(352, 456);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 527);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.embedPage.ResumeLayout(false);
            this.embedPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox plaintextBox;
		private System.Windows.Forms.TextBox ciphertextBox;
		private System.Windows.Forms.TextBox keyBox;
		private System.Windows.Forms.Button encryptButton;
		private System.Windows.Forms.Button decryptButton;
		private System.Windows.Forms.Button hashButton;
		private System.Windows.Forms.TextBox hashBox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.Button imButton;
		public System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage embedPage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button embedButton3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button fileButton3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button retrieveButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox xBox;
    }
}

