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
    public partial class ManageRepos : Form
    {
        public int LOGGED_IN_USER_ID;
        public int SELECTED_REPO_ID;
        public List<int> CONTRIBUTOR_IDS;
        public string DIRECTORY;
        public string OLD_NAME;
        public string LOGGED_IN_USER_NAME;

        public ManageRepos(int UserID, int RepoID, string Username)
        {
            LOGGED_IN_USER_ID = UserID;
            LOGGED_IN_USER_NAME = Username;
            SELECTED_REPO_ID = RepoID;
            DIRECTORY = Directory.GetCurrentDirectory();

            InitializeComponent();
            GetSelectedRepo(SELECTED_REPO_ID);
            GetContributors(SELECTED_REPO_ID, LOGGED_IN_USER_ID);
            LoadUsers(LOGGED_IN_USER_ID);
        }



        private void save_btn_Click(object sender, EventArgs e)
        {
            
            string newRepoName = repoName_tb.Text;
            if (newRepoName.CompareTo("") == 0)
                // Need a repository name
                error_label.Text = "NEED TO DECLARE A REPOSITORY NAME!";
            else if (newRepoName.Contains(" "))
            {

                // contains a space just fix it for user.
                newRepoName = newRepoName.Replace(' ', '_');

                if (CheckRepositories(LOGGED_IN_USER_ID))
                    SaveChanges(SELECTED_REPO_ID, newRepoName);
                else
                    error_label.Text = "REPOSITORY NAME ALREADY EXISTS!";

                // Now need to check if any users were added to the contributors list. If so then add them to database.
                CheckNewContributors();
            }
            else
            {
                if (CheckRepositories(LOGGED_IN_USER_ID))
                    SaveChanges(SELECTED_REPO_ID, newRepoName);
                else
                    error_label.Text = "REPOSITORY NAME ALREADY EXISTS!";

                // Now need to check if any users were added to the contributors list. If so then add them to database.
                CheckNewContributors();
            }     
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            // get username of selected user.
            string selectedName = userList.GetItemText(userList.SelectedItem);

            // remove selected name from userList
            userList.Items.Remove(userList.SelectedItem);

            // add it to contributor list.
            contributorsList.Items.Add(selectedName);
        }

        protected void GetSelectedRepo(int ID)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoName, repoDescription FROM repository WHERE repoID=@id";
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

            // Get user created Repositories
            foreach (DataRow row in myTable.Rows)
            {
                string rName = row["repoName"].ToString();
                string rDesc = row["repoDescription"].ToString();
                OLD_NAME = rName;
                header_label.Text = rName;
                repoName_tb.Text = rName;
                description_tb.Text = rDesc;
            }

            
        }

        // Method to get contributors of selected repository.
        protected void GetContributors(int ID, int UserID)
        {
            CONTRIBUTOR_IDS = new List<int>();
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT userID FROM user_connections WHERE repoID=@rID AND userID <> @uID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rID", ID);
                cmd.Parameters.AddWithValue("@uID", UserID);
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
                // Get contributor ID's and load the correct username. Adding ID to a list to know what usernames we need to display on the UserList.
                //      So we dont get duplicates.
                int contributorID = Int32.Parse(row["userID"].ToString());
                CONTRIBUTOR_IDS.Add(contributorID);
                GetUsername(contributorID);
            }
        }

        protected void GetUsername(int ID)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT username FROM user WHERE userID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rID", ID);
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
                // Get contributor ID's and load the correct username
                string contributorName = row["repoName"].ToString();
                contributorsList.Items.Add(contributorName);
            }
        }

        // Method loads ALL USERS THAT ARE NOT ALREADY CONTRIBUTORS.
        protected void LoadUsers(int ID)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT userID, userName FROM user WHERE userID <> @id";
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
                // Get contributor ID's and load the correct username
                Boolean checker = true;
                string userName = row["userName"].ToString();
                int userID = Int32.Parse(row["userID"].ToString());
                for(int i=0; i<CONTRIBUTOR_IDS.Count(); i++)
                {
                    // If userID and contributor ID match dont put in list break out of loop check next one.
                    if (userID == CONTRIBUTOR_IDS[i])
                    {
                        checker = false;
                        break;
                    }
                }

                // If checker remains true then add the username to the userList.
                if (checker)
                    userList.Items.Add(userName);
            }
        }


        protected void SaveChanges(int ID, string RepoName)
        {
            // Getting values to update.
            string newDescription = description_tb.Text;

            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE repository SET repoName=@rN, repoDescription=@rD WHERE repoID=@ID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rN", RepoName);
                cmd.Parameters.AddWithValue("@rD", newDescription);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now changing the name of the file locally.
            string sourcePath = DIRECTORY + @"\" + OLD_NAME;
            string newPath = DIRECTORY + @"\" + RepoName;
            System.IO.Directory.Move(sourcePath, newPath);

            MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }

        protected void CheckNewContributors()
        {
            // Checking if Contribotr list has added members.
            if(CONTRIBUTOR_IDS.Count < contributorsList.Items.Count)
            {
                // Loop through the added members.
                for(int i=CONTRIBUTOR_IDS.Count; i<contributorsList.Items.Count; i++)
                {
                    string username = contributorsList.Items[i].ToString();
                    // Method to get contributor ID by the username.
                    int userID = GetNewContributorID(username);
                    CreateConnection(SELECTED_REPO_ID,userID);
                }
            }
        }

        protected int GetNewContributorID(string Name)
        {
            int contributorID = 0;
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT userID FROM user WHERE userName=@uN";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uN", Name);
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
                int newID = Int32.Parse(row["userID"].ToString());
                contributorID = newID;
            }
            return contributorID;
        }

        // Create the link between user and repo.
        protected void CreateConnection(int repoID, int uID)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO user_connections (userID, repoID) VALUES (@uID, @rID);";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uID", uID);
                cmd.Parameters.AddWithValue("@rID", repoID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }


        // Methods below check user repository names and returns if they have already been created or not
        // This method checks if the repository name has already been created.
        protected Boolean CheckRepositoryName(int repoID)
        {
            string enteredName = repoName_tb.Text.ToString();
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoName FROM repository WHERE repoID=@id";
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
            conn.Close();

            foreach (DataRow row in myTable.Rows)
            {
                string repoName = row["repoName"].ToString();
                if (enteredName.CompareTo(repoName) == 0)
                    return false;
            }

            return true;
        }

        // This method gets all repositories based on the userID. Calls "checkRepositoryName" to check if the repository has already been created.
        protected Boolean CheckRepositories(int id)
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
                cmd.Parameters.AddWithValue("@id", id);
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
                int rID = Int32.Parse(row["repoID"].ToString());

                // If comes back as a match return false.
                if (!CheckRepositoryName(rID))
                    return false;
            }

            // If nothing matches the repository name then return true and create repository.
            return true;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }
    }
}
