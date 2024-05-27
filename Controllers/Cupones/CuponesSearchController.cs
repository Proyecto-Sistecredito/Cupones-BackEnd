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
    public class CuponesSearchController : ControllerBase
    {
        public readonly ICuponesService _cuponesService;

        public CuponesSearchController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }

    }
}