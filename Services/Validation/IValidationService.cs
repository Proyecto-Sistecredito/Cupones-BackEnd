using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;

namespace Cupones.Services
{
    public interface IValidationService
    {
        Cupon GetById(int id);
    }
}