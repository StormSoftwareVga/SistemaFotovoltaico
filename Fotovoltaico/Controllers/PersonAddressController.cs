using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fotovoltaico.Api.Controllers
{
    [Route("api/[controller]"), ApiController/*, Authorize*/]
    public class PersonAddressController : ControllerBase
    {
        private readonly IPersonAddressService personAdressService;

        public PersonAddressController(IPersonAddressService personAdressService)
        {
            this.personAdressService = personAdressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personAdressService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.personAdressService.GetById(id));
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(PersonAddressDto personAdressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.personAdressService.Post(personAdressDto));
        }

        [HttpPut]
        public IActionResult Put(PersonAddressDto personAdressDto)
        {
            return Ok(this.personAdressService.Put(personAdressDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.personAdressService.Delete(id));
        }
    }
}
