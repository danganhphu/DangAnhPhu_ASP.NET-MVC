﻿using BaiTap3_61134177.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap3_61134177.Controllers
{
    public class NhanVien_61134177Controller : Controller
    {
        // GET: NhanVien_61134177
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Avatar, EmpModel emp)
        {
            //Lấy thông tin từ input type = file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(Avatar.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            Avatar.SaveAs(path);
            string fSave = Server.MapPath("/emp.txt");
            string[] emInfo = {
                emp.EmpID,
                emp.Name,
                emp.BirthOfDate.ToShortDateString(),
                emp.Email,emp.Password,
                emp.Department,
                postedFileName
            };
            //Lưu các thông tin vào tập tin emp.txt
            System.IO.File.WriteAllLines(fSave, emInfo);
            //Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
            ViewBag.EmpID = emInfo[0];
            ViewBag.Name = emInfo[1];
            ViewBag.BirthOfDate = emInfo[2].ToString();
            ViewBag.Email = emInfo[3];
            ViewBag.Password = emInfo[4];
            ViewBag.Department = emInfo[5];
            ViewBag.Avatar = "/images/" + emInfo[6];
            return View("Confirm");
        }

        public ActionResult Confirm(EmpModel emp)
        {
            return View();
        }
    }
}