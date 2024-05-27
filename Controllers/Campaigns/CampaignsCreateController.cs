using System;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsCreateController : ControllerBase
    {
        private readonly ICampañasService _campañasService;

        public CampaignsCreateController(ICampañasService campañasService)
        {
            _campañasService = campañasService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Campaña campaña)
        {
            try
            {
                // Verifica si la campaña recibida es nula
                if (campaña == null)
                {
                    // Devuelve un BadRequest si la campaña es nula
                    return BadRequest("Campaña data is null");
                }

                // Agrega la nueva campaña
                _campañasService.add(campaña);

                // Devuelve un resultado Ok con la campaña creada
                return Ok(campaña);
            }
            catch (Exception ex)
            {
                // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
                return StatusCode(500, $"Error creating campaign: {ex.Message}");
            }
        }
    }
}
