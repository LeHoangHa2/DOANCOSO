using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_Library.Models;
using Website_Library.Models.DAO;

namespace Website_Library.Controllers
{
    public class PhieuMuonController : Controller
    {
        private Data_Entities db = new Data_Entities();

        // GET: PhieuMuon
        public ActionResult Index()
        {
            // Lấy danh sách phiếu mượn từ cơ sở dữ liệu
            var phieuMuons = db.PhieuMuons.Include(p => p.Sach).Include(p => p.SinhVien).ToList();

            // Cập nhật trạng thái cho từng phiếu mượn trong danh sách
            foreach (var phieuMuon in phieuMuons)
            {
                phieuMuon.UpdateTinhTrang();
            }

            // Trả về view Index với danh sách phiếu mượn đã được cập nhật trạng thái
            return View(phieuMuons);
        }


        // GET: PhieuMuon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuon phieuMuon = db.PhieuMuons.Find(id);
            if (phieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(phieuMuon);
        }

        // GET: PhieuMuon/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien");
            return View();
        }

        // POST: PhieuMuon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuMuon,MaSinhVien,NgayMuon,NgayTraDuKien,NgayTraThucTe,TinhTrang,GhiChu,MaSach")] PhieuMuon phieuMuon)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem số lượng sách có đủ để mượn không
                phieuMuon.MaPhieuMuon = PhieuMuon_DAO.Create_PM();
                Sach sach = db.Saches.Find(phieuMuon.MaSach);
                if (sach != null && sach.SoLuong > 0)
                {
                    // Giảm số lượng sách đi sau khi mượn
                    sach.SoLuong--;

                    // Tạo phiếu mượn
                    phieuMuon.UpdateTinhTrang();
                    db.PhieuMuons.Add(phieuMuon);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    // Hiển thị thông báo không thể thêm vì số lượng sách không đủ
                    ModelState.AddModelError(string.Empty, "Không thể mượn sách vì số lượng không đủ.");
                }
            }

            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", phieuMuon.MaSach);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", phieuMuon.MaSinhVien);
            return View(phieuMuon);
        }


        // GET: PhieuMuon/Edit/5
        // GET: PhieuMuon/Edit/5
        public ActionResult Edit(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PhieuMuon phieuMuon = db.PhieuMuons.Find(id);
                if (phieuMuon == null)
                {
                    return HttpNotFound();
                }
                ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", phieuMuon.MaSach);
                ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", phieuMuon.MaSinhVien);
                return View(phieuMuon);
            }


            // POST: PhieuMuon/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "MaPhieuMuon,MaSinhVien,NgayMuon,NgayTraDuKien,NgayTraThucTe,TinhTrang,GhiChu,MaSach")] PhieuMuon phieuMuon)
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra MaPhieuMuon có giá trị không null
                    if (phieuMuon.MaPhieuMuon != null)
                    {
                    phieuMuon.UpdateTinhTrang();
                    db.Entry(phieuMuon).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Xử lý khi MaPhieuMuon là null
                        // Đây có thể là một lỗi xử lý logic hoặc hiển thị thông báo lỗi cho người dùng
                    }
                }
                ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", phieuMuon.MaSach);
                ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", phieuMuon.MaSinhVien);
                return View(phieuMuon);
            }


        // GET: PhieuMuon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuon phieuMuon = db.PhieuMuons.Find(id);
            if (phieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(phieuMuon);
        }

        // POST: PhieuMuon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuMuon phieuMuon = db.PhieuMuons.Find(id);
            db.PhieuMuons.Remove(phieuMuon);
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
    }
}
