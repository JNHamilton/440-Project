namespace FinalTeamProject
{
    partial class CommitChanges
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
            this.commitDirect_btn = new System.Windows.Forms.Button();
            this.pullRequest_btn = new System.Windows.Forms.Button();
            this.comment_box = new System.Windows.Forms.RichTextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commitDirect_btn
            // 
            this.commitDirect_btn.Location = new System.Drawing.Point(15, 256);
            this.commitDirect_btn.Name = "commitDirect_btn";
            this.commitDirect_btn.Size = new System.Drawing.Size(249, 23);
            this.commitDirect_btn.TabIndex = 0;
            this.commitDirect_btn.Text = "Commit Changes Directly to Selected branch";
            this.commitDirect_btn.UseVisualStyleBackColor = true;
            this.commitDirect_btn.Click += new System.EventHandler(this.commitDirect_btn_Click);
            // 
            // pullRequest_btn
            // 
            this.pullRequest_btn.Location = new System.Drawing.Point(15, 185);
            this.pullRequest_btn.Name = "pullRequest_btn";
            this.pullRequest_btn.Size = new System.Drawing.Size(249, 23);
            this.pullRequest_btn.TabIndex = 1;
            this.pullRequest_btn.Text = "Create a Pull Request for Changes";
            this.pullRequest_btn.UseVisualStyleBackColor = true;
            this.pullRequest_btn.Click += new System.EventHandler(this.pullRequest_btn_Click);
            // 
            // comment_box
            // 
            this.comment_box.Location = new System.Drawing.Point(15, 67);
            this.comment_box.Name = "comment_box";
            this.comment_box.Size = new System.Drawing.Size(246, 112);
            this.comment_box.TabIndex = 2;
            this.comment_box.Text = "\n";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(190, 12);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Commit Changes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pull Request Comments (Optional):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "or";
            // 
            // CommitChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.comment_box);
            this.Controls.Add(this.pullRequest_btn);
            this.Controls.Add(this.commitDirect_btn);
            this.Name = "CommitChanges";
            this.Text = "CommitChanges";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commitDirect_btn;
        private System.Windows.Forms.Button pullRequest_btn;
        private System.Windows.Forms.RichTextBox comment_box;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}