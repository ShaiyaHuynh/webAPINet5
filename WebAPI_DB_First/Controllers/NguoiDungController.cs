using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_DB_First.Interfaces;
using WebAPI_DB_First.Models;

namespace WebAPI_DB_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private INguoiDungRepository _NguoiDungRepository;

        // Khai bao su dung tu Interface
        public NguoiDungController(INguoiDungRepository nguoiDungRepository)
        {
            _NguoiDungRepository = nguoiDungRepository;
        }
        [HttpGet]
        public IActionResult GetByMa(string eMail)
        {
            try
            {
                var obj_Select = _NguoiDungRepository.GetByMa(eMail);

                if (obj_Select == null)
                {
                    return NotFound();
                }
                return Ok(obj_Select);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(NguoiDungVM nguoiDung)
        {
            try
            {
                var obj_Select = _NguoiDungRepository.Add(nguoiDung);

                if (obj_Select == null)
                {
                    return NotFound();
                }
                return Ok(obj_Select);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(NguoiDungVM nguoiDung)
        {
            try
            {
                var obj_Update = _NguoiDungRepository.Update(nguoiDung);

                if (obj_Update == null)
                {
                    return NotFound();
                }
                return Ok(obj_Update);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string eMail)
        {
            try
            {
                _NguoiDungRepository.Delete(eMail);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
