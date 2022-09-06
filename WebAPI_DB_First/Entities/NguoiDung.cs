using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
