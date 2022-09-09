using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Entities;

namespace WebAPI_DB_First.Models
{
    public class NguoiDungVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal NguoiDungVM ConvertToViewModel(NguoiDung nguoiDung)
        {
            this.Email = nguoiDung.Email;
            this.Password = nguoiDung.Password;
            this.FirstName = nguoiDung.FirstName;
            this.LastName = nguoiDung.LastName;
            return this;
        }

        internal NguoiDung ConvertToEntity()
        {
            return new Entities.NguoiDung
            {
                Email = this.Email,
                Password = this.Password,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }

        internal void MapToEntity(ref NguoiDung nguoidung)
        {
            nguoidung.Email = this.Email;
            nguoidung.FirstName = this.FirstName;
            nguoidung.LastName = this.LastName;
            nguoidung.Password = this.Password;
        }
    }
}
