namespace DaldeApartmentAPI.ViewModels.Payment
{
    public class PaymentDetailsViewModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal Sum { get; set; }
        public DateTime DatePaid { get; set; }
    }
}
