﻿using System.ComponentModel.DataAnnotations;

namespace BurguerAndBeer.Api.Data.Entities
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0.1, double.MaxValue)]
        public double TotalPrice { get; set; }
        public virtual Order Order { get; set; }
    }
}
