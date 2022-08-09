using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

using EntityLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace DataAL
{
    public class DALkitap
    {
        

        public static List<tbl_kitap> KitapListesi()
        {
            List<tbl_kitap> deger = new List<tbl_kitap>();
            SqlCommand komut1 = new SqlCommand("Select * from tbl_kitap", DAL.baglanti);
            if (komut1.Connection.State != System.Data.ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {

                tbl_kitap ent = new tbl_kitap();
                ent.KitapID = int.Parse(dr["KitapID"].ToString());
                ent.KitapAD = dr["KitapAD"].ToString();
                ent.Yazar = dr["Yazar"].ToString();
                ent.Yayınevi = dr["Yayınevi"].ToString();
                ent.SayfaSayisi = short.Parse(dr["SayfaSayisi"].ToString());
                ent.Türü = short.Parse(dr["Türü"].ToString());
                ent.Bilgi = dr["Bilgi"].ToString();
                ent.Durum = dr["Durum"].ToString();
                using (var memoryStream = new MemoryStream())
                {
                    BinaryFormatter bfWrite = new BinaryFormatter();
                    bfWrite.Serialize(memoryStream, dr["KitapResim"]);
                    ent.KitapResim = memoryStream.ToArray();
                }

                deger.Add(ent);

            }
            dr.Close();
            return deger;

            
        }

        public static int KitapEkle(tbl_kitap n)
        {
            SqlCommand komut2 = new SqlCommand("Insert into tbl_kitap (KitapAD,Yazar,Yayınevi,SayfaSayisi,Türü,Bilgi,Durum,KitapResim) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", DAL.baglanti);

            if (komut2.Connection.State != System.Data.ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", n.KitapAD);
            komut2.Parameters.AddWithValue("@p2", n.Yazar);
            komut2.Parameters.AddWithValue("@p3", n.Yayınevi);
            komut2.Parameters.AddWithValue("@p4", n.SayfaSayisi);
            komut2.Parameters.AddWithValue("@p5", n.Türü);
            komut2.Parameters.AddWithValue("@p6", n.Bilgi);
            komut2.Parameters.AddWithValue("@p7", n.Durum);
            komut2.Parameters.AddWithValue("@p8", n.KitapResim);
            return komut2.ExecuteNonQuery();
        }

        public static bool KitapSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from tbl_kitap where KitapID=@p1", DAL.baglanti);
            if (komut3.Connection.State != System.Data.ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery() > 0;

        }
        public static bool GuncelleKitap(tbl_kitap n)
        {
            SqlCommand komut4 = new SqlCommand("Update tbl_kitap set KitapAD=@p1,Yazar=@p2,Yayınevi=@p3,SayfaSayisi=@p4,Türü=@p5,Bilgi=@p6,Durum=@p7 where KitapID=@p9", DAL.baglanti);
            if (komut4.Connection.State != System.Data.ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", n.KitapAD);
            komut4.Parameters.AddWithValue("@p2", n.Yazar);
            komut4.Parameters.AddWithValue("@p3", n.Yayınevi);
            komut4.Parameters.AddWithValue("@p4", n.SayfaSayisi);
            komut4.Parameters.AddWithValue("@p5", n.Türü);
            komut4.Parameters.AddWithValue("@p6", n.Bilgi);
            komut4.Parameters.AddWithValue("@p7", n.Durum);
            
            komut4.Parameters.AddWithValue("@p9", n.KitapID);

            return komut4.ExecuteNonQuery() > 0;

        }

        



    }
}
