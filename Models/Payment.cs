using System;
using System.Collections.Generic;

namespace DaldeApartmentAPI.Models
{
    public partial class Payment
    {
        public string Id { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Sum { get; set; }
        public DateTime DatePaid { get; set; }
        public string PaidTo { get; set; } = null!;
        public string RenterId { get; set; } = null!;
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }

        public virtual User PaidToNavigation { get; set; } = null!;
        public virtual Renter Renter { get; set; } = null!;
    }
}
