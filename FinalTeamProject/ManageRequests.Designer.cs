namespace FinalTeamProject
{
    partial class ManageRequests
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
            this.branch_label = new System.Windows.Forms.Label();
            this.file_label = new System.Windows.Forms.Label();
            this.repo_label = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.comments_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.viewChanges_btn = new System.Windows.Forms.Button();
            this.closeRequest_btn = new System.Windows.Forms.Button();
            this.commit_btn = new System.Windows.Forms.Button();
            this.reply_box = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // branch_label
            // 
            this.branch_label.AutoSize = true;
            this.branch_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch_label.Location = new System.Drawing.Point(12, 89);
            this.branch_label.Name = "branch_label";
            this.branch_label.Size = new System.Drawing.Size(59, 18);
            this.branch_label.TabIndex = 0;
            this.branch_label.Text = "Branch:";
            // 
            // file_label
            // 
            this.file_label.AutoSize = true;
            this.file_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_label.Location = new System.Drawing.Point(12, 107);
            this.file_label.Name = "file_label";
            this.file_label.Size = new System.Drawing.Size(139, 18);
            this.file_label.TabIndex = 1;
            this.file_label.Text = "File Being Changed:";
            // 
            // repo_label
            // 
            this.repo_label.AutoSize = true;
            this.repo_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repo_label.Location = new System.Drawing.Point(12, 71);
            this.repo_label.Name = "repo_label";
            this.repo_label.Size = new System.Drawing.Size(84, 18);
            this.repo_label.TabIndex = 2;
            this.repo_label.Text = "Repository:";
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_label.Location = new System.Drawing.Point(12, 53);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(54, 18);
            this.status_label.TabIndex = 3;
            this.status_label.Text = "Status:";
            // 
            // comments_label
            // 
            this.comments_label.AutoSize = true;
            this.comments_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comments_label.Location = new System.Drawing.Point(12, 125);
            this.comments_label.Name = "comments_label";
            this.comments_label.Size = new System.Drawing.Size(86, 18);
            this.comments_label.TabIndex = 4;
            this.comments_label.Text = "Comments:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "View Pull Request";
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(312, 9);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(75, 23);
            this.back_btn.TabIndex = 6;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // viewChanges_btn
            // 
            this.viewChanges_btn.Location = new System.Drawing.Point(133, 241);
            this.viewChanges_btn.Name = "viewChanges_btn";
            this.viewChanges_btn.Size = new System.Drawing.Size(139, 23);
            this.viewChanges_btn.TabIndex = 7;
            this.viewChanges_btn.Text = "View Changes";
            this.viewChanges_btn.UseVisualStyleBackColor = true;
            this.viewChanges_btn.Click += new System.EventHandler(this.viewChanges_btn_Click);
            // 
            // closeRequest_btn
            // 
            this.closeRequest_btn.BackColor = System.Drawing.SystemColors.Control;
            this.closeRequest_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.closeRequest_btn.Location = new System.Drawing.Point(12, 241);
            this.closeRequest_btn.Name = "closeRequest_btn";
            this.closeRequest_btn.Size = new System.Drawing.Size(103, 23);
            this.closeRequest_btn.TabIndex = 8;
            this.closeRequest_btn.Text = "Decline";
            this.closeRequest_btn.UseVisualStyleBackColor = false;
            this.closeRequest_btn.Click += new System.EventHandler(this.closeRequest_btn_Click);
            // 
            // commit_btn
            // 
            this.commit_btn.Location = new System.Drawing.Point(284, 241);
            this.commit_btn.Name = "commit_btn";
            this.commit_btn.Size = new System.Drawing.Size(103, 23);
            this.commit_btn.TabIndex = 9;
            this.commit_btn.Text = "Commit";
            this.commit_btn.UseVisualStyleBackColor = true;
            this.commit_btn.Click += new System.EventHandler(this.commit_btn_Click);
            // 
            // reply_box
            // 
            this.reply_box.Location = new System.Drawing.Point(12, 184);
            this.reply_box.Name = "reply_box";
            this.reply_box.Size = new System.Drawing.Size(375, 51);
            this.reply_box.TabIndex = 10;
            this.reply_box.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Your Reply Bellow:";
            // 
            // ManageRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reply_box);
            this.Controls.Add(this.commit_btn);
            this.Controls.Add(this.closeRequest_btn);
            this.Controls.Add(this.viewChanges_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comments_label);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.repo_label);
            this.Controls.Add(this.file_label);
            this.Controls.Add(this.branch_label);
            this.Name = "ManageRequests";
            this.Text = "ViewPullRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label branch_label;
        private System.Windows.Forms.Label file_label;
        private System.Windows.Forms.Label repo_label;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Label comments_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button viewChanges_btn;
        private System.Windows.Forms.Button closeRequest_btn;
        private System.Windows.Forms.Button commit_btn;
        private System.Windows.Forms.RichTextBox reply_box;
        private System.Windows.Forms.Label label1;
    }
}