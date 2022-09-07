using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class ChuyenBay
    {
        public ChuyenBay()
        {
            ChiTietChuyenBays = new HashSet<ChiTietChuyenBay>();
        }

        public string MaChuyenBay { get; set; }
        public string MaMayBay { get; set; }
        public string MaSanBayFrom { get; set; }
        public string MaSanBayTo { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public TimeSpan ThoiGianKhoiHanh { get; set; }
        public TimeSpan ThoiGianKetThuc { get; set; }
        public int TongSoGhe { get; set; }
        public int TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public bool FlgDel { get; set; }

        public virtual SanBay MaSanBayFromNavigation { get; set; }
        public virtual SanBay MaSanBayToNavigation { get; set; }
        public virtual TinhTrang TinhTrangNavigation { get; set; }
        public virtual ICollection<ChiTietChuyenBay> ChiTietChuyenBays { get; set; }
    }
}
