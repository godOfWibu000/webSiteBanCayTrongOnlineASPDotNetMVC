using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBanCayTrong.Models;

namespace webBanCayTrong.Controllers
{
    public class SanPhamController : Controller
    {
        QuanLyBanCayTrongEntities db = new QuanLyBanCayTrongEntities();

        public ActionResult ChiTietSanPham(int id, string Login)
        {
            ViewBag.Login = Login;
            var sp = db.SanPhams.Find(id);
            var yeuThich = (from yt in db.YeuThiches
                            where yt.MaSP == id && yt.TenTK == Login
                            select yt).ToList();
            ViewBag.Favorite = "NO";
            int i = 0;
            foreach (var item in yeuThich)
            {
                i++;
            }

            if (i > 0)
                ViewBag.Favorite = "OK";

            return View(sp);
        }

        public ActionResult DanhGiaSanPham(int id, string Login)
        {
            int i = 0;
            var dged = (from item in db.DanhGias
                        where item.MaSP == id && item.TenTK == Login
                        select item).ToList();
            foreach (var item in dged)
            {
                i++;
                ViewBag.comment = item.BinhLuanDG;
                ViewBag.soSao = item.SoSaoDG;
                ViewBag.thoiGianDG = item.ThoiGianDG;
            }
            if (i > 0)
                ViewBag.kTra = "Đã đánh giá";

            ViewBag.Login = Login;
            var sp = db.SanPhams.Find(id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult DanhGiaSanPham(string Login, int id, string SoSao, string BinhLuan)
        {

            var dg = new DanhGia();
            dg.MaSP = id;
            dg.TenTK = Login;
            dg.SoSaoDG = int.Parse(SoSao);
            dg.BinhLuanDG = BinhLuan;
            dg.ThoiGianDG = DateTime.Now;
            db.DanhGias.Add(dg);
            db.SaveChanges();

            return RedirectToAction("ChiTietSanPham", new { id = id, Login = Login });
        }

        [HttpPost]
        public ActionResult ThemVaoYeuThich(int id, string TenTK, string TorF)
        {
            if (TorF == "NO")
            {
                var yeuThich = new YeuThich();
                yeuThich.MaSP = id;
                yeuThich.TenTK = TenTK;
                db.YeuThiches.Add(yeuThich);
                db.SaveChanges();
            }
            else
            {
                var yeuThiched = (from yt in db.YeuThiches
                                  where yt.MaSP == id
                                  select yt).ToList();
                foreach (var item in yeuThiched)
                    db.YeuThiches.Remove(item);

                db.SaveChanges();
            }

            return RedirectToAction("ChiTietSanPham", new { id = id, Login = TenTK });
        }
    }
}