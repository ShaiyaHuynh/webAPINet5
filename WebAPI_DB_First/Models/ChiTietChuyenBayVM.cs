using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Entities;

namespace WebAPI_DB_First.Models
{
    public class ChiTietChuyenBayVM
    {
        public int MaChiTiet { get; set; }
        public int MaHangGhe { get; set; }
        public decimal Gia { get; set; }
        public int SoGhe { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayTao { get; set; }

        public string TinhTrangName { get; set; }
        public string HangGheName { get; set; }

        internal ChiTietChuyenBayVM ConvertToViewModel(ChiTietChuyenBay obj)
        {
            this.MaChiTiet = obj.MaChiTiet;
            this.MaHangGhe = obj.MaHangGhe;
            this.Gia = obj.Gia;
            this.SoGhe = obj.SoGhe;
            this.NgayTao = obj.NgayTao;
            this.TinhTrang = obj.TinhTrang;
            this.TinhTrangName = obj.TinhTrangNavigation.TenTinhTrang;
            this.HangGheName = obj.MaHangGheNavigation.Ten;
            return this;
        }

        internal ChiTietChuyenBay ConvertToEntity()
        {
            return new Entities.ChiTietChuyenBay
            {
                MaChiTiet = this.MaChiTiet,
                MaHangGhe = this.MaHangGhe,
                Gia = this.Gia,
                SoGhe = this.SoGhe,
                TinhTrang = this.TinhTrang,
                NgayTao = this.NgayTao
            };
        }
    }
}
