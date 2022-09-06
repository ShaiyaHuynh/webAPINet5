using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.Interfaces
{
    public interface ISanBayRepository
    {
        List<SanBayVM> GetALL();
        SanBayVM GetByMa(string maChuyenBay);
        SanBayVM Add(SanBayVM sanBay);
        SanBayVM Update(SanBayVM sanBay);
        void Delete(string maSanBay);
    }
}
