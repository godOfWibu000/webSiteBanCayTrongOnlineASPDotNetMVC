using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Mvc;
using webBanCayTrong.Models;

namespace webBanCayTrong.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanCayTrongEntities db = new QuanLyBanCayTrongEntities();


        //Trang chinh
        public ActionResult Index(string Login, string Page)
        {
            ViewBag.Login = Login;
            ViewBag.Page = Page;

            return View();
        }

        public ActionResult Contact(string Login)
        {
            ViewBag.Login = Login;

            return View();
        }

        //Trang nhan vien
        public ActionResult ChiTietQLDH(int id)
        {
            ViewBag.maDH = id;

            return View();
        }

        //Tim kiem
        public ActionResult KQTimKiem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KQTimKiem(string tuKhoa)
        {
            ViewBag.tuKhoa = tuKhoa;
            return View();
        }

    }
}