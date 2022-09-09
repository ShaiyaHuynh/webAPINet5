using Microsoft.EntityFrameworkCore;
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
            return _context.ChuyenBays.Select(obj => (new ChuyenBayVM()).ConvertToViewModel(obj)).ToList();
        }

        // Lay thong tin theo ma
        public ChuyenBayVM GetByMa(string maChuyenBay)
        {
            var chuyenbay = _context.ChuyenBays
                .Include("MaSanBayFromNavigation")
                .Include("MaSanBayToNavigation")
                .Include("TinhTrangNavigation")
                .SingleOrDefault(_object => _object.MaChuyenBay == maChuyenBay);
            if (chuyenbay != null)
            {
                return (new ChuyenBayVM()).ConvertToViewModel(chuyenbay);
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

        public object GetByCondition(ChuyenBayVM condition, int orderKey, int ascOrDesc, int page, int rowOfPage)
        {
            //var _all = _context.ChuyenBays.Include(ct=>ct.ChiTietChuyenBays).Where(_obj => !_obj.FlgDel && _obj.TongSoGhe > 0)
            var _all = _context.ChuyenBays.Where(_obj => !_obj.FlgDel && _obj.TongSoGhe > 0)
                       .AsQueryable();

            #region Filter
            if (!string.IsNullOrEmpty(condition.GhiChu))
            {
                _all = _all.Where(_where => _where.GhiChu.Contains(condition.GhiChu));
            }
            if (!string.IsNullOrEmpty(condition.MaChuyenBay))
            {
                _all = _all.Where(_where => _where.MaChuyenBay.Equals(condition.MaChuyenBay));
            }
            if (!string.IsNullOrEmpty(condition.MaMayBay))
            {
                _all = _all.Where(_where => _where.MaMayBay.Equals(condition.MaMayBay));
            }
            if (!condition.MaSanBayFrom.Equals(string.Empty))
            {
                _all = _all.Where(_where => _where.MaSanBayFrom.Equals(condition.MaSanBayFrom));
            }
            if (!condition.MaSanBayTo.Equals(string.Empty))
            {
                _all = _all.Where(_where => _where.MaSanBayTo.Equals(condition.MaSanBayTo));
            }
            if (condition.NgayKhoiHanh != null)
            {
                _all = _all.Where(_where => _where.NgayKhoiHanh == condition.NgayKhoiHanh);
            }
            #endregion

            #region Select
            var result = from _chuyenbay in _all
                         from _chitietchuyenbay in _chuyenbay.ChiTietChuyenBays
                         where _chitietchuyenbay.SoGhe > 0
                         select new
                         {
                             MaChuyenBay = _chuyenbay.MaChuyenBay,
                             MaChiTietChuyenBay = _chitietchuyenbay.MaChiTiet,
                             SanBayFrom = _chuyenbay.MaSanBayFromNavigation.Ten,
                             SanBayTo = _chuyenbay.MaSanBayToNavigation.Ten,
                             NgayBatDau = _chuyenbay.NgayKhoiHanh,
                             ThoiGianKhoiHanh = _chuyenbay.ThoiGianKhoiHanh,
                             Gia = _chitietchuyenbay.Gia,
                             SoGheConLai = _chitietchuyenbay.SoGhe
                         };
            #endregion

            #region Sorting
            result = result.OrderBy(order => order.ThoiGianKhoiHanh);
            // TH sap xep giam dan
            if (ascOrDesc == 1)
            {
                // TH  = 1 : sx theo gia
                if (orderKey == 1)
                {
                    //_all = _all
                    result = result.OrderByDescending(order => order.Gia);
                }
                // Theo gio
                else if (orderKey == 2)
                {
                    //_all = _all
                    result = result.OrderByDescending(order => order.ThoiGianKhoiHanh);
                }
            }
            else
            {
                // TH  = 1 : sx theo gia
                if (orderKey == 1)
                {
                    //_all = _all
                    result = result.OrderBy(order => order.Gia);
                }
                // Theo gio
                else if (orderKey == 2)
                {
                    //_all = _all
                    result = result.OrderBy(order => order.ThoiGianKhoiHanh);
                }
            }
            #endregion

            #region Paging
            result = result.Skip((page - 1) * rowOfPage).Take(rowOfPage);
            #endregion

            return result.ToList();
        }
    }
}
