﻿namespace FinalTeamProject
{
    partial class NewBranch
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
            this.cancel_btn = new System.Windows.Forms.Button();
            this.newBranch_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.create_btn = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create New Branch";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(165, 4);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // newBranch_tb
            // 
            this.newBranch_tb.Location = new System.Drawing.Point(15, 92);
            this.newBranch_tb.Name = "newBranch_tb";
            this.newBranch_tb.Size = new System.Drawing.Size(225, 20);
            this.newBranch_tb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Branch name:";
            // 
            // create_btn
            // 
            this.create_btn.Location = new System.Drawing.Point(12, 157);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(228, 23);
            this.create_btn.TabIndex = 6;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(114, 45);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 7;
            // 
            // NewBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 186);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newBranch_tb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Name = "NewBranch";
            this.Text = "NewBranch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox newBranch_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Label error_label;
    }
}