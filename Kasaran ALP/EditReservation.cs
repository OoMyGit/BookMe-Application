using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using static System.Net.WebRequestMethods;
using static Kasaran_ALP.MainPage2;

namespace Kasaran_ALP
{
    public partial class EditReservationForm : Form
    {
        private List<MainPage2.Reservation> reservations;
        DataTable x = new DataTable();
        public EditReservationForm(List<MainPage2.Reservation> reservation)
        {
            InitializeComponent();

            this.reservations = reservations;
        }


        private void updateDGV1()
        {
            
            try
            {
                x.Clear();
                MainPage.sqlQuery = $"select reservasiid, staysname, check_indate,check_outdate\r\nfrom Reservation r, stays s\r\nwhere userid = '{LoginPage.loggedInUserID}'and r.staysid = s.staysid;";
                MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
                MainPage.sqlAdapter = new MySqlDataAdapter(MainPage.sqlCommand);
                MainPage.sqlAdapter.Fill(x);
                dgv1.DataSource = x;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void EditReservationForm_Load(object sender, EventArgs e)
        {
            // Display the reservations in the form
            foreach (MainPage2.Reservation reservation in reservations)
            {
                // Create controls to display the reservation details
                // Add them to the form
            }
        }
        private void ExecuteSQL(string command)
        {
            try
            {
                MainPage.sqlConnect.Open();
                MainPage.sqlCommand = new MySqlCommand(command, MainPage.sqlConnect);
                MySqlDataReader sqlDataReader;
                sqlDataReader = MainPage.sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                MainPage.sqlConnect.Close();
            }
        }
        private void EditReservationForm_Load_1(object sender, EventArgs e)
        {
            MessageBox.Show(LoginPage.loggedInUserID);
            MainPage.sqlQuery = $"select reservasiid, staysname, check_indate,check_outdate\r\nfrom Reservation r, stays s\r\nwhere userid = '{LoginPage.loggedInUserID}'and r.staysid = s.staysid; ;";
            MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
            MainPage.sqlAdapter = new MySqlDataAdapter(MainPage.sqlCommand);
            MainPage.sqlAdapter.Fill(x);
            dgv1.DataSource = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tgl1 = dtp1.Value.ToString("yyyy-MM-dd");
            string tgl2 = dtp2.Value.ToString("yyyy-MM-dd");
            string text = txt1.Text;
            string command = $"update Reservation set check_indate = '{tgl1}', check_outdate= '{tgl2}' \r\nwhere reservasiid = '{text}';";
            ExecuteSQL(command);
            updateDGV1();
            
           
            

        }
    }

}
