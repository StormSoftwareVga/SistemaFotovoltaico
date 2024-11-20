using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class VerifyCodeRequestDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O código de verificação é obrigatório.")]
        public string VerificationCode { get; set; }
    }
}
