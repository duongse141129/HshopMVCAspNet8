namespace EcommerceMVC.ViewModels
{
    public class CheckOutVM
    {
        public bool SameCustomer { get; set; }
        public string? FullName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
    }
}
