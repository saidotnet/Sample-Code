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
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.Collections.ObjectModel;

namespace AgilityCIS.Orion.Common
{
    /// <summary>    
    /// This class acts as in memory cache and stores data in memory
    /// </summary>
    public class StoreInstance
    {
        #region Fields (2)

        /// <summary>
        /// Variable for the StoreInstance.
        /// </summary>
        private static StoreInstance _instance;
        /// <summary>
        /// Variable to check whether the instance has been created before creating the instance
        /// </summary>
        private static readonly object _lockInstance = new object();

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Private constructor
        /// </summary>
        private StoreInstance()
        {

        }

        #endregion Constructors

        #region Properties (3)

        public ObservableCollection<Customer> CustomerList { get; set; }

        /// <summary>
        /// Singleton object
        /// </summary>
        public static StoreInstance Instance
        {
            get
            {
                lock (_lockInstance)
                {
                    if (_instance == null)
                    {
                        _instance = new StoreInstance();
                    }
                    return _instance;
                }
            }
        }

        public int LoggedinCustNo { get; set; }

        public string SelectedCustomerId { get; set; }

        public string SelectedPartyId { get; set; }

        #endregion Properties
    }
}
