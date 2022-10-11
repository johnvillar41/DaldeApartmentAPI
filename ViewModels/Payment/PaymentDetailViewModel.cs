namespace DaldeApartmentAPI.ViewModels.Payment
{
    public class PaymentDetailViewModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal Sum { get; set; }
        public DateTime DatePaid { get; set; }
        public string PaidToName { get; set; }
        public string RenterName { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
