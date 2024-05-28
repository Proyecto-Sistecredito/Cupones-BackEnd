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
    public class CompaniesCreateController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesCreateController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Empresa empresa)
        {
            try
            {
                // Verifica si la empresa recibida es nula
                if (empresa == null)
                {
                    // Devuelve un BadRequest si la empresa es nula
                    return BadRequest("Empresa data is null");
                }

                // Agrega la nueva empresa
                _companiesService.add(empresa);

                // Devuelve un resultado Ok con la empresa creada
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
                return StatusCode(500, $"Error creating company: {ex.Message}");
            }
        }
    }
}
