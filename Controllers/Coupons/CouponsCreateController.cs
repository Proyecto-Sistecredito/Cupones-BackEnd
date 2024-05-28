using System;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponsCreateController : ControllerBase
    {
        private readonly ICuponesService _cuponesService;

        public CouponsCreateController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cupon cupon)
        {
            try
            {
                // Verifica si el cupón recibido es nulo
                if (cupon == null)
                {
                    // Devuelve un BadRequest si el cupón es nulo
                    return BadRequest("Cupón data is null");
                }

                // Agrega el nuevo cupón
                _cuponesService.add(cupon);

                // Devuelve un resultado Ok con el cupón creado
                return Ok(cupon);
            }
            catch (Exception ex)
            {
                // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
                return StatusCode(500, $"Error creating coupon: {ex.Message}");
            }
        }
    }
}
