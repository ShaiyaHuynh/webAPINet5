using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_DB_First.Models
{
    public class SanBayVM
    {
        public string Ma { get; set; }
        public string Ten { get; set; }

        public SanBayVM ConvertToViewModel(Entities.SanBay SanBayEntity)
        {
            this.Ma = SanBayEntity.Ma;
            this.Ten = SanBayEntity.Ten;

            return this;
        }

        public Entities.SanBay ConvertToEntity()
        {
            return new Entities.SanBay
            {
                Ma = this.Ma,
                Ten = this.Ten
            };
        }

        public void MapToEntity(ref Entities.SanBay SanBayEntity)
        {
            SanBayEntity.Ma = this.Ma;
            SanBayEntity.Ten = this.Ten;
        }
    }
}
