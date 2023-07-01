using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBanCayTrong.Models;

namespace webBanCayTrong.Views
{
    public class QuanLyController : Controller
    {
        QuanLyBanCayTrongEntities db = new QuanLyBanCayTrongEntities();

        //Admin
        public ActionResult Admin(string Login)
        {
            ViewBag.Login = Login;

            return View();
        }


        //Quan ly san pham
        public ActionResult QuanLySanPham()
        {
            List<SanPham> DSSP = db.SanPhams.ToList();

            return View(DSSP);
        }

        public ActionResult ChiTietQuanLySP(int id)
        {
            var sp = db.SanPhams.Find(id);

            return View(sp);
        }

        public ActionResult ThemSP()
        {
            return View(new SanPham { });
        }

        [HttpPost]
        public ActionResult ThemSP(SanPham sp)
        {
            if(ModelState.IsValid)
            {
                //sp.MaDanhMuc = danhMuc;
                //sp.MaLoai = loai;
                sp.SoLuong = sp.SLNhap;

                db.SanPhams.Add(sp);
                db.SaveChanges();

                return RedirectToAction("QuanLySanPham");
            }
            else
                return View(sp);
        }

        public ActionResult CapNhatSP(int id)
        {
            var sp = db.SanPhams.Find(id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult CapNhatSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var update = (from spUpdate in db.SanPhams
                              where spUpdate.MaSP == sp.MaSP
                              select spUpdate).ToList();
                foreach (var item in update)
                {
                    item.TenSP = sp.TenSP;
                    item.GiaBan = sp.GiaBan;
                    item.SLNhap = sp.SLNhap;
                    item.GiaNhap = sp.GiaNhap;
                }
                db.SaveChanges();

                return RedirectToAction("QuanLySanPham", "QuanLy");
            }
            else
                return View(sp);
        }

