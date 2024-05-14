using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Library.Models.DAO
{
    public class SinhVien_DAO
    {

        public static string Create_MaKH()
        {
            using (Data_Entities db = new Data_Entities())
            {
                try
                {
                    string lastMaKH = "KH_0000";
                    if (db.SinhViens.Count() != 0)
                    {
                        lastMaKH = db.SinhViens.OrderByDescending(n => n.MaSinhVien).Select(n => n.MaSinhVien).FirstOrDefault();
                    }

                    int newId = 1;
                    if (lastMaKH != null)
                    {
                        string numericPart = lastMaKH.Substring(3);
                        int lastId;
                        if (int.TryParse(numericPart, out lastId))
                        {
                            newId = lastId + 1;
                        }
                    }
                    string newMaKH = "KH_" + newId.ToString("D6");
                    return newMaKH;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }




        public static bool Check_TaiKhoan(string ma_TaiKhoan)
        {
            using (Data_Entities db = new Data_Entities())
            {
                if (db.TAIKHOANs.Any(n => n.Username == ma_TaiKhoan))
                {
                    return false;
                }
                else
                {
                    return !(db.SinhViens.Any(n => n.TaiKhoan == ma_TaiKhoan));
                }
            }
        }

        public static int Create(SinhVien model)
        {
            if (model == null)
            {
                return -1;
            }

            using (Data_Entities db = new Data_Entities())
            {
                try
                {
                    db.SinhViens.Add(model);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }


        public static SinhVien Read(string taikhoan)
        {
            using (Data_Entities db = new Data_Entities())
            {
                SinhVien khachHang = db.SinhViens.FirstOrDefault(n => n.TaiKhoan == taikhoan);
                return khachHang;
            }
        }
        public static SinhVien ReadByEmail(string email)
        {
            using (Data_Entities db = new Data_Entities())
            {
                SinhVien sinhVien = db.SinhViens.FirstOrDefault(n => n.Email == email);
                return sinhVien;
            }
        }

        public static bool Update(SinhVien sinhVien)
        {
            try
            {
                // Connect to your database here
                using (var db = new Data_Entities())
                {
                    // Find the student entity in the database
                    var existingSinhVien = db.SinhViens.FirstOrDefault(s => s.TaiKhoan == sinhVien.TaiKhoan);

                    // If the student exists, update its properties with the new values
                    if (existingSinhVien != null)
                    {
                        existingSinhVien.MaSinhVien = sinhVien.MaSinhVien;
                        existingSinhVien.TenSinhVien = sinhVien.TenSinhVien;
                        existingSinhVien.NgaySinh = sinhVien.NgaySinh;
                        existingSinhVien.GioiTinh = sinhVien.GioiTinh;
                        existingSinhVien.DiaChi = sinhVien.DiaChi;
                        existingSinhVien.DienThoai = sinhVien.DienThoai;
                        existingSinhVien.Email = sinhVien.Email;
                        existingSinhVien.TaiKhoan = sinhVien.TaiKhoan;
                        existingSinhVien.MatKhau = sinhVien.MatKhau;

                        // Save changes to the database
                        db.SaveChanges();
                        return true; // Return true if update is successful
                    }
                    else
                    {
                        // Return false if the student doesn't exist in the database
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the update process
                Console.WriteLine("Error updating student: " + ex.Message);
                return false;
            }
        }
    }
}