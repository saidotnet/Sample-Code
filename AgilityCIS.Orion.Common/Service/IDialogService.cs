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

namespace AgilityCIS.Orion.Common.Service
{
    public interface IDialogService
    {
		#region Data Members (2) 

        int Height { get; set; }

        int Width { get; set; }

		#endregion Data Members 

		#region Operations (2) 

        void Alert(string title, string message, Action<DialogResult> onClosedCallback);

        void Confirm(string title, string message, Action<DialogResult> onClosedCallback);

		#endregion Operations 
    }
        
}
