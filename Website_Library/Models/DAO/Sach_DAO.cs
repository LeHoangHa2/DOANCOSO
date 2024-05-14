using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Library.Models.DAO
{
    public class Sach_DAO
    {
        public static string Create_MaSach()
        {
            using (Data_Entities db = new Data_Entities())
            {
                try
                {
                    // Get the last book ID from the database
                    string lastMaSach = db.Saches.OrderByDescending(n => n.MaSach).Select(n => n.MaSach).FirstOrDefault();

                    int newId = 1;
                    if (!string.IsNullOrEmpty(lastMaSach))
                    {
                        // Extract numeric part and parse it to get the last ID
                        string numericPart = lastMaSach.Substring(5); // Assuming "Sach_" prefix
                        int lastId;
                        if (int.TryParse(numericPart, out lastId))
                        {
                            newId = lastId + 1;
                        }
                    }

                    // Create the new book ID
                    string newMaSach = "Sach_" + newId.ToString("D6");
                    return newMaSach;
                }
                catch (Exception ex)
                {
                    // Handle the exception or log it
                    return null;
                }
            }
        }



        public static List<Sach> Read_All(string nxb, string chude)
        {
            using (Data_Entities db = new Data_Entities())
            {

                List<Sach> ketqua;
                if (chude == null)
                {
                    if (nxb == null)
                    {
                        ketqua = db.Saches.ToList();
                    }
                    else
                    {
                        ketqua = db.Saches.Where(n => n.MaNXB == nxb).ToList();
                    }
                }
                else
                {
                    if (nxb == null)
                    {
                        ketqua = db.Saches.Where(n => n.MaLoaiSach == chude).ToList();
                    }
                    else
                    {
                        ketqua = db.Saches.Where(n => n.MaLoaiSach == chude && n.MaNXB == nxb).ToList();
                    }
                }      
                return ketqua;
            }
        }

        public static Sach Read(string ma_Sach)
        {
            if (ma_Sach == null)
                return null;

            using (Data_Entities db = new Data_Entities())
            {
                Sach ketqua = db.Saches.FirstOrDefault(n => n.MaSach == ma_Sach);

                if (ketqua != null)
                {
                    if (!String.IsNullOrEmpty(ketqua.MaTacGia))
                    {
                        ketqua.MaTacGia = ketqua.MaTacGia.TrimEnd(' ').TrimEnd(',');
                    }

                    var theLoai = db.TheLoais.FirstOrDefault(tl => tl.MaTheLoai == ketqua.MaLoaiSach);
                    if (theLoai != null)
                    {
                        ketqua.TheLoai = theLoai; // Gán đối tượng TheLoai thay vì gán tên của nó
                    }

                    var nxbResult = db.NXBs.FirstOrDefault(nxb => nxb.MaNXB == ketqua.MaNXB);
                    if (nxbResult != null)
                    {
                        ketqua.NXB = nxbResult; // Gán đối tượng NXB thay vì gán tên của nó
                    }


                }

                return ketqua;
            }
        }
        public static List<Sach> Read_All()
        {
            using (Data_Entities db = new Data_Entities())
            {
                List<Sach> ketqua = db.Saches.ToList();
                //Đếm các quyển sách có cùng Năm
                foreach (Sach nxb in ketqua)
                {
                    nxb.count = db.Saches.Count(n => n.NamXB == nxb.NamXB);
                }

                return ketqua;
            }
        }

    }
}