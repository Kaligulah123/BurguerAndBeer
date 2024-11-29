using System.ComponentModel.DataAnnotations;

namespace BurguerAndBeer.Api.Data.Entities
{
    public class Dessert
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Description { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Required, MaxLength(180)]
        public string Image { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
