using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;
using Cupones.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public class RedeemService : IRedeemService
    {
        private readonly CuponesContext _context;

        public RedeemService (CuponesContext context)
        {
            _context = context;
        }

        public Cupon GetCoupon(int id)
        {
            return _context.Cupones.Find(id);
        }

        public Compra GetPurchase (int id)
        {
            return _context.Compras.Find(id);
        }

        public void Redeem(Cupon coupon)
        {
            coupon.UsosDisponibles--;
            coupon.IdRedimido = 1;

            if (coupon.UsosDisponibles == 0)
            {
                coupon.IdEstado = 2;
            }
            
            _context.Cupones.Update(coupon);
            _context.SaveChanges();
        }
    }
}