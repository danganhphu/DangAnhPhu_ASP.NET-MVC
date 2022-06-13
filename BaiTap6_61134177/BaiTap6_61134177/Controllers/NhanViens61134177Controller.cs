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
    public class NhanViens61134177Controller : Controller
    {
        private QLNV_61134177Entities db = new QLNV_61134177Entities();

        // GET: NhanViens61134177
        private string LayMaNV()
        {
            var maMax = db.NhanVien.ToList().Select(n => n.MaNV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("000", maNV.ToString());
            return "NV" + NV.Substring(maNV.ToString().Length - 1);
        }

        public ActionResult Index()
        {
            var nhanVien = db.NhanVien.Include(n => n.PhongBan);
            return View(nhanVien.ToList());
        }

        // GET: NhanViens61134177/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens61134177/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaNV();
            ViewBag.MaPB = new SelectList(db.PhongBan, "MaPB", "TenPB");
            return View();
        }

        // POST: NhanViens61134177/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,MaPB")] NhanVien nhanVien)
        {
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            imgNV.SaveAs(path);

            if (ModelState.IsValid)
            {
                nhanVien.MaNV = LayMaNV();
                nhanVien.AnhNV = postedFileName;
                db.NhanVien.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.PhongBan, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // GET: NhanViens61134177/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.PhongBan, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // POST: NhanViens61134177/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,MaPB")] NhanVien nhanVien)
        {
            var imgNV = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                imgNV.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PhongBan, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }

        // GET: NhanViens61134177/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens61134177/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanVien.Find(id);
            db.NhanVien.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TimKiem_61134177(string maNV = "", string hoTen = "", string gioiTinh = "", string luongMin = "", string luongMax = "", string diaChi = "", string maPB = "")
        {
            string min = luongMin, max = luongMax;
            if (gioiTinh != "1" && gioiTinh != "0")
                gioiTinh = null;
            ViewBag.maNV = maNV;
            ViewBag.hoTen = hoTen;
            ViewBag.gioiTinh = gioiTinh;
            if (luongMin == "")
            {
                ViewBag.luongMin = "";
                min = "0";
            }
            else
            {
                ViewBag.luongMin = luongMin;
                min = luongMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.luongMax = "";// Int32.MaxValue.ToString();
            }
            else
            {
                ViewBag.luongMax = luongMax;
                max = luongMax;
            }
            ViewBag.diaChi = diaChi;
            ViewBag.MaPB = new SelectList(db.PhongBan, "MaPB", "TenPB");
            var nhanViens = db.NhanVien.SqlQuery("NhanVien_TimKiem'" + maNV + "','" + hoTen + "','" + gioiTinh + "','" + min + "','" + max + "',N'" + diaChi + "','" + maPB + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
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