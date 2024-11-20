using Fotovoltaico.Domain.Entities.DataTransferObjects.User;
using Fotovoltaico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.userService.Delete(id));
        }

        [HttpPost("verify"), AllowAnonymous]
        public IActionResult VerifyCode([FromBody] VerifyCodeRequestDto verifyCodeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = userService.VerifyUserAccount(verifyCodeRequest.Email, verifyCodeRequest.VerificationCode);
                return Ok(new { Message = "Conta ativada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("recover-password"), AllowAnonymous]
        public IActionResult RecoverPassword([FromBody] SendRecoveryCodeDto sendRecovery)
        {
            try
            {
                var result = userService.RecoverPassword(sendRecovery.Email);
                return Ok(new { Message = "Código de recuperação enviado para o e-mail!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("reset-password"), AllowAnonymous]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequestDto resetPasswordRequest)
        {
            if (string.IsNullOrEmpty(resetPasswordRequest.Email) || string.IsNullOrEmpty(resetPasswordRequest.RecoveryCode) || string.IsNullOrEmpty(resetPasswordRequest.NewPassword))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            try
            {
                var result = userService.ResetPassword(resetPasswordRequest.Email, resetPasswordRequest.RecoveryCode, resetPasswordRequest.NewPassword);
                return Ok(new { Message = "Senha redefinida com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    }
}
