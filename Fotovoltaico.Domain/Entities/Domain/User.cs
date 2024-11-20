using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public bool IsVerified { get; set; } = false;
        public string? RecoveryCode { get; set; }
        public DateTime? RecoveryCodeGeneratedAt { get; set; }
        public bool PasswordReset { get; set; } = false; 
    }
}
