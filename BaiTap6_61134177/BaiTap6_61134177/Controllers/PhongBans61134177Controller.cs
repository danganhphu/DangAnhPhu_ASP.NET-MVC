using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTap6_61134177.Models;

namespace BaiTap6_61134177.Controllers
{
    public class PhongBans61134177Controller : Controller
    {
        private QLNV_61134177Entities db = new QLNV_61134177Entities();

        // GET: PhongBans61134177
        public ActionResult Index()
        {
            return View(db.PhongBan.ToList());
        }

        // GET: PhongBans61134177/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBan.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // GET: PhongBans61134177/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongBans61134177/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.PhongBan.Add(phongBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongBan);
        }

        // GET: PhongBans61134177/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBan.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans61134177/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
        }

        // GET: PhongBans61134177/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBan.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans61134177/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhongBan phongBan = db.PhongBan.Find(id);
            db.PhongBan.Remove(phongBan);
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
