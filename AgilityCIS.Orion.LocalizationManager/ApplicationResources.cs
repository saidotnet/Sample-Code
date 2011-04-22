using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace AgilityCIS.Orion.LocalizationManager
{
    public class ApplicationResources : IValueConverter
    {
		#region Fields (2) 

        /// <summary>
        /// The Resource Manager loads the resources out of the executing assembly (and the XAP File where there are embedded)
        /// </summary>
        private static readonly ResourceManager resourceManager =
            new ResourceManager("AgilityCIS.Orion.LocalizationManager.Resources.Resource",
                                Assembly.GetExecutingAssembly());
        /// <summary>
        ///  property for specifying the culture
        /// </summary>
        private static CultureInfo uiCulture = Thread.CurrentThread.CurrentUICulture;

		#endregion Fields 

		#region Properties (1) 

        public static CultureInfo UiCulture
        {
            get { return uiCulture; }
            set
            {
                uiCulture = value;
                Thread.CurrentThread.CurrentCulture = uiCulture;
            }
        }

		#endregion Properties 

		#region Methods (2) 

		// Public Methods (2) 

        /// <summary>
        /// This method returns the localized string of the given resource.
        /// </summary>
        public string Get(string resource)
        {
            return resourceManager.GetString(resource, UiCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            string str = resourceManager.GetString(key, UiCulture);

            if (str != null)
            {
                if (str.Contains("<br /><br />"))
                {
                    return str.Replace("<br /><br />", Environment.NewLine);
                }

                if (str.Contains("&copy;"))
                {
                    return str.Replace("&copy;", "©");
                }
            }

            return str;
        }

		#endregion Methods 



        #region IValueConverter Members
        /// <summary>
        /// This method is used to bind the silverlight component to the resource. 
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reader = (ApplicationResources)value;
            return reader.Get((string)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ConvertBack is not used, because the Localization is only a One Way binding
            throw new NotImplementedException();
        }

        #endregion
    }
}
