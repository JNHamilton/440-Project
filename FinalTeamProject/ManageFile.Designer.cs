namespace FinalTeamProject
{
    partial class ManageFile
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
            this.fileName_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileType_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileName_tb
            // 
            this.fileName_tb.Location = new System.Drawing.Point(17, 101);
            this.fileName_tb.Name = "fileName_tb";
            this.fileName_tb.Size = new System.Drawing.Size(161, 20);
            this.fileName_tb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage File";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(195, 10);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(17, 47);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Name:";
            // 
            // fileType_box
            // 
            this.fileType_box.FormattingEnabled = true;
            this.fileType_box.Items.AddRange(new object[] {
            ".txt",
            ".md",
            ".html",
            ".ps",
            ".doc",
            ".pdf",
            ".java",
            ".cs",
            ".pyc",
            ".png",
            ".jpg",
            ".msg",
            ".ai",
            ".7z",
            ".zip",
            ".rar"});
            this.fileType_box.Location = new System.Drawing.Point(184, 100);
            this.fileType_box.Name = "fileType_box";
            this.fileType_box.Size = new System.Drawing.Size(75, 21);
            this.fileType_box.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Type:";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(17, 167);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(242, 23);
            this.save_btn.TabIndex = 7;
            this.save_btn.Text = "Save Changes";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(89, 138);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(89, 23);
            this.delete_btn.TabIndex = 8;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            // 
            // ManageFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 202);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileType_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileName_tb);
            this.Name = "ManageFile";
            this.Text = "ManageFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileName_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fileType_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button delete_btn;
    }
}