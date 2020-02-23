namespace BmiCalculator
{
    partial class BmiCalcForm
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
            this.components = new System.ComponentModel.Container();
            this.calcButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.manRadioButton = new System.Windows.Forms.RadioButton();
            this.womanRadioButton = new System.Windows.Forms.RadioButton();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.heightErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.weightErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(39, 99);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 0;
            this.calcButton.Text = "Рассчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(120, 99);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Рост:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Вес:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Пол:";
            // 
            // manRadioButton
            // 
            this.manRadioButton.AutoSize = true;
            this.manRadioButton.Checked = true;
            this.manRadioButton.Location = new System.Drawing.Point(53, 63);
            this.manRadioButton.Name = "manRadioButton";
            this.manRadioButton.Size = new System.Drawing.Size(70, 17);
            this.manRadioButton.TabIndex = 5;
            this.manRadioButton.TabStop = true;
            this.manRadioButton.Text = "мужской";
            this.manRadioButton.UseVisualStyleBackColor = true;
            // 
            // womanRadioButton
            // 
            this.womanRadioButton.AutoSize = true;
            this.womanRadioButton.Location = new System.Drawing.Point(129, 63);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(69, 17);
            this.womanRadioButton.TabIndex = 6;
            this.womanRadioButton.TabStop = true;
            this.womanRadioButton.Text = "женский";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(52, 6);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(146, 20);
            this.heightTextBox.TabIndex = 7;
            this.heightTextBox.TextChanged += new System.EventHandler(this.heightTextBox_TextChanged);
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(52, 33);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(146, 20);
            this.weightTextBox.TabIndex = 8;
            // 
            // heightErrorProvider
            // 
            this.heightErrorProvider.ContainerControl = this;
            // 
            // weightErrorProvider
            // 
            this.weightErrorProvider.ContainerControl = this;
            // 
            // BmiCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 129);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.womanRadioButton);
            this.Controls.Add(this.manRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.calcButton);
            this.Name = "BmiCalcForm";
            this.Text = "Калькулятор BMI";
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton manRadioButton;
        private System.Windows.Forms.RadioButton womanRadioButton;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.ErrorProvider heightErrorProvider;
        private System.Windows.Forms.ErrorProvider weightErrorProvider;
    }
}