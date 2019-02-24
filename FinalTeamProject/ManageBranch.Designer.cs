namespace FinalTeamProject
{
    partial class ManageBranch
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
            this.branchName_tb = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Branch";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(172, 9);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // branchName_tb
            // 
            this.branchName_tb.Location = new System.Drawing.Point(12, 61);
            this.branchName_tb.Name = "branchName_tb";
            this.branchName_tb.Size = new System.Drawing.Size(235, 20);
            this.branchName_tb.TabIndex = 2;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(12, 90);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(235, 23);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "Save Changes";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(12, 42);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 4;
            // 
            // ManageBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 125);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.branchName_tb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Name = "ManageBranch";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox branchName_tb;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label error_label;
    }
}