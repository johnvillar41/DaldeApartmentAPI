using System;
using System.Collections.Generic;

namespace DaldeApartmentAPI.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            ApartmentRenters = new HashSet<ApartmentRenter>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;

        public virtual ICollection<ApartmentRenter> ApartmentRenters { get; set; }
    }
}
