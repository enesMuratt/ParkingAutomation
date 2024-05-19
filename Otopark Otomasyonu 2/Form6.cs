using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otopark_Otomasyonu_2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ENES;Initial Catalog=e;Integrated Security=True");

        private void cıkıs()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from plakalar where plaka=@plaka", baglan);
            komut.Parameters.AddWithValue("@plaka", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        private void katSec()
        {

            if (radioButton1.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer+=1 where kat=('kat_1')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (radioButton2.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer+=1 where kat=('kat_2')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (radioButton3.Checked)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand($"Update katlar set bosYer+=1 where kat=('kat_3')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
        }
        private void ucretBelirle()
         {
            string msj;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select sure from plakalar where plaka=('"+maskedTextBox1.Text+"')", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                 msj=(dr[0].ToString());
                if (msj == "1 saatten az") {
                    MessageBox.Show("Tutar: 15TL");
                 }
               else if (msj == "1-6 saat arası")
                {
                    MessageBox.Show("Tutar: 50TL");
                }
                else if (msj == "6-24 saat arası")
                {
                    MessageBox.Show("Tutar: 200TL");
                }
                else if (msj == "24 saatten fazla")
                {
                    MessageBox.Show("Tutar: 500TL");
                }

            }
            baglan.Close();
            
            }    
        
        






        private void button1_Click(object sender, EventArgs e)
        {
            ucretBelirle();
            katSec();
            cıkıs();

        }
    }
}
