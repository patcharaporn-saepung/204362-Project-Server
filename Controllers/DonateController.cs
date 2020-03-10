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
    public class DonateController : ControllerBase
    {
        private readonly DonateService _donateService;

        public DonateController(DonateService donateService)
        {
            _donateService = donateService;
        }

        [HttpGet("list")]
        public ActionResult<List<DonateList>> Get()
        {
            return _donateService.Get().Select(don => new DonateList
            {
                Id = don.Id,
                Title = don.Title,
                Creator = don.Creator,
                Accepted = don.Accepted
            }).ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetDonate")]
        public ActionResult<Donate> Get(string id)
        {
            var don = _donateService.Get(id);

            if (don == null)
            {
                return NotFound();
            }

            return don;
        }

        [HttpPost]
        public ActionResult<Donate> Create(Donate don)
        {
            _donateService.Create(don);

            return CreatedAtRoute("GetDonate", new { id = don.Id.ToString() }, don);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Donate donIn)
        {
            var don = _donateService.Get(id);

            if (don == null)
            {
                return NotFound();
            }

            _donateService.Update(id, donIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var don = _donateService.Get(id);

            if (don == null)
            {
                return NotFound();
            }

            _donateService.Remove(don);

            return NoContent();
        }
    }
}