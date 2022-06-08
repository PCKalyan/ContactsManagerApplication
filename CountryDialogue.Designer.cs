namespace ContactsManagerApplication
{
    partial class CountryDialogue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbisactive = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textCountryName = new System.Windows.Forms.TextBox();
            this.textZipCodeEnd = new System.Windows.Forms.TextBox();
            this.textZipCodeStart = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Country Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ZipCode Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ZipCode End";
            // 
            // chbisactive
            // 
            this.chbisactive.AutoSize = true;
            this.chbisactive.Location = new System.Drawing.Point(100, 118);
            this.chbisactive.Name = "chbisactive";
            this.chbisactive.Size = new System.Drawing.Size(67, 17);
            this.chbisactive.TabIndex = 6;
            this.chbisactive.Text = "Is Active";
            this.chbisactive.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(63, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(144, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textCountryName
            // 
            this.textCountryName.Location = new System.Drawing.Point(144, 25);
            this.textCountryName.Name = "textCountryName";
            this.textCountryName.Size = new System.Drawing.Size(100, 20);
            this.textCountryName.TabIndex = 3;
            // 
            // textZipCodeEnd
            // 
            this.textZipCodeEnd.Location = new System.Drawing.Point(144, 82);
            this.textZipCodeEnd.Name = "textZipCodeEnd";
            this.textZipCodeEnd.Size = new System.Drawing.Size(100, 20);
            this.textZipCodeEnd.TabIndex = 5;
            // 
            // textZipCodeStart
            // 
            this.textZipCodeStart.Location = new System.Drawing.Point(144, 55);
            this.textZipCodeStart.Name = "textZipCodeStart";
            this.textZipCodeStart.Size = new System.Drawing.Size(100, 20);
            this.textZipCodeStart.TabIndex = 4;
            // 
            // CountryDialogue
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(281, 210);
            this.Controls.Add(this.textZipCodeStart);
            this.Controls.Add(this.textZipCodeEnd);
            this.Controls.Add(this.textCountryName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbisactive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountryDialogue";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CountryDialogue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbisactive;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textCountryName;
        private System.Windows.Forms.TextBox textZipCodeEnd;
        private System.Windows.Forms.TextBox textZipCodeStart;
    }
}