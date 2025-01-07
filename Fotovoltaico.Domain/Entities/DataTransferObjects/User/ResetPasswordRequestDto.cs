using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class ResetPasswordRequestDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required]
        public string RecoveryCode { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
