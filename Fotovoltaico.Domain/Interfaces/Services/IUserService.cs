﻿using Fotovoltaico.Domain.Entities.DataTransferObjects.User;

namespace Fotovoltaico.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDto> Get();
        UserDto GetById(string id);
        bool Post(UserDto userDto);
        bool Put(UserDto userDto);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestDto user);
        bool VerifyUserAccount(string email, string verificationCode);
        bool RecoverPassword(string email);
        bool ResetPassword(string email, string recoveryCode, string newPassword);
    }
}
