using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using AgilityCIS.Orion.Customers.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Customers.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class FinanceView : UserControl
	{
		#region Constructors (1) 

        public FinanceView()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		#endregion Constructors 

		#region Properties (1) 

        [Import]
        public FinanceViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

		#endregion Properties 
    }
}