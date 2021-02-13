using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Domain.Dtos;
using Demo.Domain.Entities;
using Demo.Domain.Queries;
using Demo.Domain.Repositories.Interfaces;
using Demo.Infra.Contexts;
using Demo.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Infra.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AppUserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
        }

        public async Task<List<UserDto>> GetAllAsync(AppUserParams appUserParams)
        {
            var query = _context.AppUsers.AsQueryable();

            query = appUserParams.OrderBy switch
            {
                "dataCreated" => query.OrderByDescending(x => x.DateCreated),
                _ => query.OrderBy(x => x.Username)
            };

            return await PagedList<UserDto>.CrateAsync(
                query.ProjectTo<UserDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                appUserParams.PageNumber, appUserParams.PageSize);
        }

        public AppUser GetByUserId(int userId)
        {
            return _context.AppUsers.AsNoTracking().FirstOrDefault(AppUserQueries.GetById(userId));
        }

        public void Update(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
