using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.Interfaces
{
    public interface IChiTietChuyenBayRepository
    {
        List<ChiTietChuyenBayVM> GetALL();
        ChiTietChuyenBayVM GetByMa(int maChiTietChuyenBay);
        ChiTietChuyenBayVM Add(ChiTietChuyenBayVM chiTietChuyenBay);
        ChiTietChuyenBayVM Update(ChiTietChuyenBayVM chiTietChuyenBay);
        void Delete(int maChiTietChuyenBay);
    }
}
