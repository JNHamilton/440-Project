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
    public partial class NewFile : Form
    {
        public int REPO_ID, BRANCH_ID, USER_ID, FILE_ADD;
        public string REPO_NAME, BRANCH_NAME, USER_NAME, DIRECTORY;
        string ext, fileName;

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();

            this.Close();
        }

        string existingPath;
        string branchPath;

        public NewFile(int RepoID, string RepoName, int BranchID, string BranchName, string Username, int ID)
        {
            REPO_ID = RepoID;
            BRANCH_ID = BranchID;
            USER_ID = ID;

            REPO_NAME = RepoName;
            BRANCH_NAME = BranchName;
            USER_NAME = Username;

            ext = "";
            fileName = "";

            DIRECTORY = Directory.GetCurrentDirectory();

            branchPath = DIRECTORY + @"\" + RepoName + @"\" + BranchName;


            FILE_ADD = 0;
            InitializeComponent();
        }

        private void addFile_btn_Click(object sender, EventArgs e)
        {
            string newFileName = fileName_tb.Text.ToString();
            string newFileExt = fileType_box.GetItemText(fileType_box.SelectedItem);
            string newFilePath = branchPath + @"\" + newFileName + newFileExt;

            // First will check if the user uploaded a file.
            if(FILE_ADD == 1)
            {
                newFileExt = fileType_box.Text;
                // Now checking if the user changed the file name that was uploaded.
                if (newFileName.CompareTo(fileName) == 0 && newFileExt.CompareTo(ext) == 0)
                {
                    CreateFile(newFileName, newFileExt, 1);
                    MoveFile(existingPath, fileName + ext);
                }
                else
                {
                    CreateFile(newFileName, newFileExt, 0);
                    CreateFileLocally(newFilePath);
                }

            }
            else
            {
                CreateFile(newFileName, newFileExt, 0);
                CreateFileLocally(newFilePath);
            }
        }

        private void selectFile_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a file";
            dialog.InitialDirectory = @"C:\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(dialog.FileName.ToString());
                existingPath = dialog.FileName;
                ext = Path.GetExtension(dialog.FileName);
                fileName = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
                error_label.Text = "IF you hit add now you will add "+dialog.SafeFileName+" to branch "+BRANCH_NAME;
                FILE_ADD = 1;
                fileName_tb.Text = fileName;
                fileType_box.Text = ext;
            }
        }

        protected void CreateFileLocally(string Path)
        {
            var file = System.IO.File.Create(Path);
            file.Close();
            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();

            this.Close();

        }

        protected void MoveFile(string Path, string FileName)
        {
            // First need to check if file has already been created in database.

            string sourcePath = Path;
            string newPath = DIRECTORY + @"\" + REPO_NAME + @"\"+ BRANCH_NAME + @"\" +FileName;
            System.IO.Directory.Move(sourcePath, newPath);

            MainMenu mainMenu = new MainMenu(USER_ID, USER_NAME, 1);
            mainMenu.Show();

            this.Close();
        }

        protected void CreateFile(string FileName, string FileExtention, int Process)
        {
            // First need to check if file has already been created in database.
            if(CheckFile(FileName, FileExtention))
            {
                // If return true then file is new and will be created.
                string connStr = "server = csdatabase.eku.edu; user = stu_csc440; database = csc440_db; port = 3306; password = Maroons18";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO files (fileName, fileType, branchID) VALUES (@fN, @fT, @bID);";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fN", FileName);
                    cmd.Parameters.AddWithValue("@fT", FileExtention);
                    cmd.Parameters.AddWithValue("@bID", BRANCH_ID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            else
            {
                error_label.Text = "File has already been established in that branch! Please choose a new name.";
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

    }
}
