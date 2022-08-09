using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAL;
namespace LogicLayer
{
    public class LogicUye
    {
        public static int EkleUye(tbl_uye p)
        {
            if (p.uyeADSOYAD != "" && p.uyeTEL != "" && p.uyePassword != "")
            {

                return DALuye.uyeEkle(p);

            }
            else
            {
                return -1;

            }

        }
    }
}
