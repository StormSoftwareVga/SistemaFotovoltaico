using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.Person
{
    public class PersonDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public int DocumentType { get; set; } // 0: CPF, 1: CNPJ, 2: RG
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
