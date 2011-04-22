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
using AgilityCIS.Orion.Common.Controls;

namespace AgilityCIS.Orion.Common.Service
{
    public class DialogService: IDialogService
    {
		#region Fields (2) 

        AlertDialog _alertDialog=new AlertDialog();
        ConfirmationDialog _confirmationDialog=new ConfirmationDialog();

		#endregion Fields 

		#region Methods (1) 

		// Public Methods (1) 

         /// <summary>
        /// Show alert message
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="onClosedCallback"></param>
        public void Alert(string title, string message, Action<DialogResult> onClosedCallback)
        {
            _confirmationDialog.Close();
            _alertDialog.Title = title;
            _alertDialog.Message = message;
            _alertDialog.Closed += (s, e) =>
            {
                if (onClosedCallback != null)
                {
                    DialogResult result = new DialogResult();
                    result.Result = _alertDialog.DialogResult;
                    onClosedCallback(result);
                }
            };
            _alertDialog.Width = Width;
            _alertDialog.Height = Height;
            _alertDialog.Show();  
        }

		#endregion Methods 



        #region IDialogService Members

        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Show confirmation popup
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="onClosedCallback"></param>
        public void Confirm(string title, string message, Action<DialogResult> onClosedCallback)
        {
            _alertDialog.Close();
            _confirmationDialog.Title = title;
            _confirmationDialog.Message = message;
            _confirmationDialog.Closed += (s, e) => 
            {
                if (onClosedCallback != null)
                {
                    DialogResult result = new DialogResult();
                    result.Result = _confirmationDialog.DialogResult;
                    onClosedCallback(result);
                }
            };
            _confirmationDialog.Width = Width;
            _confirmationDialog.Height = Height;
            _confirmationDialog.Show();                
        }
        
        #endregion
    }
}
