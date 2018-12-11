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
    public partial class MusteriIslemleri : Form
    {
        public MusteriIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;
        int id;
        int idgetirMusteri;
        private void MusteriGetir()//MÜŞTERİLERİ DATAGRİDVİEWE GETİRİYOR
        {

            con.Open();
            string kayit = "select * from Musteriler";
            SqlCommand komut = new SqlCommand(kayit, con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //FORM YÜKLENİNCE DATAGRİDEVİEW SÜTUN AYARLARI YAPILIYOR
        private void MusteriIslemleri_Load(object sender, EventArgs e)
        {
            MusteriGetir();
            DataGridViewColumn column;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                column = dataGridView1.Columns[i];
                if (i==0)
                {
                    column.Width = 30;
                }
                else
                    column.Width = 75;



            }
        }


        //DATAGRİDVİEWDE TIKLANAN KAYIT TEXTBOXLARA ÇEKİLİYOR
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EKLEME İŞLEMLERİ
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
                {
                    MessageBox.Show("Tüm Alanarı Doldurun", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
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
                        con.Close();
                        MessageBox.Show("Kayit Başarılı", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        MusteriGetir();
                    //EKLEME İŞLEMLERİ
                }


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
            //SİLME İŞLEMLERİ
            try
            {
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) == id)
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "delete from Musteriler where musteri_id='" + id + "'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MusteriGetir();
                    MessageBox.Show("Kayıt Silindi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Kayıt Silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //SİLME İŞLEMLERİ
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMLERİ
            try
            {
                if (id == 0 || id == -1)
                {
                    MessageBox.Show("Güncellenecek Kaydı Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandText = "select * from Musteriler where musteri_id='" + id+ "'";
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        idgetirMusteri = Convert.ToInt32(dr["musteri_id"]);
                    }

                    con.Close();
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "update Musteriler set musteriAd='" + textBox1.Text + "', musteriSoyad='" + textBox2.Text + "', musteriEposta='" + textBox3.Text + "',musteriTel='"+Convert.ToInt64(textBox4.Text)+"',musteriSifre='"+ Convert.ToInt32(textBox5.Text)+"' where musteri_id='" + id + "'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MusteriGetir();
                    MessageBox.Show("Kayıt Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //GÜNCELLEME İŞLEMLERİ
            }
            catch (Exception)
            {

                con.Close();
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //ANASAYFAYA YÖNLENDİRİYOR
        private void button4_Click(object sender, EventArgs e)
        {
            YoneticiIslemleri yi = new YoneticiIslemleri();
            yi.Show();
        }
    }
}
