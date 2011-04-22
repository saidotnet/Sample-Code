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
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;

namespace AgilityCIS.Orion.Common.Enums
{
    public static class EnumReader
    {
		#region Methods (3) 

		// Public Methods (3) 

        /// <summary>
        /// Gets the names of an enumeration type.
        /// </summary>
        /// <typeparam name="T">Type of enumeration.</typeparam>
        /// <returns>ObservableCollection of names of the enumeration.</returns>
        public static ObservableCollection<string> GetNameObservableCollection<T>() where T : struct
        {
            return GetNameObservableCollection(typeof(T));
        }

        /// <summary>
        /// Gets the names of an enumeration type.
        /// </summary>
        /// <param name="enumType">Type of enumeration.</param>	
        /// <returns>ObservableCollection of names of the enumeration.</returns>
        public static ObservableCollection<string> GetNameObservableCollection(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException("Specified generic parameter must be an enumeration.");
            }
            ObservableCollection<String> nameObservableCollection = new ObservableCollection<String>();

            FieldInfo[] fiArray = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo fi in fiArray)
            {
                string EnumItem = string.Empty;
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    EnumItem = attributes[0].Description;
                }
                nameObservableCollection.Add(EnumItem);
            }
            return nameObservableCollection;
        }

        public static string StringValueOf(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

		#endregion Methods 
    }
}