using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class ChiTietChuyenBay
    {
        public ChiTietChuyenBay()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int MaChiTiet { get; set; }
        public string MaChuyenBay { get; set; }
        public int MaHangGhe { get; set; }
        public decimal Gia { get; set; }
        public int SoGhe { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayTao { get; set; }

        public virtual ChuyenBay MaChuyenBayNavigation { get; set; }
        public virtual HangGhe MaHangGheNavigation { get; set; }
        public virtual TinhTrang TinhTrangNavigation { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
