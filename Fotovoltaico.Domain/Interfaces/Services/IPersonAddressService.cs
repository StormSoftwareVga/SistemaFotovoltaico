using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;

namespace Fotovoltaico.Domain.Interfaces.Services
{
    public interface IPersonAddressService
    {
        List<PersonAddressDto> Get();
        PersonAddressDto GetById(string id);
        bool Post(PersonAddressDto personAdressDto);
        bool Put(PersonAddressDto personAdressDto);
        bool Delete(string id);

    }
}
