using Demo.Domain.Entities;
using Demo.Domain.Repositories.Interfaces;
using Demo.Infra.Contexts;
using System;
using System.Collections.Generic;

namespace Demo.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Address address)
        {
            _context.Addresses.Add(address);
        }

        public IEnumerable<Address> GetAllByAppUserId(int AppUserId)
        {
            throw new NotImplementedException();
        }

        public Address GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
