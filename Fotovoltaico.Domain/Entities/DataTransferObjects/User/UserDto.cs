using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class UserDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
