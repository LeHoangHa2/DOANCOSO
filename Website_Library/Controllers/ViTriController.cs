using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Website_Library.Models;
using Website_Library.Models.DAO;

namespace Website_Library.Controllers
{
    public class ViTriController : Controller
    {
        private Data_Entities db = new Data_Entities();

        // GET: ViTri
        public ActionResult Index()
        {
            return View(db.ViTris.ToList());
        }

        // GET: ViTri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViTri/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViTri viTri)
        {
            if (ModelState.IsValid)
            {
                viTri.MaViTri = ViTri_DAO.Create_VT();
                db.ViTris.Add(viTri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viTri);
        }

        // GET: ViTri/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViTri viTri = db.ViTris.Find(id);
            if (viTri == null)
            {
                return HttpNotFound();
            }

            return View(viTri);
        }

        // POST: ViTri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViTri viTri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viTri);
        }

        // GET: ViTri/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViTri viTri = db.ViTris.Find(id);
            if (viTri == null)
            {
                return HttpNotFound();
            }

            return View(viTri);
        }

        // POST: ViTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViTri viTri = db.ViTris.Find(id);
            db.ViTris.Remove(viTri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ViTri/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViTri viTri = db.ViTris.Find(id);
            if (viTri == null)
            {
                return HttpNotFound();
            }

            return View(viTri);
        }
    }
}
