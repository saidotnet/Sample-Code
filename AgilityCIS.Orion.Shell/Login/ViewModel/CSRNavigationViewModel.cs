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
using System.ComponentModel.Composition;
using AgilityCIS.Orion.Common;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using System.Collections.ObjectModel;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using AgilityCIS.Orion.LocalizationManager;
using AgilityCIS.Orion.Common.Service;

namespace AgilityCIS.Orion.Shell.Login.ViewModel
{

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CSRNavigationViewModel : BaseViewModel, INavigationAware
    {
        #region�Fields�(18)�

        private CustomerSearchCriteria _customerNoSearchCriteria;
        private string _customerNo;
        private ObservableCollection<Customer> _customers;
        private CustomerSearchCriteria _customerSearchCriteria;
        private CustomerSummary _customerSummaryDetails;
        private DelegateCommand<object> _deleteCustomerCommand;
        private IEventAggregator _eventAggregator;
        private DelegateCommand<object> _firstCommand;
        private DelegateCommand<object> _lastCommand;
        private DelegateCommand<object> _loadCommand;
        private DelegateCommand<object> _loadCustomerCommand;
        private DelegateCommand<object> _loadContactCommand;
        private DelegateCommand<object> _saveCustDetailsCommand;
        [Import(AllowRecomposition = false)]
        public IModuleManager _moduleManager;
        private DelegateCommand<object> _nextCommand;
        private DelegateCommand<object> _previousCommand;
        private readonly IRegionManager _regionManager;
        private DelegateCommand<object> _searchCustNoCommand;
        private Customer _selectedCustomer;
        private int _seqPartyId;
        private User _user;

        #endregion�Fields�

        #region�Constructors�(1)�

        [ImportingConstructor]
        public CSRNavigationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;
            _loadCommand = new DelegateCommand<object>(ExecuteMethod, CanExecute);
            _loadContactCommand = new DelegateCommand<object>(LoadContact, CanExecute);
            _loadCustomerCommand = new DelegateCommand<object>(LoadCustomer, CanExecute);
            _searchCustNoCommand = new DelegateCommand<object>(SearchCustNo, CanLoad);
            _deleteCustomerCommand = new DelegateCommand<object>(DeleteCustomer, CanLoad);
            _nextCommand = new DelegateCommand<object>(Next, CanLoad);
            _previousCommand = new DelegateCommand<object>(Previous, CanLoad);
            _lastCommand = new DelegateCommand<object>(Last, CanLoad);
            _firstCommand = new DelegateCommand<object>(First, CanLoad);
            _saveCustDetailsCommand = new DelegateCommand<object>(SaveCustDetails, CanSave);
            Uri SearchURI = new Uri("/SearchView", UriKind.Relative);
            _regionManager.RequestNavigate("ModuleRegion", SearchURI);
            _eventAggregator = eventAggregator;
            _user = regionManager.Regions["MainContentRegion"].Context as User;
            CustomersLoadedEvent custloadevent = _eventAggregator.GetEvent<CustomersLoadedEvent>();
            custloadevent.Subscribe(CustomersEventHandler);
            SearchCustomerSelectedEvent customerSelectedEvent = _eventAggregator.GetEvent<SearchCustomerSelectedEvent>();
            customerSelectedEvent.Subscribe(CustomerSelectedEventHandler);
            ClearSearch();
            ClearTopSearch();
        }

        #endregion�Constructors�

        #region�Properties�(14)�

