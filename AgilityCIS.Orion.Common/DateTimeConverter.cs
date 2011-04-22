using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace AgilityCIS.Orion.Common
{
    public class DateTimeConverter : IValueConverter
    {
		#region Methods (2) 

		// Public Methods (2) 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            DateTime? selectedDate = value as DateTime?;



            if (selectedDate != null)
            {

                string dateTimeFormat = parameter as string;

                return selectedDate.Value.ToString(dateTimeFormat);

            }



            return string.Empty;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;

        }

		#endregion Methods 
    }
}
