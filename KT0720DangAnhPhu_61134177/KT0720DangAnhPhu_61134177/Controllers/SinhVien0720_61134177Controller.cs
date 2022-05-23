using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720DangAnhPhu_61134177.Models;

namespace KT0720DangAnhPhu_61134177.Controllers
{
    public class SinhVien0720_61134177Controller : Controller
    {
        private KT0720_61134177Entities db = new KT0720_61134177Entities();

        // GET: SinhVien0720_61134177

        public ActionResult GioiThieu_61134177()
        {
            return View();
        }

        public ActionResult Index()
        {
            var sinhVien = db.SINHVIEN.Include(s => s.LOP);
            return View(sinhVien.ToList());
        }

        // GET: SinhVien0720_61134177/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIEN.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhVien0720_61134177/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhVien0720_61134177/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sinhVien)
        {
            var anhSV = Request.Files["AnhSV"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(anhSV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            anhSV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sinhVien.AnhSV = postedFileName;
                db.SINHVIEN.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVien0720_61134177/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIEN.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: SinhVien0720_61134177/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVien0720_61134177/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIEN.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien0720_61134177/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sinhVien = db.SINHVIEN.Find(id);
            db.SINHVIEN.Remove(sinhVien);
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