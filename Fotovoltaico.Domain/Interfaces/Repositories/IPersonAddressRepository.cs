using Fotovoltaico.Domain.Entities.Domain;

namespace Fotovoltaico.Domain.Interfaces.Repositories
{
    public interface IPersonAddressRepository :IUnitOfWork<PersonAddress>
    {
        IEnumerable<PersonAddress> GetAll();
    }
}
