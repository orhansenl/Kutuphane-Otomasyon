using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAL;

namespace LogicLayer
{
    public class LogicKitao
    {
        public static List<tbl_kitap> ListeleKitap()
        {
            
            return DALkitap.KitapListesi();
        }
        
        public static int AddKitap(tbl_kitap p)
        {
            if (p.KitapAD != "" && p.Yazar != "" && p.SayfaSayisi!=0)
            {

                return DALkitap.KitapEkle(p);

            }
            else
            {
                return -1;

            }

        }


        public static bool SilKitap(int per)
        {
            if (per >= 1)
            {
                return DALkitap.KitapSil(per);
            }
            else
            {
                return false;
            }
        }
        public static bool KitapGuncelle(tbl_kitap g)
        {
            
            if (g.KitapAD != "" && g.Yazar != "" && g.SayfaSayisi >0)
            {

                return DALkitap.GuncelleKitap(g);

            }
            else
            {
                return false;

            }

        }



    }
}
