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
    public partial class musteriLogini : Form
    {
        public musteriLogini()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;
        int m_id;
        private void button1_Click(object sender, EventArgs e)
        {

            //LOGIN İŞLEMLERİ
                string tel = textBox1.Text.ToString();//string değişken oluşturuldu
                long sifre = Convert.ToInt32(textBox2.Text);
                cmd = new SqlCommand();
                con.Open();
                //Id Eşleştirme Yapılıyor
                cmd.CommandText = "SELECT * FROM Musteriler where musteriEposta='" + textBox1.Text + "' AND musteriSifre='" + textBox2.Text + "'";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MusteriFilmSecmeEkrani m = new MusteriFilmSecmeEkrani();
                    m_id = Convert.ToInt32(dr["musteri_id"]); //Eposta adresinden id bulunuyor
                    m.musteri_id = m_id;//Diğer forma gönderiliyor
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                con.Close();
                //LOGIN İŞLEMLERİ
            
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MusteriKayitFormu mk = new MusteriKayitFormu();
            mk.Show();
            this.Close();
        }

        private void musteriLogini_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
