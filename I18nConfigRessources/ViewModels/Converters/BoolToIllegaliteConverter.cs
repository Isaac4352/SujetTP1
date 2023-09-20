using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace I18nConfigRessources.ViewModels.Converters
{
    internal class BoolToIllegaliteConverter : IValueConverter
    {
        // Conversion du Model vers la View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool illegalite = (bool)value;
            return illegalite ? "Oui" : "Non";
        }

        // Conversion de la View vers le Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
