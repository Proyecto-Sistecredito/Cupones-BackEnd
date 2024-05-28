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
    public class RedeemController : ControllerBase
    {
        public readonly IRedeemService _RedeemService;

        public RedeemController(IRedeemService RedeemService)
        {
            _RedeemService = RedeemService;
        }

        [HttpGet("{id}")]
        public IActionResult Redeem(int id)
        {
            try
            {
                var purchase = _RedeemService.GetPurchase(id);
                
                if (purchase == null)
                {
                    return NotFound($"Purchase with Id = {id} not found");
                }

                var coupon = _RedeemService.GetCoupon(purchase.IdCupon);
                
                if (coupon == null)
                {
                    return NotFound($"Coupon with Id = {purchase.IdCupon} not found");
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

                if (coupon.IdTipoCupon == 3)
                {
                    try
                    {
                        var porcentaje = double.Parse(coupon.Valor) / 100.0;
                        var descuento = purchase.ValorCompra * porcentaje;
                        var cuponAplicado = purchase.ValorCompra - descuento;

                        _RedeemService.Redeem(coupon);
                        return Ok($"El cupón {coupon.Nombre} se ha aplicado correctamente quedando tu compra en ${cuponAplicado}");
                    } catch (Exception ex)
                    {
                        return StatusCode(500, $"Error al aplicar descuento a la compra: {ex.Message}");
                    }
                }

                return Ok(coupon);
                // return Ok($"El cupón {coupon.Nombre} con el código {coupon.Codigo} se ha redimido correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error coupon with id {id}: {ex.Message}");
            }
        }
    }
}