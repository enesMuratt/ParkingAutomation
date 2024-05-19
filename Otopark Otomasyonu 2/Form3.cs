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

namespace Otopark_Otomasyonu_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ENES;Initial Catalog=e;Integrated Security=True");

        private void kat3veri()
        {
         baglan.Open();
            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=3", baglan);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr.GetValue(0).ToString()+" " + "Boş Yer Var";
            }     
            baglan.Close();
        }
        private void kat2veri()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=2", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr.GetValue(0).ToString() +" "+ "Boş Yer Var";
            }
            baglan.Close();
        }
        private void kat1veri()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select bosYer from katlar where kat_id=1", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr.GetValue(0).ToString()+" "+"Boş Yer Var";
            }
            baglan.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            kat3veri();  
            kat2veri();
            kat1veri();
        }
    }
}