        public CustomerSearchCriteria CustomerNoSearchCriteria
        {
            get { return _customerNoSearchCriteria; }
            set
            {
                _customerNoSearchCriteria = value;
                RaisePropertyChanged("CustomerNoSearchCriteria");
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {

                return this._customers;
            }
            set
            {
                this._customers = value;
                RaisePropertyChanged("Customers");

            }
        }

        public CustomerSearchCriteria CustomerSearchCriteria
        {
            get { return _customerSearchCriteria; }
            set
            {
                _customerSearchCriteria = value;
                RaisePropertyChanged("CustomerSearchCriteria");
            }
        }

        public CustomerSummary CustomerSummaryDetails
        {
            get { return _customerSummaryDetails; }
            set
            {
                _customerSummaryDetails = value;
                RaisePropertyChanged("CustomerSummaryDetails");
            }
        }

        public DelegateCommand<object> DeleteCustomerCommand { get { return _deleteCustomerCommand; } set { _deleteCustomerCommand = value; } }

        public DelegateCommand<object> FirstCommand { get { return _firstCommand; } set { _firstCommand = value; } }

        public DelegateCommand<object> LastCommand { get { return _lastCommand; } set { _lastCommand = value; } }

        public DelegateCommand<object> LoadCommand { get { return _loadCommand; } set { _loadCommand = value; } }

        public DelegateCommand<object> LoadContactCommand { get { return _loadContactCommand; } set { _loadContactCommand = value; } }

        public DelegateCommand<object> LoadCustomerCommand { get { return _loadCustomerCommand; } set { _loadCustomerCommand = value; } }

        public DelegateCommand<object> NextCommand { get { return _nextCommand; } set { _nextCommand = value; } }

        public DelegateCommand<object> PreviousCommand { get { return _previousCommand; } set { _previousCommand = value; } }

        public DelegateCommand<object> SearchCustNoCommand { get { return _searchCustNoCommand; } set { _searchCustNoCommand = value; } }

        public DelegateCommand<object> SaveCustDetailsCommand { get { return _saveCustDetailsCommand; } set { _saveCustDetailsCommand = value; } }

        public Customer SelectedCustomer
        {
            get
            {
                return this._selectedCustomer;
            }
            set
            {
                if (this._selectedCustomer != value)
                {
                    this._selectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                    if (SelectedCustomer != null)
                    {
                        if (Customers != null && Customers.Count > 0)
                        {
                            if (SelectedCustomer.Products != null && SelectedCustomer.Products.Count > 0)
                            {
                                SeqPartyId = SelectedCustomer.Products[0].SeqPartyId;
                            }
                        }
                    }
                    _eventAggregator.GetEvent<HeaderCustomerSelectedEvent>().Publish(this._selectedCustomer);
                }
            }
        }

        public int SeqPartyId
        {
            get { return _seqPartyId; }
            set
            {
                _seqPartyId = value;


                ServiceAgent.LoadCustomerSummary(SeqPartyId, (s, e) =>
                {
                    if (e.Error == null)
                    {
                        CustomerSummaryDetails = e.Result;

                    }
                    else
                    {
                        HandleError(e.Error);
                    }
                });

                RaisePropertyChanged("SeqPartyId");
            }
        }

        #endregion�Properties�

        #region�Methods�(19)�

        //�Public�Methods�(5)�

        public void CustomerSelectedEventHandler(Customer customer)
        {
            SelectedCustomer = customer;
        }

        public void CustomersEventHandler(CustomersColl customers)
        {
            this.Customers = customers;

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        //�Private�Methods�(14)�

        private bool CanExecute(object ignored)
        {
            return true;
        }

        private bool CanLoad(object ignored)
        {
            return true;
        }

        private void ClearSearch()
        {
            CustomerSearchCriteria = new CustomerSearchCriteria();
            CustomerSearchCriteria.ClientName = string.Empty;
            CustomerSearchCriteria.Contact = string.Empty;
            CustomerSearchCriteria.CustomerNo = string.Empty;
            CustomerSearchCriteria.FName = string.Empty;
            CustomerSearchCriteria.LName = string.Empty;
            CustomerSearchCriteria.MeterNo = string.Empty;
            CustomerSearchCriteria.Phone = string.Empty;
            CustomerSearchCriteria.PropertyName = string.Empty;
            CustomerSearchCriteria.SalesCode = string.Empty;
            CustomerSearchCriteria.StreetName = string.Empty;
            CustomerSearchCriteria.StreetNo = string.Empty;
            CustomerSearchCriteria.StaffId = _user.UserId;
            CustomerSearchCriteria.IsCurrentAccount = true;
            CustomerSearchCriteria.Premise = string.Empty;
            Customers = new ObservableCollection<Customer>();
        }

        private void ClearSearch(object ignored)
        {
            ClearSearch();
        }

        private void ClearTopSearch()
        {
            CustomerNoSearchCriteria = new CustomerSearchCriteria();
            CustomerNoSearchCriteria.ClientName = string.Empty;
            CustomerNoSearchCriteria.Contact = string.Empty;
            CustomerNoSearchCriteria.CustomerNo = string.Empty;
            CustomerNoSearchCriteria.FName = string.Empty;
            CustomerNoSearchCriteria.LName = string.Empty;
            CustomerNoSearchCriteria.MeterNo = string.Empty;
            CustomerNoSearchCriteria.Phone = string.Empty;
            CustomerNoSearchCriteria.PropertyName = string.Empty;
            CustomerNoSearchCriteria.SalesCode = string.Empty;
            CustomerNoSearchCriteria.StreetName = string.Empty;
            CustomerNoSearchCriteria.StreetNo = string.Empty;
            CustomerNoSearchCriteria.StaffId = _user.UserId;
            CustomerNoSearchCriteria.Premise = string.Empty;
            Customers = new ObservableCollection<Customer>();
        }

        private void DeleteCustomer(object ignored)
        {
            if (SelectedCustomer != null && !string.IsNullOrEmpty(SelectedCustomer.CustomerNo))
            {

                IsBusy = true;
                ServiceAgent.DeleteCustomer(SelectedCustomer.CustomerNo, (s, e) =>
                {

                    if (e.Error != null)
                    {
                        HandleError(e.Error);
                    }
                    else
                    {
                        _regionManager.RequestNavigate("ModuleRegion", new Uri("SearchView", UriKind.Relative));
                    }

                    IsBusy = false;
                });
            }
        }

        private void SaveCustDetails(object ignored)
        {

            _eventAggregator.GetEvent<SaveCustomerEvent>().Publish(this._selectedCustomer);

        }

        private bool CanSave(object ignored)
        {
            return true;
        }

        private void ExecuteMethod(object parameter)
        {
            Uri SearchURI = new Uri("/SearchView", UriKind.Relative);
            _regionManager.RequestNavigate("ModuleRegion", SearchURI);
        }

        private void LoadContact(object parameter)
        {

            _moduleManager.LoadModuleCompleted -= ModuleManager_LoadModuleCompleted;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;

            _moduleManager.LoadModule("ContactsModule");

            Uri ContactsUri = new Uri("/ContactsView", UriKind.Relative);
            _regionManager.RequestNavigate("ModuleRegion", ContactsUri);
        }

        private void LoadCustomer(object parameter)
        {

            _moduleManager.LoadModuleCompleted -= ModuleManager_LoadModuleCompleted;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            _moduleManager.LoadModule("CustomersModule");

            Uri customersUri = new Uri("/FinanceView", UriKind.Relative);
            _regionManager.RequestNavigate("ModuleRegion", customersUri);


            //Validate if store instance custid or seqparty id is null
            if ((StoreInstance.Instance.SelectedCustomerId == null) && (StoreInstance.Instance.SelectedPartyId == null))
            {

            }
        }

        private void First(object ignored)
        {
            if (Customers != null && Customers.Count > 0)
            {
                SelectedCustomer = Customers[0];
            }
            _eventAggregator.GetEvent<FirstCustomerEvent>().Publish(this._selectedCustomer);
        }

        private int GetIndex()
        {
            int index = 0;
            if (Customers != null && Customers.Count > 0)
            {
                for (int i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i].CustomerNo == SelectedCustomer.CustomerNo)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;

        }

        private void Last(object ignored)
        {
            int currentindex = Customers.Count - 1;
            if (Customers != null && Customers.Count > 0)
            {
                SelectedCustomer = Customers[currentindex];
            }
            _eventAggregator.GetEvent<LastCustomerEvent>().Publish(this._selectedCustomer);
        }

        void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            if (e.ModuleInfo.ModuleName == "ContactsModule")
            {
                Uri contactsUri = new Uri("/ContactsView", UriKind.Relative);
                _regionManager.RequestNavigate("ModuleRegion", contactsUri);
            }
            else if (e.ModuleInfo.ModuleName == "CustomersModule")
            {
                Uri customersUri = new Uri("/FinanceView", UriKind.Relative);
                _regionManager.RequestNavigate("ModuleRegion", customersUri);

            }
            IsBusy = false;
        }

        private void Next(object ignored)
        {
            int currentIndex = GetIndex() + 1;
            if (currentIndex < Customers.Count)
            {
                if (Customers != null && Customers.Count > currentIndex)
                {
                    SelectedCustomer = Customers[currentIndex];
                }
            }
            _eventAggregator.GetEvent<NextCustomerEvent>().Publish(this.SelectedCustomer);


        }

        private void Previous(object ignored)
        {
            int currentIndex = GetIndex() - 1;
            if (currentIndex >= 0)
            {
                if (Customers != null && Customers.Count > currentIndex)
                {
                    SelectedCustomer = Customers[currentIndex];
                }
            }
            _eventAggregator.GetEvent<PreviousCustomerEvent>().Publish(this._selectedCustomer);
        }

        private void SearchCustNo(object ignored)
        {
            if (!string.IsNullOrEmpty(CustomerNoSearchCriteria.CustomerNo))
            {
                IsBusy = true;
                ServiceAgent.SearchCustomer(CustomerNoSearchCriteria, (s, e) =>
                {
                    if (e.Error == null)
                    {
                        Customers = e.Result;
                        if (Customers.Count > 0)
                        {
                            SelectedCustomer = Customers[0];
                        }
                        else
                        {
                            Message = ApplicationResources.GetString(ConstantResources.LTNORESULTSFOUND);
                        }
                    }
                    else
                    {
                        HandleError(e.Error);
                    }


                    _eventAggregator.GetEvent<HeaderCustomerNoSelectedEvent>().Publish(this._selectedCustomer);
                    IsBusy = false;
                });

            }
            else
            {
                Message = ApplicationResources.GetString(ConstantResources.LTENTERCUSTOMERNO);
            }
        }

        #endregion�Methods�

    }
}
















