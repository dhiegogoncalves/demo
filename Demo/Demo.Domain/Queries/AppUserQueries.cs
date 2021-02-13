using Demo.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Demo.Domain.Queries
{
    public static class AppUserQueries
    {
        public static Expression<Func<AppUser, bool>> GetById(int userId)
        {
            return x => x.UserId == userId;
        }
    }
}
