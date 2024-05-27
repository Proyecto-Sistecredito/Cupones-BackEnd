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
    public class EmpresasSearchController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public EmpresasSearchController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }
  
    }
}

