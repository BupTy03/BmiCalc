﻿namespace BmiCalculator
{
    partial class BmiRecordsViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BmiRecordsViewForm));
            this.recordsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // recordsListBox
            // 
            this.recordsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordsListBox.FormattingEnabled = true;
            this.recordsListBox.Location = new System.Drawing.Point(0, 0);
            this.recordsListBox.Name = "recordsListBox";
            this.recordsListBox.Size = new System.Drawing.Size(410, 220);
            this.recordsListBox.TabIndex = 0;
            // 
            // BmiRecordsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 220);
            this.Controls.Add(this.recordsListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(426, 259);
            this.Name = "BmiRecordsViewForm";
            this.Text = "Просмотр записей";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox recordsListBox;
    }
}