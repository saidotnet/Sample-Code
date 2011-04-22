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
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;

namespace AgilityCIS.Orion.Common
{
    public static class Utilities<T>
    {
		#region Methods (2) 

		// Public Methods (2) 

        public static int Compare(T x, T y)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            FieldInfo[] fields = type.GetFields();
            int compareValue = 0;

            foreach (PropertyInfo property in properties)
            {
                IComparable valx = property.GetValue(x, null) as IComparable;
                if (valx == null)
                    continue;
                object valy = property.GetValue(y, null);
                compareValue = valx.CompareTo(valy);
                if (compareValue != 0)
                    return compareValue;
            }
            foreach (FieldInfo field in fields)
            {
                IComparable valx = field.GetValue(x) as IComparable;
                if (valx == null)
                    continue;
                object valy = field.GetValue(y);
                compareValue = valx.CompareTo(valy);
                if (compareValue != 0)
                    return compareValue;
            }

            return compareValue;
        }

        public static T DeepCopy(T oSource)
        {
            T oClone;
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                dcs.WriteObject(ms, oSource);
                ms.Position = 0;
                oClone = (T)dcs.ReadObject(ms);
            }

            return oClone;
        }

		#endregion Methods 
    }


}
