using Demo.Shared.Entities;

namespace Demo.API.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
