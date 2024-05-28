using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;

namespace Cupones.Services
{
    public interface IRedeemService
    {
        Cupon GetCoupon(int id);
        Compra GetPurchase(int id);
        void Redeem(Cupon cupon);
    }
}