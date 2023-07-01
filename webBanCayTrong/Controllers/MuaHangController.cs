using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBanCayTrong.Models;

namespace webBanCayTrong.Controllers
{
    public class MuaHangController : Controller
    {
        QuanLyBanCayTrongEntities db = new QuanLyBanCayTrongEntities();

        //Them vao gio hang
        public ActionResult ThemVaoGioHang(string Login, int Id)
        {
            ViewBag.Login = Login;
            var sp = db.SanPhams.Find(Id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult ThemVaoGioHang(string Login, string maSP, string soLuong, string soTien)
        {
            var dh = new DonHang();
            dh.MaSP = Int32.Parse(maSP);
            dh.SoLuong = Int32.Parse(soLuong);
            dh.SoTien = Int32.Parse(soTien);
            dh.ThoiGian = DateTime.Now;
            dh.TrangThai = "Chưa xác nhận";
            dh.TenTK = Login;

            db.DonHangs.Add(dh);
            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", "TaiKhoan", new { Login = Login });
        }


        //Mua hang
        public ActionResult MuaHang(String Login, int Id, string Message)
        {
            ViewBag.Login = Login;
            ViewBag.Message = Message;
            var sp = db.SanPhams.Find(Id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult MuaHang(string Login, string maSP, string soLuongCon, string soLuong, string soTien)
        {
            int sLCon = int.Parse(soLuongCon);
            int sL = int.Parse(soLuong);
            int id = int.Parse(maSP);
            if(sL > sLCon)
            {
                return RedirectToAction("MuaHang", new { Login = Login , Id = id, Message = "Không đủ hàng!"});
            }
            else
            {
                var dh = new DonHang();
                dh.MaSP = Int32.Parse(maSP);
                dh.SoLuong = Int32.Parse(soLuong);
                dh.SoTien = Int32.Parse(soTien);
                dh.ThoiGian = DateTime.Now;
                dh.TrangThai = "Đang kiểm tra";
                dh.TenTK = Login;

                db.DonHangs.Add(dh);
                db.SaveChanges();

                return RedirectToAction("QuanLyTaiKhoan", "TaiKhoan", new { Login = Login });
            }
        }

        //Trang don hang
        public ActionResult MuaNgay(string Login, int id)
        {
            var donHang = (from dh in db.DonHangs
                           where dh.MaDH == id
                           select dh).ToList();
            foreach (var item in donHang)
            {
                item.TrangThai = "Đang kiểm tra";
            }
            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", "TaiKhoan", new { Login = Login });
        }

        public ActionResult XoaDH(string Login, int id)
        {
            var dh = db.DonHangs.Find(id);
            db.DonHangs.Remove(dh);
            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", "TaiKhoan", new { Login = Login });
        }
    }
}