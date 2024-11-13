using AutoMapper;
using Fotovoltaico.Domain.Entities.DataTransferObjects.User;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Fotovoltaico.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository usuarioRepository, IMapper mapper)
        {
            this.userRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<UserDto> Get()
        {
            IEnumerable<User> users = this.userRepository.GetAll();

            List<UserDto> usersDto = mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public UserDto GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("ID do usuário é inválido!");

            User user = this.userRepository.Find(x => x.Id == userId);

            if (null == user)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UserDto>(user);
        }

        public bool Post(UserDto userDto)
        {
            if (userDto.Id != Guid.Empty)
                throw new Exception("ID do usuário deve ser vazio!");

            Validator.ValidateObject(userDto, new ValidationContext(userDto), true);

            var user = mapper.Map<User>(userDto);

            this.userRepository.Create(user);

            return true;
        }

        public bool Put(UserDto userDto)
        {
            if (userDto.Id == Guid.Empty)
                throw new Exception("ID do usuário é inválido!");

            User user = this.userRepository.Find(x => x.Id == userDto.Id);

            if (null == user)
                throw new Exception("Usuário não encontrado");

            user = mapper.Map<User>(userDto);

            this.userRepository.Update(user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("ID do usuário é inválido!");

            User user = this.userRepository.Find(x => x.Id == userId);

            if (null == user)
                throw new Exception("Usuário não encontrado");

            return this.userRepository.Delete(user);

        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
                throw new Exception("Os campos E-mail e Senha são obrigatórios!");

            User user = this.userRepository.Find(x => x.Email.ToLower() == userDto.Email.ToLower() && x.Password == userDto.Password);

            if (null == user)
                throw new Exception("Usuário não encontrado");

            return new UserAuthenticateResponseViewModel(mapper.Map<UserDto>(user), TokenService.GenerateToken(user));
        }
    }
}
