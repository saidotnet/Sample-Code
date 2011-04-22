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
using System.Windows.Interactivity;

namespace AgilityCIS.Orion.CustomBehaviors
{
    public class RightClickTrigger : Behavior<System.Windows.Controls.TextBox>
    {
		#region Fields (4) 

         private ContextMenu _contextMenu;
        private MenuItem _copy;
        private MenuItem _cut;
        private MenuItem _paste;

		#endregion Fields 

		#region Constructors (1) 

        public RightClickTrigger()
        {

 

            _contextMenu = new ContextMenu();

            _cut = new MenuItem();

            _cut.Header = "Cut";

            _cut.Click += new RoutedEventHandler(cut_Click);

            _contextMenu.Items.Add(_cut);

 

            _copy = new MenuItem();

            _copy.Header = "Copy";

            _copy.Click += new RoutedEventHandler(copy_Click);

            _contextMenu.Items.Add(_copy);

 

            _paste = new MenuItem();

            _paste.Header = "Paste";

            _paste.Click += new RoutedEventHandler(paste_Click);

            _contextMenu.Items.Add(_paste);

        }

		#endregion Constructors 

		#region Methods (7) 

		// Protected Methods (2) 

        protected override void OnAttached()
        {
 

            AssociatedObject.MouseRightButtonDown += new MouseButtonEventHandler(AssociatedObject_MouseRightButtonDown);

            AssociatedObject.MouseRightButtonUp += new MouseButtonEventHandler(AssociatedObject_MouseRightButtonUp);

            AssociatedObject.SetValue(ContextMenuService.ContextMenuProperty, _contextMenu);

            base.OnAttached();
        }

        protected override void OnDetaching()
        {

            AssociatedObject.MouseRightButtonDown -= new MouseButtonEventHandler(AssociatedObject_MouseRightButtonDown);

            AssociatedObject.MouseRightButtonUp -= new MouseButtonEventHandler(AssociatedObject_MouseRightButtonUp);

            _contextMenu = null;

            base.OnDetaching();

 
        }
		// Private Methods (5) 

        private void AssociatedObject_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;

        }

       private  void AssociatedObject_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (Clipboard.ContainsText())

                _paste.IsEnabled = true;

            else

                _paste.IsEnabled = false;

 
            if (string.IsNullOrEmpty(AssociatedObject.SelectedText))

            {

                _cut.IsEnabled = false;

                _copy.IsEnabled = false;

            }

            else

            {

                _cut.IsEnabled = true;

                _copy.IsEnabled = true;

            }

            _contextMenu.IsOpen = true;


        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {

            Clipboard.SetText(AssociatedObject.SelectedText);

            AssociatedObject.Focus();

            _contextMenu.IsOpen = false;

        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {

            Clipboard.SetText(AssociatedObject.SelectedText);

            AssociatedObject.SelectedText = string.Empty;

            AssociatedObject.Focus();

            _contextMenu.IsOpen = false;

        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {

            AssociatedObject.SelectedText = Clipboard.GetText();

            _contextMenu.IsOpen = false;

        }

		#endregion Methods 
    }

}

