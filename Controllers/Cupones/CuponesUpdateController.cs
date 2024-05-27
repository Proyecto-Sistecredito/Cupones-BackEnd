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
    [Route("api/[controller]")]
    public class CuponesUpdateController : ControllerBase
    {
        public readonly ICuponesService _cuponesService;

        public CuponesUpdateController( ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }

        [HttpPut("{id}")]
        [Route("api/cupones/{id}/update")]
        public string Update(int id, [FromBody] Cupon cupon)
        {
            return "Falta actualizar";
        }
    }
}