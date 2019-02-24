using System;
using System.Collections;
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

namespace FinalTeamProject
{
    public partial class Form1 : Form
    {
        public int ID;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = username_tb.Text.ToString();
            string enteredPassword = password_tb.Text.ToString();

            if (RegisterAccount(enteredUsername, enteredPassword))
            {
                status_label.Text = "Created account! You can now login!";

            }
            else
            {
                status_label.ForeColor = System.Drawing.Color.Red;
                status_label.Text = "Username already exists! Please choose an new username.";
            }

            username_tb.Text = "";
            password_tb.Text = "";
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // When login button is selected compare what the user typed in and check if it matches any existing username/password
            string enteredUsername = username_tb.Text.ToString();
            string enteredPassword = password_tb.Text.ToString();

            // if is correct then log user in. If not tell user entered information is wrong.
            if (CheckCredentials(enteredUsername, enteredPassword, 0))
            {
                status_label.Text = "Logged in!";
                MainMenu mainMenu = new MainMenu(ID, enteredUsername, 0);
                username_tb.Text = "";
                password_tb.Text = "";
                mainMenu.Show();
            }
            else
            {
                status_label.ForeColor = System.Drawing.Color.Red;
                status_label.Text = "Username or Password entered incorrectly.";
            }
        }

        public Boolean CheckCredentials(string u, string p, int checker)
        {
            // prepare an SQL query to retrieve all usernames and passwords.
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connection to MySQL.... ");
                conn.Open();
                string sql = "SELECT userID, username, password FROM USER WHERE username=@username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", u);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Information is ready...");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            conn.Close();

            foreach(DataRow row in myTable.Rows)
            {
                int userID = Int32.Parse(row["userID"].ToString());
                string username = row["username"].ToString();
                string password = row["password"].ToString();
                
                

                // This if statement is if the user is trying to log in. 
                if (checker == 0)
                {
                    if (u.CompareTo(username) == 0 && p.CompareTo(password) == 0)
                    {
                        ID = userID;
                        return true;
                    }
                }

                // This if statement is if the user is trying to register an account.
                if (checker == 1)
                {
                    if (u.CompareTo(username) == 0)
                        return true;
                }
            }
            return false;
        }

        public Boolean RegisterAccount(string u, string p)
        {
            // check if username has already been entered before.
            if (CheckCredentials(u, p, 1))
                return false;
            // if username has not been entered before then insert data into table.
            else
            {
                string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL.....");
                    conn.Open();
                    string sql = "INSERT INTO user (username, password) VALUES (@u, @p)";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@u", u);
                    cmd.Parameters.AddWithValue("@p", p);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    conn.Close();
                    Console.WriteLine("Done.");
                    return false;
                }
                return true;
            }
        }
    }
}
