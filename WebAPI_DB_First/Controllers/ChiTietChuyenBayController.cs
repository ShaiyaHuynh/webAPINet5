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
    public class ChiTietChuyenBayController : ControllerBase
    {
        private readonly IChiTietChuyenBayRepository _ChiTietChuyenBayRepository;

        public ChiTietChuyenBayController(IChiTietChuyenBayRepository ChiTietChuyenBay)
        {
            _ChiTietChuyenBayRepository = ChiTietChuyenBay;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                return Ok(_ChiTietChuyenBayRepository.GetALL());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{maChiTietChuyenBay}")]
        public IActionResult GetByMa(int maChiTietChuyenBay)
        {
            try
            {
                return Ok(_ChiTietChuyenBayRepository.GetByMa(maChiTietChuyenBay));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(ChiTietChuyenBayVM chiTietChuyenBay)
        {
            try
            {
                var obj_Select = _ChiTietChuyenBayRepository.Add(chiTietChuyenBay);

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
        [HttpDelete]
        public IActionResult Delete(int maChiTietChuyenBay)
        {
            try
            {
                _ChiTietChuyenBayRepository.Delete(maChiTietChuyenBay);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(ChiTietChuyenBayVM chiTietChuyenBay)
        {
            try
            {
                var obj_Update = _ChiTietChuyenBayRepository.Update(chiTietChuyenBay);

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
    }
}
