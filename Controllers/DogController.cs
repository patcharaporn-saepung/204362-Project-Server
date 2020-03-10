using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MheanMaa.Models;
using MheanMaa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MheanMaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;

        public DogController(DogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet("list")]
        public ActionResult<List<DogList>> Get()
        {
            return _dogService.Get().Select(dog => new DogList
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                AgeUnit = dog.AgeUnit,
                Sex = dog.Sex,
                Description = dog.Description,
                IsAlive = dog.IsAlive,
                CollarColor = dog.CollarColor,
                Caretaker = dog.Caretaker
            }).ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetDog")]
        public ActionResult<Dog> Get(string id)
        {
            var dog = _dogService.Get(id);

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        [HttpPost]
        public ActionResult<Dog> Create(Dog dog)
        {
            _dogService.Create(dog);

            return CreatedAtRoute("GetDog", new { id = dog.Id.ToString() }, dog);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Dog dogIn)
        {
            var dog = _dogService.Get(id);

            if (dog == null)
            {
                return NotFound();
            }

            _dogService.Update(id, dogIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var dog = _dogService.Get(id);

            if (dog == null)
            {
                return NotFound();
            }

            _dogService.Remove(dog);

            return NoContent();
        }

    }
}