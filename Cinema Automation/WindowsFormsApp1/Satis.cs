using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public int film;
        public int koltuk;
        public int salon;
        public int zaman;
        public int tutar;
        public string saat;
        public int musteri;

        //FİLM BİLGİLERİNİ ÇEKME
        private void Film()
        {
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr1;
            cmd.CommandText = "SELECT top 1 film_id FROM Bilet order by bilet_id desc ";
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                 film= Convert.ToInt32(dr1["film_id"]);
            }

            con.Close();
        }
        //FİLM BİLGİLERİNİ ÇEKME

        //KOLTUK BİLGİLERİNİ ÇEKME
        private void Koltuk()
        {
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr1;
            cmd.CommandText = "SELECT top 1 koltuk_id FROM Bilet order by bilet_id desc ";
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                koltuk= Convert.ToInt32(dr1["koltuk_id"]);
            }

            con.Close();
        }
        //KOLTUK BİLGİLERİNİ ÇEKME

        //SALON BİLGİLERİNİ ÇEKME
        private void Salon()
        {
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr1;
            cmd.CommandText = "SELECT top 1 salon_id FROM Bilet order by bilet_id desc ";
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                salon = Convert.ToInt32(dr1["salon_id"]);
            }

            con.Close();
        }
        //SALON BİLGİLERİNİ ÇEKME

        //ZAMAN BİLGİLERİNİ ÇEKME
        private void Zaman()
        {
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr1;
            cmd.CommandText = "SELECT top 1 zaman_id FROM Bilet order by bilet_id desc ";
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                zaman = Convert.ToInt32(dr1["zaman_id"]);
            }

            con.Close();
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr2;
            cmd.CommandText = "select z.saat from Bilet b inner join Zaman z on z.zaman_id=b.zaman_id where z.zaman_id='"+zaman+"'";
            cmd.Connection = con;
            dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                saat = dr2["saat"].ToString();
            }

            con.Close();
        }
        //ZAMAN BİLGİLERİNİ ÇEKME

        //MÜŞTERİ BİLGİLERİNİ ÇEKME

        private void Musteri()
        {
            con.Open();
            cmd = new SqlCommand();
            SqlDataReader dr1;
            cmd.CommandText = "SELECT top 1 musteri_id FROM Satis order by satis_id desc ";
            cmd.Connection = con;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                musteri = Convert.ToInt32(dr1["musteri_id"]);
            }

            con.Close();
        }
        //MÜŞTERİ BİLGİLERİNİ ÇEKME

        private void Satis_Load(object sender, EventArgs e)
        {
            //BİLET BİLGİLEİNİ GETİRME
            Musteri();
            Zaman();
            Film();
            Salon();
            Koltuk();
            
            //MÜŞTERİ BİLGİLERİ ÇEKİLİYOR
            MusteriFilmSecmeEkrani mss = new MusteriFilmSecmeEkrani();
            int b = mss.musteri_id;
            cmd = new SqlCommand();
            SqlDataReader dr;
            con.Open();
            cmd.CommandText = "select musteriAd,musteriSoyad from Musteriler where musteri_id='" + musteri+ "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label8.Text = dr["musteriAd"].ToString() + " " + dr["musteriSoyad"].ToString();

            }
            con.Close();
            MusteriFilmSecmeEkrani ms = new MusteriFilmSecmeEkrani();
          


            //SEÇİLEN FİLM BİLGİLERİ ÇEKİLİYOR
            cmd = new SqlCommand();
            SqlDataReader dr1;
            con.Open();
            cmd.CommandText = "select * from Bilet b inner join Filmler f on f.film_id=b.film_id where f.film_id='" + film+ "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label10.Text = dr1["filmAdi"].ToString();

            }
            con.Close();



            //KOLTUK BİLGİLERİ ÇEKİLİYOR
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Koltuklar k inner join Bilet b on b.koltuk_id=k.koltuk_id where k.koltuk_id='" + koltuk + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label12.Text = dr1["koltukNo"].ToString();

            }
            con.Close();



            //SALON BİLGİLERİ ÇEKİLİYOR
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Salonlar s inner join Bilet b on b.salon_id=s.salon_id where s.salon_id='" + salon+ "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label11.Text = dr1["salonAdi"].ToString();

            }
            con.Close();


            //SEANS BİLGİLERİ ÇEKİLİYOR
            cmd = new SqlCommand();

            con.Open();
            cmd.CommandText = "select * from Zaman z inner join Bilet b on b.zaman_id=z.zaman_id where z.zaman_id='" + zaman+ "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label9.Text = dr1["zamanAralik"].ToString();

            }
            con.Close();


            //SAAT VE BİLET FİYATI ÇEKİLİYOR
            label13.Text = saat;

            label14.Text = tutar.ToString() +" TL" ;

            //BİLET BİLGİLEİNİ GETİRME
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
