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
    public class companiesController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public companiesController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }
    [HttpGet]
        [Route("api/users")]
        public IEnumerable<Empresa> Getempresa()
        {
            return _empresasService.GetAll();
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public Empresa Details(int id)
        {
            return _empresasService.GetById(id);
        }

       
    }
}

