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
    public class DALoduncalma
    {
        public static int OduncEkle(tbl_oduncalma n)
        {
            SqlCommand komut4 = new SqlCommand("Insert into tbl_oduncalma(Kitap,Uye,VerilmeTarihi,UyeTEL,UyeMail) Values (@p1,@p2,@p3,@p4,@p5)", DAL.baglanti);

            if (komut4.Connection.State != System.Data.ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", n.Kitap);
            komut4.Parameters.AddWithValue("@p2", n.Uye);
            komut4.Parameters.AddWithValue("@p3", n.VerilmeTarihi);
            komut4.Parameters.AddWithValue("@p4", n.UyeTEL);
            komut4.Parameters.AddWithValue("@p5", n.UyeMail);
            
            return komut4.ExecuteNonQuery();
        }
        public static bool KayitSil(int p)
        {
            SqlCommand komut5 = new SqlCommand("Delete from tbl_oduncalma where VerilmeID=@p1", DAL.baglanti);
            if (komut5.Connection.State != System.Data.ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@p1", p);
            return komut5.ExecuteNonQuery() > 0;

        }
        public static bool KayitGuncelle(tbl_oduncalma n)
        {
            SqlCommand komut6 = new SqlCommand("Update tbl_oduncalma set Kitap=@p1,Uye=@p2,VerilmeTarihi=@p3,UyeTEL=@p4,UyeMail=@p5 where VerilmeID=@p6", DAL.baglanti);
            if (komut6.Connection.State != System.Data.ConnectionState.Open)
            {
                komut6.Connection.Open();
            }
            komut6.Parameters.AddWithValue("@p1", n.Kitap);
            komut6.Parameters.AddWithValue("@p2", n.Uye);
            komut6.Parameters.AddWithValue("@p3", n.VerilmeTarihi);
            komut6.Parameters.AddWithValue("@p4", n.UyeTEL);
            komut6.Parameters.AddWithValue("@p5", n.UyeMail);
            komut6.Parameters.AddWithValue("@p6", n.VerilmeID);
            

            

            return komut6.ExecuteNonQuery() > 0;

        }
    }
}
