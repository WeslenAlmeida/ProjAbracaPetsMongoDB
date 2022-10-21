using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAbracaPetsMongoDB.Models;
using ProjAbracaPetsMongoDB.Services;
using System.Collections.Generic;

namespace ProjAbracaPetsMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterController : ControllerBase
    {
        private readonly AdopterService _adopterService;

        public AdopterController(AdopterService adopterServices)
        {
            _adopterService = adopterServices;
        }

        [HttpGet]
        public ActionResult<List<Adopter>> Get() => _adopterService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAdopter")]
        public ActionResult<Adopter> Get(string id)
        {
            var adopter = _adopterService.Get(id);

            if (adopter == null)
                return NotFound();

            return Ok(adopter);
        }

        [HttpPost]
        public ActionResult<Adopter> Create(Adopter adopter)
        {
            _adopterService.Create(adopter);
            return CreatedAtRoute("GetAdopter", new { id = adopter.Id.ToString() }, adopter);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Adopter adopterIn)
        {
            var adopter = _adopterService.Get(id);

            if (adopter == null)
            {
                return NotFound();
            }

            adopterIn.Id = id;

            _adopterService.Update(id, adopterIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var adopter = _adopterService.Get(id);

            if (adopter == null)
            {
                return NotFound();
            }

            _adopterService.Remove(id);

            return NoContent();
        }
    }
}
