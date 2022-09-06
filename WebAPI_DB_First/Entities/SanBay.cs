using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class SanBay
    {
        public SanBay()
        {
            ChuyenBayMaSanBayFromNavigations = new HashSet<ChuyenBay>();
            ChuyenBayMaSanBayToNavigations = new HashSet<ChuyenBay>();
        }

        public string Ma { get; set; }
        public string Ten { get; set; }
        public bool FlgDel { get; set; }

        public virtual ICollection<ChuyenBay> ChuyenBayMaSanBayFromNavigations { get; set; }
        public virtual ICollection<ChuyenBay> ChuyenBayMaSanBayToNavigations { get; set; }
    }
}
