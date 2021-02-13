using Demo.Domain.Dtos;
using Demo.Domain.Entities;
using Demo.Infra.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        void Create(AppUser appUser);
        void Update(AppUser appUser);
        AppUser GetByUserId(int UserId);
        Task<List<UserDto>> GetAllAsync(AppUserParams appUserParams);
    }
}
