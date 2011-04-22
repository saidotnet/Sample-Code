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

namespace AgilityCIS.Orion.Common.Controls
{
    public partial class ConfirmationDialog : ChildWindow
    {
		#region Fields (1) 

        private string _message;

		#endregion Fields 

		#region Constructors (2) 

        public ConfirmationDialog(string message)
            : this()
        {
            messageTextBlock.Text = message;
        }

        public ConfirmationDialog()
        {
            InitializeComponent();

        }

		#endregion Constructors 

		#region Properties (1) 

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                messageTextBlock.Text = _message;
            }
        }

		#endregion Properties 

		#region Methods (2) 

		// Private Methods (2) 

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

		#endregion Methods 
    }
}

