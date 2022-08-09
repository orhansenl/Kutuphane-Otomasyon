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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        kutupsenlEntities db = new kutupsenlEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tbl_oduncalma
                                        select new
                                        {
                                            x.VerilmeID,
                                            x.tbl_kitap.KitapAD,
                                            x.tbl_uye.uyeADSOYAD,
                                            x.VerilmeTarihi,
                                            x.tbl_uye.uyeTEL,
                                            x.tbl_uye.uyeMail,
                                            
                                        }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbl_oduncalma sil = new tbl_oduncalma();
            sil.VerilmeID = Convert.ToInt32(txtoduncid.Text);
            
            LogicOduncAlma.SilKayit(sil.VerilmeID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbl_oduncalma guncelle = new tbl_oduncalma();
            guncelle.Kitap = int.Parse(comboBox1.SelectedValue.ToString());
            guncelle.Uye = int.Parse(comboBox2.SelectedValue.ToString());
            guncelle.VerilmeTarihi = dateTimePicker1.Value;
            guncelle.UyeTEL = comboBox3.SelectedValue.ToString();
            guncelle.UyeMail = comboBox4.SelectedValue.ToString();
            guncelle.VerilmeID = int.Parse(txtoduncid.Text);


            LogicOduncAlma.GuncelleKayit(guncelle);
        }

        kutupsenlEntities db2 = new kutupsenlEntities();
        private void Form2_Load(object sender, EventArgs e)
        {
            var oduncalma = (from x in db2.tbl_kitap
                       select new
                       {
                           x.KitapID,
                           x.KitapAD,

                       }).ToList();


            comboBox1.ValueMember = "KitapID";
            comboBox1.DisplayMember = "KitapAD";
            comboBox1.DataSource = oduncalma;
            comboBox1.Text = "";
            var oduncalma2 = (from x in db2.tbl_uye
                             select new
                             {
                                 x.uyeID,
                                 x.uyeADSOYAD,

                             }).ToList();


            comboBox2.ValueMember = "uyeID";
            comboBox2.DisplayMember = "uyeADSOYAD";
            comboBox2.DataSource = oduncalma2;
            comboBox2.Text = "";

            var oduncalma3 = (from x in db2.tbl_uye
                              select new
                              {
                                  x.uyeID,
                                  x.uyeTEL,

                              }).ToList();


            comboBox3.ValueMember = "uyeID";
            comboBox3.DisplayMember = "uyeTEL";
            comboBox3.DataSource = oduncalma3;
            comboBox3.Text = "";

            var oduncalma4 = (from x in db2.tbl_uye
                              select new
                              {
                                  x.uyeID,
                                  x.uyeMail,

                              }).ToList();


            comboBox4.ValueMember = "uyeID";
            comboBox4.DisplayMember = "uyeMail";
            comboBox4.DataSource = oduncalma4;
            comboBox4.Text = "";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtoduncid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtkitapid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtuyeid.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            this.Hide();
            fr1.Show();
        }
    }
}
