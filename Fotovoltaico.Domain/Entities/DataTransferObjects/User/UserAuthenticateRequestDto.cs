namespace Fotovoltaico.Domain.Entities.DataTransferObjects.User
{
    public class UserAuthenticateRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
