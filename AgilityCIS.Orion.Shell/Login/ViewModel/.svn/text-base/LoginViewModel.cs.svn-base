using System;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using AgilityCIS.Orion.Common;
using AgilityCIS.Orion.Services;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.ServiceModel;
using System.Globalization;
using AgilityCIS.Orion.LocalizationManager;
using System.Collections.Generic;
using System.Threading;

namespace AgilityCIS.Orion.Shell.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewModel : BaseViewModel, INavigationAware
    {
		#region Fields (6) 

        private List<string> _languages = new List<string>() { "English", "German" };
        private DelegateCommand<object> _loginCommand;
        private string _password = "FRED22";
        private readonly IRegionManager _regionManager;
        private string _selectedLanguage;
        // This is just for testing
        private string _userName = "CGVAKDEV";

		#endregion Fields 

		#region Constructors (1) 

        [ImportingConstructor]
        public LoginViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _loginCommand = new DelegateCommand<object>(Login, CanLogin);

        }

		#endregion Constructors 

		#region Properties (5) 

        public List<string> Languages
        {
            get
            {

                return _languages;
            }
            set
            {
                this._languages = value;
                SelectedLanguage = Languages[0];
                RaisePropertyChanged("Languages");
            }
        }

        public DelegateCommand<object> LoginCommand { get { return _loginCommand; } set { _loginCommand = value; } }

        public string Password
        {
            get
            {

                return this._password;
            }
            set
            {
                this._password = value;
                if (this._loginCommand != null)
                    this._loginCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("Password");
            }
        }

        public string SelectedLanguage
        {
            get
            {
                if (_selectedLanguage == null)
                    SelectedLanguage = _languages[0];

                return _selectedLanguage;
            }
            set
            {
                this._selectedLanguage = value;
                RaisePropertyChanged("SelectedLanguage");
            }
        }

        public string UserName
        {
            get
            {

                return _userName;
            }
            set
            {
                this._userName = value;
                if (this._loginCommand != null)
                    this._loginCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("UserName");
            }
        }

		#endregion Properties 

		#region Methods (5) 

		// Public Methods (3) 

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //   throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // throw new NotImplementedException();
        }
		// Private Methods (2) 

        private bool CanLogin(object ignored)
        {
            if (!string.IsNullOrEmpty(this.UserName) || !string.IsNullOrEmpty(this.Password))
                return true;

            return false;
        }

        private void Login(object ignored)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Message = "Username/Password cannot be empty!";
                return;
            }

            User user = new User();
            user.UserName = UserName;
            user.Password = Password;
            IsBusy = true;
            ServiceAgent.Login(user,
                (s, e) =>
                {
                    IsBusy = false;
                    if (e.Error != null)
                    {
                        HandleError(e.Error);
                    }
                    else
                    {
                        if (e.Result != null && e.Result.UserId != 0)
                        {
                            user = e.Result;
                            StoreInstance.Instance.LoggedinCustNo = user.UserId;
                            //Culture has to be set here
                            CultureInfo currentCulture;
                            if (SelectedLanguage == "German")
                            {
                                currentCulture = new CultureInfo("de-DE");
                            }
                            else
                            {
                                currentCulture = new CultureInfo("en-US");
                            }

                            ApplicationResources.UiCulture = currentCulture;
                            Thread.CurrentThread.CurrentCulture = currentCulture;

                            _regionManager.Regions["MainContentRegion"].Context = user;                          
                           _regionManager.RequestNavigate("MainContentRegion", new Uri("CSRNavigationView", UriKind.Relative));
                           

                           
                        }
                        else
                        {
                            Message = "Invalid Username/Password!";
                        }

                    }
                });
        }

		#endregion Methods 
    }
}
