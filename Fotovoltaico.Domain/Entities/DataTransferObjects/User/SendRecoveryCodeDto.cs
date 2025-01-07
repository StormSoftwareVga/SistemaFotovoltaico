using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class SendRecoveryCodeDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
    }
}
