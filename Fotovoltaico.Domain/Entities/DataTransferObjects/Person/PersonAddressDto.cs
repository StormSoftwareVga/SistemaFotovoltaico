using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities.DataTransferObjects.Person
{
    public class PersonAddressDto : EntityDto
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
