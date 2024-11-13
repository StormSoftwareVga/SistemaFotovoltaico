using AutoMapper;
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

            #endregion

            #region Domain -> Dto

            CreateMap<User, UserDto>();

            #endregion
        }
    }
}
