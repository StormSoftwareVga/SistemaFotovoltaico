using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class UserAuthenticateRequestDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
