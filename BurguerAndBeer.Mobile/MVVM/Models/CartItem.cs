using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.Models
{
    public partial class CartItem : ObservableObject
    {
        public int Id { get; set; }
        public int ItemId { get; set; }      
        public int CategoryId { get; set; }
        public string Name { get; set; }      
        public double Price {  get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(PriceTotal))]
        private int _quantity;
        public double PriceTotal => Price * Quantity;
    }
}
