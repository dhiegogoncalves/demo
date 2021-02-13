using Demo.Domain.Commands.Interfaces;
using System.Threading.Tasks;

namespace Demo.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
