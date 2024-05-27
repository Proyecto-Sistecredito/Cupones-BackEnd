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
    public class CouponsSearchController : ControllerBase
    {
        public readonly ICuponesService _cuponesService;

        public CouponsSearchController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }
[HttpGet]
        [Route("api/users/search/{consulta}")]
        public IEnumerable<Cupon> Search(string consulta)
        {
            return _cuponesService.Search(consulta);
        }
    }
}