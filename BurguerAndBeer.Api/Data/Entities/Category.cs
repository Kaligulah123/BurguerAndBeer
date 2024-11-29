using System.ComponentModel.DataAnnotations;

namespace BurguerAndBeer.Api.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }      
    }
}
