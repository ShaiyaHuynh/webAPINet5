using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class DonHang
    {
        public int MaDonHang { get; set; }
        public int MaChiTietChuyenBay { get; set; }
        public int SoGhe { get; set; }
        public string NguoiDung { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayTao { get; set; }

        public virtual ChiTietChuyenBay MaChiTietChuyenBayNavigation { get; set; }
        public virtual NguoiDung NguoiDungNavigation { get; set; }
        public virtual TinhTrang TinhTrangNavigation { get; set; }
    }
}
