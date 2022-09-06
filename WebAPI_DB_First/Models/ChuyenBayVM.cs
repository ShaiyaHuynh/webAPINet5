using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_DB_First.Models
{
    public class ChuyenBayVM
    {
        public string MaChuyenBay { get; set; }
        public string MaMayBay { get; set; }
        public string MaSanBayFrom { get; set; }
        public string SanBayFromName { get; set; }
        public string MaSanBayTo { get; set; }
        public string SanBayToName { get; set; }
        public DateTime ThoiGianKhoiKhanh { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public int TongSoGhe { get; set; }
        public int TinhTrang { get; set; }
        public string TinhTrangName { get; set; }
        public string GhiChu { get; set; }

        public ChuyenBayVM(Entities.ChuyenBay chuyenbayEntity)
        {
            this.MaChuyenBay = chuyenbayEntity.MaChuyenBay;
            this.MaMayBay = chuyenbayEntity.MaMayBay;
            this.MaSanBayFrom = chuyenbayEntity.MaSanBayFrom;
            this.SanBayFromName = chuyenbayEntity.MaSanBayFromNavigation.Ten;
            this.MaSanBayTo = chuyenbayEntity.MaSanBayTo;
            this.SanBayToName = chuyenbayEntity.MaSanBayToNavigation.Ten;
            this.ThoiGianKhoiKhanh = chuyenbayEntity.ThoiGianKhoiKhanh;
            this.ThoiGianKetThuc = chuyenbayEntity.ThoiGianKetThuc;
            this.TongSoGhe = chuyenbayEntity.TongSoGhe;
            this.TinhTrang = chuyenbayEntity.TinhTrang;
            this.TinhTrangName = chuyenbayEntity.TinhTrangNavigation.TenTinhTrang;
            this.GhiChu = chuyenbayEntity.GhiChu;
        }

        public Entities.ChuyenBay ConvertToEntity()
        {
            return new Entities.ChuyenBay
            {
                MaChuyenBay = this.MaChuyenBay,
                MaMayBay = this.MaMayBay,
                MaSanBayFrom = this.MaSanBayFrom,
                MaSanBayTo = this.MaSanBayTo,
                ThoiGianKhoiKhanh = this.ThoiGianKhoiKhanh,
                ThoiGianKetThuc = this.ThoiGianKetThuc,
                TongSoGhe = this.TongSoGhe,
                TinhTrang = this.TinhTrang,
                GhiChu = this.GhiChu
            };
        }

        public void MapToEntity(ref Entities.ChuyenBay chuyenBayEntity)
        {
            chuyenBayEntity.MaChuyenBay = this.MaChuyenBay;
            chuyenBayEntity.MaMayBay = this.MaMayBay;
            chuyenBayEntity.MaSanBayFrom = this.MaSanBayFrom;
            chuyenBayEntity.MaSanBayTo = this.MaSanBayTo;
            chuyenBayEntity.ThoiGianKhoiKhanh = this.ThoiGianKhoiKhanh;
            chuyenBayEntity.ThoiGianKetThuc = this.ThoiGianKetThuc;
            chuyenBayEntity.TongSoGhe = this.TongSoGhe;
            chuyenBayEntity.TinhTrang = this.TinhTrang;
            chuyenBayEntity.GhiChu = this.GhiChu;
        }
    }
}
