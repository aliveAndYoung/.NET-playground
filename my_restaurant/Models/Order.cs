namespace my_restaurant.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime orderDate { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}