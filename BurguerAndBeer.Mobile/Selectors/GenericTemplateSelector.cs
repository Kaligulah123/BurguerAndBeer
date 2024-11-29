using BurguerAndBeer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Selectors
{
    public class GenericTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BurguerTemplate { get; set; }
        public DataTemplate BeerTemplate { get; set; }
        public DataTemplate ChipsTemplate { get; set; }
        public DataTemplate DessertTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item switch
            {
                BurguerDto => BurguerTemplate,
                BeerDto => BeerTemplate,
                ChipsDto => ChipsTemplate,
                DessertDto => DessertTemplate,
                _ => null
            };
        }
    }

}
