namespace EcommerceMVC.ViewModels
{
    public class DetailProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int FeedbackPoint { get; set; }
        public int Stock { get; set; }
    }
}
