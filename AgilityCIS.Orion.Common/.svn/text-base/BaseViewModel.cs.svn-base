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
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using AgilityCIS.Orion.Services;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.ServiceModel;
using AgilityCIS.Orion.Common.Service;

namespace AgilityCIS.Orion.Common
{
    public class BaseViewModel : NotificationObject
    {
		#region Fields (6) 

        private DelegateCommand<object> _closePopupCommand;
        private IDialogService _dialog;
        private bool _isBusy = default(bool);
        private string _message;
        private IServiceAgent _ServiceAgent;
        private Visibility _showPopup = Visibility.Collapsed;

		#endregion Fields 

		#region Constructors (1) 

        public BaseViewModel()
        {
            _closePopupCommand = new DelegateCommand<object>(ClosePopup, CanClose);
            _dialog = new DialogService();
            _dialog.Width = 300;
            _dialog.Height = 200;
            this._ServiceAgent = new ServiceAgent();
        }

		#endregion Constructors 

		#region Properties (6) 

        public DelegateCommand<object> ClosePopupCommand { get { return _closePopupCommand; } set { _closePopupCommand = value; } }

        public IDialogService Dialogs
        {
            get { return this._dialog; }
            set { this._dialog = value; }
        }

        /// <summary>
        /// Set to true if loading needs to be shown
        /// </summary>
        public bool IsBusy
        {
            get
            {

                return this._isBusy;
            }
            set
            {
                this._isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// Show the error message
        /// </summary>
        public string Message
        {
            get
            {

                return this._message;
            }
            set
            {
                this._message = value;                         
                _dialog.Alert("Error", _message, null);
                RaisePropertyChanged("Message");
            }
        }

        public IServiceAgent ServiceAgent
        {
            get { return this._ServiceAgent; }
            set { this._ServiceAgent = value; }
        }

        public Visibility ShowPopup
        {
            get
            {

                return this._showPopup;
            }
            set
            {
                this._showPopup = value;
                RaisePropertyChanged("ShowPopup");
            }
        }

		#endregion Properties 

		#region Methods (4) 

		// Public Methods (1) 

        public void HandleError(Exception exception)
        {
            FaultException<FaultDetail> faultException = exception as FaultException<FaultDetail>;
            if (faultException != null)
            {
                Message = faultException.Detail.Type;

            }
            else
            {
                Message = exception.Message;
            }
        }
		// Protected Methods (1) 

        protected override void RaisePropertyChanged(string propertyName)
        {            
            base.RaisePropertyChanged(propertyName);
        }
		// Private Methods (2) 

        private bool CanClose(object ignored)
        {
            return true;
        }

        private void ClosePopup(object ignored)
        {
            ShowPopup = Visibility.Collapsed;
        }

		#endregion Methods 
    }
}
