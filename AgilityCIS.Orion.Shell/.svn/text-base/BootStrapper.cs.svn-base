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
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition.Hosting;

namespace AgilityCIS.Orion.Shell
{
    public class BootStrapper : MefBootstrapper
    {
		#region Fields (1) 

        private const string ModuleCatalogUri = "/AgilityCIS.Orion.Shell;component/ModulesCatalog.xaml";

		#endregion Fields 

		#region Methods (5) 

		// Protected Methods (5) 

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(BootStrapper).Assembly));          
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return
                Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri(ModuleCatalogUri,
                                                                                          UriKind.Relative));
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = (UIElement)this.Shell;
        }

		#endregion Methods 
    }
}
