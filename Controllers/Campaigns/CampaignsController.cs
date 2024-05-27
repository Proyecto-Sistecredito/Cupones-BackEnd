using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampañasService _campañasService;

        public CampaignsController(ICampañasService campañasService)
        {
            _campañasService = campañasService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Campaña>> GetCampaigns()
        {
            try
            {
                return Ok(_campañasService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

    }
}



