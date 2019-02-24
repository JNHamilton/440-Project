using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace FinalTeamProject
{
    public partial class MainMenu : Form
    {
        public int LOGGED_IN_USER_ID;
        public string LOGGED_IN_USERNAME;
        public int HAS_REPOSITORIES_BEEN_CREATED;
        public string DIRECTORY;
        public List<int> REPOSITORY_IDS;
        public List<int> BRANCH_IDS;
        public List<string> FILE_TYPES;
        public List<int> FILE_IDS;
        public List<int> PR_IDS;
        public List<string> PR_STATUS;
        public List<int> PR_BRANCH;
        public List<int> PR_FILE;
        public List<int> ALL_USER_IDs;


        string path;

        public MainMenu(int ID, string username, int FirstLogin)
        {
            InitializeComponent();
            LOGGED_IN_USER_ID = ID;
            LOGGED_IN_USERNAME = username;
            HAS_REPOSITORIES_BEEN_CREATED = FirstLogin;
            DIRECTORY = Directory.GetCurrentDirectory();
            path = AppDomain.CurrentDomain.BaseDirectory;
            welcome_label.Text = "Welcome " + username;
            header_label.Text = "";
            GetRepos(LOGGED_IN_USER_ID);
            GetAllUserIDs();
        }

        private void signOut_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Get selected branches from selected repository.
        private void repoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clearing branches and files when new repository is selected.
            branchList.Items.Clear();
            fileList.Items.Clear();
            pullList.Items.Clear();

            // Now need to get the repository ID for the selected repository.
            if(repoList.SelectedIndex != -1)
            {
                int selectedID = REPOSITORY_IDS[repoList.SelectedIndex];
                // Next need to create/load branches in selected repository.
                LoadBranches(selectedID);
                LoadPullRequests(selectedID);
            }
            

            
        }

        private void branchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a branch is selected clear the file list
            fileList.Items.Clear();

            // Now getting selected branch ID.
            if (branchList.SelectedIndex != -1)
            {
                int selectedID = BRANCH_IDS[branchList.SelectedIndex];
                // Now loading files.
                LoadFiles(selectedID);
            }

            
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (fileList.SelectedIndex != -1)
            {
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);
                string selectedBranch = branchList.GetItemText(branchList.SelectedItem);
                string selectedFile = fileList.GetItemText(fileList.SelectedItem) + FILE_TYPES[fileList.SelectedIndex];
                
                string path = DIRECTORY + @"\" + selectedRepo + @"\" + selectedBranch + @"\" + selectedFile;
                
                byte[] data = File.ReadAllBytes(path);
                string contents = Encoding.ASCII.GetString(data);
                fileContents_box.Text = contents;
            }
        }

        private void pullList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GetAllUserIDs()
        {
            ALL_USER_IDs = new List<int>();

            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT userID, userName FROM user WHERE userID <> @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", LOGGED_IN_USER_ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            foreach (DataRow row in myTable.Rows)
            {
                int userID = Int32.Parse(row["userID"].ToString());
                string userName = row["userName"].ToString();
                ALL_USER_IDs.Add(userID);
                userList_box.Items.Add(userName);
            }
        }

        protected void GetRepos(int ID)
        {
            // Storing user IDs into a list array will use later to pull branches and files out.
            REPOSITORY_IDS = new List<int>();

            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoID FROM user_connections WHERE userID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Get user created Repositories
            foreach(DataRow row in myTable.Rows)
            {
                int repoID = Int32.Parse(row["repoID"].ToString());
                REPOSITORY_IDS.Add(repoID);
                GetAllPullRequests(repoID);
                LoadRepos(repoID, 1);
                
            }
        }

        protected void GetAllPullRequests(int ID)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT * from pull_requests WHERE repoID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                // Sets repository to list box then creates repository on local computer.
                string prID = row["prID"].ToString();
                string repoName = GetRepoName(Int32.Parse(row["repoID"].ToString()));
                string branchName = GetBranchName(Int32.Parse(row["branchID"].ToString()));
                string fileName = GetFileName(Int32.Parse(row["branchID"].ToString()));
                string comments = row["prComments"].ToString();
                int status = Int32.Parse(row["prStatus"].ToString());

                string statusString = "";
                if (status == 0)
                    statusString = "Open!";
                if (status == 1)
                    statusString = "Closed (Commited)";
                if (status == 2)
                    statusString = "Closed (Denied)";
                string prContents = "Repo: "+repoName+ ", Branch: " + branchName + ", File: " + fileName + " Comments: " + comments + " Status: "+statusString;

                // Now will sort based on status
                if (status != 0)
                    closedPR_box.Items.Add(prContents);
                else
                    openPR_box.Items.Add(prContents);
            }
        }

        protected void GetUserInfo(int ID, int Process)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT * from user WHERE userID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                
                string name = row["name"].ToString();
                string email = row["email"].ToString();
                string company = row["company"].ToString();
                string location = row["location"].ToString();
                if(Process == 0)
                {
                    name_tb.Text = name;
                    email_tb.Text = email;
                    company_tb.Text = company;
                    location_tb.Text = location;
                    GetUserRepo(ID, 1);
                }
                else
                {
                    name_label.Text = name;
                    email_label.Text = email;
                    company_label.Text = company;
                    location_label.Text = location;
                    GetUserRepo(ID, 2);
                }
            }
        }

        protected void GetUserRepo(int ID, int Process)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoID FROM user_connections WHERE userID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create and load repositories into table.
            foreach (DataRow row in myTable.Rows)
            {
                int RepoID = Int32.Parse(row["repoID"].ToString());
                if (Process == 1)
                    LoadRepos(RepoID, 2);
                else
                    LoadRepos(RepoID, 3);
            }
        }


        protected void LoadRepos(int repoID, int Process)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoName from repository WHERE repoID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", repoID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create and load repositories into table.
            foreach (DataRow row in myTable.Rows)
            {
                // Sets repository to list box then creates repository on local computer.
                string rName = row["repoName"].ToString();

                // Checking what process.
                if (Process == 1)
                {
                    repoList.Items.Add(rName);
                    userRepoList.Items.Add(rName);
                }
                else if (Process == 2)
                    Console.WriteLine("Repo"); // for testing

                else if (Process == 3)
                    selectedUserRepo_box.Items.Add(rName);

                if (HAS_REPOSITORIES_BEEN_CREATED == 0)
                {
                    if (Process == 1)
                    {
                        CreateRepo(rName);
                        CreateBranches(repoID, rName);
                    }
                }
            }
        }

        protected void LoadBranches(int ID)
        {
            BRANCH_IDS = new List<int>();
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT branchID, branchName from test WHERE repoID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create and load repositories into table.
            foreach (DataRow row in myTable.Rows)
            {
                //Adding the branch ID to the list and adding item to listbox.
                int bID = Int32.Parse(row["branchID"].ToString());
                BRANCH_IDS.Add(bID);
                string bName = row["branchName"].ToString();
                branchList.Items.Add(bName);
            }
        }

        // Loading files of selected branch
        protected void LoadFiles(int ID)
        {
            FILE_TYPES = new List<string>();
            FILE_IDS = new List<int>();
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT * from files WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create and load repositories into table.
            foreach (DataRow row in myTable.Rows)
            {
                //Adding file types and IDs to list while adding file IDs to list also.
                //      Then adding file names to listbox.
                string fType = row["fileType"].ToString();
                FILE_TYPES.Add(fType);
                string fName = row["fileName"].ToString();
                fileList.Items.Add(fName);

                // Now loading the contents of the file into the file itself.
                string fileContents = row["fileContents"].ToString();
                string branchName = GetBranchName(Int32.Parse(row["branchID"].ToString()));
                string repoName = GetRepoName(Int32.Parse(row["branchID"].ToString()));

                string path = DIRECTORY + @"\" + repoName + @"\" + branchName + @"\" + fName + fType;

                byte[] data = Encoding.ASCII.GetBytes(fileContents);

                File.WriteAllBytes(path, data);
                
                int fID = Int32.Parse(row["fileID"].ToString());
                FILE_IDS.Add(fID);
            }
        }

        // Loading pull requests when a repository is selected.
        protected void LoadPullRequests(int ID)
        {
            PR_IDS = new List<int>();
            PR_BRANCH = new List<int>();
            PR_FILE = new List<int>();


            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Will only show open pull requests.
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT * from pull_requests WHERE repoID=@id AND prStatus=@Status";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@Status", 0);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                int prID = Int32.Parse(row["prID"].ToString());
                int prBranch = Int32.Parse(row["branchID"].ToString());
                int prFile = Int32.Parse(row["fileID"].ToString());
                string branchName = GetBranchName(prBranch);

                // Setting all IDs to use later when wanting to merge or view a specific pull request.
                PR_IDS.Add(prID);
                PR_BRANCH.Add(prBranch);
                PR_FILE.Add(prFile);

                // Adding pull requests names to list box
                pullList.Items.Add("pr-" + branchName);
            }
        }

        protected string GetBranchName(int ID)
        {
            string branchName = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT branchName from test WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                branchName = row["branchName"].ToString();
            }
            return branchName;
        }

        protected string GetRepoName(int ID)
        {
            string repoName = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoID from test WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                repoName = GetRepo(Int32.Parse(row["repoID"].ToString()));
            }
            return repoName;
        }

        protected string GetFileName(int ID)
        {
            string fileName = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoID from test WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                fileName = GetRepo(Int32.Parse(row["repoID"].ToString()));
            }
            return fileName;
        }

        protected string GetRepo(int ID)
        {
            string repoName = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoName from repository WHERE repoID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                repoName = row["repoName"].ToString();
            }
            return repoName;
        }

        // Creates repository locally.
        protected void CreateRepo(string repoName)
        {
            string path = DIRECTORY + @"\" + repoName;
            System.IO.Directory.CreateDirectory(path);
        }

        // This method creates branches locally based on database.
        protected void CreateBranches(int ID, string Name)
        {
            
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT branchName, branchID from test WHERE repoID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                // Creating local folder for branch.
                string bName = row["branchName"].ToString();
                string path = DIRECTORY + @"\" + Name + @"\" + bName;
                var file = System.IO.Directory.CreateDirectory(path);
                file.Refresh();

                // Now will create files inside the branch. First getting branch ID.
                int bID = Int32.Parse(row["branchID"].ToString());
                CreateFiles(bID, Name, bName);
            }
        }

        // Method for creating files locally based on branch ID, Repo name, and Branch name.
        protected void CreateFiles(int ID, string RepoName, string BranchName)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT fileID, fileName, fileType, fileContents from files WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (DataRow row in myTable.Rows)
            {
                // Creating local folder for branch.
                string fName = row["fileName"].ToString();
                string fType = row["fileType"].ToString();
                string fContents = row["fileContents"].ToString();
                string file = fName + fType;
                string path = DIRECTORY + @"\" + RepoName + @"\" + BranchName + @"\" + file;

                byte[] data = Encoding.ASCII.GetBytes(fContents);
                File.WriteAllBytes(path, data);
                var createdFile = System.IO.File.Create(path);
                createdFile.Close();
                
            }
        }

        private void createRepo_Click(object sender, EventArgs e)
        {
            createRepo create = new createRepo(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME);
            create.Show();
            this.Hide();
        }

        private void manageRepo_btn_Click(object sender, EventArgs e)
        {
            if (repoList.SelectedIndex != -1)
            {
                int selectedID = REPOSITORY_IDS[repoList.SelectedIndex];
                ManageRepos manageRepos = new ManageRepos(LOGGED_IN_USER_ID, selectedID, LOGGED_IN_USERNAME);
                manageRepos.Show();
                this.Hide();
            }
            error_label.Text = "Please select a repository to manage!";
        }

        private void createBranch_btn_Click(object sender, EventArgs e)
        {
            if (repoList.SelectedIndex != -1)
            {
                int selectedID = REPOSITORY_IDS[repoList.SelectedIndex];
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);
                NewBranch newBranch = new NewBranch(LOGGED_IN_USER_ID, selectedID, selectedRepo);
                newBranch.Show();
                this.Hide();
            }
            error_label.Text = "Please select a repository to create a branch in!";
        }

        private void manageBranch_btn_Click(object sender, EventArgs e)
        {
            if (branchList.SelectedIndex != -1)
            {
                // Getting selected repo data.
                int selectedRepoID = REPOSITORY_IDS[repoList.SelectedIndex];
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);

                // Getting selected branch data.
                int selectedBranchID = BRANCH_IDS[branchList.SelectedIndex];
                string selectedBranch = branchList.GetItemText(branchList.SelectedItem);

                ManageBranch manageBranch = new ManageBranch(selectedRepoID, selectedRepo, selectedBranchID, selectedBranch, LOGGED_IN_USERNAME, LOGGED_IN_USER_ID);
                manageBranch.Show();
                this.Hide();
            }
            error_label.Text = "Please select a branch to manage!";
        }

        private void newFile_btn_Click(object sender, EventArgs e)
        {
            if (branchList.SelectedIndex != -1)
            {
                // Getting selected repo data.
                int selectedRepoID = REPOSITORY_IDS[repoList.SelectedIndex];
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);

                // Getting selected branch data.
                int selectedBranchID = BRANCH_IDS[branchList.SelectedIndex];
                string selectedBranch = branchList.GetItemText(branchList.SelectedItem);

                NewFile newFile = new NewFile(selectedRepoID, selectedRepo, selectedBranchID, selectedBranch, LOGGED_IN_USERNAME, LOGGED_IN_USER_ID);
                newFile.Show();
                
                this.Hide();
            }
            error_label.Text = "Please select a branch to manage!";
        }

        private void manageFile_btn_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedIndex != -1)
            {
                // Getting selected repo data.
                int selectedRepoID = REPOSITORY_IDS[repoList.SelectedIndex];
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);

                // Getting selected branch data.
                int selectedBranchID = BRANCH_IDS[branchList.SelectedIndex];
                string selectedBranch = branchList.GetItemText(branchList.SelectedItem);

                // Getting selected file ID, Name, and Type.
                int selectedFileID = FILE_IDS[fileList.SelectedIndex];
                string selectedFileName = fileList.GetItemText(fileList.SelectedItem);
                string selectedFileType = FILE_TYPES[fileList.SelectedIndex];

                ManageFile manageFile = new ManageFile( selectedBranchID, selectedRepo, selectedBranch, selectedFileID, selectedFileName, selectedFileType, LOGGED_IN_USERNAME, LOGGED_IN_USER_ID);
                manageFile.Show();

                this.Hide();
            }
            error_label.Text = "Please select a branch to manage!";
        }

        private void viewPR_btn_Click(object sender, EventArgs e)
        {
            if (pullList.SelectedIndex != -1)
            {
                int RepoID = REPOSITORY_IDS[repoList.SelectedIndex];
                int PRID = PR_IDS[pullList.SelectedIndex];
                int fileID = PR_FILE[pullList.SelectedIndex];
                int branchID = PR_BRANCH[pullList.SelectedIndex];
                string RepoName = repoList.GetItemText(repoList.SelectedItem);

                ManageRequests pullRequests = new ManageRequests(PRID, RepoName, LOGGED_IN_USERNAME, LOGGED_IN_USER_ID);
                pullRequests.Show();

                this.Hide();
            }
            else
            {
                error_label.Text = "Please select a pull request to view!";
            }
        }

        private void commit_btn_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedIndex != -1)
            {
                string selectedRepo = repoList.GetItemText(repoList.SelectedItem);
                string selectedBranch = branchList.GetItemText(branchList.SelectedItem);
                string selectedFile = fileList.GetItemText(fileList.SelectedItem) + FILE_TYPES[fileList.SelectedIndex];
                string path = DIRECTORY + @"\" + selectedRepo + @"\" + selectedBranch + @"\" + selectedFile;

                int repoID = REPOSITORY_IDS[repoList.SelectedIndex];
                

                int fileID = FILE_IDS[fileList.SelectedIndex];
                int branchID = BRANCH_IDS[branchList.SelectedIndex];
                string RepoName = repoList.GetItemText(repoList.SelectedItem);

                string fileContents = fileContents_box.Text.ToString();
                byte[] contents = Encoding.UTF8.GetBytes(fileContents);

                CommitChanges commitChanges = new CommitChanges(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME, fileID, repoID, branchID, selectedRepo, selectedBranch, selectedFile, contents);
                commitChanges.Show();
                this.Hide();
            }
        }

        private void userList_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUserRepo_box.Items.Clear();
            int selectedID = ALL_USER_IDs[userList_box.SelectedIndex];
            GetUserRepo(selectedID, 2);
        }

        private void saveProfile_btn_Click(object sender, EventArgs e)
        {
            string newBio = bio_tb.Text.ToString();
            string newName = name_tb.Text.ToString();
            string newEmail = email_tb.Text.ToString();
            string newCompany = company_label.Text.ToString();
            string newLocation = location_label.Text.ToString();

            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE user SET bio=@bio, name=@n, email=@e, company=@c, location=@l WHERE userID=@uID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@uID", LOGGED_IN_USER_ID);
                cmd.Parameters.AddWithValue("@bio", newBio);
                cmd.Parameters.AddWithValue("@n", newName);
                cmd.Parameters.AddWithValue("@e", newEmail);
                cmd.Parameters.AddWithValue("@c", newCompany);
                cmd.Parameters.AddWithValue("@l", newLocation);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            saved_label.Text = "Contents saved!";
        }
    }
}
