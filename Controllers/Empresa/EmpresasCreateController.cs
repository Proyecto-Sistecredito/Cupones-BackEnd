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
  public class EmpresasCreateController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public EmpresasCreateController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
          }

    
    }
}