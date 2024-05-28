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
    public class ValidationController : ControllerBase
    {
        public readonly IValidationService _ValidationService;

        public ValidationController(IValidationService ValidationService)
        {
            _ValidationService = ValidationService;
        }

        [HttpGet("{id}")]
        public IActionResult Validation(int id)
        {
            try
            {
                var coupon = _ValidationService.GetById(id);
                
                if (coupon == null)
                {
                    return NotFound($"Coupon with Id = {id} not found");
                }

                if (coupon.IdEstado == 2)
                {
                    return BadRequest("El cupón está Inactivo");
                }

                if (coupon.UsosDisponibles == 0)
                {
                    return BadRequest("El cupón no tiene mas usos");
                }

                if (coupon.FechaFin < DateTime.Now)
                {
                    return BadRequest("Fecha del cupón vencida");
                }

                return Ok($"El cupón {coupon.Nombre} con el código {coupon.Codigo} es redimible");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving coupon with id {id}: {ex.Message}");
            }
        }
    }
}