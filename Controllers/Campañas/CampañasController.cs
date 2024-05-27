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
    public class CampañasController : ControllerBase
    {
        public readonly ICampañasService _campañasService;

        public CampañasController(ICampañasService campañasService)
        {
            _campañasService = campañasService;
        }

        [HttpGet]
        [Route("api/campañas")]
        public IEnumerable<Campaña> GetCampaigns()
        {
            return _campañasService.GetAll();
        }

        [HttpGet]
        [Route("api/campañas/{id}")]
        public Campaña Details(int id)
        {
            return _campañasService.GetById(id);
        }

       
    }
}