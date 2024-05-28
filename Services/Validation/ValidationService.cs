using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupones.Models;
using Cupones.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public class ValidationService : IValidationService
    {
        private readonly CuponesContext _context;

        public ValidationService (CuponesContext context)
        {
            _context = context;
        }

        public Cupon GetById(int id)
        {
            return _context.Cupones.Find(id);
        }
    }
}