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
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ageErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.showRecordsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // calcButton
            // 
            this.calcButton.Enabled = false;
            this.calcButton.Location = new System.Drawing.Point(104, 120);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 0;
            this.calcButton.Text = "Рассчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.CalculateButtonClicked);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(185, 120);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Рост:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Вес:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Пол:";
            // 
            // manRadioButton
            // 
            this.manRadioButton.AutoSize = true;
            this.manRadioButton.Checked = true;
            this.manRadioButton.Location = new System.Drawing.Point(64, 90);
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
            this.womanRadioButton.Location = new System.Drawing.Point(141, 90);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(69, 17);
            this.womanRadioButton.TabIndex = 6;
            this.womanRadioButton.TabStop = true;
            this.womanRadioButton.Text = "женский";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(64, 38);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(146, 20);
            this.heightTextBox.TabIndex = 7;
            this.heightTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(64, 64);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(146, 20);
            this.weightTextBox.TabIndex = 8;
            this.weightTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // heightErrorProvider
            // 
            this.heightErrorProvider.ContainerControl = this;
            // 
            // weightErrorProvider
            // 
            this.weightErrorProvider.ContainerControl = this;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(64, 12);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(146, 20);
            this.ageTextBox.TabIndex = 9;
            this.ageTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Возраст:";
            // 
            // ageErrorProvider
            // 
            this.ageErrorProvider.ContainerControl = this;
            // 
            // showRecordsButton
            // 
            this.showRecordsButton.Location = new System.Drawing.Point(23, 120);
            this.showRecordsButton.Name = "showRecordsButton";
            this.showRecordsButton.Size = new System.Drawing.Size(75, 23);
            this.showRecordsButton.TabIndex = 11;
            this.showRecordsButton.Text = "Просмотр";
            this.showRecordsButton.UseVisualStyleBackColor = true;
            this.showRecordsButton.Visible = false;
            this.showRecordsButton.Click += new System.EventHandler(this.OnShowRecordsButtonClicked);
            // 
            // BmiCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 155);
            this.Controls.Add(this.showRecordsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.womanRadioButton);
            this.Controls.Add(this.manRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.calcButton);
            this.MinimumSize = new System.Drawing.Size(260, 168);
            this.Name = "BmiCalcForm";
            this.ShowIcon = false;
            this.Text = "Калькулятор BMI";
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageErrorProvider)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.ErrorProvider ageErrorProvider;
        private System.Windows.Forms.Button showRecordsButton;
    }
}