//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webBanCayTrong.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGia
    {
        public int MaDanhGia { get; set; }
        public Nullable<int> MaSP { get; set; }
        public Nullable<int> SoSaoDG { get; set; }
        public string BinhLuanDG { get; set; }
        public string TenTK { get; set; }
        public Nullable<System.DateTime> ThoiGianDG { get; set; }
    
        public virtual SanPham SanPham { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}