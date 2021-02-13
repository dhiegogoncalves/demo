using System.Threading.Tasks;

namespace Demo.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }
        IAddressRepository AddressRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
