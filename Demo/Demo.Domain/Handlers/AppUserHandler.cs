using Demo.Domain.Commands;
using Demo.Domain.Commands.Interfaces;
using Demo.Domain.Entities;
using Demo.Domain.Handlers.Interfaces;
using Demo.Domain.Repositories.Interfaces;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace Demo.Domain.Handlers
{
    public class AppUserHandler : Notifiable, IHandler<CreateAppUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(CreateAppUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possível criar conta", command.Notifications);

            var appUser = new AppUser(command.Username, command.Fullname, command.Email, command.UserId);

            _unitOfWork.AppUserRepository.Create(appUser);

            if (await _unitOfWork.Complete()) return new GenericCommandResult(true, "Conta criada com sucesso", null);

            return new GenericCommandResult(false, "Não foi possível criar conta", null);
        }
    }
}
