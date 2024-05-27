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
    public class CuponesController : ControllerBase
    {
        public readonly ICuponesService _cuponesService;

        public CuponesController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }

    }
}