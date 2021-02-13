using Flunt.Notifications;

namespace Demo.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; set; }
    }
}
