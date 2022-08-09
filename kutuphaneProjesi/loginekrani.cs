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
    public partial class loginekrani : Form
    {
        public loginekrani()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uyeolformu fruye = new uyeolformu();
            this.Hide();
            fruye.Show();
        }

        private void loginekrani_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand loginUye = new SqlCommand("Select * from tbl_uye where uyeUsername=@a1 and uyePassword=@a2", DAL.baglanti);

            loginUye.Parameters.AddWithValue("@a1", textBox4.Text);
            loginUye.Parameters.AddWithValue("@a2", textBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(loginUye);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Form3 fr3 = new Form3();
                vericekme.loggedUserName = dt.Rows[0]["uyeADSOYAD"].ToString();
                vericekme.loggedUserTel = dt.Rows[0]["uyeTEL"].ToString();
                vericekme.loggedUserMail= dt.Rows[0]["uyeMail"].ToString();

                fr3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
            DAL.baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand loginyetkili = new SqlCommand("Select * from tbl_yetkili where yetkiliUsername=@a1 and yetkiliPassword=@a2", DAL.baglanti);
            loginyetkili.Parameters.AddWithValue("@a1", textBox1.Text);
            loginyetkili.Parameters.AddWithValue("@a2", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(loginyetkili);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Form1 fr1 = new Form1();


                fr1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
            DAL.baglanti.Close();
        }
    }
}
