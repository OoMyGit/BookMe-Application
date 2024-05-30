using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Kasaran_ALP.MainPage2;

namespace Kasaran_ALP
{
    public partial class Favorite : Form
    {
        private List<StayDetail> favoriteStays;
        private StayDetail taek;
        private List<StayDetail> favStays;

        public Favorite(List<StayDetail> favStays)
        {
            InitializeComponent();
            this.favoriteStays = favStays;
        }


        private void Favorite_Load(object sender, EventArgs e)
        {
            int x = 0;
            foreach (StayDetail stay in favoriteStays)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(200, 180);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Tag = stay.Name;
                pictureBox.Image = Image.FromFile(stay.Picture);
                pictureBox.Location = new Point(30, 30 + (x * 80));

                Label nameLabel = new Label();
                nameLabel.Location = new Point(pictureBox.Location.X + 20, pictureBox.Location.Y);
                nameLabel.Text = stay.Name;
                nameLabel.Size = new Size(250, 30);
                nameLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                nameLabel.ForeColor = Color.Black;

                this.Controls.Add(pictureBox);
                this.Controls.Add(nameLabel);

                x++;
            }
        }
    }
}
