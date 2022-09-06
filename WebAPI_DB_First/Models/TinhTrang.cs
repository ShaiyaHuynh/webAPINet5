using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_DB_First.Models
{
    public class TinhTrang
    {
        public enum LoaiTinhTrang { TinhTrangVe = 0, TinhTrangChuyenBay = 1 }

        public string MaTT { get; set; }
        public string TenTT { get; set; }

        public TinhTrang(string _MaTT, string _TenTT)
        {
            this.MaTT = _MaTT;

            this.TenTT = _TenTT;
        }

        public List<TinhTrang> GetALL(LoaiTinhTrang _tinhtrang)
        {
            if (_tinhtrang == LoaiTinhTrang.TinhTrangChuyenBay)
            {
                return new List<TinhTrang>() {
                    new TinhTrang ("0", "Đang được mở"),
                    new TinhTrang ("1", "Đã đóng"),
                    new TinhTrang ("-1", "Đang bị hủy")
                };
            }
            else if (_tinhtrang == LoaiTinhTrang.TinhTrangVe)
            {
                return new List<TinhTrang>() {
                    new TinhTrang ("0", "Còn vé"),
                    new TinhTrang ("1", "Hết vé")
                };
            }
            else
            {
                return null;
            }    
        }
    }
}
