using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.Interfaces
{
    public interface INguoiDungRepository
    {
        NguoiDungVM GetByMa(string eMail);
        NguoiDungVM Add(NguoiDungVM nguoiDung);
        NguoiDungVM Update(NguoiDungVM nguoiDung);
        void Delete(string eMail);
    }
}
