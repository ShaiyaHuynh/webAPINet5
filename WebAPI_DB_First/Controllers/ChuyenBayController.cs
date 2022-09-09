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
        public ChuyenBayController(IChuyenBayRepository chuyenBayRepository)
        {
            _chuyenBayRepository = chuyenBayRepository;
        }

        [HttpGet("[action]", Name = "GetAll")]
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

        [HttpGet("{Ma}", Name = "GetByMa")]
        public IActionResult GetByMa(string Ma)
        {
            try
            {
                var obj_Select = _chuyenBayRepository.GetByMa(Ma);

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

        [HttpGet("[action]", Name = "GetByCondition") ]
        public object GetByCondition(ChuyenBayVM condition, int orderKey, int ascOrDesc, int page, int rowOfPage)
        {
            try
            {
                return null;
                var obj_Select = _chuyenBayRepository.GetByCondition(condition, orderKey, ascOrDesc, page, rowOfPage);

                if (obj_Select == null)
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
        public IActionResult Add(ChuyenBayVM chuyenBay)
        {
            try
            {
                var obj_Select = _chuyenBayRepository.Add(chuyenBay);

                if (obj_Select == null)
                {
                    return NotFound();
                }
                return Ok(obj_Select);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string maChuyenBay)
        {
            try
            {
                _chuyenBayRepository.Delete(maChuyenBay);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(ChuyenBayVM chuyenBay)
        {
            try
            {
                var obj_Update = _chuyenBayRepository.Update(chuyenBay);

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
