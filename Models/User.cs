using System;
using System.Collections.Generic;

namespace DaldeApartmentAPI.Models
{
    public partial class User
    {
        public User()
        {
            Payments = new HashSet<Payment>();
        }

        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
