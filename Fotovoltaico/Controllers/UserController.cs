using Fotovoltaico.Domain.Entities.DataTransferObjects.User;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fotovoltaico.Api.Controllers
{
    [Route("api/[controller]"), ApiController/*, Authorize*/]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.userService.Post(userDto));
        }

        [HttpPost("autenticate"), AllowAnonymous]
        public IActionResult Autenticar(UserAuthenticateRequestDto userDto)
        {
            return Ok(this.userService.Authenticate(userDto));
        }

        [HttpPut]
        public IActionResult Put(UserDto userDto)
        {
            return Ok(this.userService.Put(userDto));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            var _idUsuario = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(this.userService.Delete(_idUsuario));
        }
    }
}
