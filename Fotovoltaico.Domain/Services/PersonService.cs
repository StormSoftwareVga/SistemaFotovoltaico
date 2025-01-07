using AutoMapper;
using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Services
{
    public class PersonService : IPersonService   
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public List<PersonDto> Get()
        {
            IEnumerable<Person> people = this.personRepository.GetAll();

            List<PersonDto> peopleDto = mapper.Map<List<PersonDto>>(people);

            return peopleDto;
        }

        public PersonDto GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid personId))
                throw new Exception("ID da pessoa é inválido!");

            Person person = this.personRepository.Find(x => x.Id == personId);

            if (null == person)
                throw new Exception("Pessoa não encontrada");

            return mapper.Map<PersonDto>(person);
        }

        public bool Post(PersonDto personDto)
        {
            if (personDto.Id != Guid.Empty)
                throw new Exception("O ID da pessoa deve ser vazio!");

            Validator.ValidateObject(personDto, new ValidationContext(personDto), true);

            var person = mapper.Map<Person>(personDto);

            this.personRepository.Create(person);

            return true;
        }

        public bool Put(PersonDto personDto)
        {
            if (personDto.Id == Guid.Empty)
                throw new Exception("ID da pessoa é inválido!");

            Person person = this.personRepository.Find(x => x.Id == personDto.Id);

            if (null == person)
                throw new Exception("Pessoa não encontrada");

            person = mapper.Map<Person>(personDto);

            this.personRepository.Update(person);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid personId))
                throw new Exception("ID da pessoa é inválido!");

            Person person = this.personRepository.Find(x => x.Id == personId);

            if (null == person)
                throw new Exception("Pessoa não encontrada");

            return this.personRepository.Delete(person);

        }
    }
}
