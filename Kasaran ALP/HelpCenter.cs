using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasaran_ALP
{
    public partial class HelpCenter : Form
    {
        public HelpCenter()
        {
            InitializeComponent();
        }


        private void lbl1_Click(object sender, EventArgs e)
        {
            string jwb1 = "Untuk melakukan pembatalan penginapan, silakan klik bagian edit reservation. " +
                "Harap dicatat bahwa ada kebijakan pembatalan yang berlaku dan memungkinkan ada pembatalan yang tidak berhasil tergantung pada waktu pembatalan.";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb1,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            string jwb = "Kebijakan pembatalan kami berlaku tergantung pada waktu pembatalan. Apabila pembatalan dilakukan pada h-1 maka pembatalan tidak akan berhasil";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            string jwb = "Untuk melakukan pengubahan tanggal reservasi penginapan, silakan klik bagian edit reservation. ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl4_Click(object sender, EventArgs e)
        {
            string jwb = "Pembatalan status yang gagal bisa terjadi karena pembatalan dilakukan h-1 reservasi ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            string jwb = "Setiap penginapan memiliki fasilitas yang berbeda-beda, untuk bisa mengecek fasilitas yang ada pada penginapan harap membaca deskripsi tiap penginapan ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            string jwb = "1. Pilihlah penginapan yang anda tuju \n2. Bisa dibaca terlebih dahulu deskripsi pada penginapana agar tidak salah reservasi. Setelah merasa sesuai silahkan klik reservasi \n3. Lakukan pembayaran ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl7_Click(object sender, EventArgs e)
        {
            string jwb = "1. Bisa melalui M-Bangking seperti BCA ataupun BNI \n2. Bisa melalui minimarket seperti Indomaret atau Alfamart \n3. Bisa memlalui E-Wallet seperti Go-Pay, Ovo maupun ShoppePay ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void lbl8_Click(object sender, EventArgs e)
        {
            string jwb = "Check-in tersedia mulai pukul 14.00 atau setelahnya, sedangkan check-out diharapkan sebelum pukul 12.00 sesuai kebijakan penginapan.  ";
            paneljwb.Controls.Clear();
            Label labelJwb1 = new Label
            {
                Text = jwb,
                AutoSize = true
            };
            paneljwb.Controls.Add(labelJwb1);
            Controls.Add(paneljwb);
        }

        private void HelpCenter_Load(object sender, EventArgs e)
        {

        }

        private void paneljwb_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