        public ActionResult XoaSP(int id)
        {
            var sp = db.SanPhams.Find(id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();

            return RedirectToAction("QuanLySanPham");
        }

        //Quan ly tai khoan
        public ActionResult QuanLyTaiKhoan()
        {
            List<TaiKhoan> dsTK = (from tk in db.TaiKhoans
                                   where tk.LoaiTK=="Khách hàng"
                                   select tk).ToList();

            return View(dsTK);
        }

        public ActionResult ChiTietTaiKhoan(string id)
        {
            var tk = db.TaiKhoans.Find(id);

            return View(tk);
        }


        //Trang nhan vien
        public ActionResult NhanVien(string Login)
        {
            ViewBag.Login = Login;

            return View();
        }


        //Quan ly don hang
        public ActionResult QuanLyDonHang(int loc)
        {
            ViewBag.loc = loc;

            return View();
        }

        public ActionResult ChiTietQuanLyDH(int id)
        {
            ViewBag.maDH = id;

            return View();
        }

        public ActionResult VanDonHang(int id)
        {
            ViewBag.id = id;

            return View();
        }

        public ActionResult ChiTietNguoiVanChuyen(int id)
        {
            ViewBag.id = id;

            return View();
        }

        public ActionResult ChiDinhShipper(int id, int MaShipper)
        {
            ViewBag.id = id;
            ViewBag.MaShipper = MaShipper;
            ViewBag.ngayGiao = DateTime.Now;
            ViewBag.ngayNhan = DateTime.Now;

            return View();
        }

        [HttpPost]
        public ActionResult ChiDinhShipper(string MaDH, string MaShipper, string NgayGiao, string NgayNhan)
        {
            var donGiao = new DonGiao();
            donGiao.MaDH = int.Parse(MaDH);
            donGiao.MaShipper = int.Parse(MaShipper);
            donGiao.NgayGiao = DateTime.Parse(NgayGiao);
            donGiao.NgayNhanHang = DateTime.Parse(NgayNhan);
            donGiao.TrangThai = "Đang giao";

            db.DonGiaos.Add(donGiao);

            int maDH = int.Parse(MaDH);

            var donHang = (from dh in db.DonHangs
                           where dh.MaDH==maDH
                           select dh).ToList();
            foreach(var item in donHang)
            {
                item.TrangThai = "Đang giao";
            }

            db.SaveChanges();

            return RedirectToAction("ChiTietQuanLyDH", new { id = int.Parse(MaDH) });
        }


        //Quan ly khach hang
        public ActionResult QuanLyKhachHang()
        {
            List<KhachHang> dsKH = db.KhachHangs.ToList();

            return View(dsKH);
        }

        public ActionResult ChiTietKhachHang(int id)
        {
            var kh = db.KhachHangs.Find(id);

            return View(kh);
        }

        //Doanh so ban hang
        public ActionResult DoanhSoBanHang()
        {
            List<DoanhThu> dsDT = db.DoanhThus.ToList();

            return View(dsDT);
        }

        public ActionResult ChiTietDoanhThu(string thang)
        {
            ViewBag.thang = thang;
            var dt = db.DoanhThus.Find(thang);

            return View(dt);
        }

        //Giao hang
        public ActionResult GiaoHang(string Login)
        {
            int id = 0;

            var Shp = (from shp in db.Shippers
                      where shp.TenTK == Login
                      select shp).ToList();

            foreach(var item in Shp)
            {
                id = item.MaShipper;
            }

            ViewBag.Login = Login;
            ViewBag.id = id;

            return View();
        }

        public ActionResult ChiTietGiaoHang(string Login, int id)
        {
            ViewBag.Login = Login;
            ViewBag.id = id;

            return View();
        }

        public ActionResult GiaoHangThanhCong(string Login, int id)
        {
            var DG = (from dg in db.DonGiaos
                      where dg.MaDH == id
                      select dg).ToList();
            var DH = (from dh in db.DonHangs
                      where dh.MaDH == id
                      select dh).ToList();
            foreach(var item1 in DG)
            {
                item1.TrangThai = "Đã giao";
                item1.NgayNhanHang = DateTime.Now;
                string thang = string.Format("{0:yyyy-MM}", item1.NgayNhanHang);
                var DT = (from dt in db.DoanhThus
                          where dt.Thang == thang
                          select dt).ToList();
                foreach (var item2 in DH)
                {
                    item2.TrangThai = "Đã giao";
                    string MaSP = string.Format("{0:#,0}", item2.MaSP);
                    int maSP = int.Parse(MaSP);
                    string slStr = string.Format("{0:#,0}", item2.SoLuong);
                    int sl = int.Parse(slStr);
                    var SP = (from sp in db.SanPhams
                              where sp.MaSP == maSP
                              select sp).ToList();
                    foreach(var item3 in SP)
                    {
                        string tienLaiStr = string.Format("{0:#,0}", item3.GiaBan-item3.GiaNhap);
                        int tienLai = int.Parse(tienLaiStr);
                        item3.SoLuong -= sl;
                        item3.SLDaBan += sl;
                        foreach (var item4 in DT)
                        {
                            item4.SLBan += sl;
                            item4.DoanhThu1 += tienLai * sl;
                        }
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("GiaoHang", new { Login = Login });
        }

        public ActionResult ThayDoiNgayNhanHang(string Login, int id)
        {
            ViewBag.Login = Login;
            var dg = db.DonGiaos.Find(id);

            return View(dg);
        }

        [HttpPost]
        public ActionResult ThayDoiNgayNhanHang(string Login, int id, string ngayNhanHang)
        {
            var DG = (from dg in db.DonGiaos
                      where dg.MaDH == id
                      select dg).ToList();

            foreach(var item in DG)
            {
                item.NgayNhanHang = DateTime.Parse(ngayNhanHang);
            }

            db.SaveChanges();

            return RedirectToAction("ChiTietGiaoHang", new { Login = Login, id = id });
        }
    }
}