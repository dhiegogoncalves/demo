using Demo.Domain.Entities;
using System.Collections.Generic;

namespace Demo.Domain.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        void Create(Address address);
        void Update(Address address);
        Address GetById(int id);
        IEnumerable<Address> GetAllByAppUserId(int AppUserId);
    }
}
