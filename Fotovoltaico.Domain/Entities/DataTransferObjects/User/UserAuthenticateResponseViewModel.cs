namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UserDto usuario, string token)
        {
            this.User = usuario;
            this.Token = token;
        }

        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
