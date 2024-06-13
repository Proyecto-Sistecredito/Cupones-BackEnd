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
        private readonly ICampaignsService _campaignsService;

        public CampaignsController(ICampaignsService campaignsService)
        {
            _campaignsService = campaignsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Campaña>> GetCampaigns()
        {
            try
            {
                return Ok(_campaignsService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCampaign(int id)
        {
            try
            {
                var campaign = _campaignsService.GetById(id);
                
                if (campaign == null)
                {
                    return NotFound($"Campaign with Id = {id} not found");
                }
                return Ok(campaign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving campaign with id {id}: {ex.Message}");
            }
        }
    }
}
