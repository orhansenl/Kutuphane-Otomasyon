using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAL;
using EntityLayer;
using LogicLayer;
using System.IO;
using System.Data.SqlClient;

namespace kutuphaneProjesi
{
    public partial class uyeolformu : Form
    {
        public uyeolformu()
        {
            InitializeComponent();
        }

        private void uyeolformu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_uye ekle = new tbl_uye();
            ekle.uyeADSOYAD = textBox1.Text;
            ekle.uyeTEL = textBox2.Text;
            ekle.uyeMail = textBox3.Text;
            ekle.uyeUsername = textBox4.Text;
            ekle.uyePassword = textBox5.Text;
            LogicUye.EkleUye(ekle);

            MessageBox.Show("Üyelik Oluşturuldu Giriş Ekranına Dönebilirsiniz.");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginekrani frlogin = new loginekrani();
            this.Hide();
            frlogin.Show();
        }
    }
}
