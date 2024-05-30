using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kasaran_ALP.LoginPage;
using static Kasaran_ALP.MainPage2;

namespace Kasaran_ALP
{
    public partial class MainPage : Form
    {
        public static string connectionString = "server=localhost; uid=root; pwd=isbmantap; database=alpaddd";
        public static MySqlConnection sqlConnect = new MySqlConnection(connectionString);
        public static MySqlCommand sqlCommand;
        public static MySqlDataAdapter sqlAdapter;
        public static string sqlQuery;
        DataTable dtTeam = new DataTable();
        DataTable dtNat = new DataTable();
        DataTable dtA = new DataTable();


        public List<MainPage2.Stays> stays;
        public MainPage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel3.Hide();
            MainPage2 mp2 = new MainPage2();
            mp2.FormBorderStyle = FormBorderStyle.None;
            mp2.Dock = DockStyle.Fill;
            mp2.TopLevel = false;
            mp2.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(mp2);
            mp2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

        }

        bool x;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x)
            {
                if (panel3.Width >= 100)
                {
                    timer1.Stop();

                }
                panel3.Width += 5;
            }
            else
            {
                if (panel3.Width <= 0)
                {
                    panel3.Hide();
                    timer1.Stop();
                }
                panel3.Width -= 5;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel3.Visible)
            {
                x = false;
                timer1.Start();
            }
            else
            {
                panel3.Show();
                x = true;
                timer1.Start();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Reservation Label
            MainPage2 mp2 = new MainPage2();
            mp2.FormBorderStyle = FormBorderStyle.None;
            mp2.Dock = DockStyle.Fill;
            mp2.TopLevel = false;
            mp2.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(mp2);
            mp2.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //Edit Reservation Label
            OpenEditReservationForm();

        }
        private void OpenEditReservationForm()
        {
            EditReservationForm editReservationForm = Application.OpenForms["EditReservationForm"] as EditReservationForm;
            editReservationForm.FormBorderStyle = FormBorderStyle.None;
            editReservationForm.Dock = DockStyle.Fill;
            editReservationForm.TopLevel = false;
            editReservationForm.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(editReservationForm);
            editReservationForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Favorites Label
            Favorite fav = Application.OpenForms["Favorite"] as Favorite;
            fav.FormBorderStyle = FormBorderStyle.None;
            fav.Dock = DockStyle.Fill;
            fav.TopLevel = false;
            fav.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(fav);
            fav.Show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            //Inbox Label
            Inbox inbox = new Inbox();
            inbox.FormBorderStyle = FormBorderStyle.None;
            inbox.Dock = DockStyle.Fill;
            inbox.TopLevel = false;
            inbox.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(inbox);
            inbox.Show();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label jancoklahgataulagi = (Label)sender;
            jancoklahgataulagi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label jancoklahgataulagi = (Label)sender;
            jancoklahgataulagi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Help Center Label
            HelpCenter help = new HelpCenter();
            help.FormBorderStyle = FormBorderStyle.None;
            help.Dock = DockStyle.Fill;
            help.TopLevel = false;
            help.ControlBox = false;
            this.panel5.Controls.Clear();
            this.panel5.Controls.Add(help);
            help.Show();
        }
    }
}
