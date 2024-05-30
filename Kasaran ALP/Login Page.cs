using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kasaran_ALP
{
    public partial class LoginPage : Form
    {
        public List<User> user;
        public static string loggedInUserID;
        DataTable dtUserLogin = new DataTable();
        public bool bisalogin = false;
        public static string loggedInUserName;
        public static string loggedInUserPass;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegisterPage registerpage= new RegisterPage();
            registerpage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = textBox2.Text;

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(x));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            string encryptedpass = stringBuilder.ToString();

            MainPage.sqlQuery = "select userid, username, userpass from customer";
            MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
            MainPage.sqlAdapter = new MySqlDataAdapter(MainPage.sqlCommand);
            MainPage.sqlAdapter.Fill(dtUserLogin);

            foreach (DataRow row in dtUserLogin.Rows)
            {
                string username = row["username"].ToString();
                string password = row["userpass"].ToString();

                // Compare the username and password
                if (username == textBox1.Text && password == encryptedpass)
                {
                    loggedInUserID = row["userid"].ToString();
                    MainPage.sqlConnect.Close();
                    MainPage mainpage = new MainPage();
                    mainpage.ShowDialog();
                    return;
                }
            }

            // If the loop completes without finding a match, show an error message
            MessageBox.Show("Invalid username or password.");
        }
        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
    }
}
