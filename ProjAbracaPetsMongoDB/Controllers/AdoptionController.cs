using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAbracaPetsMongoDB.Models;
using ProjAbracaPetsMongoDB.Services;
using System.Collections.Generic;
using System.Net;

namespace ProjAbracaPetsMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionController : ControllerBase
    {
        private readonly AdoptionService _adoptionServices;
        private readonly AdopterService _adopterServices;
        private readonly AnimalService _animalServices;

        public AdoptionController(AdopterService adopterService, AdoptionService adoptionService, AnimalService animalService)
        {
            _adopterServices = adopterService;
            _animalServices = animalService;    
            _adoptionServices = adoptionService;    
        }

        [HttpGet]
        public ActionResult<List<Adoption>> Get() => _adoptionServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetAdoption")]
        public ActionResult<Adoption> Get(string id)
        {
            var adoption = _adoptionServices.Get(id);

            if (adoption == null)
                return NotFound();

            return Ok(adoption);
        }

        [HttpPost("{idAdopter:length(24)}/{idAnimal:length(24)}")]
        public ActionResult<Adoption> Create(string idAdopter, string idAnimal, Adoption adoption)
        {
            adoption.AdopterId = _adopterServices.Get(idAdopter).Id;
            adoption.AnimalId = _animalServices.Get(idAnimal).Id;
            adoption.DataAdocao = System.DateTime.Now.ToString("yyyy-MM-dd");  

            _adoptionServices.Create(adoption);
            return CreatedAtRoute("GetAdoption", new { id = adoption.Id.ToString() }, adoption);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Adoption adoptionIn)
        {
            var adoption = _adoptionServices.Get(id);

            if (adoption == null)
            {
                return NotFound();
            }

            adoptionIn.Id = id;

            _adoptionServices.Update(id, adoptionIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var adoption = _adoptionServices.Get(id);

            if (adoption == null)
            {
                return NotFound();
            }

            _adoptionServices.Remove(id);

            return NoContent();
        }
    }
}
