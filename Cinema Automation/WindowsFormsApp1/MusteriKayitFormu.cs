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
    public partial class MusteriKayitFormu : Form
    {
        public MusteriKayitFormu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");

        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {

            //YENİ MÜŞTERİ KAYIT İŞLEMİ YAPILIYOR
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Tüm Alanarı Doldurun", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox5.Text == textBox6.Text)
                    {
                        con.Open();
                        string kayit = "Insert into Musteriler(musteriAd,musteriSoyad,musteriTel,musteriEposta,musteriSifre) values(@ad,@soyad,@tel,@eposta,@sifre)";
                        cmd = new SqlCommand(kayit, con);
                        cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                        cmd.Parameters.AddWithValue("@eposta", textBox3.Text);
                        cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                        cmd.Parameters.AddWithValue("@sifre", textBox5.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayit Başarılı", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                        MessageBox.Show("Şifreler Uyuşmuyor","HATA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //YENİ MÜŞTERİ KAYIT İŞLEMİ YAPILIYOR
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Hata", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteriLogini ml = new musteriLogini();
            ml.Show();
            this.Close();
        }
    }
}
