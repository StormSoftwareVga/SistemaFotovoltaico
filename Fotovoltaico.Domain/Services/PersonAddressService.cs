using AutoMapper;
using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Services
{
    public class PersonAddressService : IPersonAddressService   
    {
        private readonly IPersonAddressRepository personAddressRepository;
        private readonly IMapper mapper;

        public PersonAddressService(IPersonAddressRepository personAddressRepository, IMapper mapper)
        {
            this.personAddressRepository = personAddressRepository;
            this.mapper = mapper;
        }

        public List<PersonAddressDto> Get()
        {
            IEnumerable<PersonAddress> personAddresses = this.personAddressRepository.GetAll();

            List<PersonAddressDto> personAddressesDto = mapper.Map<List<PersonAddressDto>>(personAddresses);

            return personAddressesDto;
        }

        public PersonAddressDto GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid personAddressId))
                throw new Exception("ID do endereço é inválido!");

            PersonAddress personAddress = this.personAddressRepository.Find(x => x.Id == personAddressId);

            if (null == personAddress)
                throw new Exception("Endereço não encontrado");

            return mapper.Map<PersonAddressDto>(personAddress);
        }

        public bool Post(PersonAddressDto personAddressesDto)
        {
            if (personAddressesDto.Id != Guid.Empty)
                throw new Exception("O ID da pessoa deve ser vazio!");

            Validator.ValidateObject(personAddressesDto, new ValidationContext(personAddressesDto), true);

            var personAddress = mapper.Map<PersonAddress>(personAddressesDto);

            this.personAddressRepository.Create(personAddress);

            return true;
        }

        public bool Put(PersonAddressDto personAddressDto)
        {
            if (personAddressDto.Id == Guid.Empty)
                throw new Exception("ID do endereço é inválido!");

            PersonAddress personAddress = this.personAddressRepository.Find(x => x.Id == personAddressDto.Id);

            if (null == personAddress)
                throw new Exception("Endereço não encontrado");

            personAddress = mapper.Map<PersonAddress>(personAddressDto);

            this.personAddressRepository.Update(personAddress);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid personAddressId))
                throw new Exception("ID do endereço é inválido!");

            PersonAddress personAddress = this.personAddressRepository.Find(x => x.Id == personAddressId);

            if (null == personAddress)
                throw new Exception("Endereço não encontrado");

            return this.personAddressRepository.Delete(personAddress);

        }
    }
}
