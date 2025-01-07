using FinancialVariation.Data.UnitOfWork;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Infra.Data.Context;

namespace Fotovoltaico.Infra.Data.Repositories
{
    public class PersonAddressRepository : Repository<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<PersonAddress> GetAll()
        {
            return Query(x => x != null);
        }
    }
}
