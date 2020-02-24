namespace BmiCalculator
{
    partial class BmiResultForm
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
            this.bmiPictureBox = new System.Windows.Forms.PictureBox();
            this.bmiResultLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bmiPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bmiPictureBox
            // 
            this.bmiPictureBox.Location = new System.Drawing.Point(12, 12);
            this.bmiPictureBox.Name = "bmiPictureBox";
            this.bmiPictureBox.Size = new System.Drawing.Size(399, 221);
            this.bmiPictureBox.TabIndex = 0;
            this.bmiPictureBox.TabStop = false;
            // 
            // bmiResultLabel
            // 
            this.bmiResultLabel.AutoSize = true;
            this.bmiResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bmiResultLabel.ForeColor = System.Drawing.Color.Red;
            this.bmiResultLabel.Location = new System.Drawing.Point(9, 271);
            this.bmiResultLabel.Name = "bmiResultLabel";
            this.bmiResultLabel.Size = new System.Drawing.Size(88, 24);
            this.bmiResultLabel.TabIndex = 1;
            this.bmiResultLabel.Text = "Ваш BMI:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(176, 328);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // BmiResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 363);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.bmiResultLabel);
            this.Controls.Add(this.bmiPictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 402);
            this.Name = "BmiResultForm";
            this.ShowIcon = false;
            this.Text = "Результаты";
            ((System.ComponentModel.ISupportInitialize)(this.bmiPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bmiPictureBox;
        private System.Windows.Forms.Label bmiResultLabel;
        private System.Windows.Forms.Button okButton;
    }
}