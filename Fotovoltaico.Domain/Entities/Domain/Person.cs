namespace Fotovoltaico.Domain.Entities.Domain
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public int DocumentType { get; set; } // 0: CPF, 1: CNPJ, 2: RG
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public ICollection<PersonAddress> Addresses { get; set; }
    }
}
