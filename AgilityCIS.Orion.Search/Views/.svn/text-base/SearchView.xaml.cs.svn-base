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
using System.ComponentModel.Composition;
using AgilityCIS.Orion.Search.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Search.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SearchView : UserControl
    {
		#region Constructors (1) 

        public SearchView()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		#endregion Constructors 

		#region Properties (1) 

        [Import]
        public SearchViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

		#endregion Properties 
    }
}
