namespace Fotovoltaico.Domain.Entities.Domain
{
    public class PersonAddress : Entity
    {
        public Guid PersonId { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }

        public Person Person { get; set; }
    }
}
