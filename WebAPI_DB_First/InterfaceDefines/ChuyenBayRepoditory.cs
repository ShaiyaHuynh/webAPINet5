using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Entities;
using WebAPI_DB_First.Interfaces;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.InterfaceDefines
{
    public class ChuyenBayRepoditory : IChuyenBayRepository
    {
        private readonly WebAPI_DB_FirstContext _context;

        public ChuyenBayRepoditory(WebAPI_DB_FirstContext context)
        {
             _context = context;
        }
        
        // Lay tat ca thong tin
        public  List<ChuyenBayVM> GetALL()
        {
            return _context.ChuyenBays.Select(obj => new ChuyenBayVM(obj)).ToList();
        }

        // Lay thong tin theo ma
        public ChuyenBayVM GetByMa(string maChuyenBay)
        {
            var chuyenbay = _context.ChuyenBays.SingleOrDefault(_object => _object.MaChuyenBay == maChuyenBay);
            if (chuyenbay != null)
            {
                return new ChuyenBayVM(chuyenbay);
            }
            return null;
        }

        // them 1 thong tin
        public ChuyenBayVM Add(ChuyenBayVM chuyenBay)
        {
            // TH da ton tai roi thi return
            if (GetByMa(chuyenBay.MaChuyenBay) != null)
            {
                return null;
            }
            _context.ChuyenBays.Add(chuyenBay.ConvertToEntity());
            _context.SaveChanges();
            return chuyenBay;
        }

        // xoa 1 thong tin
        public void Delete(string maChuyenBay)
        {
            var _chuyenbay = _context.ChuyenBays.FirstOrDefault(_obj => _obj.MaChuyenBay == maChuyenBay);
            if (_chuyenbay != null)
            {
                _context.ChuyenBays.Remove(_chuyenbay);
                _context.SaveChanges();
            }
        }

        // update thong tin
        public ChuyenBayVM Update(ChuyenBayVM chuyenBay)
        {
            if(GetByMa(chuyenBay.MaChuyenBay)== null)
            {
                return null;
            }

            var _chuyenBay = _context.ChuyenBays.SingleOrDefault(_obj=>_obj.MaChuyenBay == chuyenBay.MaChuyenBay);
            chuyenBay.MapToEntity(ref _chuyenBay);
            _context.SaveChanges();

            return GetByMa(chuyenBay.MaChuyenBay);
        }

        public List<ChuyenBayVM> GetByCondition(ChuyenBayVM condition, int orderKey, int ascOrDesc)
        {
            var _all = _context.ChuyenBays.Where(_obj => !_obj.FlgDel && _obj.TongSoGhe > 0);
            #region Filter
            if (!string.IsNullOrEmpty(condition.GhiChu))
            {
                _all.Where(_where => _where.GhiChu.Contains(condition.GhiChu));
            }
            if (!string.IsNullOrEmpty(condition.MaChuyenBay))
            {
                _all.Where(_where => _where.MaChuyenBay.Equals(condition.MaChuyenBay));
            }
            if (!string.IsNullOrEmpty(condition.MaMayBay))
            {
                _all.Where(_where => _where.MaMayBay.Equals(condition.MaMayBay));
            }
            if (!condition.MaSanBayFrom.Equals(string.Empty))
            {
                _all.Where(_where => _where.MaSanBayFrom.Equals(condition.MaSanBayFrom));
            }
            if (!condition.MaSanBayTo.Equals(string.Empty))
            {
                _all.Where(_where => _where.MaSanBayTo.Equals(condition.MaSanBayTo));
            }
            if (condition.NgayKhoiHanh != null)
            {
                _all.Where(_where => _where.NgayKhoiHanh == condition.NgayKhoiHanh);
            }
            #endregion

            #region Sorting
            //_all.OrderByDescending(_order => _order.ThoiGianKhoiKhanh)
            #endregion

            return _all.Select(_obj => new ChuyenBayVM(_obj)).ToList();
        }
    }
}
