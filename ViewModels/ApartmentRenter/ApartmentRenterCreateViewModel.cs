namespace DaldeApartmentAPI.ViewModels.ApartmentRenter
{
    public class ApartmentRenterCreateOrUpdateViewModel
    {
        public string Id { get; set; }
        public string ApartmentId { get; set; }
        public string RenterId { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
