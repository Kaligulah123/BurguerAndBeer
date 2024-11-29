using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Converters
{
    public class CategoryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int categoryId)
            {
                return categoryId switch
                {
                    1 => "hamburguesa.png",
                    2 => "chapa_cerveza.png",
                    3 => "papas_fritas.png",
                    4 => "magdalena.png",
                    _ => "hamburguesa.png" // Imagen predeterminada para valores no reconocidos
                };
            }
            return "hamburguesa.png"; // Imagen predeterminada para valores inválidos
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
