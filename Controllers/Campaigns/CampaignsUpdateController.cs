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
    public class CampaignsUpdateController : ControllerBase
    {
        public readonly ICampañasService _campañasService;

        public CampaignsUpdateController(ICampañasService campañasService)
        {
            _campañasService = campañasService;
        }

        [HttpPut("{id}")]
        [Route("api/campañas/{id}/update")]
        public string Update(int id, [FromBody] Campaña campaña)
        {
            return "Falta actualizar";
        }
    }
}