using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public string Status { get; set; }
        //public byte TentativasLogin { get; set; }
        //public DateTime? LastAcessDate { get; set; }
        //public string RecoveryToken { get; set; }
        //public string ProfileImage { get; set; }
    }
}
