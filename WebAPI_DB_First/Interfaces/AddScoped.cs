using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.InterfaceDefines;

namespace WebAPI_DB_First.Interfaces
{
    public static class Interfaces
    {
        public static void AddScoped(ref IServiceCollection iService)
        {
            iService.AddScoped<ISanBayRepository, SanBayRepoditory>();
            //iService.AddScoped<IChuyenBayRepository, ChuyenBayRepository>();
        }
    }
}
