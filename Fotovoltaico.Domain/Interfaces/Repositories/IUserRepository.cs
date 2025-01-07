using Fotovoltaico.Domain.Entities.Domain;

namespace Fotovoltaico.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IUnitOfWork<User>
    {
        IEnumerable<User> GetAll();
    }
}
