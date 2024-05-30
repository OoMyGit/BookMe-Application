using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Kasaran_ALP.MainPage2;

namespace Kasaran_ALP
{
    public partial class MainPage2 : Form
    {
        public List<Stays> stay;
        public List<StayDetail> staydetail;
        private List<Reservation> reservation;

        public static List<StayDetail> favstays = new List<StayDetail>();
        public static List<StayDetail> editres = new List<StayDetail>();
        public static StayDetail anjing;
        PictureBox[] pic = new PictureBox[1000];
        Label[] nam = new Label[1000];
        Label[] detailLabels = new Label[1000];
        System.Windows.Forms.Button reserveButton;
        System.Windows.Forms.Button buttonapply;
        DataTable x = new DataTable();
        Label labelcheckin = new Label();
        Label labelcheckout = new Label();
        DateTimePicker dateTimePickerCheckIn = new DateTimePicker();
        DateTimePicker dateTimePickerCheckOut = new DateTimePicker();
        public static List<Reservation> reservations = new List<Reservation>();
        System.Windows.Forms.ComboBox combopayment = new System.Windows.Forms.ComboBox();
        Label labelpromo = new Label();
        Label labelfinalprice = new Label();
        int finalprice;
        int totalprice;
        Label labelpayment = new Label();
        System.Windows.Forms.TextBox tbpromo = new System.Windows.Forms.TextBox();
        System.Windows.Forms.Button buttoncheckout = new System.Windows.Forms.Button();
        System.Windows.Forms.Button favoritebutton = new System.Windows.Forms.Button();
        public static StayDetail selectedStay;

        public MainPage2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();
            int x = 0;
            foreach (Stays a in stay)
            {
                pic[x] = new PictureBox();
                pic[x].Size = new Size(200, 180);
                pic[x].SizeMode = PictureBoxSizeMode.StretchImage;
                pic[x].Tag = a.StaysName;
                //MessageBox.Show(a.Picture,"ANJINGASU");
                //string filename = "Properties.Resources." + a.Picture.ToString();
                //foto = new Bitmap(filename);
                pic[x].Image = Image.FromFile(a.Picture);
                pic[x].Click += pic_Click;

                if (x == 0)
                {
                    pic[x].Location = new Point(30, 30);
                }
                else if (x % 4 == 0)
                {
                    pic[x].Location = new Point(pic[x-4].Location.X, pic[x - 4].Bottom + 120);
                }
                else
                {
                    pic[x].Location = new Point(pic[x - 1].Right + 60, pic[x-1].Location.Y);
                }

                nam[x] = new Label();
                nam[x].Location = new Point(pic[x].Location.X, pic[x].Bottom + 10);
                nam[x].Text = a.StaysName;
                nam[x].Size = new Size(250,30);
                nam[x].Font = new Font("Arial", 10, FontStyle.Bold);
                nam[x].ForeColor = Color.Black;

                this.panel2.Controls.Add(pic[x]);
                this.panel2.Controls.Add(nam[x]);

                x++;
            }
        }

