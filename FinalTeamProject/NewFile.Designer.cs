namespace FinalTeamProject
{
    partial class NewFile
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
            this.label2 = new System.Windows.Forms.Label();
            this.fileName_tb = new System.Windows.Forms.TextBox();
            this.fileType_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectFile_btn = new System.Windows.Forms.Button();
            this.addFile_btn = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New File";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(275, 6);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New File Name:";
            // 
            // fileName_tb
            // 
            this.fileName_tb.Location = new System.Drawing.Point(19, 81);
            this.fileName_tb.Name = "fileName_tb";
            this.fileName_tb.Size = new System.Drawing.Size(145, 20);
            this.fileName_tb.TabIndex = 3;
            this.fileName_tb.Text = "README";
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
            this.fileType_box.Location = new System.Drawing.Point(170, 81);
            this.fileType_box.Name = "fileType_box";
            this.fileType_box.Size = new System.Drawing.Size(79, 21);
            this.fileType_box.TabIndex = 4;
            this.fileType_box.Text = ".md";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Type:";
            // 
            // selectFile_btn
            // 
            this.selectFile_btn.Location = new System.Drawing.Point(275, 108);
            this.selectFile_btn.Name = "selectFile_btn";
            this.selectFile_btn.Size = new System.Drawing.Size(75, 23);
            this.selectFile_btn.TabIndex = 6;
            this.selectFile_btn.Text = "Upload FIle";
            this.selectFile_btn.UseVisualStyleBackColor = true;
            this.selectFile_btn.Click += new System.EventHandler(this.selectFile_btn_Click);
            // 
            // addFile_btn
            // 
            this.addFile_btn.Location = new System.Drawing.Point(19, 108);
            this.addFile_btn.Name = "addFile_btn";
            this.addFile_btn.Size = new System.Drawing.Size(145, 23);
            this.addFile_btn.TabIndex = 7;
            this.addFile_btn.Text = "Add";
            this.addFile_btn.UseVisualStyleBackColor = true;
            this.addFile_btn.Click += new System.EventHandler(this.addFile_btn_Click);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(19, 33);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 8;
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 143);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.addFile_btn);
            this.Controls.Add(this.selectFile_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileType_box);
            this.Controls.Add(this.fileName_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Name = "NewFile";
            this.Text = "NewFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileName_tb;
        private System.Windows.Forms.ComboBox fileType_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectFile_btn;
        private System.Windows.Forms.Button addFile_btn;
        private System.Windows.Forms.Label error_label;
    }
}