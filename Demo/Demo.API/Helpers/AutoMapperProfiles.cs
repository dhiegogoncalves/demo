using AutoMapper;
using Demo.API.Dtos;
using Demo.Domain.Dtos;
using Demo.Domain.Entities;
using Demo.Shared.Entities;
using System.Collections.Generic;

namespace Demo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<AppUser, UserDto>();
        }
    }
}
