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
    public partial class BilgiAl : Form
    {
        public BilgiAl()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        private void BilgiAl_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from Sehirler";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
              
                comboBox11.Items.Add(dr["sehirAd"]);
            }
            con.Close();


        }

        //Stored Procedure Burada
        //Seçili Şehirdeki Sinemaları Gösterir
        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox11.Text == "")
            {
                MessageBox.Show("Lütfen Şehri Seçiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlDataAdapter sql = new SqlDataAdapter("spSehirdekiSinemaBilgileri", con);
                sql.SelectCommand.CommandType = CommandType.StoredProcedure;
                sql.SelectCommand.Parameters.AddWithValue("@sehirAd", comboBox11.SelectedItem.ToString());
                DataSet ds = new DataSet();
                sql.Fill(ds);
                dataGridView4.DataSource = ds.Tables[0];



                con.Close();

            }
        }
        //View Kullanımı
        //Tüm Şehirlerdeki Sinemaları Getirir
        private void button16_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from vwSehirSinemaSalon";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }



        //Fonksiyon Kullanımı 
        //Seçilen Şehre Göre Satılan Bilet Sayısını Gösterir
        private void button17_Click(object sender, EventArgs e)
        {

            if (comboBox11.Text == "")
            {
                MessageBox.Show("Lütfen Şehri Seçiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand sql2 = new SqlCommand("select dbo.fnSehirBiletSatisi(@sehirAd) as donen", con);
                sql2.CommandType = CommandType.Text;
                sql2.Parameters.AddWithValue("@sehirAd", comboBox11.SelectedItem.ToString());
                SqlDataReader dr = sql2.ExecuteReader();
                if (dr.Read())
                    MessageBox.Show(dr["donen"].ToString());
                con.Close();
            }

        }
    }
}
