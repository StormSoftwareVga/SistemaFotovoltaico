using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fotovoltaico.Api.Controllers
{
    [Route("api/[controller]"), ApiController/*, Authorize*/]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.personService.GetById(id));
        }

        [HttpPost, AllowAnonymous, IgnoreAntiforgeryToken]
        public IActionResult Post([FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.personService.Post(personDto));
        }

        [HttpPut,IgnoreAntiforgeryToken]
        public IActionResult Put([FromBody] PersonDto personDto)
        {
            return Ok(this.personService.Put(personDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.personService.Delete(id));
        }
    }
}
