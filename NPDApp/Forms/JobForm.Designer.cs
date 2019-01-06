using System;
using NPDApp.models;

namespace NPDApp
{
    partial class JobForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clientLocationTxt = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.faultDescTxt = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.jobUrgencyComboBox = new System.Windows.Forms.ComboBox();
            this.machineComboBox = new System.Windows.Forms.ComboBox();
            this.addMachineButton = new System.Windows.Forms.Button();
            this.submitJobButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register a new Job";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.clientComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.clientLocationTxt);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.faultDescTxt);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 39);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(295, 235);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Client";
            // 
            // clientComboBox
            // 
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(2, 22);
            this.clientComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(290, 21);
            this.clientComboBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Client Location";
            // 
            // clientLocationTxt
            // 
            this.clientLocationTxt.Location = new System.Drawing.Point(2, 67);
            this.clientLocationTxt.Margin = new System.Windows.Forms.Padding(2);
            this.clientLocationTxt.Name = "clientLocationTxt";
            this.clientLocationTxt.Size = new System.Drawing.Size(289, 40);
            this.clientLocationTxt.TabIndex = 6;
            this.clientLocationTxt.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fault Description";
            // 
            // faultDescTxt
            // 
            this.faultDescTxt.Location = new System.Drawing.Point(2, 131);
            this.faultDescTxt.Margin = new System.Windows.Forms.Padding(2);
            this.faultDescTxt.Name = "faultDescTxt";
            this.faultDescTxt.Size = new System.Drawing.Size(289, 105);
            this.faultDescTxt.TabIndex = 5;
            this.faultDescTxt.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Machine";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.jobUrgencyComboBox);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.machineComboBox);
            this.flowLayoutPanel2.Controls.Add(this.addMachineButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(309, 41);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(291, 233);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Job Urgency";
            // 
            // jobUrgencyComboBox
            // 
            this.jobUrgencyComboBox.Location = new System.Drawing.Point(2, 22);
            this.jobUrgencyComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.jobUrgencyComboBox.Name = "jobUrgencyComboBox";
            this.jobUrgencyComboBox.Size = new System.Drawing.Size(287, 21);
            this.jobUrgencyComboBox.TabIndex = 1;
            // 
            // machineComboBox
            // 
            this.machineComboBox.FormattingEnabled = true;
            this.machineComboBox.Location = new System.Drawing.Point(2, 67);
            this.machineComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.machineComboBox.Name = "machineComboBox";
            this.machineComboBox.Size = new System.Drawing.Size(246, 21);
            this.machineComboBox.TabIndex = 8;
            // 
            // addMachineButton
            // 
            this.addMachineButton.Location = new System.Drawing.Point(252, 67);
            this.addMachineButton.Margin = new System.Windows.Forms.Padding(2);
            this.addMachineButton.Name = "addMachineButton";
            this.addMachineButton.Size = new System.Drawing.Size(37, 22);
            this.addMachineButton.TabIndex = 9;
            this.addMachineButton.Text = "Add";
            this.addMachineButton.UseVisualStyleBackColor = true;
            this.addMachineButton.Click += new System.EventHandler(this.AddMachineButton_Click);
            // 
            // submitJobButton
            // 
            this.submitJobButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitJobButton.Location = new System.Drawing.Point(539, 278);
            this.submitJobButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitJobButton.Name = "submitJobButton";
            this.submitJobButton.Size = new System.Drawing.Size(64, 27);
            this.submitJobButton.TabIndex = 3;
            this.submitJobButton.Text = "Submit";
            this.submitJobButton.UseVisualStyleBackColor = true;
            this.submitJobButton.Click += new System.EventHandler(this.SubmitJobButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(485, 278);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(50, 27);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // JobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 311);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.submitJobButton);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Job - NPD";
            this.Activated += new System.EventHandler(this.JobForm_Activated);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox clientLocationTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox faultDescTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox jobUrgencyComboBox;
        private System.Windows.Forms.ComboBox machineComboBox;
        private System.Windows.Forms.Button addMachineButton;
        private System.Windows.Forms.Button submitJobButton;
        private System.Windows.Forms.Button resetButton;
    }
}