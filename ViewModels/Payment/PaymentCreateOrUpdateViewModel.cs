namespace DaldeApartmentAPI.ViewModels.Payment
{
    public class PaymentCreateOrUpdateViewModel
    {
        public string? Id { get; set; }
        public string Type { get; set; }
        public decimal Sum { get; set; }
        public DateTime DatePaid { get; set; }
        public string PaidTo { get; set; }
        public string WhoRentedId { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
