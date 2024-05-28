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
        public readonly IEmpresasService _empresasService;

        public CompaniesCreateController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
          }
[HttpPost]
        [Route("api/empresas")]
        public IActionResult Create([FromBody] Empresa empresa)
        {
            try{
                if(empresa == null){
                    return BadRequest("Cupon data is null");
                }
                _empresasService.add(empresa);
                return Ok(empresa);
            }
            catch(Exception ex){
                return StatusCode(500, $"Error creating campaign: {ex.Message}");
            }
         
        }
    
    }
}