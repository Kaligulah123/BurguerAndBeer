using BurguerAndBeer.Mobile.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Data
{
    public class CartItemEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public CartItemEntity(CartItem cartItemModel)
        {
            ItemId = cartItemModel.ItemId;
            CategoryId = cartItemModel.CategoryId;
            Name = cartItemModel.Name;
            Price = cartItemModel.Price;
            Quantity = cartItemModel.Quantity;
        }

        public CartItemEntity()
        {
            
        }

        public CartItem ToCartItemModel() =>
            new()
            {
                Id = ItemId,
                CategoryId = CategoryId,
                Name = Name,
                Price = Price,
                Quantity = Quantity,
            };      
    }
}
