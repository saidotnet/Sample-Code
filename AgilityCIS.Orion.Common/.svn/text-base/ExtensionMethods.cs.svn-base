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
using System.Collections.Generic;

namespace AgilityCIS.Orion.Common
{
    public static class ExtensionMethods
    {
		#region Methods (1) 

		// Public Methods (1) 

     /// <summary>
        /// A generic method that converts the given IEnumerable into an ObservableCollection     
        /// </summary>
        /// <typeparam name="T">The type of object to Convert</typeparam>
        /// <param name="source">object to Convert</param>
        /// <returns></returns>
         public static ObservableCollection<T> ToObservableCollection<T> ( this IEnumerable<T> obj ) {
                ObservableCollection<T> o = new ObservableCollection<T> ();
                foreach ( T item in obj ) {
                    o.Add (item);
                }
                return o;
            }

		#endregion Methods 
        }
    }

