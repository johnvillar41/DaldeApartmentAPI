namespace DaldeApartmentAPI.ViewModels.Renter
{
    public class RenterDetailViewModel
    {
        public string Id { get; set; }
        public string ContactNumber { get; set; } 
        public string FullName { get; set; }
        public string ContractLink { get; set; } 
        public string ReceiptLink { get; set; } 
        public DateTime DateRented { get; set; }
    }
}
