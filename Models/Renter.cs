using System;
using System.Collections.Generic;

namespace DaldeApartmentAPI.Models
{
    public partial class Renter
    {
        public Renter()
        {
            ApartmentRenters = new HashSet<ApartmentRenter>();
            Payments = new HashSet<Payment>();
        }

        public string Id { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string ContractLink { get; set; } = null!;
        public string ReceiptLink { get; set; } = null!;
        public DateTime DateRented { get; set; }

        public virtual ICollection<ApartmentRenter> ApartmentRenters { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
