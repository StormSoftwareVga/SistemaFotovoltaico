using AutoMapper;
using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Entities.DataTransferObjects.User;
using Fotovoltaico.Domain.Entities.Domain;

namespace Fotovoltaico.Domain.Mappers
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region Dto -> Domain

            CreateMap<UserDto, User>();
            CreateMap<PersonDto, Person>();
            CreateMap<PersonAddressDto, PersonAddress>();

            #endregion

            #region Domain -> Dto

            CreateMap<User, UserDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<PersonAddress, PersonAddressDto>();

            #endregion
        }
    }
}
