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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        kutupsenlEntities db5 = new kutupsenlEntities();
        private void Form3_Load(object sender, EventArgs e)
        {
            
            

            var uyead = (from x in db5.tbl_uye
                         select new
                         {
                             x.uyeID,
                             x.uyeADSOYAD,

                         }).ToList();


            comboBox3.ValueMember = "uyeID";
            comboBox3.DisplayMember = "uyeADSOYAD";
            comboBox3.DataSource = uyead;
            comboBox3.Text = $"{vericekme.loggedUserName}";

            var uyetel = (from x in db5.tbl_uye
                         select new
                         {
                             x.uyeID,
                             x.uyeTEL,

                         }).ToList();


            comboBox4.ValueMember = "uyeID";
            comboBox4.DisplayMember = "uyeTEL";
            comboBox4.DataSource = uyetel;
            comboBox4.Text = $"{vericekme.loggedUserTel}";
            var uyemail = (from x in db5.tbl_uye
                          select new
                          {
                              x.uyeID,
                              x.uyeMail,

                          }).ToList();


            comboBox5.ValueMember = "uyeID";
            comboBox5.DisplayMember = "uyeMail";
            comboBox5.DataSource = uyemail;
            comboBox5.Text = $"{vericekme.loggedUserMail}";



            var kitapad = (from x in db5.tbl_kitap
                           select new
                           {
                               x.KitapID,
                               x.KitapAD,

                           }).ToList();


            comboBox2.ValueMember = "KitapID";
            comboBox2.DisplayMember = "KitapAD";
            comboBox2.DataSource = kitapad;
            comboBox2.Text = "";

            var kitapturu = (from x in db5.tbl_kategorikitap
                             select new
                             {
                                 x.KategoriID,
                                 x.KategoriAD,

                             }).ToList();


            comboBox1.ValueMember = "KategoriID";
            comboBox1.DisplayMember = "KategoriAD";
            comboBox1.DataSource = kitapturu;
            comboBox1.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtyazar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtyayinevi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtsayfasayisi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtbilgi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtdurum.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("select KitapResim from tbl_kitap where KitapID='" + txtid.Text + "'", DAL.baglanti));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            Byte[] data = new Byte[0];
            data = (Byte[])(dataSet.Tables[0].Rows[0]["KitapResim"]);
            MemoryStream mem = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(mem);
        }
        kutupsenlEntities db = new kutupsenlEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tbl_kitap
                                        select new
                                        {
                                            x.KitapID,
                                            x.KitapAD,
                                            x.Yazar,
                                            x.Yayınevi,
                                            x.SayfaSayisi,
                                            x.tbl_kategorikitap.KategoriAD,
                                            x.Bilgi,
                                            x.Durum,
                                            x.KitapResim,


                                        }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_oduncalma ekle = new tbl_oduncalma();
            ekle.Kitap = Convert.ToInt32(comboBox2.SelectedValue);
            ekle.Uye = Convert.ToInt32(comboBox3.SelectedValue);
            ekle.VerilmeTarihi = dateTimePicker1.Value;
            ekle.UyeTEL = comboBox4.Text;
            ekle.UyeMail = comboBox5.Text;
            LogicOduncAlma.EkleOdunc(ekle);
            MessageBox.Show("Kitap Ödünç Alındı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış Yapılıyor");
            vericekme.loggedUserName = null;
            vericekme.loggedUserTel = null;
            vericekme.loggedUserMail = null;
            vericekme.loggedUserPassword = null;
            vericekme.loggedID = -1;

            loginekrani frlogin = new loginekrani();
            this.Hide();
            frlogin.Show();
        }
    }
}
