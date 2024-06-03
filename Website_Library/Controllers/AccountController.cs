using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Library.Models.DAO;
using Website_Library.Models;
using System.Security.Principal;
using Website_Library.Controllers;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web.Helpers;
using System.Net;
using System.Web.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Website_Library.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string url)
        {
            ViewBag.Url = url;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TAIKHOAN model)
        {
            if (ModelState.IsValid)
            {
                TAIKHOAN taikhoan = TAIKHOAN_DAO.Read(model.Username);
                if (taikhoan == null)
                {
                    //Kiểm tra tài khoản có nằm bên bảng Khách hàng hay ko?
                    //(Khách hàng mới đăng ký tài khoản)
                    SinhVien taiKhoan_Moi = SinhVien_DAO.Read(model.Username);
                    if (taiKhoan_Moi == null)
                    {
                        ModelState.AddModelError("Username", "Ko tìm thấy tài khoản");
                        return View(model);
                    }

                    if (taiKhoan_Moi.MatKhau != model.Password && !PasswordHasher.VerifyPassword(model.Password, taikhoan.Password))
                    {
                        ModelState.AddModelError("Password", "Mật khẩu ko đúng");
                        return View(model);
                    }

                    //Tạo mới trên Dữ liệu Tài khoản
                    taikhoan = new TAIKHOAN()
                    {
                        Username = taiKhoan_Moi.TaiKhoan,
                        Password = taiKhoan_Moi.MatKhau,
                        Ma_LoaiTK = "SINHVIEN"
                    };
                    if (TAIKHOAN_DAO.Create(taikhoan) != 0)
                    {
                        ModelState.AddModelError("Username", "Ko tạo được tài khoản");
                        return View(model);
                    }
                }
                else
                {
                    if (taikhoan.Password != model.Password)
                    {
                        ModelState.AddModelError("Password", "Mật khẩu ko đúng");
                        return View(model);
                    }
                }

                Response.Cookies["TaiKhoan"].Value = model.Username;
                taikhoan = TAIKHOAN_DAO.Read(model.Username);
                Response.Cookies["ChucNang"].Value = string.Join(",", taikhoan.list_ChucNang);
                if (model.Ghinho_Dangnhap == true)
                {
                    Response.Cookies["TaiKhoan"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["ChucNang"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    Response.Cookies["TaiKhoan"].Expires = DateTime.Now.AddHours(4);
                    Response.Cookies["ChucNang"].Expires = DateTime.Now.AddHours(4);
                }

                if (String.IsNullOrEmpty(model.url))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(model.url);
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Response.Cookies["TaiKhoan"].Value = null;
            Response.Cookies["TaiKhoan"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ChucNang"].Value = null;
            Response.Cookies["ChucNang"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Change_Password()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_Password(TAIKHOAN model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TAIKHOAN TaiKhoan = TAIKHOAN_DAO.Read(model.Username);

            if (TaiKhoan.Password != model.Password)
            {
                ModelState.AddModelError("Password", "Mật khẩu cũ không chính xác");
                return View(model);
            }

            if (model.New_Password != model.Repeat_Password)
            {
                ModelState.AddModelError("Repeat_Password", "Mật khẩu không giống nhau");
                return View();
            }

            TaiKhoan.Password = model.New_Password;
            if (TAIKHOAN_DAO.Update(TaiKhoan) != 0)
            {
                ModelState.AddModelError("Password", "Không thay đổi được Password");
                return View(model);
            }
            SinhVien SinhVien = SinhVien_DAO.Read(model.Username);
            if (SinhVien != null)
            {
                SinhVien.MatKhau = model.New_Password;
                SinhVien.MatKhau = PasswordHasher.HashPassword(model.New_Password);
                if (!SinhVien_DAO.Update(SinhVien)) 
                {
                    ModelState.AddModelError("Password", "Không thay đổi được Password cho SinhVien");
                    return View(model);
                }
            }
            Response.Cookies["TaiKhoan"].Value = null;
            Response.Cookies["TaiKhoan"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ChucNang"].Value = null;
            Response.Cookies["ChucNang"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register(string url)
        {
            ViewBag.Url = url;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(SinhVien model)
        {
            // Kiểm tra nếu model.MaSinhVien là null, tạo mã sinh viên mới
            if (model.MaSinhVien == null)
            {
                model.MaSinhVien = SinhVien_DAO.Create_MaKH();
            }

            // Kiểm tra ModelState.IsValid để đảm bảo dữ liệu nhập vào là hợp lệ
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra xem tên tài khoản đã tồn tại chưa
            if (!String.IsNullOrEmpty(model.TaiKhoan))
            {
                if (SinhVien_DAO.Check_TaiKhoan(model.TaiKhoan))
                {
                    ModelState.AddModelError("TaiKhoan", "Tài khoản đã tồn tại");
                    return View(model);
                }
            }
            // Kiểm tra xem mật khẩu và nhập lại mật khẩu có khớp nhau không
            if (!String.IsNullOrEmpty(model.MatKhau) && model.Repeat_Password != model.MatKhau)
            {
                ModelState.AddModelError("Repeat_Password", "Mật khẩu không giống nhau");
                return View(model);
            }

            // Thực hiện tạo mới SinhVien trong cơ sở dữ liệu
            if (SinhVien_DAO.Create(model) != 0)
            {
                ModelState.AddModelError("Ten_KH", "Không đăng ký được thành viên");
                return View(model);
            }

            // Nếu đăng ký thành công, chuyển hướng đến trang chủ
            if (String.IsNullOrEmpty(model.url))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return Redirect(model.url);
            }
        }

        private string RetrieveStudentName(string taiKhoan)
        {
            // Thực hiện truy vấn cơ sở dữ liệu hoặc nguồn dữ liệu của bạn để lấy tên sinh viên từ tên tài khoản
            SinhVien sinhVien = SinhVien_DAO.Read(taiKhoan); // Giả sử có phương thức ReadByTaiKhoan để lấy thông tin sinh viên từ tên tài khoản

            // Nếu sinh viên được tìm thấy, trả về tên của họ, ngược lại trả về chuỗi rỗng
            return sinhVien != null ? sinhVien.TenSinhVien : string.Empty;
        }


        //Tìm lại mật khẩu
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                // Tìm sinh viên dựa trên email
                using (var context = new Data_Entities()) // Thay YourDbContext bằng DbContext của bạn
                {
                    var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.Email == email);

                    if (sinhVien != null)
                    {
                        // Tạo mật khẩu mới
                        string newPassword = GenerateRandomPassword();

                        // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                        sinhVien.MatKhau = newPassword;
                        context.SaveChanges();

                        // Gửi email thông báo mật khẩu mới
                        SendEmail(sinhVien.Email, "Mật khẩu mới của bạn", $"Mật khẩu mới của bạn là: {newPassword}");

                        ViewBag.Message = "Mật khẩu mới đã được gửi đến email của bạn.";
                        return View();
                    }
                }
            }

            // Nếu không tìm thấy email hoặc có lỗi, hiển thị thông báo lỗi
            ViewBag.ErrorMessage = "Email không hợp lệ. Vui lòng thử lại.";
            return View();
        }

        // Phương thức để tạo mật khẩu ngẫu nhiên
        private static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var newPassword = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return newPassword;
        }

        // Phương thức để gửi email
        private void SendEmail(string toEmail, string subject, string body)
        {
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            string senderEmail = "nervergone111@gmail.com";
            string senderPassword = "0919413488@Ha";

            using (SmtpClient client = new SmtpClient(smtpServer, port))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, body);
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
