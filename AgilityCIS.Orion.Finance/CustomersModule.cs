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
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Customers
{
     [ModuleExport(typeof(CustomersModule), InitializationMode = InitializationMode.OnDemand)]
    public class CustomersModule:IModule
    {
		#region Fields (1) 

        [Import]
        public IRegionManager RegionManager;

		#endregion Fields 

		#region Methods (1) 

		// Public Methods (1) 

        public void Initialize()
        {            
            this.RegionManager.RegisterViewWithRegion("ModuleRegion", typeof(Views.FinanceView));

        }

		#endregion Methods 
    }
}
