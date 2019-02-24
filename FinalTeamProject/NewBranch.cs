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
    public partial class NewBranch : Form
    {
        public int LOGGED_IN_USER_ID;
        public string LOGGED_IN_USERNAME;
        public int SELECTED_REPO_ID;
        public string REPO_NAME;
        string DIRECTORY;

        public NewBranch(int ID, int RepoID, string RepoName)
        {
            LOGGED_IN_USER_ID = ID;
            SELECTED_REPO_ID = RepoID;
            REPO_NAME = RepoName;
            DIRECTORY = Directory.GetCurrentDirectory();
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME, 1);
            mainMenu.Show();
            this.Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string branchName = newBranch_tb.Text.ToString();
              
            if (branchName.Contains(" "))
            {
                branchName = branchName.Replace(' ', '_');
                CreateBranch(SELECTED_REPO_ID, branchName);
            }
            else if (branchName.CompareTo("") == 0)
                error_label.Text = "Please enter a name for the branch";
            else
            {
                CreateBranch(SELECTED_REPO_ID, branchName);
            }
              
        }


        // Method to create a branch in the database.
        protected void CreateBranch(int ID, string Name)
        {
            // Checking if branch is a new branch and not existing already in the database.
            if (CheckBranch(ID, Name))
            {
                string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO test (repoID, branchName) VALUES (@rID, @bN);";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@rID", ID);
                    cmd.Parameters.AddWithValue("@bN", Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();

                CreateLocalBranch(Name);

                MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME, 1);
                mainMenu.Show();
                this.Close();
            }
            else
            {
                error_label.ForeColor = System.Drawing.Color.Red;
                error_label.Text = "Branch name already created!";
            } 
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

        protected void CreateLocalBranch(string Name)
        {
            string path = DIRECTORY + @"\" + REPO_NAME + @"\"+Name;
            System.IO.Directory.CreateDirectory(path);
        }
    }
}
