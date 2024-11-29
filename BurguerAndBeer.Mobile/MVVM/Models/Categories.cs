using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.Models
{
    public partial class Categories : ObservableObject
    {
        public int Id {  get; set; } 
        public string Name { get; set; }
        public string Image {  get; set; }

        [ObservableProperty]
        public bool _isSelected;

    }
}
