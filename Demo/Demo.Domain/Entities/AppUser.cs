using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain.Entities
{
    public class AppUser : Entity
    {
        private IList<Address> _addresses;

        public AppUser(string username, string fullname, string email, int userId)
        {
            Username = username;
            Fullname = fullname;
            Email = email;
            Active = true;
            UserId = userId;
            _addresses = new List<Address>();
            DateCreated = DateTime.Now;
        }

        public string Username { get; private set; }

        public string Fullname { get; private set; }

        public string Document { get; private set; }

        public string Email { get; private set; }

        public bool Active { get; private set; }

        public int UserId { get; private set; }

        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }        

        public IReadOnlyCollection<Address> Addresses { get => _addresses.ToArray(); }
    }
}
