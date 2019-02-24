namespace FinalTeamProject
{
    partial class ViewRequest
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
            this.close_btn = new System.Windows.Forms.Button();
            this.orig_box = new System.Windows.Forms.RichTextBox();
            this.changed_box = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(12, 323);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(385, 23);
            this.close_btn.TabIndex = 0;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // orig_box
            // 
            this.orig_box.Location = new System.Drawing.Point(12, 70);
            this.orig_box.Name = "orig_box";
            this.orig_box.Size = new System.Drawing.Size(170, 247);
            this.orig_box.TabIndex = 1;
            this.orig_box.Text = "";
            // 
            // changed_box
            // 
            this.changed_box.Location = new System.Drawing.Point(227, 70);
            this.changed_box.Name = "changed_box";
            this.changed_box.Size = new System.Drawing.Size(170, 247);
            this.changed_box.TabIndex = 2;
            this.changed_box.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Changed File:";
            // 
            // ViewRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changed_box);
            this.Controls.Add(this.orig_box);
            this.Controls.Add(this.close_btn);
            this.Name = "ViewRequest";
            this.Text = "ViewRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.RichTextBox orig_box;
        private System.Windows.Forms.RichTextBox changed_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}