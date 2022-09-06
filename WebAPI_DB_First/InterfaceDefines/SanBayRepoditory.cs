using System.Collections.Generic;
using System.Linq;
//using WebAPI_DB_First.Entities;
using WebAPI_DB_First.Interfaces;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.InterfaceDefines
{
    public class SanBayRepoditory : ISanBayRepository
    {
        private readonly Entities.WebAPI_DB_FirstContext _context;

        public SanBayRepoditory(Entities.WebAPI_DB_FirstContext context)
        {
            _context = context;
        }

        // Lay tat ca thong tin
        public List<SanBayVM> GetALL()
        {
            return _context.SanBays.Select(_sanBay => (new SanBayVM()).ConvertToViewModel(_sanBay)).ToList();
        }

        // Lay thong tin theo ma
        public SanBayVM GetByMa(string maSanBay)
        {
            var SanBay = _context.SanBays.SingleOrDefault(_object => _object.Ma == maSanBay);
            if (SanBay != null)
            {
                return (new SanBayVM()).ConvertToViewModel(SanBay);
            }
            return null;
        }

        // them 1 thong tin
        public SanBayVM Add(SanBayVM SanBay)
        {
            // TH da ton tai roi thi return
            if (GetByMa(SanBay.Ma) != null)
            {
                return null;
            }
            _context.SanBays.Add(SanBay.ConvertToEntity());
            _context.SaveChanges();
            return SanBay;
        }

        // xoa 1 thong tin
        public void Delete(string maSanBay)
        {
            var _SanBay = _context.SanBays.FirstOrDefault(_obj => _obj.Ma == maSanBay);
            if (_SanBay != null)
            {
                _context.SanBays.Remove(_SanBay);
                _context.SaveChanges();
            }
        }

        // update thong tin
        public SanBayVM Update(SanBayVM SanBay)
        {
            if (GetByMa(SanBay.Ma) == null)
            {
                return null;
            }

            var _SanBay = _context.SanBays.SingleOrDefault(_obj => _obj.Ma == SanBay.Ma);
            SanBay.MapToEntity(ref _SanBay);
            _context.SaveChanges();

            return GetByMa(SanBay.Ma);
        }
    }
}
