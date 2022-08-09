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
    public class DALuye
    {
        public static int uyeEkle(tbl_uye n)
        {
            SqlCommand komut1 = new SqlCommand("Insert into tbl_uye (uyeADSOYAD,uyeTEL,uyeMail,uyeUsername,uyePassword) Values (@p1,@p2,@p3,@p4,@p5)", DAL.baglanti);

            if (komut1.Connection.State != System.Data.ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", n.uyeADSOYAD);
            komut1.Parameters.AddWithValue("@p2", n.uyeTEL);
            komut1.Parameters.AddWithValue("@p3", n.uyeMail);
            komut1.Parameters.AddWithValue("@p4", n.uyeUsername);
            komut1.Parameters.AddWithValue("@p5", n.uyePassword);
            
            return komut1.ExecuteNonQuery();
        }
    }
}
