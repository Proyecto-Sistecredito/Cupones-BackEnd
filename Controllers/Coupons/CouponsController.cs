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
    public class CouponsController : ControllerBase
    {
        public readonly ICuponesService _cuponesService;

        public CouponsController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }

        [HttpGet]
        [Route("api/cupones")]
        public IEnumerable<Cupon> GetCupons()
        {
            return _cuponesService.GetAll();
        }

        [HttpGet]
        [Route("api/cupones/{id}")]
        public Cupon Details(int id)
        {
            return _cuponesService.GetById(id);
        }
     
    }
}