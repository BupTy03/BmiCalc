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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BmiCalcForm));
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageErrorProvider)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calcButton
            // 
            this.calcButton.Enabled = false;
            this.calcButton.Location = new System.Drawing.Point(161, 3);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 0;
            this.calcButton.Text = "&Рассчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.OnCalculateButtonClicked);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(242, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "&Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.OnExitButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Рост:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вес:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(27, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пол:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manRadioButton
            // 
            this.manRadioButton.AutoSize = true;
            this.manRadioButton.Checked = true;
            this.manRadioButton.Location = new System.Drawing.Point(3, 3);
            this.manRadioButton.Name = "manRadioButton";
            this.manRadioButton.Size = new System.Drawing.Size(70, 17);
            this.manRadioButton.TabIndex = 5;
            this.manRadioButton.TabStop = true;
            this.manRadioButton.Text = "&мужской";
            this.manRadioButton.UseVisualStyleBackColor = true;
            // 
            // womanRadioButton
            // 
            this.womanRadioButton.AutoSize = true;
            this.womanRadioButton.Location = new System.Drawing.Point(79, 3);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(69, 17);
            this.womanRadioButton.TabIndex = 6;
            this.womanRadioButton.TabStop = true;
            this.womanRadioButton.Text = "&женский";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heightTextBox.Location = new System.Drawing.Point(63, 29);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(253, 20);
            this.heightTextBox.TabIndex = 7;
            this.heightTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // weightTextBox
            // 
            this.weightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightTextBox.Location = new System.Drawing.Point(63, 55);
            this.weightTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(253, 20);
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
            this.ageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ageTextBox.Location = new System.Drawing.Point(63, 3);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(253, 20);
            this.ageTextBox.TabIndex = 9;
            this.ageTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Возраст:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ageErrorProvider
            // 
            this.ageErrorProvider.ContainerControl = this;
            // 
            // showRecordsButton
            // 
            this.showRecordsButton.Location = new System.Drawing.Point(80, 3);
            this.showRecordsButton.Name = "showRecordsButton";
            this.showRecordsButton.Size = new System.Drawing.Size(75, 23);
            this.showRecordsButton.TabIndex = 11;
            this.showRecordsButton.Text = "&Просмотр";
            this.showRecordsButton.UseVisualStyleBackColor = true;
            this.showRecordsButton.Visible = false;
            this.showRecordsButton.Click += new System.EventHandler(this.OnShowRecordsButtonClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exitButton);
            this.flowLayoutPanel1.Controls.Add(this.calcButton);
            this.flowLayoutPanel1.Controls.Add(this.showRecordsButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 139);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 29);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.manRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.womanRadioButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(63, 81);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(270, 23);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ageTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.heightTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.weightTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 133);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // BmiCalcForm
            // 
            this.AcceptButton = this.calcButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(348, 174);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(364, 213);
            this.Name = "BmiCalcForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Калькулятор BMI";
            ((System.ComponentModel.ISupportInitialize)(this.heightErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageErrorProvider)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}