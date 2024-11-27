namespace EcommerceMVC.ViewModels
{
    public class CartItem
    {
        public int ProductId { get; set; } 
        public string ProductPhoto { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int quantity { get; set; }
        public double cost => quantity * Price;
    }
}
