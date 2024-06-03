using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_Library.Models;
using Website_Library.Models.DAO;
using PagedList;
namespace Website_Library.Controllers
{
    public class SachController : Controller
    {
        private Data_Entities db = new Data_Entities();

        // GET: Sach
        public ActionResult Index(int? page, string search)

        {
            IQueryable<Sach> query = db.Saches;

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(sp => sp.TenSach.Contains(search));
            }
            int pageSize = 10; // Số lượng sách mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại, mặc định là 1 nếu không có giá trị

            //var books = db.Saches.OrderBy(s => s.MaSach).ToList();

            var pagedListBooks = query.OrderBy(s=>s.MaSach).ToPagedList(pageNumber, pageSize);

            return View(pagedListBooks);
        }

        // GET: Sach/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Sach/Create
        public ActionResult Create()
        {
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB");
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia");
            ViewBag.MaLoaiSach = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            ViewBag.MaViTri = new SelectList(db.ViTris, "MaViTri", "Ngan");
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Sach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sach sach, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                sach.MaSach = Sach_DAO.Create_MaSach();
            }
            if (ModelState.IsValid)
            {


                // Thêm sách vào cơ sở dữ liệu
                db.Saches.Add(sach);
                db.SaveChanges();

                // Nếu file được tải lên thành công
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = "";
                    int index = file.FileName.IndexOf(".");
                    _FileName = "sach" + sach.MaSach + "." + file.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/BookImages"), _FileName);
                    file.SaveAs(_path);

                    // Cập nhật đường dẫn ảnh của sách trong cơ sở dữ liệu
                    sach.ImagePath = _FileName;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, hiển thị lại view với dữ liệu đã nhập
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            ViewBag.MaLoaiSach = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sach.MaLoaiSach);
            ViewBag.MaViTri = new SelectList(db.ViTris, "MaViTri", "Ngan", sach.MaViTri);
            ViewBag.ImagePath = new SelectList(db.Saches, "ImagePath", "ImagePath", sach.ImagePath);

            return View(sach);
        }

        // Phương thức để tạo mã sách mới




        // GET: Sach/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            ViewBag.MaLoaiSach = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sach.MaLoaiSach);
            ViewBag.MaViTri = new SelectList(db.ViTris, "MaViTri", "Ngan", sach.MaViTri);
            ViewBag.ImagePath = new SelectList(db.ViTris, "ImagePath", "ImagePath", sach.ImagePath);
            return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sach sach, HttpPostedFileBase file)

        {
            Sach sach2 = db.Saches.FirstOrDefault(x => x.MaSach == sach.MaSach);

            sach2.TenSach = sach.TenSach;
            sach2.MaLoaiSach = sach.MaLoaiSach;
            sach2.MaTacGia = sach.MaTacGia;
            sach2.NamXB = sach.NamXB;
            sach2.MaNXB = sach.MaNXB;
            sach2.MaViTri = sach.MaViTri;
            sach2.NgonNgu = sach.NgonNgu;
            sach2.TimeCreate = sach.TimeCreate;
            sach2.TimeUpdate = sach.TimeUpdate;
            sach2.SoLuong = sach.SoLuong;

            if (file != null && file.ContentLength > 0)
            {
                string id = sach2.MaSach;
                string _FileName = "";
                int index = file.FileName.IndexOf(".");
                _FileName = "sach" + id.ToString() + "." + file.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/BookImages"), _FileName);
                file.SaveAs(_path);
                sach2.ImagePath = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Sach/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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

        public ActionResult Danhmuc(string nxb, string chude, int page = 1)
        {
            List<Sach> model = Sach_DAO.Read_All(nxb, chude);

            //Phân trang
            int pageSize = (page == 1) ? 12 : 12;
            ViewBag.NXB = nxb;
            ViewBag.ChuDe = chude;
            return View(model.ToPagedList(page, pageSize));
        }
        public ActionResult Chitiet_Sach(string ma_Sach)
        {
            using (var context = new Data_Entities())
            {
                var model = context.Saches
                    .Include(s => s.TheLoai)
                    .Include(s => s.TacGia)
                    .Include(s => s.NXB)
                    .FirstOrDefault(s => s.MaSach == ma_Sach);

                return PartialView(model);
            }
        }



    }
}
