using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webBanCayTrong.Controllers
{
    public class DanhMucSPController : Controller
    {
        public ActionResult DanhMuc(int id, string Login)
        {
            ViewBag.Login = Login;
            ViewBag.maDanhMuc = id;
            if (id == 1)
            {
                ViewBag.tenDanhMuc = "cây ăn quả";
            }
            else
            {
                ViewBag.tenDanhMuc = "cây công trình";
            }

            return View();
        }

        public ActionResult LoaiCay(int id, string name)
        {
            ViewBag.maLoai = id;
            ViewBag.tenLoai = name;

            return View();
        }
    }
}