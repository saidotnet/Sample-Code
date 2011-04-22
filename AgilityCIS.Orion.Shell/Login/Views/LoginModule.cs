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
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Shell
{
    [ModuleExport(typeof(LoginModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class LoginModule : IModule
    {
		#region Fields (1) 

        [Import]
        public IRegionManager RegionManager;

		#endregion Fields 

		#region Methods (1) 

		// Public Methods (1) 

        public void Initialize()
        {
            this.RegionManager.RegisterViewWithRegion("MainContentRegion", typeof(Views.LoginView));

        }

		#endregion Methods 
    }
}
