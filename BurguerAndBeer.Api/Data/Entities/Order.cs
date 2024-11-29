using System.ComponentModel.DataAnnotations;

namespace BurguerAndBeer.Api.Data.Entities
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public DateTime OrderAt { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }

        [Required, MaxLength(30)]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string UserEmail { get; set; }

        [Required, MaxLength(150)]
        public string UserAddress { get; set; }

        [Range(0.1, double.MaxValue)]
        public double TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
