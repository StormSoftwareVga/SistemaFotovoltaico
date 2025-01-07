using FinancialVariation.Data.UnitOfWork;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Infra.Data.Context;

namespace Fotovoltaico.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAll()
        {
            return Query(x => x != null);
        }
    }
}
