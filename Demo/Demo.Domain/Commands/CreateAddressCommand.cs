using Demo.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Demo.Domain.Commands
{
    public class CreateAddressCommand : Notifiable, ICommand
    {
        public CreateAddressCommand()
        {
        }

        public CreateAddressCommand(string street, string number, string neighborhood, string city, string state, string country, string zipCode, bool main, int appUserId)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Main = main;
            AppUserId = appUserId;
        }

        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public bool Main { get;  set; }
        public int AppUserId { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Street, "Street", "Rua é obrigatório")
                    .IsNotNull(Number, "Number", "Número é obrigatório")
                    .IsNotNull(Neighborhood, "Neighborhood", "Bairro é obrigatório")
                    .IsNotNull(City, "City", "Cidade é obrigatório")
                    .IsNotNull(State, "State", "Estado é obrigatório")
                    .IsNotNull(Country, "Country", "País é obrigatório")
                    .IsNotNull(ZipCode, "ZipCode", "CEP é obrigatório")
            );
        }
    }
}
