using System;
using System.Collections.Generic;

namespace DaldeApartmentAPI.Models
{
    public partial class ApartmentRenter
    {
        public string Id { get; set; } = null!;
        public string ApartmentId { get; set; } = null!;
        public string RenterId { get; set; } = null!;
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
        public virtual Renter Renter { get; set; } = null!;
    }
}
