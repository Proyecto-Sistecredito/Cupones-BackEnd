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
  public class EmpresasUpdateController : ControllerBase
  {
    public readonly IEmpresasService _empresasService;

    public EmpresasUpdateController(IEmpresasService empresasService)
    {
      _empresasService = empresasService;
    }

    [HttpPut("{id}")]
    [Route("api/empresas/{id}/update")]
    public string Update(int id, [FromBody] Empresa empresa)
    {
      return "Falta actualizar";
    }
  }
}