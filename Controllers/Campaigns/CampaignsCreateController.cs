using System;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/Campaigns/Create")]
    public class CampaignsCreateController : ControllerBase
    {
        private readonly ICampaignsService _campaignsService;

        public CampaignsCreateController(ICampaignsService campaignsService)
        {
            _campaignsService = campaignsService;
        }

        [HttpPost]
        public IActionResult Create(Campaña campaña)
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
                _campaignsService.add(campaña);

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
