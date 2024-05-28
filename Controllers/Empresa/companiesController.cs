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
    public class CompaniesController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public CompaniesController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }
    [HttpGet]
     
        public ActionResult<IEnumerable<Empresa>> Getempresa()
        {
             try
    {
        var company = _empresasService.GetAll(); // Obtiene todos los cupones del servicio
        return Ok(company); // Devuelve un resultado Ok con los cupones recuperados
    }
    catch (Exception ex)
    {
        // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
        return StatusCode(500, $"Error al recuperar los cupones: {ex.Message}");
    }
        }

               [HttpGet("{id}")]
        public IActionResult GetCupon(int id)
        {
            try
            {
                var company = _empresasService.GetById(id); // Obtiene el cupón con el ID especificado del servicio
                if (company == null)
                {
                    // Si el cupón no existe, devuelve un NotFound con un mensaje indicando que no se encontró el cupón
                    return NotFound($"Cupon with id {id} not found");
                }
                return Ok(company); // Devuelve un resultado Ok con el cupón recuperado
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
                return StatusCode(500, $"Error retrieving cupon with id {id}: {ex.Message}");
            }
        }
       
    }
}

