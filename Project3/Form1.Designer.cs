namespace Project3
{
    partial class Project3
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
            if(disposing && (components != null))
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
            this.chooseFormat = new System.Windows.Forms.ComboBox();
            this.weightText = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chooseBttn = new System.Windows.Forms.Button();
            this.convertBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseFormat
            // 
            this.chooseFormat.FormattingEnabled = true;
            this.chooseFormat.Items.AddRange(new object[] {
            "4:4:4",
            "4:2:2",
            "4:2:0"});
            this.chooseFormat.Location = new System.Drawing.Point(808, 12);
            this.chooseFormat.Name = "chooseFormat";
            this.chooseFormat.Size = new System.Drawing.Size(121, 21);
            this.chooseFormat.TabIndex = 0;
            // 
            // weightText
            // 
            this.weightText.Location = new System.Drawing.Point(808, 40);
            this.weightText.Name = "weightText";
            this.weightText.Size = new System.Drawing.Size(121, 20);
            this.weightText.TabIndex = 1;
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(808, 67);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(121, 20);
            this.heightText.TabIndex = 2;
            // 
            // weight
            // 
            this.weight.AutoSize = true;
            this.weight.Location = new System.Drawing.Point(766, 43);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(38, 13);
            this.weight.TabIndex = 3;
            this.weight.Text = "weight";
            // 
            // height
            // 
            this.height.AutoSize = true;
            this.height.Location = new System.Drawing.Point(766, 70);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(36, 13);
            this.height.TabIndex = 4;
            this.height.Text = "height";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(808, 94);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(121, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 365);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "";
            // 
            // chooseBttn
            // 
            this.chooseBttn.Location = new System.Drawing.Point(808, 124);
            this.chooseBttn.Name = "chooseBttn";
            this.chooseBttn.Size = new System.Drawing.Size(121, 23);
            this.chooseBttn.TabIndex = 7;
            this.chooseBttn.Text = "choose file";
            this.chooseBttn.UseVisualStyleBackColor = true;
            this.chooseBttn.Click += new System.EventHandler(this.chooseBttn_Click);
            // 
            // convertBttn
            // 
            this.convertBttn.Location = new System.Drawing.Point(808, 154);
            this.convertBttn.Name = "convertBttn";
            this.convertBttn.Size = new System.Drawing.Size(121, 23);
            this.convertBttn.TabIndex = 8;
            this.convertBttn.Text = "Convert";
            this.convertBttn.UseVisualStyleBackColor = true;
            this.convertBttn.Click += new System.EventHandler(this.convertBttn_Click);
            // 
            // Project3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 389);
            this.Controls.Add(this.convertBttn);
            this.Controls.Add(this.chooseBttn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.height);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.weightText);
            this.Controls.Add(this.chooseFormat);
            this.Name = "Project3";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Project3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseFormat;
        private System.Windows.Forms.TextBox weightText;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.Label height;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chooseBttn;
        private System.Windows.Forms.Button convertBttn;
    }
}

