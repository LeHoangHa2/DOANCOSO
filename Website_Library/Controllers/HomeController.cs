using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Library.Models;

namespace Website_Library.Controllers
{
    public class HomeController : Controller
    {
        Data_Entities db = new Data_Entities();

        public ActionResult Index(int page = 1, int pageSize = 10, string Search = "", string categoryId = null, string publisherId = null ,int? namxb = null)
        {
            IQueryable<Sach> query = db.Saches;

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(sp => sp.TenSach.Contains(Search));
            }

            // Lọc theo thể loại nếu có
            if (!string.IsNullOrEmpty(categoryId))
            {
                query = query.Where(sp => sp.MaLoaiSach == categoryId);
            }

            // Lọc theo nhà xuất bản nếu có
            if (!string.IsNullOrEmpty(publisherId))
            {
                query = query.Where(sp => sp.MaNXB == publisherId);
            }
            if (namxb.HasValue)
            {
                query = query.Where(sp => sp.NamXB == namxb.Value);
            }
            // Sắp xếp và phân trang
            var products = query.OrderBy(s => s.MaSach)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Tính tổng số sản phẩm và số trang
            var totalProducts = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            // Đặt ViewBag cho phân trang
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}