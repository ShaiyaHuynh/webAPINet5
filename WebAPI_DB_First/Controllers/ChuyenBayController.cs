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
    public class ChuyenBayController : ControllerBase
    {
        private readonly IChuyenBayRepository _chuyenBayRepository;

        // Khai bao su dung tu Interface
        public ChuyenBayController(IChuyenBayRepository chuyenBayRepository) {
            _chuyenBayRepository = chuyenBayRepository;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                return Ok(_chuyenBayRepository.GetALL());
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
               var obj_Select = _chuyenBayRepository.GetByMa(Ma);

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
        //[HttpPost]
        //public IActionResult Add(ChuyenBayView chuyenBay)
        //{

        //}
        //ChuyenBayView Update(ChuyenBayView chuyenBay);
        //void Delete(string maChuyenBay);
    }
}
