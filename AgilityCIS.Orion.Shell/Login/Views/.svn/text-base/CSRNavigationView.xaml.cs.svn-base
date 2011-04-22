using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Modularity;
using AgilityCIS.Orion.Shell.ViewModel;
using AgilityCIS.Orion.Shell.Login.ViewModel;

namespace AgilityCIS.Orion.Shell.Login.Views
{
     [Export("CSRNavigationView")]
    public partial class CSRNavigationView : UserControl,INavigationAware
    {

        
        #region Constructors (1)

        public CSRNavigationView()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties (1)

        [Import]
        public CSRNavigationViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

        #endregion Properties

        #region Methods (3)

        // Public Methods (3) 

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
                        
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
           // throw new NotImplementedException();
        }
        #endregion Methods

       
        
    }
}
