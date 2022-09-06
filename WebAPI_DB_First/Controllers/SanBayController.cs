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
    public class SanBayController : ControllerBase
    {
        private readonly ISanBayRepository _SanBayRepository;

        // Khai bao su dung tu Interface
        public SanBayController(ISanBayRepository SanBayRepository) {
            _SanBayRepository = SanBayRepository;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                return Ok(_SanBayRepository.GetALL());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{Ma}")]
        public IActionResult GetByMa(string Ma)
        {
            try
            {
               var obj_Select = _SanBayRepository.GetByMa(Ma);

                if(obj_Select== null)
                {
                    return NotFound();
                }
                return Ok(obj_Select);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] SanBayVM SanBay)
        {
            try
            {
                var obj_Select = _SanBayRepository.Add(SanBay);

                if (obj_Select == null)
                {
                    return BadRequest();
                }
                return Ok(obj_Select);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(SanBayVM SanBay)
        {
            try
            {
                var obj_Select = _SanBayRepository.Update(SanBay);

                if (obj_Select == null)
                {
                    return BadRequest();
                }
                return Ok(obj_Select);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string maSanBay)
        {
            try
            {
                _SanBayRepository.Delete(maSanBay);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
