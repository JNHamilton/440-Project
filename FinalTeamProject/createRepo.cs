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
    public partial class createRepo : Form
    {
        int LOGGED_IN_USER_ID;
        string LOGGED_IN_USERNAME;
        public string DIRECTORY;

        public createRepo(int ID, string username)
        {
            LOGGED_IN_USER_ID = ID;
            LOGGED_IN_USERNAME = username;
            DIRECTORY = Directory.GetCurrentDirectory();
            InitializeComponent();
            loadUsers(LOGGED_IN_USERNAME);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME, 1);
            mainMenu.Show();
            this.Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string desiredRepo = desiredName_tb.Text.ToString();
            string desiredDescription = description_tb.Text.ToString();

            if(desiredRepo.CompareTo("") == 0)
                // Need a repository name
                error_tb.Text = "NEED TO DECLARE A REPOSITORY NAME!";
            else if(desiredRepo.Contains(" "))
            {

                // contains a space just fix it for user.
                desiredRepo = desiredRepo.Replace(' ', '_');
                createNewRepo(desiredRepo, desiredDescription, LOGGED_IN_USER_ID);
            }
            else
                // First will create repository for the user who is signed in.
                createNewRepo(desiredRepo, desiredDescription, LOGGED_IN_USER_ID);
            
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

        private void remove_btn_Click(object sender, EventArgs e)
        {
            // get username of selected user.
            string selectedName = contributorsList.GetItemText(contributorsList.SelectedItem);

            // remove selected name from contributorList
            contributorsList.Items.Remove(contributorsList.SelectedItem);

            // Add it back to user list.
            userList.Items.Add(selectedName);
        }

        protected void loadUsers(string uName)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();

                // where username doesnt equal user.
                string sql = "SELECT username FROM user WHERE username <> @uN;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@uN", uName);
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
                // Getting usernames
                string username = row["username"].ToString();
                userList.Items.Add(username);
            }
        }

        protected void createNewRepo(string repoName, string description, int userID)
        {
            // First will check if a repository with this name has already been created for the user who created it.
            if (checkRepositories(userID))
            {
                
                // First will create repository.
                CreateRepo(repoName, description);

                // Now checking if any contributors were added. if they were then add them to connection as well.
                for(int i=0; i<contributorsList.Items.Count; i++)
                {
                    int contributorID = getContributorID(contributorsList.Items[i].ToString());

                    // Now will get the new repository ID.
                    int newRepoID = getRepoID(repoName);

                    createConnection(newRepoID, contributorID);
                }

                // Created repository and added connections so closing page
                MainMenu mainMenu = new MainMenu(LOGGED_IN_USER_ID, LOGGED_IN_USERNAME, 1);
                mainMenu.Show();
                this.Close();
                
            }
            else
            {
                error_tb.Text = "Repository name already exists for you! Please choose another name.";
                error_tb.ForeColor = System.Drawing.Color.Red;
                desiredName_tb.Text = "";
            }

        }

        // This method checks if the repository name has already been created.
        protected Boolean checkRepositoryName(int repoID)
        {
            string enteredName = desiredName_tb.Text.ToString();
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            foreach(DataRow row in myTable.Rows)
            {
                string repoName = row["repoName"].ToString();
                if (enteredName.CompareTo(repoName) == 0)
                    return false;
            }

            return true;
        }

        // This method gets all repositories based on the userID. Calls "checkRepositoryName" to check if the repository has already been created.
        protected Boolean checkRepositories(int id)
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
                if (!checkRepositoryName(rID))
                    return false;
            }

            // If nothing matches the repository name then return true and create repository.
            return true;
        }

        protected void CreateRepo(string repoName, string repoDesc)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO repository (repoName, repoDescription) VALUES (@rN, @rD);";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rN", repoName);
                cmd.Parameters.AddWithValue("@rD", repoDesc);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now will get the new repository ID.
            int newRepoID = getRepoID(repoName);
            Console.Write(newRepoID);

            // Now will create the connection between the user creator and the new repo.
            createConnection(newRepoID, LOGGED_IN_USER_ID);

            // Creating repo on local computer.
            string path = DIRECTORY + @"\" + repoName;
            System.IO.Directory.CreateDirectory(path);

            // Now creating a branch
            CreateBranch(newRepoID, repoName);
        }

        protected int GetCorrespondingID(int ID, string Name)
        {
            int correctID = 0;
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoName FROM user_connections WHERE repoID=@id";
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
                string repoName = row["repoName"].ToString();
                if (Name.CompareTo(repoName) == 0)
                    correctID = ID;
            }
            return correctID;
        }

        // Creating branch locally and in database.
        protected void CreateBranch(int ID, string Name)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO test (repoID, branchName) VALUES (@rID, @Name);";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rID", ID);
                cmd.Parameters.AddWithValue("@Name", "master");
                cmd.ExecuteNonQuery();
                Console.WriteLine("Created branch!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now creating branches locally. 
            string path = DIRECTORY + @"\" + Name + @"\master";
            System.IO.Directory.CreateDirectory(path);
            
        }

        // Create the link between user and repo.
        protected void createConnection(int repoID, int uID)
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

        // Method gets the selected contributor ID.
        protected int getContributorID(string username)
        {
            int cID = 0;
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT userID FROM user WHERE userName=@uN";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uN", username);
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
                // set userID
                cID = Int32.Parse(row["userID"].ToString());
            }
            return cID;
        }

        // Method gets the new repository ID.
        protected int getRepoID(string repoName)
        {
            int rID = 0;
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT repoID FROM repository WHERE repoName=@rN";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rN", repoName);
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
                // set repoID
                rID = Int32.Parse(row["repoID"].ToString());
            }
            // return repoID.
            return rID;
        }
    }
}
