using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
[ApiController]
    [Route("[controller]")]
    public class CouponsCreateController : ControllerBase
    {
        private readonly ICuponesService _cuponesService;

        public CouponsCreateController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }
        [HttpPost]
        [Route("api/cupones")]

        public IActionResult Create([FromBody] Cupon cupon)
        {
            try{
                if(cupon == null){
                    return BadRequest("Cupon data is null");
                }
                _cuponesService.add(cupon);
                return Ok(cupon);
            }
            catch(Exception ex){
                return StatusCode(500, $"Error creating campaign: {ex.Message}");
            }
         
        }
    }
}