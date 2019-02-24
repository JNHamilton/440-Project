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
    public partial class CommitChanges : Form
    {
        public int USER_ID, RI, BI, FI;
        public string USER_NAME, DIRECTORY, RN, BN, FN;
        public byte[] CONTENTS;

    public CommitChanges(int UserID, string Username, int FileID, int RepoID, int BranchID, string RepoName, string BranchName, string FileName, byte[] Contents)
        {
            USER_ID = UserID;
            USER_NAME = Username;
            DIRECTORY = Directory.GetCurrentDirectory();

            // Repo, Branch, and File names.
            RN = RepoName;
            BN = BranchName;
            FN = FileName;

            // Repo, Branch, and File IDs.
            RI = RepoID;
            BI = BranchID;
            FI = FileID;

            CONTENTS = Contents;

            InitializeComponent();
        }

      
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }

        private void pullRequest_btn_Click(object sender, EventArgs e)
        {
            string comment = comment_box.Text.ToString();
            int prID = 0;
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO pull_requests (repoID, branchID, fileID, prStatus, prComments) VALUES (@rID, @bID, @fID, @prS, @prC);";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rID", RI);
                cmd.Parameters.AddWithValue("@bID", BI);
                cmd.Parameters.AddWithValue("@fID", FI);
                cmd.Parameters.AddWithValue("@prS", 0);
                cmd.Parameters.AddWithValue("@prC", comment);
                cmd.ExecuteNonQuery();

                prID = Int32.Parse(cmd.LastInsertedId.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            string newFolderPath = DIRECTORY + @"\" + RN + @"\ps-" + prID + "-" + BN;
            string newFilePath = newFolderPath + @"\" + FN;

            Directory.CreateDirectory(newFolderPath);
            var file = File.Create(newFilePath);
            file.Close();
            // Now putting new contents in File.
            File.WriteAllBytes(newFilePath, CONTENTS);

            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }

        private void commitDirect_btn_Click(object sender, EventArgs e)
        {
            string filePath = DIRECTORY + @"\" + RN + @"\"+ BN + @"\" + FN;
            int ID = FI;
            // updating the database contents
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE files SET fileContents=@fC WHERE fileID=@fID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                string contents = Encoding.ASCII.GetString(CONTENTS);

                cmd.Parameters.AddWithValue("@fID", ID);
                Console.WriteLine("ID: " + ID);
                cmd.Parameters.AddWithValue("@fC", contents);
                Console.WriteLine("Contents: " + contents);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now putting new contents in File.
            File.WriteAllBytes(filePath, CONTENTS);

            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
            this.Close();
        }
    }
}
