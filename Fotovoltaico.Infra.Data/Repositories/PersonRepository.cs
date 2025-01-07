using FinancialVariation.Data.UnitOfWork;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Infra.Data.Context;

namespace Fotovoltaico.Infra.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Person> GetAll()
        {
            return Query(x => x != null);
        }
    }
}
