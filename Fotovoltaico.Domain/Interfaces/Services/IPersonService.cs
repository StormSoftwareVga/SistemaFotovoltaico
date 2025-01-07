using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;

namespace Fotovoltaico.Domain.Interfaces.Services
{
    public interface IPersonService
    {
        List<PersonDto> Get();
        PersonDto GetById(string id);
        bool Post(PersonDto personDto);
        bool Put(PersonDto personDto);
        bool Delete(string id);

    }
}
