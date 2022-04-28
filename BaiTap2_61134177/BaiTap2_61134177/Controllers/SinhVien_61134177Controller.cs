using BaiTap2_61134177.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap2_61134177.Controllers
{
    public class SinhVien_61134177Controller : Controller
    {
        // GET: SinhVien_61134177
        public ActionResult UseRequestIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseRequest()
        {
            string Id = Request["Id"];
            string Name = Request["Name"];
            double Marks = Convert.ToDouble(Request["Marks"]);
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View(ViewBag);
        }

        //sử dụng Action
        public ActionResult UseActionIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseAction(string Id, string Name, string Marks)
        {
            ViewBag.Id = Id;
            ViewBag.Names = Name;
            ViewBag.Marks = Marks;

            return View(ViewBag);
        }

        //sử dụng FormCollection
        public ActionResult UseFormCollectionIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseFormCollection(FormCollection form)
        {
            ViewBag.Id = form["Id"];
            ViewBag.Name = form["Name"];
            ViewBag.Marks = form["Marks"];

            return View(ViewBag);
        }

        //sử dụng model
        public ActionResult UseModelIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseModel(SinhVien sv)
        {
            ViewBag.Id = sv.Id;
            ViewBag.Name = sv.Name;
            ViewBag.Marks = sv.Marks;

            return View(ViewBag);
        }
    }
}