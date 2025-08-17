namespace my_restaurant.Models
{
    public class ProductIngredient
    {
        public int ProductId { get; set; } //FK
        public Product Product { get; set; }
        public int IngredientId { get; set; } //FK
        public Ingredient Ingredient { get; set; }
    }
}