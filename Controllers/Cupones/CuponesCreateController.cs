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
    public class CuponesCreateController : ControllerBase
    {
        private readonly ICuponesService _cuponesService;

        public CuponesCreateController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }
        [HttpPost]
        [Route("api/cupones")]

        public IActionResult Create([FromBody] Cupon cupon)
        {
            _cuponesService.add(cupon);
            return Ok();
        }
    }
}