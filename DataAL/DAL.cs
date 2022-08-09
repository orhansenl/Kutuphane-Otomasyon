using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAL
{
    
    public class DAL
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=s305-00;Initial Catalog=kutupsenl;User ID=sa;Password=1234");
    }
}
