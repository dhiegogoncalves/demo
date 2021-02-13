using Demo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Demo.Domain.Commands
{
    public class CreateAppUserCommand : Notifiable, ICommand
    {
        public CreateAppUserCommand()
        {
        }

        public CreateAppUserCommand(string username, string fullname, string email, int userId)
        {
            Username = username;
            Fullname = fullname;
            Email = email;
            UserId = userId;
        }

        public string Username { get;  set; }

        public string Fullname { get;  set; }

        public string Email { get;  set; }

        public int UserId { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Username, 3, "Username", "Usuário deve conter pelo menos 3 caracteres")
                    .HasMinLen(Fullname, 5, "Fullname", "Nome Completo deve conter pelo menos 5 caracteres")
                    .IsEmail(Email, "Email", "E-mail inválido")
            );
        }
    }
}
