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
    public partial class ManageFile : Form
    {
        public int USER_ID, FILE_ID, BRANCH_ID;
        public string USER_NAME, ORIGINAL_NAME, ORIGINAL_EXT, DIRECTORY, REPO_NAME, BRANCH_NAME;

        public ManageFile(int BranchID, string RepoName, string BranchName, int FileID, string FileName, string FileExt, string Username, int UserID)
        {
            USER_NAME = Username;
            USER_ID = UserID;
            FILE_ID = FileID;
            BRANCH_ID = BranchID;
            ORIGINAL_EXT = FileExt;
            ORIGINAL_NAME = FileName;
            REPO_NAME = RepoName;
            BRANCH_NAME = BranchName;

            DIRECTORY = Directory.GetCurrentDirectory();

            InitializeComponent();

            fileName_tb.Text = FileName;
            fileType_box.SelectedItem = FileExt;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // Checking if the user even changed the file name or extention.
            string newName = fileName_tb.Text;
            string newExt = fileType_box.GetItemText(fileType_box.SelectedItem);

            if (ORIGINAL_NAME.CompareTo(newName) == 0 && ORIGINAL_EXT.CompareTo(newExt) == 0)
                CloseWindow();
            else
            {
                if(CheckFile(newName, newExt))
                {
                    UpdateFile(newName, newExt);
                }
                else
                {
                    error_label.Text = "File name already exists under this branch! Please change the name or the type!";
                }
            }
        }

        protected Boolean CheckFile(string Name, string Ext)
        {
            DataTable myTable = new DataTable();
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connection to MySQL...");
                conn.Open();
                string sql = "SELECT fileName, fileType FROM files WHERE branchID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", BRANCH_ID);
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
                string fName = row["fileName"].ToString();
                string fType = row["fileType"].ToString();
                if (Name.CompareTo(fName) == 0 && Ext.CompareTo(fType) == 0)
                    return false;
            }

            return true;
        }

        protected void UpdateFile(string Name, string Ext)
        {
            string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE files SET fileName=@fN, fileType=@fT WHERE fileID=@ID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fN", Name);
                cmd.Parameters.AddWithValue("@fT", Ext);
                cmd.Parameters.AddWithValue("@ID", FILE_ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            // Now changing the name of the file locally.
            string sourcePath = DIRECTORY + @"\" + REPO_NAME + @"\" + BRANCH_NAME + @"\" + ORIGINAL_NAME + ORIGINAL_EXT;
            string newPath = DIRECTORY + @"\" + REPO_NAME + @"\" + BRANCH_NAME + @"\" + Name + Ext;
            System.IO.Directory.Move(sourcePath, newPath);

            CloseWindow();
        }

        protected void CloseWindow()
        {
            this.Close();
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();
        }
    }
}
