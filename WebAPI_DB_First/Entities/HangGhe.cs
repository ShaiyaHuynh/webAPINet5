using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class HangGhe
    {
        public HangGhe()
        {
            ChiTietChuyenBays = new HashSet<ChiTietChuyenBay>();
        }

        public int Ma { get; set; }
        public string Ten { get; set; }
        public string ChiChu { get; set; }

        public virtual ICollection<ChiTietChuyenBay> ChiTietChuyenBays { get; set; }
    }
}
