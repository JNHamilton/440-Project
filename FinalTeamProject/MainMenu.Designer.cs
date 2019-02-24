namespace FinalTeamProject
{
    partial class MainMenu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.repositoryTab = new System.Windows.Forms.TabPage();
            this.error_label = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.commit_btn = new System.Windows.Forms.Button();
            this.fileContents_box = new System.Windows.Forms.RichTextBox();
            this.viewPR_btn = new System.Windows.Forms.Button();
            this.pullList = new System.Windows.Forms.ListBox();
            this.manageFile_btn = new System.Windows.Forms.Button();
            this.newFile_btn = new System.Windows.Forms.Button();
            this.manageBranch_btn = new System.Windows.Forms.Button();
            this.manageRepo_btn = new System.Windows.Forms.Button();
            this.createBranch_btn = new System.Windows.Forms.Button();
            this.branchList = new System.Windows.Forms.ListBox();
            this.fileList = new System.Windows.Forms.ListBox();
            this.createRepo = new System.Windows.Forms.Button();
            this.repoList = new System.Windows.Forms.ListBox();
            this.pullRequestTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.openRequestsTab = new System.Windows.Forms.TabPage();
            this.openPR_box = new System.Windows.Forms.ListBox();
            this.closedRequestsTab = new System.Windows.Forms.TabPage();
            this.closedPR_box = new System.Windows.Forms.ListBox();
            this.accountTab = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.saved_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveProfile_btn = new System.Windows.Forms.Button();
            this.userRepoList = new System.Windows.Forms.ListBox();
            this.location_tb = new System.Windows.Forms.TextBox();
            this.company_tb = new System.Windows.Forms.TextBox();
            this.bio_tb = new System.Windows.Forms.RichTextBox();
            this.email_tb = new System.Windows.Forms.TextBox();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.socialTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedUserRepo_box = new System.Windows.Forms.ListBox();
            this.bio_label = new System.Windows.Forms.Label();
            this.location_label = new System.Windows.Forms.Label();
            this.company_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.userList_box = new System.Windows.Forms.ListBox();
            this.signOut_btn = new System.Windows.Forms.Button();
            this.welcome_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.repositoryTab.SuspendLayout();
            this.pullRequestTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.openRequestsTab.SuspendLayout();
            this.closedRequestsTab.SuspendLayout();
            this.accountTab.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.profileTab.SuspendLayout();
            this.socialTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.repositoryTab);
            this.tabControl1.Controls.Add(this.pullRequestTab);
            this.tabControl1.Controls.Add(this.accountTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // repositoryTab
            // 
            this.repositoryTab.Controls.Add(this.error_label);
            this.repositoryTab.Controls.Add(this.header_label);
            this.repositoryTab.Controls.Add(this.commit_btn);
            this.repositoryTab.Controls.Add(this.fileContents_box);
            this.repositoryTab.Controls.Add(this.viewPR_btn);
            this.repositoryTab.Controls.Add(this.pullList);
            this.repositoryTab.Controls.Add(this.manageFile_btn);
            this.repositoryTab.Controls.Add(this.newFile_btn);
            this.repositoryTab.Controls.Add(this.manageBranch_btn);
            this.repositoryTab.Controls.Add(this.manageRepo_btn);
            this.repositoryTab.Controls.Add(this.createBranch_btn);
            this.repositoryTab.Controls.Add(this.branchList);
            this.repositoryTab.Controls.Add(this.fileList);
            this.repositoryTab.Controls.Add(this.createRepo);
            this.repositoryTab.Controls.Add(this.repoList);
            this.repositoryTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repositoryTab.Location = new System.Drawing.Point(4, 22);
            this.repositoryTab.Name = "repositoryTab";
            this.repositoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.repositoryTab.Size = new System.Drawing.Size(602, 419);
            this.repositoryTab.TabIndex = 0;
            this.repositoryTab.Text = "Repositories";
            this.repositoryTab.UseVisualStyleBackColor = true;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(9, 39);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 16;
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Location = new System.Drawing.Point(171, 13);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(0, 13);
            this.header_label.TabIndex = 15;
            // 
            // commit_btn
            // 
            this.commit_btn.Location = new System.Drawing.Point(448, 392);
            this.commit_btn.Name = "commit_btn";
            this.commit_btn.Size = new System.Drawing.Size(150, 23);
            this.commit_btn.TabIndex = 13;
            this.commit_btn.Text = "Commit Changes";
            this.commit_btn.UseVisualStyleBackColor = true;
            this.commit_btn.Click += new System.EventHandler(this.commit_btn_Click);
            // 
            // fileContents_box
            // 
            this.fileContents_box.Location = new System.Drawing.Point(195, 241);
            this.fileContents_box.Name = "fileContents_box";
            this.fileContents_box.Size = new System.Drawing.Size(404, 153);
            this.fileContents_box.TabIndex = 12;
            this.fileContents_box.Text = "";
            // 
            // viewPR_btn
            // 
            this.viewPR_btn.Location = new System.Drawing.Point(8, 371);
            this.viewPR_btn.Name = "viewPR_btn";
            this.viewPR_btn.Size = new System.Drawing.Size(151, 23);
            this.viewPR_btn.TabIndex = 11;
            this.viewPR_btn.Text = "View Selected Pull Request";
            this.viewPR_btn.UseVisualStyleBackColor = true;
            this.viewPR_btn.Click += new System.EventHandler(this.viewPR_btn_Click);
            // 
            // pullList
            // 
            this.pullList.FormattingEnabled = true;
            this.pullList.Location = new System.Drawing.Point(7, 270);
            this.pullList.Name = "pullList";
            this.pullList.Size = new System.Drawing.Size(151, 95);
            this.pullList.TabIndex = 10;
            this.pullList.SelectedIndexChanged += new System.EventHandler(this.pullList_SelectedIndexChanged);
            // 
            // manageFile_btn
            // 
            this.manageFile_btn.Location = new System.Drawing.Point(448, 187);
            this.manageFile_btn.Name = "manageFile_btn";
            this.manageFile_btn.Size = new System.Drawing.Size(151, 23);
            this.manageFile_btn.TabIndex = 8;
            this.manageFile_btn.Text = "Manage Selected";
            this.manageFile_btn.UseVisualStyleBackColor = true;
            this.manageFile_btn.Click += new System.EventHandler(this.manageFile_btn_Click);
            // 
            // newFile_btn
            // 
            this.newFile_btn.Location = new System.Drawing.Point(448, 58);
            this.newFile_btn.Name = "newFile_btn";
            this.newFile_btn.Size = new System.Drawing.Size(151, 23);
            this.newFile_btn.TabIndex = 7;
            this.newFile_btn.Text = "Create New File";
            this.newFile_btn.UseVisualStyleBackColor = true;
            this.newFile_btn.Click += new System.EventHandler(this.newFile_btn_Click);
            // 
            // manageBranch_btn
            // 
            this.manageBranch_btn.Location = new System.Drawing.Point(225, 188);
            this.manageBranch_btn.Name = "manageBranch_btn";
            this.manageBranch_btn.Size = new System.Drawing.Size(151, 23);
            this.manageBranch_btn.TabIndex = 6;
            this.manageBranch_btn.Text = "Manage Selected";
            this.manageBranch_btn.UseVisualStyleBackColor = true;
            this.manageBranch_btn.Click += new System.EventHandler(this.manageBranch_btn_Click);
            // 
            // manageRepo_btn
            // 
            this.manageRepo_btn.Location = new System.Drawing.Point(7, 188);
            this.manageRepo_btn.Name = "manageRepo_btn";
            this.manageRepo_btn.Size = new System.Drawing.Size(150, 23);
            this.manageRepo_btn.TabIndex = 5;
            this.manageRepo_btn.Text = "Manage Selected";
            this.manageRepo_btn.UseVisualStyleBackColor = true;
            this.manageRepo_btn.Click += new System.EventHandler(this.manageRepo_btn_Click);
            // 
            // createBranch_btn
            // 
            this.createBranch_btn.Location = new System.Drawing.Point(225, 58);
            this.createBranch_btn.Name = "createBranch_btn";
            this.createBranch_btn.Size = new System.Drawing.Size(151, 23);
            this.createBranch_btn.TabIndex = 4;
            this.createBranch_btn.Text = "Create New Branch";
            this.createBranch_btn.UseVisualStyleBackColor = true;
            this.createBranch_btn.Click += new System.EventHandler(this.createBranch_btn_Click);
            // 
            // branchList
            // 
            this.branchList.FormattingEnabled = true;
            this.branchList.Location = new System.Drawing.Point(225, 87);
            this.branchList.Name = "branchList";
            this.branchList.Size = new System.Drawing.Size(151, 95);
            this.branchList.TabIndex = 3;
            this.branchList.SelectedIndexChanged += new System.EventHandler(this.branchList_SelectedIndexChanged);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(448, 87);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(151, 95);
            this.fileList.TabIndex = 2;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            // 
            // createRepo
            // 
            this.createRepo.Location = new System.Drawing.Point(7, 58);
            this.createRepo.Name = "createRepo";
            this.createRepo.Size = new System.Drawing.Size(150, 23);
            this.createRepo.TabIndex = 1;
            this.createRepo.Text = "Create New Repository";
            this.createRepo.UseVisualStyleBackColor = true;
            this.createRepo.Click += new System.EventHandler(this.createRepo_Click);
            // 
            // repoList
            // 
            this.repoList.FormattingEnabled = true;
            this.repoList.Location = new System.Drawing.Point(6, 87);
            this.repoList.Name = "repoList";
            this.repoList.Size = new System.Drawing.Size(151, 95);
            this.repoList.TabIndex = 0;
            this.repoList.SelectedIndexChanged += new System.EventHandler(this.repoList_SelectedIndexChanged);
            // 
            // pullRequestTab
            // 
            this.pullRequestTab.Controls.Add(this.tabControl2);
            this.pullRequestTab.Location = new System.Drawing.Point(4, 22);
            this.pullRequestTab.Name = "pullRequestTab";
            this.pullRequestTab.Padding = new System.Windows.Forms.Padding(3);
            this.pullRequestTab.Size = new System.Drawing.Size(602, 419);
            this.pullRequestTab.TabIndex = 1;
            this.pullRequestTab.Text = "Pull Requests";
            this.pullRequestTab.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.openRequestsTab);
            this.tabControl2.Controls.Add(this.closedRequestsTab);
            this.tabControl2.Location = new System.Drawing.Point(8, 52);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(583, 289);
            this.tabControl2.TabIndex = 0;
            // 
            // openRequestsTab
            // 
            this.openRequestsTab.Controls.Add(this.openPR_box);
            this.openRequestsTab.Location = new System.Drawing.Point(4, 22);
            this.openRequestsTab.Name = "openRequestsTab";
            this.openRequestsTab.Padding = new System.Windows.Forms.Padding(3);
            this.openRequestsTab.Size = new System.Drawing.Size(575, 263);
            this.openRequestsTab.TabIndex = 0;
            this.openRequestsTab.Text = "Open Requests";
            this.openRequestsTab.UseVisualStyleBackColor = true;
            // 
            // openPR_box
            // 
            this.openPR_box.FormattingEnabled = true;
            this.openPR_box.Location = new System.Drawing.Point(4, 4);
            this.openPR_box.Name = "openPR_box";
            this.openPR_box.Size = new System.Drawing.Size(568, 251);
            this.openPR_box.TabIndex = 0;
            // 
            // closedRequestsTab
            // 
            this.closedRequestsTab.Controls.Add(this.closedPR_box);
            this.closedRequestsTab.Location = new System.Drawing.Point(4, 22);
            this.closedRequestsTab.Name = "closedRequestsTab";
            this.closedRequestsTab.Padding = new System.Windows.Forms.Padding(3);
            this.closedRequestsTab.Size = new System.Drawing.Size(575, 263);
            this.closedRequestsTab.TabIndex = 1;
            this.closedRequestsTab.Text = "Closed Requests";
            this.closedRequestsTab.UseVisualStyleBackColor = true;
            // 
            // closedPR_box
            // 
            this.closedPR_box.FormattingEnabled = true;
            this.closedPR_box.Location = new System.Drawing.Point(3, 3);
            this.closedPR_box.Name = "closedPR_box";
            this.closedPR_box.Size = new System.Drawing.Size(566, 251);
            this.closedPR_box.TabIndex = 0;
            // 
            // accountTab
            // 
            this.accountTab.Controls.Add(this.tabControl3);
            this.accountTab.Location = new System.Drawing.Point(4, 22);
            this.accountTab.Name = "accountTab";
            this.accountTab.Size = new System.Drawing.Size(602, 419);
            this.accountTab.TabIndex = 2;
            this.accountTab.Text = "Account";
            this.accountTab.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.profileTab);
            this.tabControl3.Controls.Add(this.socialTab);
            this.tabControl3.Location = new System.Drawing.Point(8, 12);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(583, 394);
            this.tabControl3.TabIndex = 0;
            // 
            // profileTab
            // 
            this.profileTab.Controls.Add(this.label3);
            this.profileTab.Controls.Add(this.saved_label);
            this.profileTab.Controls.Add(this.label1);
            this.profileTab.Controls.Add(this.saveProfile_btn);
            this.profileTab.Controls.Add(this.userRepoList);
            this.profileTab.Controls.Add(this.location_tb);
            this.profileTab.Controls.Add(this.company_tb);
            this.profileTab.Controls.Add(this.bio_tb);
            this.profileTab.Controls.Add(this.email_tb);
            this.profileTab.Controls.Add(this.name_tb);
            this.profileTab.Location = new System.Drawing.Point(4, 22);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3);
            this.profileTab.Size = new System.Drawing.Size(575, 368);
            this.profileTab.TabIndex = 0;
            this.profileTab.Text = "Profile";
            this.profileTab.UseVisualStyleBackColor = true;
            // 
            // saved_label
            // 
            this.saved_label.AutoSize = true;
            this.saved_label.ForeColor = System.Drawing.Color.Green;
            this.saved_label.Location = new System.Drawing.Point(237, 38);
            this.saved_label.Name = "saved_label";
            this.saved_label.Size = new System.Drawing.Size(0, 13);
            this.saved_label.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "This is how your profile looks to other people.\r\nYou can make changes here if you" +
    " would like.";
            // 
            // saveProfile_btn
            // 
            this.saveProfile_btn.Location = new System.Drawing.Point(6, 342);
            this.saveProfile_btn.Name = "saveProfile_btn";
            this.saveProfile_btn.Size = new System.Drawing.Size(178, 23);
            this.saveProfile_btn.TabIndex = 6;
            this.saveProfile_btn.Text = "Save Changes";
            this.saveProfile_btn.UseVisualStyleBackColor = true;
            this.saveProfile_btn.Click += new System.EventHandler(this.saveProfile_btn_Click);
            // 
            // userRepoList
            // 
            this.userRepoList.FormattingEnabled = true;
            this.userRepoList.Location = new System.Drawing.Point(342, 52);
            this.userRepoList.Name = "userRepoList";
            this.userRepoList.Size = new System.Drawing.Size(227, 173);
            this.userRepoList.TabIndex = 5;
            // 
            // location_tb
            // 
            this.location_tb.Location = new System.Drawing.Point(6, 194);
            this.location_tb.Name = "location_tb";
            this.location_tb.Size = new System.Drawing.Size(178, 20);
            this.location_tb.TabIndex = 4;
            this.location_tb.Text = "Location";
            // 
            // company_tb
            // 
            this.company_tb.Location = new System.Drawing.Point(6, 150);
            this.company_tb.Name = "company_tb";
            this.company_tb.Size = new System.Drawing.Size(178, 20);
            this.company_tb.TabIndex = 3;
            this.company_tb.Text = "Company";
            // 
            // bio_tb
            // 
            this.bio_tb.Location = new System.Drawing.Point(6, 237);
            this.bio_tb.Name = "bio_tb";
            this.bio_tb.Size = new System.Drawing.Size(563, 96);
            this.bio_tb.TabIndex = 2;
            this.bio_tb.Text = "Bio";
            // 
            // email_tb
            // 
            this.email_tb.Location = new System.Drawing.Point(6, 101);
            this.email_tb.Name = "email_tb";
            this.email_tb.Size = new System.Drawing.Size(178, 20);
            this.email_tb.TabIndex = 1;
            this.email_tb.Text = "Email";
            // 
            // name_tb
            // 
            this.name_tb.Location = new System.Drawing.Point(6, 52);
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(178, 20);
            this.name_tb.TabIndex = 0;
            this.name_tb.Text = "Name";
            // 
            // socialTab
            // 
            this.socialTab.Controls.Add(this.label2);
            this.socialTab.Controls.Add(this.selectedUserRepo_box);
            this.socialTab.Controls.Add(this.bio_label);
            this.socialTab.Controls.Add(this.location_label);
            this.socialTab.Controls.Add(this.company_label);
            this.socialTab.Controls.Add(this.email_label);
            this.socialTab.Controls.Add(this.name_label);
            this.socialTab.Controls.Add(this.userList_box);
            this.socialTab.Location = new System.Drawing.Point(4, 22);
            this.socialTab.Name = "socialTab";
            this.socialTab.Padding = new System.Windows.Forms.Padding(3);
            this.socialTab.Size = new System.Drawing.Size(575, 368);
            this.socialTab.TabIndex = 1;
            this.socialTab.Text = "Social";
            this.socialTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Repositories:";
            // 
            // selectedUserRepo_box
            // 
            this.selectedUserRepo_box.FormattingEnabled = true;
            this.selectedUserRepo_box.Location = new System.Drawing.Point(425, 57);
            this.selectedUserRepo_box.Name = "selectedUserRepo_box";
            this.selectedUserRepo_box.Size = new System.Drawing.Size(120, 147);
            this.selectedUserRepo_box.TabIndex = 6;
            // 
            // bio_label
            // 
            this.bio_label.AutoSize = true;
            this.bio_label.Location = new System.Drawing.Point(161, 153);
            this.bio_label.Name = "bio_label";
            this.bio_label.Size = new System.Drawing.Size(28, 13);
            this.bio_label.TabIndex = 5;
            this.bio_label.Text = "Bio: ";
            // 
            // location_label
            // 
            this.location_label.AutoSize = true;
            this.location_label.Location = new System.Drawing.Point(161, 121);
            this.location_label.Name = "location_label";
            this.location_label.Size = new System.Drawing.Size(54, 13);
            this.location_label.TabIndex = 4;
            this.location_label.Text = "Location: ";
            // 
            // company_label
            // 
            this.company_label.AutoSize = true;
            this.company_label.Location = new System.Drawing.Point(161, 89);
            this.company_label.Name = "company_label";
            this.company_label.Size = new System.Drawing.Size(57, 13);
            this.company_label.TabIndex = 3;
            this.company_label.Text = "Company: ";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(161, 57);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(38, 13);
            this.email_label.TabIndex = 2;
            this.email_label.Text = "Email: ";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(161, 22);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(38, 13);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Name:";
            // 
            // userList_box
            // 
            this.userList_box.FormattingEnabled = true;
            this.userList_box.Location = new System.Drawing.Point(6, 22);
            this.userList_box.Name = "userList_box";
            this.userList_box.Size = new System.Drawing.Size(120, 316);
            this.userList_box.TabIndex = 0;
            this.userList_box.SelectedIndexChanged += new System.EventHandler(this.userList_box_SelectedIndexChanged);
            // 
            // signOut_btn
            // 
            this.signOut_btn.Location = new System.Drawing.Point(520, 12);
            this.signOut_btn.Name = "signOut_btn";
            this.signOut_btn.Size = new System.Drawing.Size(75, 23);
            this.signOut_btn.TabIndex = 14;
            this.signOut_btn.Text = "Sign Out";
            this.signOut_btn.UseVisualStyleBackColor = true;
            this.signOut_btn.Click += new System.EventHandler(this.signOut_btn_Click);
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Location = new System.Drawing.Point(27, 13);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(81, 13);
            this.welcome_label.TabIndex = 15;
            this.welcome_label.Text = "Welcome name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your repositories:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 476);
            this.Controls.Add(this.welcome_label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.signOut_btn);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.tabControl1.ResumeLayout(false);
            this.repositoryTab.ResumeLayout(false);
            this.repositoryTab.PerformLayout();
            this.pullRequestTab.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.openRequestsTab.ResumeLayout(false);
            this.closedRequestsTab.ResumeLayout(false);
            this.accountTab.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.profileTab.ResumeLayout(false);
            this.profileTab.PerformLayout();
            this.socialTab.ResumeLayout(false);
            this.socialTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage repositoryTab;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button commit_btn;
        private System.Windows.Forms.RichTextBox fileContents_box;
        private System.Windows.Forms.Button viewPR_btn;
        private System.Windows.Forms.ListBox pullList;
        private System.Windows.Forms.Button manageFile_btn;
        private System.Windows.Forms.Button newFile_btn;
        private System.Windows.Forms.Button manageBranch_btn;
        private System.Windows.Forms.Button manageRepo_btn;
        private System.Windows.Forms.Button createBranch_btn;
        private System.Windows.Forms.ListBox branchList;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button createRepo;
        private System.Windows.Forms.ListBox repoList;
        private System.Windows.Forms.TabPage pullRequestTab;
        private System.Windows.Forms.TabPage accountTab;
        private System.Windows.Forms.Button signOut_btn;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage openRequestsTab;
        private System.Windows.Forms.TabPage closedRequestsTab;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.ListBox userRepoList;
        private System.Windows.Forms.TextBox location_tb;
        private System.Windows.Forms.TextBox company_tb;
        private System.Windows.Forms.RichTextBox bio_tb;
        private System.Windows.Forms.TextBox email_tb;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.TabPage socialTab;
        private System.Windows.Forms.Label bio_label;
        private System.Windows.Forms.Label location_label;
        private System.Windows.Forms.Label company_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.ListBox userList_box;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.ListBox openPR_box;
        private System.Windows.Forms.ListBox closedPR_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveProfile_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox selectedUserRepo_box;
        private System.Windows.Forms.Label saved_label;
        private System.Windows.Forms.Label label3;
    }
}