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
    public partial class ManageRequests : Form
    {
        public int USER_ID, FILE_ID, REPO_ID, PR_ID;
        public string USER_NAME, REPO_NAME, DIRECTORY, BRANCH_NAME, FILE_NAME, CHANGED_PATH, ORIG_PATH;

        public ManageRequests(int PrID, string RepoName, string Username, int UserID)
        {
            DIRECTORY = Directory.GetCurrentDirectory();
            PR_ID = PrID;
            USER_ID = UserID;
            USER_NAME = Username;
            REPO_NAME = RepoName;
            InitializeComponent();
            LoadPage(PrID);
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }

        public void LoadPage(int ID)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Will only show open pull requests.
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT * from pull_requests WHERE prID=@id";
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
                int fileID = Int32.Parse(row["fileID"].ToString());
                FILE_ID = fileID;

                FILE_NAME = GetFileName(fileID);
                int branchID = Int32.Parse(row["branchID"].ToString());
                BRANCH_NAME = GetBranchName(branchID);
                int repoID = Int32.Parse(row["repoID"].ToString());

                CHANGED_PATH = DIRECTORY + @"\" + REPO_NAME + @"\ps-" + PR_ID + "-" + BRANCH_NAME;
                CHANGED_PATH = CHANGED_PATH + @"\" + FILE_NAME;

                ORIG_PATH = DIRECTORY + @"\" + REPO_NAME + @"\" + BRANCH_NAME + @"\" + FILE_NAME;

                int status = Int32.Parse(row["prStatus"].ToString());

                if (status == 1)
                    status_label.Text = "Status: Colsed (Commited)";
                if (status == 2)
                    status_label.Text = "Status: Colsed (Denied)";
                if (status == 0)
                    status_label.Text = "Status: Open";
                
                repo_label.Text = "Repository: " + REPO_NAME;
                branch_label.Text = "Branch: " + BRANCH_NAME;
                file_label.Text = "File Being Changed: " + FILE_NAME;
                comments_label.Text = "Comments: " + row["prComments"].ToString();
            }
        }

        public string GetFileName(int ID)
        {
            string name = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Will only show open pull requests.
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT fileName, fileType from files WHERE fileID=@id";
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
                name = row["fileName"].ToString() + row["fileType"].ToString();
            }
            return name;
        }

        private void viewChanges_btn_Click(object sender, EventArgs e)
        {
            // Get file that has been changed. Getting the path of the changed file.
            
            ViewRequest viewRequests = new ViewRequest(CHANGED_PATH, ORIG_PATH);
            viewRequests.Show();

        }

        private void commit_btn_Click(object sender, EventArgs e)
        {
            // First need to copy file and move it to correct folder.
            //      This move will overwrite the change.
            byte[] data = File.ReadAllBytes(CHANGED_PATH);
            string contents = Encoding.ASCII.GetString(data);

            
            File.Delete(ORIG_PATH);
            

            File.Move(CHANGED_PATH, ORIG_PATH);


          

            // Now deleting folder.
            string folder = DIRECTORY + @"\" + REPO_NAME + @"\ps-" + PR_ID + "-" + BRANCH_NAME;
            Directory.Delete(folder);

            string reply = reply_box.Text.ToString();
            if (reply.CompareTo("") == 0)
                reply = "Commited!";

            // Updating database.
            UpdateDatabase(1, reply, PR_ID, FILE_ID, contents);
        }

        private void closeRequest_btn_Click(object sender, EventArgs e)
        {
            // Now deleting folder.
            string folder = DIRECTORY + @"\" + REPO_NAME + @"\" + @"\ps-" + PR_ID + "-" + BRANCH_NAME;

            // Deleting changed path and folder.
            File.Delete(CHANGED_PATH);
            Directory.Delete(folder);

            string reply = reply_box.Text.ToString();
            if (reply.CompareTo("") == 0)
                reply = "Denied!";

            // Updating database.
            UpdateDatabase(2, reply, PR_ID, FILE_ID, "");
        }

        public string GetBranchName(int ID)
        {
            string name = "";
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Will only show open pull requests.
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
                name = row["branchName"].ToString();
            }
            return name;
        }

        public void UpdateDatabase(int Status, string Reply, int ID, int FileID, string Contents)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE pull_requests SET prStatus=@Status, prComments=@Comments WHERE prID=@ID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Comments", Reply);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now checking if the file contents needs to be updated
            if(Status == 1)
            {
                connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
                conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "UPDATE files SET fileContents=@fC WHERE fileID=@ID;";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fC", Contents);
                    cmd.Parameters.AddWithValue("@ID", FileID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }

            CloseWindow();
        }

        public void CloseWindow()
        {
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();

            this.Close();
        }
    }
}
