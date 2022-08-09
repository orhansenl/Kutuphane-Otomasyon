using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAL;


namespace LogicLayer
{
    public class LogicOduncAlma
    {
        public static bool SilKayit(int per)
        {
            if (per >= 1)
            {
                return DALoduncalma.KayitSil(per);
            }
            else
            {
                return false;
            }
        }
        public static bool GuncelleKayit(tbl_oduncalma g)
        {

            if (g.Kitap != null && g.Uye != null && g.UyeTEL!="" && g.UyeMail!="")
            {

                return DALoduncalma.KayitGuncelle(g);

            }
            else
            {
                return false;

            }

        }
        public static int EkleOdunc(tbl_oduncalma p)
        {
            if (p.Kitap != null && p.Uye != null)
            {

                return DALoduncalma.OduncEkle(p);

            }
            else
            {
                return -1;

            }

        }
    }
}
