using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otopark_Otomasyonu_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=ENES;Initial Catalog=e;Integrated Security=True");


        private void kat1veri()
        {
            baglan.Open();
            label5.Text = "";

            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=1", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr.GetValue(0).ToString() + " " + "Boş Yer Var";
            }
            baglan.Close();
        }
        private void kat2veri()
        {
            baglan.Open();
            label6.Text = "";

            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=2", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr.GetValue(0).ToString() + " " + "Boş Yer Var";
            }
            baglan.Close();
        }
        private void kat3veri()
        {
            baglan.Open();
            label7.Text = "";

            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=3", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr.GetValue(0).ToString() + " " + "Boş Yer Var";
            }
            baglan.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            kat1veri();
            kat2veri();
            kat3veri();
        }

        private void plakaDogrula()
        {
            baglan.Open();
            string @plaka = maskedTextBox1.Text;

            SqlCommand veriGetir = new SqlCommand("select * from plakalar where plaka=@plaka", baglan);
            veriGetir.Parameters.AddWithValue("@plaka", maskedTextBox1.Text);

            SqlDataReader dr = veriGetir.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Yanlış Plaka Girdiniz.\nBu Plaka Zaten Otoparkta.");
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("Plaka Doğrulandı");
            }
            baglan.Close();
        }
        private void girisKaydet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into plakalar(plaka,tur,sure) values ('" + maskedTextBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        private void katSec()
        {

            if (radioButton1.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer-=1 where kat='kat_1' and bosYer>0", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (radioButton2.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer-=1 where kat=('kat_2')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (radioButton3.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer-=1 where kat=('kat_3')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
        }

        private bool tıklandiMi = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (tıklandiMi == false)
            {
                MessageBox.Show("Lütfen Önce Plakayı Doğrulayın");
            }
            else if (tıklandiMi == true)
            {
                girisKaydet();
                katSec();
                MessageBox.Show("Park Tamamlandı.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            plakaDogrula();
            tıklandiMi = true;
        }
    }
}
