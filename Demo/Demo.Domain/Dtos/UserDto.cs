using System;

namespace Demo.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
