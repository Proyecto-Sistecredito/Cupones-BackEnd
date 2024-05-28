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
    public class CompaniesUpdateController : ControllerBase
    {
        public readonly ICompaniesService _companiesService;

        public CompaniesUpdateController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Empresa empresa)
        {
            try
            {
                // Verifica si la campaña recibida es nula
                if (empresa == null)
                {
                    // Devuelve un BadRequest si la campaña es nula
                    return BadRequest("Campaña data is null");
                }

                // Verifica si el ID de la campaña coincide con el ID proporcionado en la ruta
                if (id != empresa.Id)
                {
                    // Devuelve un BadRequest si el ID de la campaña no coincide con el ID en la ruta
                    return BadRequest("ID mismatch between route parameter and cupon data");
                }

                var existingCampaign = _companiesService.GetById(id);
                if (existingCampaign == null)
                {
                    // Devuelve un NotFound si la campaña no existe
                    return NotFound($"Campaign with Id = {id} not found");
                }

                // Actualiza la campaña
                _companiesService.update(empresa);

                // Devuelve un resultado Ok con un mensaje indicando que la campaña se ha actualizado correctamente
                return Ok("Campaign updated successfully");
            }
            catch (Exception ex)
            {
                // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
                return StatusCode(500, $"Error updating campaign: {ex.Message}");
            }
        }
    }
}