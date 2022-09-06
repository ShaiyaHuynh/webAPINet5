using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.Interfaces
{
    public interface IChuyenBayRepository
    {
        List<ChuyenBayVM> GetALL();
        ChuyenBayVM GetByMa(string maChuyenBay);
        ChuyenBayVM Add(ChuyenBayVM chuyenBay);
        ChuyenBayVM Update(ChuyenBayVM chuyenBay);
        void Delete(string maChuyenBay);
    }
}
