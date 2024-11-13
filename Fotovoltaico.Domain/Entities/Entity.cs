using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public DateTime? ChangeDate { get; set; }
    }
}
