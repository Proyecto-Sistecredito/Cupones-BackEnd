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
    public class companiesSearchController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public companiesSearchController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }
   [HttpGet]
        [Route("api/users/search/{consulta}")]
        public IEnumerable<Empresa> Search(string consulta)
        {
            return _empresasService.Search(consulta);
        }
    }
}

