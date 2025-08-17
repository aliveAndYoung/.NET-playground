using Microsoft.AspNetCore.Identity;

namespace my_restaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
