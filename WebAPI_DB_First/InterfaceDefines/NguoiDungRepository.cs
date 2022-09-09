using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Entities;
using WebAPI_DB_First.Interfaces;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.InterfaceDefines
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly WebAPI_DB_FirstContext _context;

        public NguoiDungRepository(WebAPI_DB_FirstContext context)
        {
            _context = context;
        }
        public NguoiDungVM Add(NguoiDungVM nguoiDung)
        {
            // TH da ton tai roi thi return
            if (GetByMa(nguoiDung.Email) != null)
            {
                return null;
            }
            _context.NguoiDungs.Add(nguoiDung.ConvertToEntity());
            _context.SaveChanges();
            return nguoiDung;
        }

        public void Delete(string eMail)
        {
            var _nguoidung = _context.NguoiDungs.FirstOrDefault(_obj => _obj.Email == eMail);
            if(_nguoidung!=null)
            {
                _context.NguoiDungs.Remove(_nguoidung);
                _context.SaveChanges();
            }
        }

        public NguoiDungVM GetByMa(string eMail)
        {
            var _nguoiDung = _context.NguoiDungs.FirstOrDefault(_obj => _obj.Email == eMail);
            if(_nguoiDung!= null)
            {
                return new NguoiDungVM().ConvertToViewModel(_nguoiDung);
            }
            return null;
        }

        public NguoiDungVM Update(NguoiDungVM nguoiDung)
        {
            if (GetByMa(nguoiDung.Email) == null)
            {
                return null;
            }

            var _nguoidung = _context.NguoiDungs.SingleOrDefault(_obj => _obj.Email == nguoiDung.Email);
            nguoiDung.MapToEntity(ref _nguoidung);
            _context.SaveChanges();

            return GetByMa(nguoiDung.Email);
        }
    }
}
