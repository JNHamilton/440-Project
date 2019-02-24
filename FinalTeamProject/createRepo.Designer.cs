namespace FinalTeamProject
{
    partial class createRepo
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
            this.desiredName_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.description_tb = new System.Windows.Forms.RichTextBox();
            this.userList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.add_btn = new System.Windows.Forms.Button();
            this.contributorsList = new System.Windows.Forms.ListBox();
            this.remove_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.error_tb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Repository";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(211, 6);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // desiredName_tb
            // 
            this.desiredName_tb.Location = new System.Drawing.Point(12, 63);
            this.desiredName_tb.Name = "desiredName_tb";
            this.desiredName_tb.Size = new System.Drawing.Size(274, 20);
            this.desiredName_tb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "* Name of Repository:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repository Description:";
            // 
            // description_tb
            // 
            this.description_tb.Location = new System.Drawing.Point(12, 291);
            this.description_tb.Name = "description_tb";
            this.description_tb.Size = new System.Drawing.Size(274, 117);
            this.description_tb.TabIndex = 5;
            this.description_tb.Text = "";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(12, 122);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(120, 95);
            this.userList.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Add Contributors:";
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(12, 224);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(120, 23);
            this.add_btn.TabIndex = 8;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // contributorsList
            // 
            this.contributorsList.FormattingEnabled = true;
            this.contributorsList.Location = new System.Drawing.Point(166, 122);
            this.contributorsList.Name = "contributorsList";
            this.contributorsList.Size = new System.Drawing.Size(120, 95);
            this.contributorsList.TabIndex = 9;
            // 
            // remove_btn
            // 
            this.remove_btn.Location = new System.Drawing.Point(166, 223);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(120, 23);
            this.remove_btn.TabIndex = 10;
            this.remove_btn.Text = "Remove";
            this.remove_btn.UseVisualStyleBackColor = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // create_btn
            // 
            this.create_btn.Location = new System.Drawing.Point(16, 415);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(270, 23);
            this.create_btn.TabIndex = 11;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Current Contributors:";
            // 
            // error_tb
            // 
            this.error_tb.AutoSize = true;
            this.error_tb.Location = new System.Drawing.Point(16, 28);
            this.error_tb.Name = "error_tb";
            this.error_tb.Size = new System.Drawing.Size(0, 13);
            this.error_tb.TabIndex = 13;
            // 
            // createRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 451);
            this.Controls.Add(this.error_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.contributorsList);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.description_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.desiredName_tb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Name = "createRepo";
            this.Text = "createRepo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox desiredName_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox description_tb;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.ListBox contributorsList;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label error_tb;
    }
}