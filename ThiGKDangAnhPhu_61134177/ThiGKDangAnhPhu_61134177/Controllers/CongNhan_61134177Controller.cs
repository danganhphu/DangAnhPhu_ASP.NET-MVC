using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiGKDangAnhPhu_61134177.Models;

namespace ThiGKDangAnhPhu_61134177.Controllers
{
    public class CongNhan_61134177Controller : Controller
    {
        private ThiGK_61134177Entities db = new ThiGK_61134177Entities();

        // GET: CongNhan_61134177
        public ActionResult Index()
        {
            var congNhan = db.CongNhan.Include(c => c.ToQuanLy);
            return View(congNhan.ToList());
        }

        // GET: CongNhan_61134177/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhan congNhan = db.CongNhan.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }

        // GET: CongNhan_61134177/Create
        public ActionResult Create()
        {
            ViewBag.MaTo = new SelectList(db.ToQuanLy, "MaTo", "TenTo");
            return View();
        }

        // POST: CongNhan_61134177/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCN,HoCN,TenCN,AnhDaiDien,NgaySinh,GioiTinh,SoDT,DiaChi,MaTo")] CongNhan congNhan)
        {
            var imgCN = Request.Files["AnhDaiDien"];
            string postedFileName = System.IO.Path.GetFileName(imgCN.FileName);
            var path = Server.MapPath("/images/" + postedFileName);
            imgCN.SaveAs(path);
            if (ModelState.IsValid)
            {
                congNhan.AnhDaiDien = postedFileName;
                db.CongNhan.Add(congNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTo = new SelectList(db.ToQuanLy, "MaTo", "TenTo", congNhan.MaTo);
            return View(congNhan);
        }

        public ActionResult TimKiem_61134177(string hoTen = "")
        {
            ViewBag.hoTen = hoTen;
            var congNhans = from cn in db.CongNhan
                            where (cn.HoCN + " " + cn.TenCN).Contains(hoTen)
                            select cn;
            if (congNhans.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";

            return View(congNhans.ToList());
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