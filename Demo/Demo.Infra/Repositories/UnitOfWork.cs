using AutoMapper;
using Demo.Domain.Repositories.Interfaces;
using Demo.Infra.Contexts;
using System.Threading.Tasks;

namespace Demo.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IAppUserRepository AppUserRepository => new AppUserRepository(_context, _mapper);

        public IAddressRepository AddressRepository => new AddressRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
