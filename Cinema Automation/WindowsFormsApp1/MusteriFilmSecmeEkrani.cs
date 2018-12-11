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
    public partial class MusteriFilmSecmeEkrani : Form
    {
        public MusteriFilmSecmeEkrani()
        {
            InitializeComponent();
        }
        public int musteri_id;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        //Seçilen Özellikler İçin Veritabanından İd Çekme
        int koltukVarmi;
        int kapasite;
        int sinemaid;
        int koltuk;
        int filmid;
        public int fiyat;
        public int zamanid;
        public string saat;
        public int salonid;
        public int koltukid;
        public int idfilm;//datagridwiewden alınan değer
        int biletIdGonder;//Satış Tablosuna Id Göndermek İçin
        //Seçilen Özellikler İçin Veritabanından İd Çekme

        private int FilmIdBul()//Seçili combobaxtaki filmin idsini getirir
        {
            cmd = new SqlCommand();
            con.Open();
            //inner join ile seçili salondaki filmler listeleniyor
            cmd.CommandText = "select * from Filmler f inner join Salonlar s on f.film_id=s.film_id where s.salonAdi='"+comboBox2.SelectedItem.ToString()+"'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())//veri tabanından data çekildi
            {
                filmid= Convert.ToInt32(dr["film_id"]);
            }
            con.Close();
          

            return filmid;
        }
        
        private void SalonIdBul()//Seçili combobaxtaki salonun idsini getirir inner join ile
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Sinema si inner join Salonlar s on si.sinema_id=s.sinema_id where s.salonAdi='" + comboBox3.SelectedItem.ToString() + "' and si.sinemaAd='"+comboBox2.SelectedItem.ToString()+"'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                salonid = Convert.ToInt32(dr["salon_id"]);
            }
            con.Close();

            Satis s = new Satis();
            s.salon = salonid;
          
        }

        private void KoltukIdBul()//Veritabanından koltuk id çekiliyor
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Koltuklar where koltukNo='" + koltuk + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                koltukid = Convert.ToInt32(dr["koltuk_id"]);
            }
            con.Close();
            Satis s = new Satis();
            s.koltuk = koltukid;

        }
        private int TabloKoltukEkle(int a)//Koltuklar Tablosuna Seçilen Koltuk Ekleniyor
        {
            SalonIdBul();
            con.Open();
            cmd = new SqlCommand();
      
            cmd.CommandText = "insert into Koltuklar(salon_id,koltukNo) values(@salonid,@koltuk)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@salonid",salonid);
            cmd.Parameters.AddWithValue("@koltuk",a);
            cmd.ExecuteNonQuery();
            con.Close();
            


            return koltukid;
        }
        private void ZamanIdBul()//Seçili combobaxtaki zamanın idsini getirir 
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Zaman where zamanAralik='" + comboBox6.SelectedItem.ToString() + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                zamanid = Convert.ToInt32(dr["zaman_id"]);
                saat = dr["saat"].ToString();
            }
            con.Close();
            Satis s = new Satis();
            s.zaman = zamanid;
            s.saat = saat;

        }
        private void GosterimdekiFilmiGetir()
        {
            int filmyil = 2017;
            //Film DatagridWiewine Ver Çekme
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select f.film_id as 'id', f.filmAdi as 'Film Adı', f.filmYil as 'Yılı', f.filmYonetmen as 'Yönetmeni', f.filmSure as 'Süre', a.aktorAdi as 'Aktör Adı',ak.aktrisAdi as 'Aktiris Adı',d.dil as 'Dil'  from Filmler f inner join Aktorler a on f.aktor_id=a.aktor_id  inner join Aktrisler ak on f.aktris_id=ak.aktiris_id inner join Dil d on f.dil_id=d.dil_id inner join Zaman z on f.zaman_id=z.zaman_id where f.filmYil='"+filmyil+"'";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();


            //Film DatagridWiewine Ver Çekme
        }
        private void SeansGetir()//Seansları Combobaxa Ekliyor
        {

            con.Open();
            string kayit = "select * from Zaman";
            cmd = new SqlCommand(kayit, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Add(dr["zamanAralik"]);
            }
            con.Close();
        }

        private void kayitGetirSinema()//İlgili Tabloları İnner Join İle Birleştirip Seçili Şehirdeki Sinemalar Comboboxa Yansılıtıyor
        {
            con.Open();
            string kayit = "select Sinema.sinemaAd from Sinema inner join Sehirler on Sehirler.sehir_id=Sinema.sehir_id where Sehirler.sehirAd='" + comboBox1.SelectedItem + "'";
            cmd = new SqlCommand(kayit, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["sinemaAd"]);
            }
            con.Close();
        }
        private void SinemaIdBul()//İnner Join ile Seçili Sinemadaki Salonlar Ekrana Geliyor
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Sinema s inner join Sehirler se on se.sehir_id=s.sehir_id where s.sinemaAd='" + comboBox2.SelectedItem.ToString() + "' and se.sehirAd='"+comboBox1.SelectedItem.ToString()+"'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                sinemaid = Convert.ToInt32(dr["sinema_id"]);

            }
            con.Close();
         
           

        }
        private void SalonKapasite()//Seçilen Salonun Kapasitesi Değişkene Çekiliyor
        {
            SinemaIdBul();
            int sinemaidisi = sinemaid;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Salonlar sa inner join Sinema s on sa.sinema_id=s.sinema_id where Sa.sinema_id='"+sinemaidisi+"' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                kapasite = Convert.ToInt32(dr["salonKapasite"]);
            }
            con.Close();
            


        }

        private void kayitGetirSalon()//Seçili Sinemadaki Salonlar Comboboxa ÇEkiliyor
        {
            con.Open();
            string kayit = "select Salonlar.salonAdi from Sinema inner join Salonlar on Salonlar.sinema_id=Sinema.sinema_id where Sinema.sinemaAd='" + comboBox2.SelectedItem + "'";
            cmd = new SqlCommand(kayit, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["salonAdi"]);
            }
            con.Close();
        }

        private void KayitGetirSalonFilm()//Seçili Salondaki Filmler Datagridwiewe Getiriliyor
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select f.film_id as 'id', f.filmAdi, f.filmYil as 'Film Yılı',f.filmSure as 'Film Süresi',f.filmYonetmen as 'Yönetmen', aktor.aktorAdi as 'Başrol Aktör',aktris.aktrisAdi as 'Başrol Aktris',sa.salonAdi as 'Salon Adı'  from Sehirler as s inner join Sinema as si on s.sehir_id=si.sehir_id inner join Salonlar as sa on sa.sinema_id=si.sinema_id inner join Filmler as f on f.film_id=sa.film_id inner join Aktorler as aktor on aktor.aktor_id=f.aktor_id inner join Aktrisler as aktris on aktris.aktiris_id=f.aktris_id  where sa.salonAdi='" + comboBox3.SelectedItem.ToString() +"'";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        private void SehirYuklecombo1()//Veritabanından Comboboxa Şehirler ÇEkiliyor
        {
           
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Sehirler";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["sehirAd"]);
               
            }
            con.Close();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void MusteriFilmSecmeEkrani_Load(object sender, EventArgs e)
        {
            //ŞEHİR FİLM SEANS VERİLERİNİ COMBOBOXA VE DATAGRİDWİEWE ÇEKME
            GosterimdekiFilmiGetir();
            SehirYuklecombo1();
            SeansGetir();

            DataGridViewColumn column;
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                column = dataGridView2.Columns[i];
                if (i == 0 || i == 2 || i == 4 )
                {
                    column.Width = 35;
                }
                else
                    column.Width = 75;
            }

            cmd = new SqlCommand();
            SqlDataReader dr;
            con.Open();
            cmd.CommandText="select musteriAd,musteriSoyad from Musteriler where musteri_id='"+ musteri_id+"'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label10.Text = dr["musteriAd"].ToString() + " " + dr["musteriSoyad"].ToString();
                
            }
            con.Close();
            //ŞEHİR FİLM SEANS VERİLERİNİ COMBOBOXA VE DATAGRİDWİEWE ÇEKME
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            kayitGetirSinema();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//COMBOBOXA SALON VERİLERİ GELİYOR
        {
            comboBox3.Items.Clear();
            kayitGetirSalon();
        }

        //DATAGRİDVİEWDEN SEÇİLİ FİLMİN ID Sİ SEÇİLİYOR
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idfilm = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Satis s = new Satis();
            s.film= Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //COMBOBOXA VERİ ÇEKME

            comboBox5.Items.Clear();
            KayitGetirSalonFilm();
            SalonKapasite();
            SalonIdBul();
           
            for (int i = 1; i <=kapasite; i++)
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select distinct koltukNo from Koltuklar k inner join Salonlar s on s.salon_id=k.salon_id where s.salon_id='"+salonid+"' and k.koltukNo in ('" + i + "')";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    koltukVarmi = Convert.ToInt32(dr["koltukNo"]);
                   // MessageBox.Show(koltukVarmi.ToString());
                   
                       

                }
                //MessageBox.Show(koltukVarmi.ToString());
                if (koltukVarmi == i)
                {
                    ;

                }
                else
                {
                    comboBox5.Items.Add(i);

                }
                con.Close();
                //COMBOBOXA VERİ ÇEKME
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        //SEÇİLEN KOLTUK KLTUKLAR TABLOSUNA EKLENİYOR
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString()!="")
            {
                koltuk = Convert.ToInt32(comboBox5.SelectedItem);
                MessageBox.Show(koltuk.ToString() + " numaralı koltuk seçildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TabloKoltukEkle(koltuk);

                //comboBox5.Items.Clear();
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FİLM SEÇME İŞLEMLERİ
            try
            {
                if (comboBox1.Text != "")
                {
                    
                    if (comboBox2.Text != "")
                    {
                        if (comboBox3.Text != "")
                        {
                            if (dateTimePicker1.Text != "")
                            {
                                if (comboBox5.Text != "")
                                {
                                    if (comboBox6.Text != "")
                                    {
                                        if (idfilm == -1 || idfilm == 0)
                                        {
                                            MessageBox.Show("Flmi Seçmediniz!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            //Id ler Bulunuyor
                                            SalonIdBul();
                                            SinemaIdBul();
                                            ZamanIdBul();
                                            KoltukIdBul();

                                            //Seans Ücretleri Ödeniyor
                                            if (zamanid == 1 || zamanid == 2)
                                            {
                                                DialogResult secenek = MessageBox.Show("Bilet Ücreti 20 TL,Onaylıyor Musunuz", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                                                if (secenek == DialogResult.Yes)
                                                {
                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    cmd.CommandText = "insert into Bilet (film_id,salon_id,sinema_id,koltuk_id,zaman_id) values(@filmid,@salonid,@sinemaid,@koltukid,@zamanid)";
                                                    cmd.Connection = con;
                                                    cmd.Parameters.AddWithValue("@filmid", idfilm);
                                                    cmd.Parameters.AddWithValue("@salonid", salonid);
                                                    cmd.Parameters.AddWithValue("@sinemaid", sinemaid);
                                                    cmd.Parameters.AddWithValue("@koltukid", koltukid);
                                                    cmd.Parameters.AddWithValue("@zamanid", zamanid);
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();
                                                    MessageBox.Show("Kayıt Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    comboBox2.Items.Clear();
                                                    comboBox3.Items.Clear();
                                                    comboBox5.Items.Clear();
                                                    
                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    SqlDataReader dr1;
                                                    cmd.CommandText = "SELECT top 1 bilet_id FROM Bilet order by bilet_id desc ";
                                                    cmd.Connection = con;
                                                    dr1 = cmd.ExecuteReader();
                                                    if (dr1.Read())
                                                    {
                                                        biletIdGonder = Convert.ToInt32(dr1["bilet_id"]);
                                                    }

                                                    con.Close();
                                                  
                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    cmd.CommandText = "insert into Satis(bilet_id,musteri_id) values(@bilet,@musteri)";
                                                    cmd.Connection = con;
                                                    cmd.Parameters.AddWithValue("@bilet", Convert.ToInt32(biletIdGonder));
                                                    cmd.Parameters.AddWithValue("@musteri", Convert.ToInt32(musteri_id));
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();

                                                    Satis sa = new Satis();
                                                    sa.tutar = 20;
                                                    sa.Show();
                                                }
                                                else if (secenek == DialogResult.No)
                                                {
                                                    MessageBox.Show("Bilet Satış İşlemi İptal Edildi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }

                                            else if (zamanid == 3)
                                            {
                                                DialogResult secenek = MessageBox.Show("Bilet Ücreti 10 TL,Onaylıyor Musunuz", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                //bilet Tablosuna Ekleme Yapılıyor
                                                if (secenek == DialogResult.Yes)
                                                {
                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    cmd.CommandText = "insert into Bilet (film_id,salon_id,sinema_id,koltuk_id,zaman_id) values(@filmid,@salonid,@sinemaid,@koltukid,@zamanid)";
                                                    cmd.Connection = con;
                                                    cmd.Parameters.AddWithValue("@filmid", idfilm);
                                                    cmd.Parameters.AddWithValue("@salonid", salonid);
                                                    cmd.Parameters.AddWithValue("@sinemaid", sinemaid);
                                                    cmd.Parameters.AddWithValue("@koltukid", koltukid);
                                                    cmd.Parameters.AddWithValue("@zamanid", zamanid);
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();
                                                    MessageBox.Show("Kayıt Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                   
                                                    comboBox2.Items.Clear();
                                                    comboBox3.Items.Clear();
                                                    comboBox5.Items.Clear();
                                                   
                                                    //seçili dataların bilete yansıması ve satış tablosuna eklenmesi
                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    SqlDataReader dr1;
                                                    cmd.CommandText = "SELECT top 1 bilet_id FROM Bilet order by bilet_id desc ";
                                                    cmd.Connection = con;
                                                    dr1 = cmd.ExecuteReader();
                                                    if (dr1.Read())
                                                    {
                                                        biletIdGonder = Convert.ToInt32(dr1["bilet_id"]);
                                                    }
                                                    con.Close();

                                                    con.Open();
                                                    cmd = new SqlCommand();
                                                    cmd.CommandText = "insert into Satis(bilet_id,musteri_id) values(@bilet,@musteri)";
                                                    cmd.Connection = con;
                                                    cmd.Parameters.AddWithValue("@bilet", Convert.ToInt32(biletIdGonder));
                                                    cmd.Parameters.AddWithValue("@musteri", Convert.ToInt32(musteri_id));
                                                    cmd.ExecuteNonQuery();
                                                    con.Close();


                                                    fiyat = 10;
                                                    
                                                    Satis sa1 = new Satis();
                                                    sa1.tutar = 10;
                                                    sa1.Show();
                                                }
                                                else if (secenek == DialogResult.No)
                                                {
                                                    MessageBox.Show("Bilet Satış İşlemi İptal Edildi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                    ;
                                                //seçili dataların bilete yansıması ve bilet tablosuna eklenmesi
                                            }
                                        }

                                    }
                                    else
                                        MessageBox.Show("Seansı Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                    MessageBox.Show("Bir Koltuk Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Bir Tarih Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Bir Salon Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Bir Sinema Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bir Şehir Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //FİLM SEÇME İŞLEMLERİ
            }
            catch (Exception)
            {

                con.Close();
                MessageBox.Show("Bir Sinema Seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }
    }
}
