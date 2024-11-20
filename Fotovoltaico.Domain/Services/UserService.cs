using AutoMapper;
using Fotovoltaico.Domain.Entities.DataTransferObjects.User;
using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

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

            var verificationCode = new Random().Next(100000, 999999).ToString();
            user.VerificationCode = verificationCode;

            this.userRepository.Create(user);

            SendVerificationCode(user.Email, verificationCode);

            return true;
        }

        private void SendVerificationCode(string email, string verificationCode)
        {
            var smtpClient = new SmtpClient("smtp.hostinger.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("desenvolvimento@stormsoftware.com.br", "St0rm$0ftw@r&321"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("desenvolvimento@stormsoftware.com.br"),
                Subject = "Código de Verificação",
                Body = $"Seu código de verificação é: {verificationCode}, você possui 30 minutos para utilizar antes que o código expire",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            smtpClient.Send(mailMessage);
        }

        public bool VerifyUserAccount(string email, string verificationCode)
        {
            var user = userRepository.Find(x => x.Email == email);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            if (user.VerificationCode != verificationCode)
                throw new Exception("Código de verificação inválido.");

            if (user.InclusionDate.AddMinutes(30) < DateTime.UtcNow)
                throw new Exception("O código de verificação expirou.");

            user.IsVerified = true;
            userRepository.Update(user);

            return true;
        }

        public bool RecoverPassword(string email)
        {
            var user = userRepository.Find(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var recoveryCode = new Random().Next(100000, 999999).ToString();
            user.RecoveryCode = recoveryCode;
            user.RecoveryCodeGeneratedAt = DateTime.UtcNow;

            userRepository.Update(user);

            // Enviar código de recuperação por e-mail
            SendRecoveryCode(user.Email, recoveryCode);

            return true;
        }

        private void SendRecoveryCode(string email, string recoveryCode)
        {
            var smtpClient = new SmtpClient("smtp.hostinger.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("desenvolvimento@stormsoftware.com.br", "St0rm$0ftw@r&321"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("desenvolvimento@stormsoftware.com.br"),
                Subject = "Recuperação de Senha",
                Body = $"Seu código de recuperação é: {recoveryCode}, você possui 30 minutos para utilizá-lo antes que o código expire.",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            smtpClient.Send(mailMessage);
        }

        public bool ResetPassword(string email, string recoveryCode, string newPassword)
        {
            var user = userRepository.Find(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            if (user.RecoveryCode != recoveryCode)
                throw new Exception("Código de recuperação inválido.");

            if (user.RecoveryCodeGeneratedAt.HasValue && user.RecoveryCodeGeneratedAt.Value.AddMinutes(30) < DateTime.UtcNow)
                throw new Exception("O código de recuperação expirou.");

            user.Password = newPassword;
            user.RecoveryCode = null; // Limpa o código de recuperação
            user.RecoveryCodeGeneratedAt = null;

            userRepository.Update(user);

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
