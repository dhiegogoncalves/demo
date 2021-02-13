using Demo.API.Dtos;
using Demo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<GenericResultDto> Register(RegisterDto registerDto);

        Task<GenericResultDto> Login(LoginDto loginDto);
    }
}
