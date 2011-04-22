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
using AgilityCIS.Orion.Contacts.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace AgilityCIS.Orion.Contacts.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ContactsView : UserControl
    {
        #region Constructors (1)

        public ContactsView()
        {
            // Required to initialize variables
            InitializeComponent();

        }

           
        #endregion Constructors

        #region Properties (1)

        [Import]
        public ContactsViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

        



        #endregion Properties

        
     

    }

}