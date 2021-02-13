using AutoMapper;
using Demo.API.Dtos;
using Demo.API.Services.Interfaces;
using Demo.Domain.Commands;
using Demo.Domain.Handlers;
using Demo.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Demo.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly AppUserHandler _handler;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper, AppUserHandler handler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _handler = handler;
        }

        public async Task<GenericResultDto> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return new GenericResultDto(false, "Nome de usuário está indisponível");

            var user = _mapper.Map<User>(registerDto);

            user.UserName = registerDto.Username.ToLower();
            user.Active = true;

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return new GenericResultDto(false, "Erro ao tentar salvar o usuário", null);

            //var roleResult = await _userManager.AddToRoleAsync(user, "USUARIO");
            //if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var createAppUserCommand = new CreateAppUserCommand(registerDto.Username, registerDto.Fullname, registerDto.Email, user.Id);
            var commandResult = (GenericCommandResult)await _handler.Handle(createAppUserCommand);

            if (commandResult.Success)
            {
                var tokenDto = new TokenDto { Token = _tokenService.CreateToken(user) };
                return new GenericResultDto(true, "Conta criada com sucesso", tokenDto);
            }

            return new GenericResultDto(commandResult.Success, commandResult.Message, commandResult.Data);
        }

        public async Task<GenericResultDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return new GenericResultDto(false, "Usuário ou Senha inválido");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return new GenericResultDto(false, "Usuário ou Senha inválido");

            var tokenDto = new TokenDto { Token = _tokenService.CreateToken(user) };

            return new GenericResultDto(true, "Conta criada com sucesso", tokenDto);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }    
}
