using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class TinhTrang
    {
        public TinhTrang()
        {
            ChiTietChuyenBays = new HashSet<ChiTietChuyenBay>();
            ChuyenBays = new HashSet<ChuyenBay>();
            DonHangs = new HashSet<DonHang>();
        }

        public int Loai { get; set; }
        public int MaTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }

        public virtual ICollection<ChiTietChuyenBay> ChiTietChuyenBays { get; set; }
        public virtual ICollection<ChuyenBay> ChuyenBays { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
