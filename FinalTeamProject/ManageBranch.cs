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
    public partial class ManageBranch : Form
    {
        public int REPO_ID, BRANCH_ID, USER_ID;
        public string REPO_NAME, OLD_BRANCH_NAME, USER_NAME, DIRECTORY;

        public ManageBranch(int RepoID, string RepoName, int BranchID, string BranchName, string Username, int ID)
        {
            REPO_ID = RepoID;
            BRANCH_ID = BranchID;

            REPO_NAME = RepoName;
            OLD_BRANCH_NAME = BranchName;

            USER_ID = ID;
            USER_NAME = Username;

            DIRECTORY = Directory.GetCurrentDirectory();

            InitializeComponent();

            branchName_tb.Text = BranchName;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // First checking if branch name contains a space or is empty.
            string newBranchName = branchName_tb.Text.ToString();

            if(newBranchName.CompareTo("") == 0)
            {
                error_label.Text = "Please enter a name for the branch!"; 
            } else if(newBranchName.Contains(" "))
            {
                newBranchName = newBranchName.Replace(" ", "_");
                if (CheckBranch(REPO_ID, newBranchName))
                    UpdateBranch(BRANCH_ID, newBranchName);
                else
                    error_label.Text = "Branch name already in use!";
            } else
            {
                if(CheckBranch(REPO_ID, newBranchName))
                    UpdateBranch(BRANCH_ID, newBranchName);
                else
                    error_label.Text = "Branch name already in use!";
            }

        }

        protected void UpdateBranch(int ID, string Name)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE test SET branchName=@bID WHERE branchID=@ID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bID", Name);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now changing the name of the file locally.
            string sourcePath = DIRECTORY + @"\" + REPO_NAME + @"\" + OLD_BRANCH_NAME;
            string newPath = DIRECTORY + @"\" + REPO_NAME + @"\" + Name;
            System.IO.Directory.Move(sourcePath, newPath);

            this.Close();
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();

        }
        // Method for checking if branch is already created under the user profile in that repository.
        protected Boolean CheckBranch(int ID, string Name)
        {

            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT branchName FROM test WHERE repoID=@id";
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
            conn.Close();

            foreach (DataRow row in myTable.Rows)
            {
                string branchName = row["branchName"].ToString();
                if (Name.CompareTo(branchName) == 0)
                    return false;
            }
            return true;
        }
    }
}
