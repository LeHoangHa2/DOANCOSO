using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Mvc;
using Website_Library.Models;
using Website_Library.Models.DAO;

namespace Website.Controllers
{
    public class SinhVienController : Controller
    {
        private Data_Entities db = new Data_Entities(); // Thay YourDbContext bằng DbContext của bạn

        // GET: SinhVien
        public ActionResult Index()
        {
            return View(db.SinhViens.ToList());
        }

        // GET: SinhVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSinhVien,TenSinhVien,Email,NgaySinh,GioiTinh,DiaChi,DienThoai,TaiKhoan,MatKhau")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                sinhVien.MatKhau = PasswordHasher.HashPassword(sinhVien.MatKhau);
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSinhVien,TenSinhVien,Email,NgaySinh,GioiTinh,DiaChi,DienThoai,TaiKhoan,MatKhau")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult ThongTinChiTiet()
        {
            // Lấy thông tin của sinh viên từ cookie hoặc từ cơ sở dữ liệu
            string taiKhoan = Request.Cookies["TaiKhoan"]?.Value;
            var sinhVien = Website_Library.Models.DAO.SinhVien_DAO.Read(taiKhoan);

            if (sinhVien != null)
            {
                return View(sinhVien);
            }
            else
            {
                // Redirect đến trang đăng nhập nếu không tìm thấy thông tin sinh viên
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult CapNhatThongTin(SinhVien sinhVien)
        {
            // Kiểm tra xem dữ liệu đã được nhập hợp lệ chưa
            if (ModelState.IsValid)
            {
                // Code để cập nhật thông tin sinh viên trong cơ sở dữ liệu
                // Ví dụ:
                if (SinhVien_DAO.Update(sinhVien))
                {
                    ViewBag.ThemThanhCong = true;
                }

                // Chuyển hướng lại đến trang hiển thị thông tin cá nhân
                return RedirectToAction("ThongTinChiTiet");
            }
            else
            {
                // Nếu dữ liệu không hợp lệ, trả về view ThongTinChiTiet với dữ liệu hiện tại
                return View("ThongTinChiTiet", sinhVien);
            }
        }



    }
}
