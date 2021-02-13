using AutoMapper;
using Demo.API.Dtos;
using Demo.API.Extensions;
using Demo.API.Services.Interfaces;
using Demo.Domain.Dtos;
using Demo.Domain.Entities;
using Demo.Domain.Repositories.Interfaces;
using Demo.Infra.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[Authorize]
        [Route("users")]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllAsync([FromQuery] AppUserParams userParams)
        {
            var result = (PagedList<UserDto>) await _unitOfWork.AppUserRepository.GetAllAsync(userParams);

            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);

            return result;
        }

        //[Authorize]
        [Route("users/{id}")]
        [HttpGet]
        public UserDto GetByUserId(int id)
        {
            var result = _unitOfWork.AppUserRepository.GetByUserId(id);
            return _mapper.Map<UserDto>(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<TokenDto>> Register(RegisterDto registerDto)
        {
            var genericResultDto = await _accountService.Register(registerDto);

            if (genericResultDto.Success)
            {
                return Ok(genericResultDto);
            }
            return BadRequest(genericResultDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            var genericResultDto = await _accountService.Login(loginDto);

            if (genericResultDto.Success)
            {
                return Ok(genericResultDto);
            }
            return BadRequest(genericResultDto);
        }
    }
}
