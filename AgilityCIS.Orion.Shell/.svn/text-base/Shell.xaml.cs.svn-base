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
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Shell
{
    [Export]
    public partial class Shell : UserControl, IPartImportsSatisfiedNotification
    {
		#region Fields (8) 
       
        private const string LoginModuleName = "LoginModule";
        private static Uri LoginURI = new Uri("/LoginView", UriKind.Relative);
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;
        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;        

		#endregion Fields 

		#region Constructors (1) 

        public Shell()
        {
            InitializeComponent();
        }

		#endregion Constructors 

		#region Methods (1) 

		// Public Methods (1) 

        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    // todo: 01 - Navigation on when modules are loaded.
                    // When using region navigation, be sure to use it consistently
                    // to ensure you get proper journal behavior.  If we mixed
                    // usage of adding views directly to regions, such as through
                    // RegionManager.AddToRegion, and then use RegionManager.RequestNavigate,
                    // we may not be able to navigate back correctly.
                    //// 
                    // Here, we wait until the module we want to start with is
                    // loaded and then navigate to the view we want to display
                    // initially.
                    //     
                    if (e.ModuleInfo.ModuleName == LoginModuleName)
                    {
                        this.RegionManager.RequestNavigate(
                            "MainContentRegion",
                            LoginURI);
                    }                 
                 
                };
        }

		#endregion Methods 
    }
}
