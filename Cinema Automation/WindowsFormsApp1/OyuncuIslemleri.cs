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
    public partial class OyuncuIslemleri : Form
    {
        public OyuncuIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;


        int id1;
        int id2;

        //AKTÖR VERİLERİ GETİR
        private void kayitGetirAktor()
        {
            //Aktör DatagridWiewine Ver Çekme
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Aktorler";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


            //Aktör DatagridWiewine Ver Çekme
        }
        //AKTÖR VERİLERİ GETİR

        //AKTRİS VERİLERİ GETİR
        private void kayitGetirAktris()
        {
            //Aktör DatagridWiewine Ver Çekme
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Aktrisler";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();


            //Aktör DatagridWiewine Ver Çekme
        }

        //AKTRİS VERİLERİ GETİR



        private void OyuncuIslemleri_Load(object sender, EventArgs e)
        {

            //ÇEŞİTLİ VERİLERİ GETİRME
            kayitGetirAktor();
            kayitGetirAktris();



            DataGridViewColumn column;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                column = dataGridView1.Columns[i];
                if (i == 0)
                {
                    column.Width = 35;
                }
                else
                    column.Width = 95;
            }


            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                column = dataGridView2.Columns[i];
                if (i == 0)
                {
                    column.Width = 35;
                }
                else
                    column.Width = 95;
            }
            //ÇEŞİTLİ VERİLERİ GETİRME
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EKLEME İŞLEMLERİ
            try
            {
                if (textBox1.Text != "")
                {

                    cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandText = "insert into Aktorler(aktorAdi) values (@ad)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    kayitGetirAktor();
                    MessageBox.Show("Kayıt Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("İsim Girmediniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //EKLEME İŞLEMLERİ
            }
            catch (Exception)
            {

               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SİLME İŞLEMLERİ
            try
            {
                if (textBox1.Text != "")
                {
                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) == id1)
                    {
                        cmd = new SqlCommand();
                        con.Open();
                        cmd.CommandText = "delete from Aktorler where aktor_id='" + id1 + "'";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        kayitGetirAktor();
                        MessageBox.Show("Kayıt Silindi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Kayıt Silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Silinecek Kaydı seçiniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //SİLME İŞLEMLERİ
            }
            catch (Exception)
            {
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            id1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMLERİ
            try
            {
                if (id1 == 0 || id1 == -1)
                {
                    MessageBox.Show("Güncellenecek Kaydı Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox1.Text != "")
                    {

                        cmd = new SqlCommand();
                        con.Open();
                        cmd.CommandText = "update Aktorler set aktorAdi='" + textBox1.Text + "' where aktor_id='" + id1 + "'";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        kayitGetirAktor();
                        MessageBox.Show("Kayıt Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Güncellenecek Kaydı seçiniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //GÜNCELLEME İŞLEMLERİ
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            id2 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //EKLEME İŞLEMLERİ
            try
            {
                if (textBox2.Text != "")
                {
                    con.Open();
                    string k = "insert into Aktrisler (aktrisAdi) values (@ad)";
                    cmd = new SqlCommand(k, con);
                    cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    kayitGetirAktris();
                    MessageBox.Show("Kayıt Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("İsim Girmediniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //EKLEME İŞLEMLERİ
            }
            catch (Exception)
            {
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SİLME İŞLEMLERİ
            try
            {
                if (textBox2.Text != "")
                {
                    if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value) == id2)
                    {
                        cmd = new SqlCommand();
                        con.Open();
                        cmd.CommandText = "delete from Aktrisler where aktiris_id='" + id2 + "'";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        kayitGetirAktris();
                        MessageBox.Show("Kayıt Silindi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Kayıt Silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Silinecek Kaydı seçiniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //SİLME İŞLEMLERİ
            }
            catch (Exception)
            {

                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMLERİ
            try
            {
                if (id2 == 0 || id2 == -1)
                {
                    MessageBox.Show("Güncellenecek Kaydı Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox2.Text != "")
                    {

                        cmd = new SqlCommand();
                        con.Open();
                        cmd.CommandText = "update Aktrisler set aktrisAdi='" + textBox2.Text + "' where aktiris_id='" + id2 + "'";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        kayitGetirAktris();
                        MessageBox.Show("Kayıt Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Güncellenecek Kaydı seçiniz..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //GÜNCELLEME İŞLEMLERİ
            }
            catch (Exception)
            {
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            YoneticiIslemleri yi = new YoneticiIslemleri();
            yi.Show();
            this.Close();
        }



        //KAYIT ARAMA
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string aranan = textBox1.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                
                                break;
                                
                            }
                            
                        }
                        
                        cell.Style.BackColor = Color.White;
                    }
                   
                }
            }
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox2.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;

                            }

                        }

                        cell.Style.BackColor = Color.White;
                    }
                  
                }
                
            }
           
        }
        //KAYIT ARAMA
    }
}
