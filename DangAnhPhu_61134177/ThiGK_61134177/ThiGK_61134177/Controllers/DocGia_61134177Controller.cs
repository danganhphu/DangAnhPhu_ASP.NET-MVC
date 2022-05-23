using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiGK_61134177.Models;

namespace ThiGK_61134177.Controllers
{
    public class DocGia_61134177Controller : Controller
    {
        private ThiGK_61134177Entities db = new ThiGK_61134177Entities();

        // GET: DocGia_61134177
        public ActionResult Index()
        {
            var docGia = db.DocGia.Include(d => d.LoaiDocGia);
            return View(docGia.ToList());
        }

        // GET: DocGia_61134177/Details/5
        public ActionResult GioiThieu_61134177(string id)
        {
            return View();
        }

        // GET: DocGia_61134177/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGia, "MaLoaiDocGia", "TenLoaiDocGia");
            return View();
        }

        // POST: DocGia_61134177/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDocGia")] DocGia docGia)
        {
            var imgDG = Request.Files["AnhDG"];
            string postedFileName = System.IO.Path.GetFileName(imgDG.FileName);
            var path = Server.MapPath("/images/" + postedFileName);
            imgDG.SaveAs(path);
            if (ModelState.IsValid)
            {
                docGia.AnhDG = postedFileName;
                db.DocGia.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGia, "MaLoaiDocGia", "TenLoaiDocGia", docGia.MaLoaiDocGia);
            return View(docGia);
        }

        // GET: DocGia_61134177/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGia.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGia_61134177/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DocGia docGia = db.DocGia.Find(id);
            db.DocGia.Remove(docGia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TimKiemDG_61134177(string hoTen = "")
        {
            ViewBag.hoTen = hoTen;
            var docGias = from dg in db.DocGia
                          where (dg.HoDG + " " + dg.TenDG).Contains(hoTen)
                          select dg;
            if (docGias.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";

            return View(docGias.ToList());
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