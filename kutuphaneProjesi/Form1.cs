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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        kutupsenlEntities db = new kutupsenlEntities();
        private void button1_Click(object sender, EventArgs e)
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
       
        public void btnekle_Click(object sender, EventArgs e)
        {
            
            tbl_kitap ekle = new tbl_kitap();
            ekle.KitapAD = txtad.Text;
            ekle.Yazar = txtyazar.Text;
            ekle.Yayınevi = txtyayinevi.Text;
            ekle.SayfaSayisi = short.Parse(txtsayfasayisi.Text);
            ekle.Türü = int.Parse(comboBox1.SelectedValue.ToString());
            ekle.Bilgi = txtbilgi.Text;
            ekle.Durum = txtdurum.Text;
            byte[] ImageByteArray = File.ReadAllBytes(pictureBox1.ImageLocation.ToString());
            ekle.KitapResim = ImageByteArray;
            LogicKitao.AddKitap(ekle);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Stream mystream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "JPEG (*.jpg;*.jpeg;*.jpe)|*.jpg;*.jpeg;*.jpe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if ((mystream=openFileDialog1.OpenFile())!=null)
                {
                    using (mystream)
                    {
                        foreach (string s in openFileDialog1.FileNames)
                        {
                            pictureBox1.ImageLocation = s;
                        }
                    }
                }
            }


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            tbl_kitap sil = new tbl_kitap();
            sil.KitapID = Convert.ToInt32(txtid.Text);
            LogicKitao.SilKitap(sil.KitapID);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            tbl_kitap guncelle = new tbl_kitap();
            guncelle.KitapAD = txtad.Text;
            guncelle.Yazar = txtyazar.Text;
            guncelle.Yayınevi = txtyayinevi.Text;
            guncelle.SayfaSayisi = short.Parse(txtsayfasayisi.Text);
            guncelle.Türü = int.Parse(comboBox1.SelectedValue.ToString());
            guncelle.Bilgi = txtbilgi.Text;
            guncelle.Durum = txtdurum.Text;
            guncelle.KitapID = int.Parse(txtid.Text);
            
            LogicKitao.KitapGuncelle(guncelle);
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
                if (item is PictureBox)
                {
                    PictureBox pbox = (PictureBox)item;
                    pbox.Image = null;
                }
                if (item is RichTextBox)
                {
                    RichTextBox rbox = (RichTextBox)item;
                    rbox.Clear();
                }
                if (item is ComboBox)
                {
                    ComboBox cbox = (ComboBox)item;
                    cbox.SelectedValue = "";
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var kat = (from x in db.tbl_kategorikitap
                         select new
                         {
                             x.KategoriID,
                             x.KategoriAD,

                         }).ToList();
            

            comboBox1.ValueMember = "KategoriID";
            comboBox1.DisplayMember = "KategoriAD";
            comboBox1.DataSource = kat;
            comboBox1.Text = "";
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
        }
    }
}
