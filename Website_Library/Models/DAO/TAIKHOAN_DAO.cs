using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Library.Models.DAO
{
    public class TAIKHOAN_DAO
    {
        public static int Create(TAIKHOAN model)
        {
            try
            {
                using (Data_Entities db = new Data_Entities())
                {
                    db.TAIKHOANs.Add(model);
                    db.SaveChanges();
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static TAIKHOAN Read(string username)
        {
            using (Data_Entities db = new Data_Entities())
            {
                TAIKHOAN taikhoan = db.TAIKHOANs.FirstOrDefault(n => n.Username == username);
                if (taikhoan != null)
                {
                    foreach (CHUCNANG cn in taikhoan.LOAI_TAIKHOAN.CHUCNANGs)
                    {
                        taikhoan.list_ChucNang += cn.Ma_ChucNang + "_";
                    }
                    db.SaveChanges();
                }

                return taikhoan;
            }
        }

        public static int Update(TAIKHOAN model)
        {
            try
            {
                using (Data_Entities db = new Data_Entities())
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}