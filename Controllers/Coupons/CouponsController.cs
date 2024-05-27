using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController] // Indica que esta clase es un controlador de API
    [Route("api/[controller]")] // Establece la ruta base para las acciones en este controlador
    public class CouponsController : ControllerBase // Deriva de ControllerBase para obtener funcionalidad de controlador sin vistas
    {
        private readonly ICuponesService _cuponesService; // Interfaz del servicio de cupones

        // Constructor que recibe una instancia del servicio de cupones
        public CouponsController(ICuponesService cuponesService)
        {
            _cuponesService = cuponesService; // Asigna el servicio de cupones al campo privado
        }

        // Método de acción HTTP GET que devuelve todos los cupones
        [HttpGet]
        public IActionResult GetCupons()
        {
            try
            {
                var cupons = _cuponesService.GetAll(); // Obtiene todos los cupones del servicio
                return Ok(cupons); // Devuelve un resultado Ok con los cupones recuperados
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
                return StatusCode(500, $"Error retrieving cupons: {ex.Message}");
            }
        }

        // Método de acción HTTP GET que devuelve un cupón específico según su ID
        [HttpGet("{id}")]
        public IActionResult GetCupon(int id)
        {
            try
            {
                var cupon = _cuponesService.GetById(id); // Obtiene el cupón con el ID especificado del servicio
                if (cupon == null)
                {
                    // Si el cupón no existe, devuelve un NotFound con un mensaje indicando que no se encontró el cupón
                    return NotFound($"Cupon with id {id} not found");
                }
                return Ok(cupon); // Devuelve un resultado Ok con el cupón recuperado
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
                return StatusCode(500, $"Error retrieving cupon with id {id}: {ex.Message}");
            }
        }
    }
}
