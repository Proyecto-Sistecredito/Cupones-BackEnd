using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampañasCreateController : ControllerBase
    {
        public readonly ICampañasService _campañasService;

        public CampañasCreateController(ICampañasService campañasService)
        {
            _campañasService = campañasService;
        }

        [HttpPost]
        [Route("api/campañas")]
        public IActionResult Create([FromBody] Campaña campaña)
        {
            _campañasService.add(campaña);
            return Ok();
        }
    }
}