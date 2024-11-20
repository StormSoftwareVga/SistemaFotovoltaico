namespace Fotovoltaico.Domain.Entities
{
    public class EntityDto
    {
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public DateTime? ChangeDate { get; set; }
    }
}
