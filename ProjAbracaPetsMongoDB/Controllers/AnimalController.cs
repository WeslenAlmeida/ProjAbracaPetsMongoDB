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
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalServices)
        {
            _animalService = animalServices;
        }

        [HttpGet]
        public ActionResult<List<Animal>> Get() => _animalService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAnimal")]
        public ActionResult<Animal> Get(string id)
        {
            var animal = _animalService.Get(id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> Create(Animal animal)
        {
            _animalService.Create(animal);
            return CreatedAtRoute("GetAnimal", new { id = animal.Id.ToString() }, animal);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Animal animalIn)
        {
            var animal = _animalService.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            animalIn.Id = id;

            _animalService.Update(id, animalIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var animal = _animalService.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            _animalService.Remove(id);

            return NoContent();
        }
    }
}
