namespace FinalTeamProject
{
    partial class ManageRepos
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
            this.save_btn = new System.Windows.Forms.Button();
            this.userList = new System.Windows.Forms.ListBox();
            this.contributorsList = new System.Windows.Forms.ListBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.repoName_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.description_tb = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(16, 371);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(279, 23);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Save Changes";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(16, 139);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(120, 95);
            this.userList.TabIndex = 1;
            // 
            // contributorsList
            // 
            this.contributorsList.FormattingEnabled = true;
            this.contributorsList.Location = new System.Drawing.Point(175, 139);
            this.contributorsList.Name = "contributorsList";
            this.contributorsList.Size = new System.Drawing.Size(120, 95);
            this.contributorsList.TabIndex = 2;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(16, 240);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(120, 23);
            this.add_btn.TabIndex = 3;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.Location = new System.Drawing.Point(175, 239);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(120, 23);
            this.remove_btn.TabIndex = 4;
            this.remove_btn.Text = "Remove";
            this.remove_btn.UseVisualStyleBackColor = true;
            // 
            // repoName_tb
            // 
            this.repoName_tb.Location = new System.Drawing.Point(16, 80);
            this.repoName_tb.Name = "repoName_tb";
            this.repoName_tb.Size = new System.Drawing.Size(279, 20);
            this.repoName_tb.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add Contributors:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Current Contributors:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Current Repository Name:";
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(13, 13);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(94, 20);
            this.header_label.TabIndex = 9;
            this.header_label.Text = "Repo Name";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(220, 10);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // description_tb
            // 
            this.description_tb.Location = new System.Drawing.Point(19, 291);
            this.description_tb.Name = "description_tb";
            this.description_tb.Size = new System.Drawing.Size(276, 74);
            this.description_tb.TabIndex = 11;
            this.description_tb.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Description:";
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(16, 48);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 13;
            // 
            // ManageRepos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 406);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.description_tb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repoName_tb);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.contributorsList);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.save_btn);
            this.Name = "ManageRepos";
            this.Text = "ManageRepos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.ListBox contributorsList;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.TextBox repoName_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.RichTextBox description_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label error_label;
    }
}