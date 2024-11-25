using Fotovoltaico.Domain.Entities.Domain;

namespace Fotovoltaico.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IUnitOfWork<Person>
    {
        IEnumerable<Person> GetAll();
    }
}
