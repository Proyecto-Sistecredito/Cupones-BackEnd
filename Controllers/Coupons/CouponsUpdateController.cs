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
    public class CouponsUpdateController : ControllerBase
    {
        public readonly ICouponsService _couponsService;

        public CouponsUpdateController(ICouponsService couponsService)
        {
            _couponsService = couponsService;
        }
    [HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] Cupon cupon)
{
    try
    {
        // Verifica si la campaña recibida es nula
        if (cupon == null)
        {
            // Devuelve un BadRequest si la campaña es nula
            return BadRequest("Campaña data is null");
        }

        // Verifica si el ID de la campaña coincide con el ID proporcionado en la ruta
        if (id != cupon.Id)
        {
            // Devuelve un BadRequest si el ID de la campaña no coincide con el ID en la ruta
            return BadRequest("ID mismatch between route parameter and cupon data");
        }

        var existingCoupon = _couponsService.GetById(id);
        if (existingCoupon == null)
        {
            // Devuelve un NotFound si el cupón no existe
            return NotFound($"Cupón with Id = {id} not found");
        }

        // Verifica si el cupón está redimido
        if (existingCoupon.IdRedimido != 0)
        {
            // Si el cupón está redimido, devuelve un BadRequest con el mensaje correspondiente
            return BadRequest("Los cupones entregados previamente no son válidos para nuevas transacciones");
        }

        // Actualiza el cupón
        _couponsService.update(cupon);

        // Devuelve un resultado Ok con un mensaje indicando que el cupón se ha actualizado correctamente
        return Ok("Cupón updated successfully");
    }
    catch (Exception ex)
    {
        // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
        return StatusCode(500, $"Error updating coupon: {ex.Message}");
    }
}
    }
}

