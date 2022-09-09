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
    public class ChiTietChuyenBayRepository : IChiTietChuyenBayRepository
    {
        private readonly WebAPI_DB_FirstContext _context;

        public ChiTietChuyenBayRepository(WebAPI_DB_First.Entities.WebAPI_DB_FirstContext context)
        {
            _context = context;
        }

        public List<ChiTietChuyenBayVM> GetALL()
        {
            return _context.ChiTietChuyenBays.Select(obj => new ChiTietChuyenBayVM().ConvertToViewModel(obj)).ToList();
        }

        public ChiTietChuyenBayVM GetByMa(int maChiTietChuyenBay)
        {
            var chuyenbay = _context.ChiTietChuyenBays
                .Include("MaHangGheNavigation")
                .Include("TinhTrangNavigation")
                .SingleOrDefault(_object => _object.MaChiTiet == maChiTietChuyenBay);
            if (chuyenbay != null)
            {
                return (new ChiTietChuyenBayVM()).ConvertToViewModel(chuyenbay);
            }
            return null;
        }
        public ChiTietChuyenBayVM Add(ChiTietChuyenBayVM chiTietChuyenBay)
        {
            return null;
        }

        public void Delete(int maChiTietChuyenBay)
        {
            var _ChiTiet = _context.ChiTietChuyenBays.FirstOrDefault(_ChiTiet => _ChiTiet.MaChiTiet == maChiTietChuyenBay);
            if(_ChiTiet!= null)
            {
                _context.ChiTietChuyenBays.Remove(_ChiTiet);
                _context.SaveChanges();
            }
        }

        public ChiTietChuyenBayVM Update(ChiTietChuyenBayVM chiTietChuyenBay)
        {
            // TH da ton tai roi thi return
            if (GetByMa(chiTietChuyenBay.MaChiTiet) != null)
            {
                return null;
            }
            _context.ChiTietChuyenBays.Add(chiTietChuyenBay.ConvertToEntity());
            _context.SaveChanges();
            return chiTietChuyenBay;
        }
    }
}
