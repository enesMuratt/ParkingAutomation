using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Otomasyonu_2
{
    public partial class Form2 : Form
    {
        string kul_adi = "Enes Murat";
        string sifre = "1234";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*   if(kul_adi ==textBox1.Text)
               {
                   if (sifre == textBox2.Text)
                   {
                       Form3 f3 = new Form3();
                       f3.ShowDialog();
                   }
                   else
                   {
                       MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                   }
               }
               else
               {
                   MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
               }*/
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

    }
}
