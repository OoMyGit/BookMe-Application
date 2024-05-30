using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kasaran_ALP
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string phonenum = textBox5.Text;
            string password = textBox4.Text;
            string address = textBox3.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string encryptedPass = GetMD5Hash(password);

            string connectionString = "server=localhost;uid=root;pwd=isbmantap;database=alpaddd";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve the maximum user ID from the customer table
                string getMaxIdQuery = "SELECT MAX(SUBSTRING(userid, 3)) FROM customer";
                using (MySqlCommand getMaxIdCommand = new MySqlCommand(getMaxIdQuery, connection))
                {
                    string maxId = getMaxIdCommand.ExecuteScalar().ToString();
                    int nextId = (maxId != null) ? int.Parse(maxId) + 1 : 1;
                    string newUserId = "US" + nextId.ToString("D3");

                    string sqlQuery = $"INSERT INTO customer (userid, username, userpass, alamatcust, notelpcust, email, tanggalregristasi) " +
                        $"VALUES (@userid, @username, @password, @address, @phone, @email, @date)";

                    // Create the MySqlCommand object
                    using (MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, connection))
                    {
                        // Add the parameters and set their values
                        sqlCommand.Parameters.AddWithValue("@userid", newUserId);
                        sqlCommand.Parameters.AddWithValue("@username", username);
                        sqlCommand.Parameters.AddWithValue("@password", encryptedPass);
                        sqlCommand.Parameters.AddWithValue("@address", address);
                        sqlCommand.Parameters.AddWithValue("@phone", phonenum);
                        sqlCommand.Parameters.AddWithValue("@email", email);
                        sqlCommand.Parameters.AddWithValue("@date", date);

                        sqlCommand.ExecuteNonQuery().ToString();

                        // Show a success message
                        MessageBox.Show("Registration successful!");
                    }
                }
                connection.Close();
            }
            this.Close();
        }

        private string GetMD5Hash(string input)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < result.Length; i++)
                {
                    stringBuilder.Append(result[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}