        private void pic_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            PictureBox stays = (PictureBox)sender;
            string tag = stays.Tag.ToString();
            foreach (StayDetail a in staydetail)
            {
                if (a.Name == tag)
                {
                    selectedStay = a;

                    stays = new PictureBox();
                    stays.Size = new Size(200, 180);
                    stays.Location = new Point (30,30);
                    stays.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    stays.Image = Image.FromFile(a.Picture);
                    // Display the details in a label
                    Label labelname = new Label();
                    labelname.Text = "Name: " +a.Name.ToString();
                    labelname.Font = new Font("Arial", 8);
                    labelname.ForeColor = Color.Black;
                    labelname.Size = new Size(800, 20);
                    labelname.Location = new Point(30, stays.Bottom + 10);
                    Label labelcity = new Label();
                    labelcity.Text = "City: "+ a.City.ToString();
                    labelcity.Font = new Font("Arial", 8);
                    labelcity.ForeColor = Color.Black;
                    labelcity.Size = new Size(800, 20);
                    labelcity.Location = new Point(30, labelname.Bottom + 10);
                    Label labeladdress = new Label();
                    labeladdress.Text = "Address: "+ a.Address.ToString();
                    labeladdress.Font = new Font("Arial", 8);
                    labeladdress.ForeColor = Color.Black;
                    labeladdress.Size = new Size(800, 20);
                    labeladdress.Location = new Point(30, labelcity.Bottom + 10);
                    Label labelphone = new Label();
                    labelphone.Text = "Phone: "+a.NoTelp.ToString();
                    labelphone.Font = new Font("Arial", 8);
                    labelphone.ForeColor = Color.Black;
                    labelphone.Size = new Size(800, 20);
                    labelphone.Location = new Point(30, labeladdress.Bottom + 10);
                    Label labelcapacity = new Label();
                    labelcapacity.Text = $"Capacity: {a.Capacity.ToString()}";
                    labelcapacity.Font = new Font("Arial", 8);
                    labelcapacity.ForeColor = Color.Black;
                    labelcapacity.Size = new Size(800,20);
                    labelcapacity.Location = new Point(30, labelphone.Bottom + 10);
                    Label labelprice = new Label();
                    labelprice.Text = $"Price: Rp. {a.Price.ToString()}";
                    labelprice.Font = new Font("Arial", 8);
                    labelprice.ForeColor = Color.Black;
                    labelprice.Size = new Size(800, 20);
                    labelprice.Location = new Point(30, labelcapacity.Bottom + 10);

                    totalprice = a.Price;

                    Label labelfacility= new Label();
                    string totalfas = "";
                    foreach(string fas in a.Facilities)
                    {
                        totalfas += fas + ", ";
                    }
                    labelfacility.Text = "Facilities: " + totalfas;
                    labelfacility.Font = new Font("Arial", 8);
                    labelfacility.ForeColor = Color.Black;
                    labelfacility.Size = new Size(3800, 20);
                    labelfacility.Location = new Point(30, labelprice.Bottom + 10);

                    anjing = a;

                    // Create button for reserving the stay SUNDALA TELASO
                    reserveButton = new System.Windows.Forms.Button();
                    reserveButton.Text = "Reserve";
                    reserveButton.Font = new Font("Arial", 12, FontStyle.Bold);
                    reserveButton.ForeColor = Color.White;
                    reserveButton.BackColor = Color.Blue;
                    reserveButton.Tag = tag;
                    reserveButton.Size = new Size(200, 100);
                    reserveButton.Location = new Point(30, labelfacility.Bottom + 20);
                    reserveButton.Click += reserveButton_Click;


                    favoritebutton = new System.Windows.Forms.Button();
                    favoritebutton.Text = "Add To Favorite";
                    favoritebutton.Font = new Font("Arial", 12, FontStyle.Bold);
                    favoritebutton.ForeColor = Color.White;
                    favoritebutton.BackColor = Color.Blue;
                    //favoritebutton.Tag = tag;
                    favoritebutton.Size = new Size(300, 100);
                    favoritebutton.Location = new Point(reserveButton.Right + 50, reserveButton.Location.Y);
                    favoritebutton.Click += Favoritebutton_Click;

                    // Add PARA KONTOLS ANJINGGG AKU STRESS COKKKKK to the panel
                    this.panel2.Controls.Add(labelname);
                    this.panel2.Controls.Add(labelcity);
                    this.panel2.Controls.Add(labeladdress);
                    this.panel2.Controls.Add(labelphone);
                    this.panel2.Controls.Add(labelcapacity);
                    this.panel2.Controls.Add(labelprice);
                    this.panel2.Controls.Add(labelfacility);
                    this.panel2.Controls.Add(stays);
                    this.panel2.Controls.Add(reserveButton);
                    this.panel2.Controls.Add(favoritebutton);

                    break;
                }
            }
        }
        private List<StayDetail> favoriteStays = new List<StayDetail>();

        private void Favoritebutton_Click(object sender, EventArgs e)
        {
            favstays.Add(anjing);
            Favorite favoriteForm = new Favorite(favstays);
            favoriteForm.Show();
            favoriteForm.Hide();

        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            // Get the selected stay details
            System.Windows.Forms.Button stays = (System.Windows.Forms.Button)sender;
            string tag = stays.Tag.ToString();
            selectedStay = staydetail.FirstOrDefault(s => s.Name == tag);
            labelcheckin.Location = new Point(30, 30);
            labelcheckin.Text = "Check In Date: ";

            labelcheckout.Location = new Point(labelcheckin.Location.X, labelcheckin.Location.Y+30);
            labelcheckout.Text = "Check Out Date: ";

            dateTimePickerCheckIn.Location = new Point(labelcheckin.Location.X+100, labelcheckin.Location.Y);

            dateTimePickerCheckOut.Location = new Point(labelcheckout.Location.X+100, labelcheckout.Location.Y);

            labelpayment.Text = "Payment Method: ";
            labelpayment.Location = new Point(labelcheckout.Location.X, labelcheckout.Location.Y + 30);
            combopayment.Location = new Point(labelpayment.Location.X + 100, labelpayment.Location.Y);

            GetPaymentMethod(x);
            combopayment.DataSource = x;
            combopayment.DisplayMember = "paymentmethod";

            labelpromo.Location = new Point(labelpayment.Location.X, labelpayment.Location.Y + 30);
            labelpromo.Text = "Promo : ";

            tbpromo.Location = new Point(labelpromo.Right + 30, labelpromo.Location.Y);

            buttonapply = new System.Windows.Forms.Button();
            buttonapply.Text = "Apply";
            buttonapply.Font = new Font("Arial", 8, FontStyle.Bold);
            buttonapply.ForeColor = Color.Blue;
            buttonapply.BackColor = Color.White;
            buttonapply.Location = new Point(tbpromo.Right + 10, tbpromo.Location.Y);
            buttonapply.Tag = tbpromo.Text;
            buttonapply.Click += Buttonapply_Click;


            labelfinalprice.Location = new Point(labelpromo.Location.X, labelpromo.Location.Y + 30);
            labelfinalprice.Text = "Total Price: " + totalprice.ToString();

            buttoncheckout = new System.Windows.Forms.Button();
            buttoncheckout.Location = new Point(labelfinalprice.Location.X, labelfinalprice.Location.Y + 70);
            buttoncheckout.Text = "Checkout";
            buttoncheckout.Font = new Font("Arial", 12, FontStyle.Bold);
            buttoncheckout.ForeColor = Color.White;
            buttoncheckout.BackColor = Color.Blue;
            buttoncheckout.Size = new Size(200, 100);
            buttoncheckout.Click += Buttoncheckout_Click;


            this.panel2.Controls.Add(dateTimePickerCheckIn);
            this.panel2.Controls.Add(dateTimePickerCheckOut);
            this.panel2.Controls.Add(labelcheckin);
            this.panel2.Controls.Add(labelcheckout);
            this.panel2.Controls.Add(labelpromo);
            this.panel2.Controls.Add(tbpromo);
            this.panel2.Controls.Add(buttoncheckout);
            this.panel2.Controls.Add(buttonapply);
            this.panel2.Controls.Add(labelpayment);
            this.panel2.Controls.Add(combopayment);
            this.panel2.Controls.Add(labelfinalprice);

           
        }

        private void Buttonapply_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button apply = (System.Windows.Forms.Button)sender;
            string usedpromocode = apply.Tag.ToString();
            int diskonan = 0;

            string connectionString = "server=localhost;uid=root;pwd=isbmantap;database=alpaddd";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string getDiscountQuery = "SELECT discount FROM promo WHERE kodepromo = @usedpromocode;";
                using (MySqlCommand getDiscountCommand = new MySqlCommand(getDiscountQuery, connection))
                {
                    // Modify the SQL query to use a parameterized query
                    getDiscountCommand.Parameters.AddWithValue("@usedpromocode", usedpromocode);

                    object result = getDiscountCommand.ExecuteScalar();

                    // Check if the promo successfully applied
                    if (result != DBNull.Value)
                    {
                        diskonan = Convert.ToInt32(result);
                        MessageBox.Show("Promo Applied");
                    }
                    else
                    {
                        Console.WriteLine("Wrong Promo Code");
                    }
                }
                connection.Close();
            }
            finalprice = totalprice - diskonan;
            MessageBox.Show(finalprice.ToString());
            this.panel2.Controls.Remove(labelfinalprice);
            labelfinalprice.Location = new Point(labelpromo.Location.X, labelpromo.Location.Y + 30);
            labelfinalprice.Text = "Total Price: " + finalprice.ToString();
            this.panel2.Controls.Add(labelfinalprice);
        }

        private void Buttoncheckout_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            if (selectedStay != null)
            {
                DateTime checkInDate = dateTimePickerCheckIn.Value;
                DateTime checkOutDate = dateTimePickerCheckOut.Value;

                // Insert the reservation into the database
                try
                {
                    MainPage.sqlConnect.Open();
                    MainPage.sqlQuery = "INSERT INTO Reservation (reservasiid, userid, staysid, orang, check_indate, check_outdate, paymentmethod) VALUES (@reservasiid, @userid, @staysid, @orang, @check_indate, @check_outdate, @paymentmethod)";
                    MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);

                    // Generate a new reservation ID according to the database format (R001, R002, etc.)
                    string lastReservationID = GetLastReservationID();
                    int reservationNumber = int.Parse(lastReservationID.Substring(1)) + 1;
                    string newReservationID = "R" + reservationNumber.ToString("D3");

                    // Add the reservation to the list
                    Reservation newReservation = new Reservation(newReservationID, selectedStay.Name, checkInDate, checkOutDate);
                    reservations.Add(newReservation);

                    // Set the parameter values
                    MainPage.sqlCommand.Parameters.AddWithValue("@reservasiid", newReservationID);
                    MainPage.sqlCommand.Parameters.AddWithValue("@userid", LoginPage.loggedInUserID);
                    MainPage.sqlCommand.Parameters.AddWithValue("@staysid", selectedStay.Name);
                    MainPage.sqlCommand.Parameters.AddWithValue("@orang", selectedStay.Capacity);
                    MainPage.sqlCommand.Parameters.AddWithValue("@check_indate", checkInDate);
                    MainPage.sqlCommand.Parameters.AddWithValue("@check_outdate", checkOutDate);
                    MainPage.sqlCommand.Parameters.AddWithValue("@paymentmethod", combopayment.SelectedItem.ToString());

                    MainPage.sqlCommand.ExecuteNonQuery().ToString();
                    MessageBox.Show("Reservation created successfully!");
                    OpenEditReservationForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR5: " + ex.Message);
                }
                finally
                {
                    MainPage.sqlConnect.Close();
                }
                //reservation.Add(anjing);
                //EditReservationForm rese = new EditReservationForm(editres);
                //rese.Show();
                //rese.Hide();
            }
        }

        private void OpenEditReservationForm()
        {
            EditReservationForm editReservationForm = new EditReservationForm(reservations);
            editReservationForm.Show();
                            editReservationForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SEARCH BUTTON IDIOT
            panel2.Controls.Clear();
            string searchedCityName = textBox1.Text;

            // Filter the stays based on the selected city
            List<Stays> filteredStays = stay.Where(s => s.StaysName.Contains(searchedCityName)).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredStays);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
        }

        private List<Stays> GetStaysFromDatabase()
        {
            List<Stays> stays = new List<Stays>();

            try
            {
                MainPage.sqlConnect.Open();
                MainPage.sqlQuery = "SELECT * FROM Stays";
                MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
                MySqlDataReader dataReader1 = MainPage.sqlCommand.ExecuteReader();
                dataReader1.Close();
                MySqlDataReader dataReader = MainPage.sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Stays stay = new Stays();
                    stay.StaysName = dataReader["staysname"].ToString();
                    stay.StaysCity = dataReader["cityid"].ToString();
                    stay.StaysPrice = Convert.ToInt32(dataReader["staysprice"]);
                    string picpathwithjpg = dataReader["pictures"].ToString();
                    string trimpicpath = picpathwithjpg.Substring(0, picpathwithjpg.Length - 0);
                    string finalpicpath = trimpicpath.Substring(21);
                    stay.Picture = Path.Combine(Application.StartupPath, finalpicpath); // Update the picture path with the full path

                    // Retrieve the facilities for the stay from the 'fasilitas' table
                    stay.Facilities = GetFacilitiesForStay(stay.StaysName);
                    stays.Add(stay);
                }

                dataReader.Close(); // Close the data reader after retrieving the data
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR1: " + ex.Message);
            }
            finally
            {
                MainPage.sqlConnect.Close();
            }

            return stays;
        }

        private List<string> GetFacilitiesForStay(string staysName)
        {
            List<string> facilities = new List<string>();

            try
            {
                MySqlConnection DATAREADERANJINGBUANGWAKTU = new MySqlConnection(MainPage.connectionString);
                MainPage.sqlQuery = "SELECT f.namafas FROM fasilitas f, hadfas h, stays s WHERE f.fasid = h.fasid AND h.staysid = s.staysid AND s.staysname = @staysName";
                MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, DATAREADERANJINGBUANGWAKTU);
                MainPage.sqlCommand.Parameters.AddWithValue("@staysName", staysName);

                // Use MySqlDataAdapter to fill data into a DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(MainPage.sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Iterate over the DataTable rows and retrieve facility names
                foreach (DataRow row in dataTable.Rows)
                {
                    string facility = row["namafas"].ToString();
                    facilities.Add(facility);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error2: " + ex.Message);
            }

            return facilities;
        }

        private List<StayDetail> GetStayDetailsFromDatabase()
        {
            List<StayDetail> stayDetails = new List<StayDetail>();

            try
            {
                MainPage.sqlConnect.Open();
                MainPage.sqlQuery = "SELECT s.staysname as namababi,c.cityname as kotakontol,s.alamatstays as alamatsundala,s.notelpstays as notelpjudi,s.kapasitas as kapasitot,s.staysprice,s.pictures FROM Stays s, City c WHERE c.cityid=s.cityid";
                MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
                MySqlDataReader dataReader = MainPage.sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    StayDetail stayDetail = new StayDetail();
                    stayDetail.Name = dataReader["namababi"].ToString();
                    stayDetail.City = dataReader["kotakontol"].ToString();
                    //MessageBox.Show(stayDetail.City);
                    stayDetail.Address = dataReader["alamatsundala"].ToString();
                    //MessageBox.Show(stayDetail.Address);
                    stayDetail.NoTelp = dataReader["notelpjudi"].ToString();
                    stayDetail.Capacity = Convert.ToInt32(dataReader["kapasitot"]);
                    stayDetail.Price = Convert.ToInt32(dataReader["staysprice"]);
                    string picpathwithjpg = dataReader["pictures"].ToString();
                    string trimpicpath = picpathwithjpg.Substring(0, picpathwithjpg.Length - 0);
                    string finalpicpath = trimpicpath.Substring(21);
                    stayDetail.Picture = Path.Combine(Application.StartupPath, finalpicpath); // Update the picture path with the full path
                    // Retrieve the facilities for the stay from the 'fasilitas' table
                    stayDetail.Facilities = GetFacilitiesForStay(stayDetail.Name);

                    stayDetails.Add(stayDetail);
                }

                dataReader.Close(); // Close the data reader after retrieving the data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error3: " + ex.Message);
            }
            finally
            {
                MainPage.sqlConnect.Close();
            }

            return stayDetails;
        }


        private string GetLastReservationID()
        {
            string lastReservationID = string.Empty;

            try
            {
                MainPage.sqlQuery = "SELECT MAX(reservasiid) AS lastReservationID FROM Reservation";
                MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
                object result = MainPage.sqlCommand.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    lastReservationID = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error4: " + ex.Message);
            }

            return lastReservationID;
        }

        private DataTable GetPaymentMethod(DataTable x)
        {
            MainPage.sqlQuery = "SELECT paymentmethod FROM Reservation GROUP BY 1;";
            MainPage.sqlCommand = new MySqlCommand(MainPage.sqlQuery, MainPage.sqlConnect);
            MainPage.sqlAdapter = new MySqlDataAdapter(MainPage.sqlCommand);
            MainPage.sqlAdapter.Fill(x);

            return x;

        }

        public void DisplayFilteredStays(List<Stays> filteredStays)
        {
            int x = 0;
            foreach (Stays a in filteredStays)
            {
                pic[x] = new PictureBox();
                pic[x].Size = new Size(200, 180);
                pic[x].SizeMode = PictureBoxSizeMode.StretchImage;
                pic[x].Tag = a.StaysName;
                pic[x].Image = Image.FromFile(a.Picture);
                pic[x].Click += pic_Click;

                if (x == 0)
                {
                    pic[x].Location = new Point(30, 30);
                }
                else if (x % 4 == 0)
                {
                    pic[x].Location = new Point(30, pic[x - 4].Bottom + 120);
                }
                else
                {
                    pic[x].Location = new Point(pic[x - 1].Right + 40, 30);
                }

                nam[x] = new Label();
                nam[x].Location = new Point(pic[x].Location.X, pic[x].Bottom + 10);
                nam[x].Text = a.StaysName;
                nam[x].Font = new Font("Arial", 10, FontStyle.Bold);
                nam[x].ForeColor = Color.Black;

                this.panel2.Controls.Add(pic[x]);
                this.panel2.Controls.Add(nam[x]);

                x++;
            }
        }


        public class Stays
        {
            public string StaysName { get; set; }
            public string StaysCity { get; set; }
            public int StaysPrice { get; set; }
            public string Picture { get; set; }
            public List<string> Facilities { get; set; }
        }

        public class StayDetail
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
            public string NoTelp { get; set; }
            public int Capacity { get; set; }
            public int Price { get; set; }
            public string Picture { get; set; }
            public List<string> Facilities { get; set; }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            //WIFI BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;

            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Free Wi-Fi")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SPA BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;
            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Spa")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //POOL BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;

            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Swimming Pool")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //BAR BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;

            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Bar")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //BREAKFAST BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;

            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Breakfast Included")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //KIDS PLAYGROUND BUTTON IDIOT
            panel2.Controls.Clear();

            System.Windows.Forms.Button fas = (System.Windows.Forms.Button)sender;

            // Filter the stays based on the selected city
            List<Stays> filteredstays = stay.Where(s => s.Facilities.Contains("Children Playground")).ToList();

            stay = GetStaysFromDatabase();
            staydetail = GetStayDetailsFromDatabase();

            DisplayFilteredStays(filteredstays);
        }

        private void AddToFavorites(StayDetail stay)
        {
            favoriteStays.Add(stay);
        }

        public class Reservation
        {
            public string ReservationID { get; set; }
            public string StayID { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            // Add more properties as needed

            // Constructor
            public Reservation(string reservationID, string stayID, DateTime checkInDate, DateTime checkOutDate)
            {
                ReservationID = reservationID;
                StayID = stayID;
                CheckInDate = checkInDate;
                CheckOutDate = checkOutDate;
            }
        }

    }
}
