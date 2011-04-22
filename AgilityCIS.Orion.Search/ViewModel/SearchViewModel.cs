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
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.Collections.ObjectModel;
using AgilityCIS.Orion.Common;
using Microsoft.Practices.Prism.Events;
using System.Linq;
using AgilityCIS.Orion.LocalizationManager;
using AgilityCIS.Orion.Common.Enums;
using Microsoft.Practices.Prism.Modularity;

namespace AgilityCIS.Orion.Search.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SearchViewModel : BaseViewModel, INavigationAware
    {
        #region Fields (27)

        private DelegateCommand<object> _clearCommand;
        private string _customerNo;
        private CustomerSearchCriteria _customerNoSearchCriteria;
        private ObservableCollection<Customer> _customers;
        private CustomerSearchCriteria _customerSearchCriteria;
        private CustomerSummary _customerSummaryDetails;
        private DelegateCommand<object> _deleteCustomerCommand;
        private IEventAggregator _eventAggregator;
        private DelegateCommand<object> _firstCommand;
        private bool _isLoadingCustDetails;
        private DelegateCommand<object> _lastCommand;
        private DelegateCommand<object> _loadCustomerCommand;
        [Import(AllowRecomposition = false)]
        public IModuleManager _moduleManager;
        private DelegateCommand<object> _nextCommand;
        private int _premisesCount;
        private DelegateCommand<object> _previousCommand;
        private RecentCustomerSearchResult _recentCustomerSearch;
        private ObservableCollection<RecentCustomerSearchResult> _recentCustomerSearchResults;
        private readonly IRegionManager _regionManager;
        private DelegateCommand<object> _searchCommand;
        private DelegateCommand<object> _searchCustNoCommand;
        private Customer _selectedCustomer;
        private Product _selectedProduct;
        private string _selectedSortedItem;
        private int _seqPartyId;
        private ObservableCollection<string> _sortCollection;
        private User _user;

        #endregion Fields

        #region Constructors (1)

        [ImportingConstructor]
        public SearchViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;
            _searchCommand = new DelegateCommand<object>(Search, CanSearch);
            _searchCustNoCommand = new DelegateCommand<object>(SearchCustNo, CanLoad);
            _deleteCustomerCommand = new DelegateCommand<object>(DeleteCustomer, CanLoad);
            _nextCommand = new DelegateCommand<object>(Next, CanLoad);
            _previousCommand = new DelegateCommand<object>(Previous, CanLoad);
            _lastCommand = new DelegateCommand<object>(Last, CanLoad);
            _firstCommand = new DelegateCommand<object>(First, CanLoad);
            _loadCustomerCommand = new DelegateCommand<object>(LoadCustomerAction, CanSelect);
            _clearCommand = new DelegateCommand<object>(ClearSearch, CanSelect);
            _eventAggregator = eventAggregator;
            _user = regionManager.Regions["MainContentRegion"].Context as User;
            ClearSearch();
            ClearTopSearch();
            LoadRecentSearch();
            HeaderCustomerSelectedEvent customerSelectedEvent = _eventAggregator.GetEvent<HeaderCustomerSelectedEvent>();
            customerSelectedEvent.Subscribe(CustomerSelectedEventHandler);
            HeaderCustomerNoSelectedEvent customerNoSelectedEvent = _eventAggregator.GetEvent<HeaderCustomerNoSelectedEvent>();
            customerNoSelectedEvent.Subscribe(CustomerNoSelectedEventHandler);

        }

        #endregion Constructors

        #region Properties (22)

        public DelegateCommand<object> ClearCommand
        {
            get { return _clearCommand; }
            set { _clearCommand = value; }
        }

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
                CustomersColl customerColl = new CustomersColl();
                for (int i = 0; i < this._customers.Count; i++)
                {
                    customerColl.Add(this._customers[i]);
                }

                _eventAggregator.GetEvent<CustomersLoadedEvent>().Publish(customerColl);
                if (this._customers != null)
                {
                    PremisesCount = this._customers.SelectMany(c => c.Products).Count();
                }
                else
                {
                    PremisesCount = 0;
                }
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

        public bool IsLoadingCustDetails
        {
            get { return _isLoadingCustDetails; }
            set { _isLoadingCustDetails = value; RaisePropertyChanged("IsLoadingCustDetails"); }
        }

        public DelegateCommand<object> LastCommand { get { return _lastCommand; } set { _lastCommand = value; } }

        public DelegateCommand<object> LoadCustomerCommand
        {
            get { return _loadCustomerCommand; }
            set
            {
                _loadCustomerCommand = value;
            }
        }

        public DelegateCommand<object> NextCommand { get { return _nextCommand; } set { _nextCommand = value; } }

        public int PremisesCount
        {
            get { return _premisesCount; }
            set
            {
                _premisesCount = value;
                RaisePropertyChanged("PremisesCount");
            }
        }

        public DelegateCommand<object> PreviousCommand { get { return _previousCommand; } set { _previousCommand = value; } }

        public RecentCustomerSearchResult RecentCustomerSearch
        {
            get { return _recentCustomerSearch; }
            set
            {
                _recentCustomerSearch = value;
                if (_recentCustomerSearch != null)
                {
                    IsBusy = true;
                    CustomerSearchCriteria criteria = new CustomerSearchCriteria();
                    criteria.CustomerNo = _recentCustomerSearch.SearchSeqPartyCode.ToString();
                    ServiceAgent.SearchCustomer(criteria, (s, e) =>
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

                        IsBusy = false;
                    });
                }

                RaisePropertyChanged("RecentCustomerSearch");
            }
        }

        public ObservableCollection<RecentCustomerSearchResult> RecentCustomerSearchResults
        {
            get { return _recentCustomerSearchResults; }
            set
            {
                _recentCustomerSearchResults = value; RaisePropertyChanged("RecentCustomerSearchResults");
            }
        }

        public DelegateCommand<object> SearchCommand { get { return _searchCommand; } set { _searchCommand = value; } }

        public DelegateCommand<object> SearchCustNoCommand { get { return _searchCustNoCommand; } set { _searchCustNoCommand = value; } }

        public Customer SelectedCustomer
        {
            get
            {
                return this._selectedCustomer;
            }
            set
            {
                if (this._selectedCustomer != null && value != null)
                {
                    if (this._selectedCustomer.CustomerNo != value.CustomerNo)
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

                                    StoreInstance.Instance.LoggedinCustNo = int.Parse(this._selectedCustomer.CustomerNo);
                                    StoreInstance.Instance.SelectedPartyId = SeqPartyId.ToString();
                                    
                                }
                            }
                        }
                        //Future ref
                        _eventAggregator.GetEvent<SearchCustomerSelectedEvent>().Publish(this._selectedCustomer);

                    }
                }
                else
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
                                StoreInstance.Instance.LoggedinCustNo = int.Parse(this._selectedCustomer.CustomerNo);
                                StoreInstance.Instance.SelectedPartyId = SeqPartyId.ToString();
                                StoreInstance.Instance.CustomerList = Customers;
                            }
                        }
                    }

                    _eventAggregator.GetEvent<SearchCustomerSelectedEvent>().Publish(this._selectedCustomer);
                }
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (this._selectedProduct != null)
                {
                    SeqPartyId = this._selectedProduct.SeqPartyId;
                }

                RaisePropertyChanged("SelectedProduct");
            }
        }

        public string SelectedSortItem
        {
            get
            {
                return this._selectedSortedItem;
            }
            set
            {
                this._selectedSortedItem = value;
                SortSearchResults();
                RaisePropertyChanged("SelectedSortItem");
            }
        }

        public int SeqPartyId
        {
            get { return _seqPartyId; }
            set
            {
                _seqPartyId = value;

                //Load customer summary details
                IsLoadingCustDetails = true;
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

                    IsLoadingCustDetails = false;
                });

                RaisePropertyChanged("SeqPartyId");
            }
        }

        public ObservableCollection<string> SortCollection
        {
            get
            {

                return this._sortCollection;
            }
            set
            {
                this._sortCollection = value;
                if (SortCollection != null && SortCollection.Count > 0)
                {
                    SelectedSortItem = SortCollection[0];
                }
                RaisePropertyChanged("SortCollection");
            }
        }

        #endregion Properties

        #region Methods (22)

        // Public Methods (4) 

        public void CustomerSelectedEventHandler(Customer customer)
        {
            SelectedCustomer = customer;
        }

        public void CustomerNoSelectedEventHandler(Customer customer)
        {
            ObservableCollection<Customer> custs = new ObservableCollection<Customer>();
            customer.Products = new ObservableCollection<Product>();
            custs.Add(customer);
            Customers = custs;
            RaisePropertyChanged("Customers");
            SelectedCustomer = customer;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add("CustomerID", this._customerNo);
            StoreInstance.Instance.SelectedCustomerId = this._customerNo;
            if (_customers != null)
            {
                Customer selCust = _customers.FirstOrDefault(sel => sel.CustomerNo == this._customerNo);
                if (selCust != null && selCust.Products != null && selCust.Products.Count > 0)
                {
                    StoreInstance.Instance.CustomerList = _customers;
                    navigationContext.Parameters.Add("SeqPartyId", selCust.Products[0].SeqPartyId.ToString());
                    StoreInstance.Instance.SelectedPartyId = selCust.Products[0].SeqPartyId.ToString();
                }
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // left intentionally

        }
        // Private Methods (18) 

        private bool CanLoad(object ignored)
        {
            return true;
        }

        private bool CanSearch(object ignored)
        {

            return true;
        }

        private bool CanSelect(object ignored)
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

        private void FillSortDropdown()
        {
            SortCollection = EnumReader.GetNameObservableCollection<CustomerSortParameters>();
            SelectedSortItem = SortCollection[0];

        }

        private void First(object ignored)
        {
            if (Customers != null && Customers.Count > 0)
            {
                SelectedCustomer = Customers[0];
            }
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
        }

        private void LoadCustomerAction(object customerNo)
        {
            IsBusy = true;

            _moduleManager.LoadModuleCompleted -= ModuleManager_LoadModuleCompleted;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this._customerNo = customerNo as string;
            _moduleManager.LoadModule("CustomersModule");
            Uri SearchURI = new Uri("/FinanceView", UriKind.Relative);
            _regionManager.RequestNavigate("ModuleRegion", SearchURI);
            IsBusy = false;
        }

        void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            if (e.ModuleInfo.ModuleName == "CustomersModule")
            {
                Uri SearchURI = new Uri("/FinanceView", UriKind.Relative);
                _regionManager.RequestNavigate("ModuleRegion", SearchURI);
            }

            IsBusy = false;
        }


        private void LoadRecentSearch()
        {
            ServiceAgent.GetRecentSearchResults(StoreInstance.Instance.LoggedinCustNo, (s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    RecentCustomerSearchResults = e.Result;
                }
            });
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
        }

        private void Search(object SearchCustNo)
        {
            if (!string.IsNullOrEmpty(CustomerSearchCriteria.ClientName) ||
               !string.IsNullOrEmpty(CustomerSearchCriteria.Contact) ||
               !string.IsNullOrEmpty(CustomerSearchCriteria.CustomerNo) ||
              !string.IsNullOrEmpty(CustomerSearchCriteria.Phone) ||
              !string.IsNullOrEmpty(CustomerSearchCriteria.PropertyName) ||
              !string.IsNullOrEmpty(CustomerSearchCriteria.SalesCode) ||
              !string.IsNullOrEmpty(CustomerSearchCriteria.StreetName) ||
              !string.IsNullOrEmpty(CustomerSearchCriteria.StreetNo) ||
   !string.IsNullOrEmpty(CustomerSearchCriteria.MeterNo) ||
                !string.IsNullOrEmpty(CustomerSearchCriteria.Premise))
            {
                IsBusy = true;
                ServiceAgent.SearchCustomer(CustomerSearchCriteria, (s, e) =>
                {
                    if (e.Error == null)
                    {
                        Customers = e.Result;
                        FillSortDropdown();
                        if (Customers.Count > 0)
                        {
                            SelectedCustomer = Customers[0];
                        }
                        else
                        {
                            Dialogs.Alert(ApplicationResources.GetString(ConstantResources.LTSEARCH), ApplicationResources.GetString(ConstantResources.LTNOCLIENTS), null);
                        }
                    }
                    else
                    {
                        HandleError(e.Error);
                    }

                    IsBusy = false;
                });
            }
            else
            {
                Dialogs.Alert(ApplicationResources.GetString(ConstantResources.LTSEARCHCRITERIA), ApplicationResources.GetString(ConstantResources.LTFILLSEARCHCRITERIA), null);
            }
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

                    IsBusy = false;
                });
            }
            else
            {
                Message = ApplicationResources.GetString(ConstantResources.LTENTERCUSTOMERNO);
            }
        }

        private void SortSearchResults()
        {
            if (SelectedSortItem != string.Empty)
            {
                if (SelectedSortItem == EnumReader.StringValueOf(CustomerSortParameters.CustomerNo))
                {
                    Customers = Customers.ToList().OrderBy(c => c.CustomerNo).ToObservableCollection();

                }
                else if (SelectedSortItem == EnumReader.StringValueOf(CustomerSortParameters.CustomerName))
                {
                    Customers = Customers.ToList().OrderBy(c => c.CustomerName).ToObservableCollection();
                }
                else if (SelectedSortItem == EnumReader.StringValueOf(CustomerSortParameters.SiteAddress))
                {

                    HandleError(new Exception(ApplicationResources.GetString(ConstantResources.LTSITESORTING)));
                }
                else if (SelectedSortItem == EnumReader.StringValueOf(CustomerSortParameters.PremiseAddress))
                {

                    HandleError(new Exception(ApplicationResources.GetString(ConstantResources.LTPREMISEADDRESSSORTING)));
                }

                if (Customers.Count > 0)
                {
                    SelectedCustomer = Customers[0];
                }

            }
        }

        #endregion Methods
    }


}
