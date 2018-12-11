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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-14CBEL7;Initial Catalog=SinemaOtomasyonu;Integrated Security=SSPI");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            musteriLogini m = new musteriLogini();
            m.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiLogini y = new YoneticiLogini();
            y.Show();
        }
    }
}
