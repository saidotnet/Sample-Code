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
using AgilityCIS.Orion.Shell.ViewModel;

namespace AgilityCIS.Orion.Shell.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class LoginView : UserControl, INavigationAware
    {
		#region Constructors (1) 

        public LoginView()
        {
            InitializeComponent();
            
        }

		#endregion Constructors 

		#region Properties (1) 

        [Import]
        public LoginViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

		#endregion Properties 

		#region Methods (3) 

		
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // left intentionally
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // left intentionally
        }

		#endregion Methods 
    }
}
