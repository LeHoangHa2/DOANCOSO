using Website_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Library.Models.DAO;

namespace Website_Library.Controllers
{
    public class AdminController : Controller
    {

        private Data_Entities db = new Data_Entities();
        public static bool IsAdminArea { get; set; }
        // GET: Admin

        public ActionResult Index()
        {
            ViewBag.CurrentUrl = Request.Url.PathAndQuery;

            if (!UserIsLoggedIn())
            {
                // Nếu chưa đăng nhập, điều hướng người dùng đến trang đăng nhập và lưu URL hiện tại
                return RedirectToAction("AdminLogin", new { url = Request.Url.PathAndQuery });
            }

            // Người dùng đã đăng nhập, cho phép truy cập vào trang Index
            return View();
        }
        public ActionResult AdminLogin(string url)
        {
            ViewBag.Url = url;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(TAIKHOAN model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản có tồn tại trong Admin hay không
                TAIKHOAN adminAccount = TAIKHOAN_DAO.Read(model.Username);
                if (adminAccount != null && adminAccount.Password == model.Password && adminAccount.Ma_LoaiTK == "ADMIN")
                {
                    // Đăng nhập thành công, điều hướng đến trang Admin/Index
                    Response.Cookies["TaiKhoan1"].Value = model.Username;
                    Response.Cookies["ChucNang1"].Value = string.Join(",", adminAccount.list_ChucNang);
                    if (model.Ghinho_Dangnhap)
                    {
                        Response.Cookies["TaiKhoan1"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["ChucNang1"].Expires = DateTime.Now.AddDays(7);
                    }
                    else
                    {
                        Response.Cookies["TaiKhoan1"].Expires = DateTime.Now.AddDays(4);
                        Response.Cookies["ChucNang1"].Expires = DateTime.Now.AddDays(4);
                    }
                    AdminController.IsAdminArea = true;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid username or password");
                    return View(model);
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Response.Cookies["TaiKhoan1"].Value = null;
            Response.Cookies["TaiKhoan1"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ChucNang1"].Value = null;
            Response.Cookies["ChucNang1"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("AdminLogin", "Admin");
        }

        // GET: Admin/Table
        public ActionResult Table()
        {
            return View();
        }

        // POST: Admin/Table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Table(Sach product)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(product);
                db.SaveChanges();

                var danhSachSachMoi = LayDanhSachSachMoi();

                return View("_DanhMuc", danhSachSachMoi);

            }

            return View(product);
        }

        // Phương thức để lấy danh sách sách mới
        private List<Sach> LayDanhSachSachMoi()
        {
            var danhSachSachMoi = db.Saches.OrderByDescending(s => s.TimeCreate).Take(10).ToList();
            return danhSachSachMoi;
        }

        private bool AuthenticateUser(TAIKHOAN model)
        {
            // Thực hiện kiểm tra tài khoản trong cơ sở dữ liệu
            var user = db.TAIKHOANs.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password && u.Ma_LoaiTK == "ADMIN");

            // Nếu tìm thấy tài khoản, xác thực thành công
            if (user != null)
            {
                return true;
            }

            // Nếu không, xác thực thất bại
            return false;
        }
        private bool UserIsLoggedIn()
        {
            // Kiểm tra xem cookie "TaiKhoan" có tồn tại hay không
            if (Request.Cookies["TaiKhoan1"] != null)
            {
                // Nếu tồn tại, người dùng đã đăng nhập
                return true;
            }

            // Nếu không tồn tại, người dùng chưa đăng nhập
            return false;
        }

    }
}
