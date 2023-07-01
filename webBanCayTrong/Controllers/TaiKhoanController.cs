using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBanCayTrong.Models;

namespace webBanCayTrong.Controllers
{
    public class TaiKhoanController : Controller
    {
        QuanLyBanCayTrongEntities db = new QuanLyBanCayTrongEntities();

        //Dang nhap
        public ActionResult Login(string Message)
        {
            ViewBag.Message = Message;

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var tk = db.TaiKhoans.Find(username);
            if (tk != null)
            {
                if (tk.MatKhau == password)
                {
                    if (tk.LoaiTK == "Quản trị viên")
                        return RedirectToAction("Admin", "QuanLy", new { Login = tk.TenTK });
                    else if (tk.LoaiTK == "Khách hàng")
                        return RedirectToAction("Index", "Home", new { Login = tk.TenTK });
                    else if(tk.LoaiTK == "Shipper")
                        return RedirectToAction("GiaoHang", "QuanLy", new { Login = tk.TenTK });
                    else
                        return RedirectToAction("NhanVien", "QuanLy", new { Login = tk.TenTK });
                }
                else
                    return RedirectToAction("Login", new { Message = "Tên tài khoản hoặc mật khẩu không chính xác!" });
            }
            else
                return RedirectToAction("Login", new { Message = "Tài khoản không tồn tại!!!" });
        }


        //Dang ky
        public ActionResult Register(string Message, string Login)
        {
            ViewBag.Message = Message;
            ViewBag.Login = Login;

            return View(new TaiKhoan() { });
        }

        [HttpPost]
        public ActionResult Register(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(tk);
                db.SaveChanges();

                return RedirectToAction("Register", new { Message = "Đăng ký thành công!", Login = "Đăng nhập ngay" });
            }
            else
                return View(tk);
        }


        //Quan ly tai khoan
        public ActionResult QuanLyTaiKhoan(string Login)
        {
            ViewBag.Login = Login;

            return View();
        }

        [HttpPost]
        public ActionResult LuuTTTK(string TenTK, string TenHienThi, string Email)
        {
            var taiKhoan = (from tk in db.TaiKhoans
                            where tk.TenTK == TenTK
                            select tk).ToList();
            foreach (var item in taiKhoan)
            {
                item.TenHienThi = TenHienThi;
                item.Email = Email;
            }

            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", new { Login = TenTK });
        }

        [HttpPost]
        public ActionResult LuuTTKH(string TenTK, string TenKH, string NgaySinh, string SDT, string DiaChi)
        {
            var khachHang = (from kh in db.KhachHangs
                             where kh.TenTK == TenTK
                             select kh).ToList();
            foreach (var item in khachHang)
            {
                item.TenKH = TenKH;
                item.NgaySinh = DateTime.Parse(NgaySinh);
                item.SDT = SDT;
                item.DiaChi = DiaChi;
            }

            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", new { Login = TenTK });
        }

        public ActionResult XoaSPYeuThich(string Login, string MaYT)
        {
            int id = Int32.Parse(MaYT);
            var yt = db.YeuThiches.Find(id);
            db.YeuThiches.Remove(yt);
            db.SaveChanges();

            return RedirectToAction("QuanLyTaiKhoan", new { Login = Login });
        }
    }
}