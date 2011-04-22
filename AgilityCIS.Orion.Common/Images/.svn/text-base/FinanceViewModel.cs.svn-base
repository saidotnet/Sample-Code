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
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using AgilityCIS.Orion.Common;
using Microsoft.Practices.Prism.Events;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AgilityCIS.Orion.Common.Service;
using AgilityCIS.Orion.LocalizationManager;

namespace AgilityCIS.Orion.Customers.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FinanceViewModel : BaseViewModel, INavigationAware
    {
		#region Fields (41) 

        private ObservableCollection<AddressType> _addressTypes;
        private ObservableCollection<BillingCycle> _billingCycles;
        private ObservableCollection<BillingUnit> _billingUnits;
        private ObservableCollection<CardType> _cardTypes;
        private ObservableCollection<Company> _companies;
        private ObservableCollection<CreditCheckScore> _creditCheckScores;
        private ObservableCollection<CreditControlStatus> _creditControlStatuses;
        private CustomerSearchCriteria _customerNoSearchCriteria;
        private ObservableCollection<Customer> _customers;
        private CustomerSummary _customerSummaryDetails;
        private ObservableCollection<CustomerType> _customerTypes;
        private const string _defaultColor = "#FF000002";
        private DelegateCommand<object> _deleteCustomerCommand;
        private DelegateCommand<object> _firstCommand;
        private ObservableCollection<Industry> _industries;
        private ObservableCollection<InvoiceDelivery> _invoiceDeliveries;
        private ObservableCollection<InvoiceStyle> _invoiceStyles;
        private bool _isAlertExpires;
        private SolidColorBrush _isBankMandatory;
        private SolidColorBrush _isCardMandatory;
        private Visibility _isCompany;
        private const string _isMandatoryColor = "#FF5AD049";
        private Visibility _isResidential;
        private DelegateCommand<object> _lastCommand;
        private DelegateCommand<object> _loadSearchCommand;
        private DelegateCommand<object> _nextCommand;
        private ObservableCollection<Party> _parties;
        private ObservableCollection<PayMethod> _payMethods;
        private DelegateCommand<object> _previousCommand;
        private ObservableCollection<Priority> _priorities;
        private readonly IRegionManager _regionManager;
        private DelegateCommand<object> _saveCustDetailsCommand;
        private DelegateCommand<object> _searchCustNoCommand;
        private CustomerDetails _selectedCustomer;
        private string _selectedCustomerId;
        private Customer _selectedCustomerName;
        private PayMethod _selPayMethod;
        private string _seqPartyId;
        private ObservableCollection<TaxIndicator> _taxIndicators;
        private CustomerDetails _tempCustomer;
        private ObservableCollection<TreatmentType> _treatmentTypes;

		#endregion Fields 

		#region Constructors (1) 

        [ImportingConstructor]
        public FinanceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;

            _loadSearchCommand = new DelegateCommand<object>(NavigateToSearch, CanLoad);
            _searchCustNoCommand = new DelegateCommand<object>(SearchCustNo, CanLoad);
            _deleteCustomerCommand = new DelegateCommand<object>(DeleteCustomer, CanLoad);
            _firstCommand = new DelegateCommand<object>(LoadFirstCustomerDetails, CanLoad);
            _lastCommand = new DelegateCommand<object>(LoadLastCustomerDetails, CanLoad);
            _nextCommand = new DelegateCommand<object>(LoadNextCustomerDetails, CanLoad);
            _previousCommand = new DelegateCommand<object>(LoadPreviousCustomerDetails, CanLoad);
            _saveCustDetailsCommand = new DelegateCommand<object>(SaveCustDetails, CanSave);
            CustomerSummaryDetails = new CustomerSummary();
            SelectedCustomer = new CustomerDetails();
        }

		#endregion Constructors 

		#region Properties (35) 

        public ObservableCollection<AddressType> AddressTypes
        {
            get { return _addressTypes; }
            set
            {
                _addressTypes = value; RaisePropertyChanged("AddressTypes");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<BillingCycle> BillingCycles
        {
            get { return _billingCycles; }
            set
            {
                _billingCycles = value;
                RaisePropertyChanged("BillingCycles");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<BillingUnit> BillingUnits
        {
            get { return _billingUnits; }
            set
            {
                _billingUnits = value; RaisePropertyChanged("BillingUnits");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<CardType> CardTypes
        {
            get { return _cardTypes; }
            set
            {
                _cardTypes = value; RaisePropertyChanged("CardTypes");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set
            {
                _companies = value; RaisePropertyChanged("Companies");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<CreditCheckScore> CreditCheckScores
        {
            get { return _creditCheckScores; }
            set
            {
                _creditCheckScores = value; RaisePropertyChanged("CreditCheckScores");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<CreditControlStatus> CreditControlStatuses
        {
            get { return _creditControlStatuses; }
            set
            {
                _creditControlStatuses = value; RaisePropertyChanged("CreditControlStatuses");
                RaiseSelectedCustomerPropertyChanged();
            }
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

        public ObservableCollection<CustomerType> CustomerTypes
        {
            get { return _customerTypes; }
            set
            {
                _customerTypes = value; RaisePropertyChanged("CustomerTypes");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public DelegateCommand<object> DeleteCustomerCommand { get { return _deleteCustomerCommand; } set { _deleteCustomerCommand = value; } }

        public DelegateCommand<object> FirstCommand { get { return _firstCommand; } set { _firstCommand = value; } }

        public ObservableCollection<Industry> Industries
        {
            get { return _industries; }
            set
            {
                _industries = value;
                RaisePropertyChanged("Industries");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<InvoiceDelivery> InvoiceDeliveries
        {
            get { return _invoiceDeliveries; }
            set
            {
                _invoiceDeliveries = value; RaisePropertyChanged("InvoiceDeliveries");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<InvoiceStyle> InvoiceStyles
        {
            get { return _invoiceStyles; }
            set
            {
                _invoiceStyles = value; RaisePropertyChanged("InvoiceStyles");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public bool IsAlertExpires
        {
            get { return _isAlertExpires; }
            set
            {
                _isAlertExpires = value;
                RaisePropertyChanged("IsAlertExpires");
            }
        }

        public SolidColorBrush IsBankMandatory
        {
            get { return _isBankMandatory; }
            set
            {
                _isBankMandatory = value;
                RaisePropertyChanged("IsBankMandatory");
            }
        }

        public SolidColorBrush IsCardMandatory
        {
            get { return _isCardMandatory; }
            set
            {
                _isCardMandatory = value;
                RaisePropertyChanged("IsCardMandatory");
            }
        }

        public Visibility IsCompany
        {
            get { return _isCompany; }
            set
            {
                _isCompany = value;
                RaisePropertyChanged("IsCompany");
            }
        }

        public Visibility IsResidential
        {
            get { return _isResidential; }
            set
            {
                _isResidential = value;
                RaisePropertyChanged("IsResidential");
            }
        }

        public DelegateCommand<object> LastCommand { get { return _lastCommand; } set { _lastCommand = value; } }

        public DelegateCommand<object> LoadSearchCommand { get { return _loadSearchCommand; } set { _loadSearchCommand = value; } }

        public DelegateCommand<object> NextCommand { get { return _nextCommand; } set { _nextCommand = value; } }

        public ObservableCollection<Party> Parties
        {
            get { return _parties; }
            set
            {
                _parties = value;
                RaisePropertyChanged("Parties");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<PayMethod> PayMethods
        {
            get { return _payMethods; }
            set
            {
                _payMethods = value; RaisePropertyChanged("PayMethods");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public DelegateCommand<object> PreviousCommand { get { return _previousCommand; } set { _previousCommand = value; } }

        public ObservableCollection<Priority> Priorities
        {
            get { return _priorities; }
            set { _priorities = value; RaisePropertyChanged("Priorities"); }
        }

        public DelegateCommand<object> SaveCustDetailsCommand
        {
            get { return _saveCustDetailsCommand; }
            set { _saveCustDetailsCommand = value; }
        }

        public DelegateCommand<object> SearchCustNoCommand { get { return _searchCustNoCommand; } set { _searchCustNoCommand = value; } }

        public CustomerDetails SelectedCustomer
        {
            get
            {
                return this._selectedCustomer;
            }
            set
            {
                this._selectedCustomer = value;
                if (this.BillingCycles != null && this.SelectedCustomer.SeqBillCycle != null)
                {
                    this.SelectedCustomer.SeqBillCycle = this.BillingCycles.FirstOrDefault(sel => sel.BillingCycleId == this.SelectedCustomer.SeqBillCycle.BillingCycleId);
                }

                if (this.PayMethods != null && this.SelectedCustomer.PmtMethod != null)
                {
                    this.SelectedCustomer.PmtMethod = this.PayMethods.FirstOrDefault(sel => sel.PayMethodId == this.SelectedCustomer.PmtMethod.PayMethodId);
                    this.SelPayMethod = this.SelectedCustomer.PmtMethod;
                }

                if (this.Companies != null && this.SelectedCustomer.CustCompany != null)
                {
                    this.SelectedCustomer.CustCompany = this.Companies.FirstOrDefault(sel => sel.CompanyId == this.SelectedCustomer.CustCompany.CompanyId);
                }

                if (this.CreditCheckScores != null && this.SelectedCustomer.Score != null)
                {
                    this.SelectedCustomer.Score = this.CreditCheckScores.FirstOrDefault(sel => sel.CreditCheckScoreId == this.SelectedCustomer.Score.CreditCheckScoreId);
                }

                if (this.CreditControlStatuses != null && this.SelectedCustomer.CreditCtrlStatus != null)
                {
                    this.SelectedCustomer.CreditCtrlStatus = this.CreditControlStatuses.FirstOrDefault(sel => sel.CreditControlStatusId == this.SelectedCustomer.CreditCtrlStatus.CreditControlStatusId);
                }

                if (this.CustomerTypes != null && this.SelectedCustomer.CustType != null)
                {
                    this.SelectedCustomer.CustType = this.CustomerTypes.FirstOrDefault(sel => sel.CustomerTypeId == this.SelectedCustomer.CustType.CustomerTypeId);

                }

                if (this.InvoiceDeliveries != null && this.SelectedCustomer.InvDelivery != null)
                {
                    this.SelectedCustomer.InvDelivery = this.InvoiceDeliveries.FirstOrDefault(sel => sel.InvoiceDeliveryId == this.SelectedCustomer.InvDelivery.InvoiceDeliveryId);

                }

                if (this.InvoiceStyles != null && this.SelectedCustomer.InvStyle != null)
                {
                    this.SelectedCustomer.InvStyle = this.InvoiceStyles.FirstOrDefault(sel => sel.InvoiceStyleId == this.SelectedCustomer.InvStyle.InvoiceStyleId);
                }

                if (this.PayMethods != null && this.SelectedCustomer.PmtMethod != null)
                {
                    this.SelectedCustomer.PmtMethod = this.PayMethods.FirstOrDefault(sel => sel.PayMethodId == this.SelectedCustomer.PmtMethod.PayMethodId);
                    this.SelPayMethod = this.SelectedCustomer.PmtMethod;
                }

                if (this.TaxIndicators != null && this.SelectedCustomer.SeqTaxIndicator != null)
                {
                    this.SelectedCustomer.SeqTaxIndicator = this.TaxIndicators.FirstOrDefault(sel => sel.TaxIndicatorId == this.SelectedCustomer.SeqTaxIndicator.TaxIndicatorId);
                }

                if (this.Priorities != null && this.SelectedCustomer.SeqPriority != null)
                {
                    this.SelectedCustomer.SeqPriority = this.Priorities.FirstOrDefault(sel => sel.PriorityId == this.SelectedCustomer.SeqPriority.PriorityId);
                }

                if (this.TreatmentTypes != null && this.SelectedCustomer.Type != null)
                {
                    this.SelectedCustomer.Type = this.TreatmentTypes.FirstOrDefault(sel => sel.TreatmentTypeId == this.SelectedCustomer.Type.TreatmentTypeId);
                }

                if (this.Industries != null && this.SelectedCustomer.IndustryDetails != null)
                {
                    this.SelectedCustomer.IndustryDetails = this.Industries.FirstOrDefault(sel => sel.IndustryId == this.SelectedCustomer.IndustryDetails.IndustryId);
                }

                if (this.Parties != null && this.SelectedCustomer.AccMgr != null)
                {
                    this.SelectedCustomer.AccMgr = this.Parties.FirstOrDefault(sel => sel.SeqPartyId == this.SelectedCustomer.AccMgr.SeqPartyId);
                }

                _tempCustomer = Utilities<CustomerDetails>.DeepCopy(this._selectedCustomer);
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public Customer SelectedCustomerName
        {
            get
            {
                return this._selectedCustomerName;
            }
            set
            {
                this._selectedCustomerName = value;
                if (_selectedCustomerName != null)
                {
                    var objCustomer = StoreInstance.Instance.CustomerList.ToList().FirstOrDefault(c => c.CustomerNo == SelectedCustomerName.CustomerNo);
                    string customerID = objCustomer.CustomerNo;
                    if (objCustomer.Products != null && objCustomer.Products.Count > 0)
                    {
                        int productID = objCustomer.Products[0].SeqPartyId;
                        GetCustomerDetails(productID.ToString());
                    }
                }
                RaisePropertyChanged("SelectedCustomerName");
            }
        }

        public PayMethod SelPayMethod
        {
            get { return _selPayMethod; }
            set
            {
                _selPayMethod = value;
                if (_selPayMethod != null)
                {
                    if (_selPayMethod.IsBankAccReqd)
                    {

                        IsBankMandatory = new SolidColorBrush(Color.FromArgb(
            Convert.ToByte(_isMandatoryColor.Substring(1, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(3, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(5, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(7, 2), 16)));
                    }
                    else
                    {
                        IsBankMandatory = new SolidColorBrush(Color.FromArgb(
         Convert.ToByte(_defaultColor.Substring(1, 2), 16),
         Convert.ToByte(_defaultColor.Substring(3, 2), 16),
         Convert.ToByte(_defaultColor.Substring(5, 2), 16),
         Convert.ToByte(_defaultColor.Substring(7, 2), 16)));
                    }

                    if (_selPayMethod.IsCreditCardReqd)
                    {

                        IsCardMandatory = new SolidColorBrush(Color.FromArgb(
            Convert.ToByte(_isMandatoryColor.Substring(1, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(3, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(5, 2), 16),
            Convert.ToByte(_isMandatoryColor.Substring(7, 2), 16)));
                    }
                    else
                    {
                        IsCardMandatory = new SolidColorBrush(Color.FromArgb(
         Convert.ToByte(_defaultColor.Substring(1, 2), 16),
         Convert.ToByte(_defaultColor.Substring(3, 2), 16),
         Convert.ToByte(_defaultColor.Substring(5, 2), 16),
         Convert.ToByte(_defaultColor.Substring(7, 2), 16)));
                    }
                }

                RaisePropertyChanged("SelPayMethod");
            }
        }

        public ObservableCollection<TaxIndicator> TaxIndicators
        {
            get { return _taxIndicators; }
            set
            {
                _taxIndicators = value; RaisePropertyChanged("TaxIndicators");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

        public ObservableCollection<TreatmentType> TreatmentTypes
        {
            get { return _treatmentTypes; }
            set
            {
                _treatmentTypes = value; RaisePropertyChanged("TreatmentTypes");
                RaiseSelectedCustomerPropertyChanged();
            }
        }

		#endregion Properties 

		#region Methods (44) 

		// Public Methods (5) 

        public void FundAddedEventHandler(Customer fundOrder)
        {

        }

        public bool FundOrderFilter(Customer fundOrder)
        {
            // return fundOrder.CustomerId == _customerId;
            return true;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // left intentionally
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IsBusy = true;
            _selectedCustomerId = navigationContext.Parameters["CustomerID"];
            _seqPartyId = navigationContext.Parameters["SeqPartyId"];
            CustomerNoSearchCriteria = new CustomerSearchCriteria();
            IsCompany = Visibility.Collapsed;

            //Load master data
            LoadBillingCycles();

            //Load invoice styles
            LoadInvoiceStyles();

            //Load invoice deliveries
            LoadInvoiceDeliveries();

            //Load credit check scores
            LoadCreditCheckScores();

            LoadPaymentMethods();

            LoadCardTypes();

            LoadCreditControlStatuses();

            LoadTreatmentTypes();

            LoadCompanies();

            LoadCustomerTypes();

            LoadAddressTypes();

            LoadTaxIndicators();

            LoadBillingUnits();

            LoadPriorities();

            LoadIndustries();

            LoadParties();

            GetDataforCustomerNameDropdown();

            GetCustomerDetails(_seqPartyId);

        }
		// Private Methods (39) 

        private bool CanLoad(object ignored)
        {
            return true;
        }

        private bool CanSave(object ignored)
        {
            return true;
        }

        private bool CheckForValidInputs()
        {
            bool retVal = true;

            try
            {
                double.Parse(SelectedCustomer.CreditLimit);
            }
            catch
            {
                Message = ApplicationResources.GetString(ConstantResources.LTINCORRECTCREDITLIMIT);
                retVal = false;
            }

            return retVal;
        }

        private void DeleteCustomer(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                DeleteSelectedCustomer();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        DeleteSelectedCustomer();
                                    }
                                }
                                );
            }

        }

        private void DeleteSelectedCustomer()
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
                        _regionManager.RequestNavigate("MainContentRegion", new Uri("SearchView", UriKind.Relative));
                    }

                    IsBusy = false;
                });
            }
        }

        private void GetCustomerDetails(string seqPartyId)
        {
            IsBusy = true;
            // Load customer details based on selected customer       
            if (!string.IsNullOrEmpty(seqPartyId))
            {
                //SelectedCustomer = ServiceAgent.LoadCustomerDetails(int.Parse(selectedCustomerId));
                ServiceAgent.LoadCustomerDetails(int.Parse(seqPartyId), (s, e) =>
                {
                    if (e.Error != null)
                    {
                        HandleError(e.Error);
                    }
                    else
                    {
                        SelectedCustomer = e.Result;

                        if (e.Result.CustomerNo != null)
                        {
                            _selectedCustomerName = StoreInstance.Instance.CustomerList.FirstOrDefault(sel => sel.CustomerNo == e.Result.CustomerNo);
                            RaisePropertyChanged("SelectedCustomerName");
                        }

                        // The logic written below is dirty. Could not find a better way though!
                        if (SelectedCustomer.CustType != null)
                        {
                            if (SelectedCustomer.CustType.CustomerTypeId == 8)
                            {
                                IsCompany = Visibility.Visible;
                            }
                            else
                            {
                                IsCompany = Visibility.Collapsed;
                            }

                            if (SelectedCustomer.CustType.CustomerTypeId == 9)
                            {
                                IsResidential = Visibility.Visible;
                            }
                            else
                            {
                                IsResidential = Visibility.Collapsed;
                            }
                        }

                        if (e.Result.AlertExpiryDate != null && e.Result.AlertExpiryDate.HasValue &&
                            e.Result.AlertExpiryDate > DateTime.UtcNow)
                        {
                            this.Dialogs.Alert("Alert", e.Result.Alert, null);
                        }

                        SelPayMethod = SelectedCustomer.PmtMethod;
                        IsAlertExpires = SelectedCustomer.IsAlertExpires;
                    }

                    IsBusy = false;
                });

                if (!string.IsNullOrEmpty(seqPartyId))
                {
                    ServiceAgent.LoadCustomerSummary(int.Parse(seqPartyId), (s, e) =>
                    {
                        if (e.Error == null)
                        {
                            CustomerSummaryDetails = e.Result;

                        }
                        else
                        {
                            HandleError(e.Error);
                        }

                        IsBusy = false;
                    });
                }
            }
        }

        private void GetDataforCustomerNameDropdown()
        {
            Customers = StoreInstance.Instance.CustomerList;
        }

        private int GetIndex()
        {
            int index = 0;
            if (StoreInstance.Instance.CustomerList != null && StoreInstance.Instance.CustomerList.Count > 0)
            {
                for (int i = 0; i < StoreInstance.Instance.CustomerList.Count; i++)
                {
                    if (StoreInstance.Instance.CustomerList[i].CustomerNo.ToString() == SelectedCustomer.CustomerNo)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;

        }

        private bool IsDirty()
        {
            if (this._tempCustomer != null && this._selectedCustomer != null)
            {
                if (this._tempCustomer.AccMgrName != this._selectedCustomer.AccMgrName)
                {
                    return true;
                }
                else if (this._tempCustomer.AgcRewards != this._selectedCustomer.AgcRewards)
                {
                    return true;
                }
                else if (this._tempCustomer.Alert != this._selectedCustomer.Alert)
                {
                    return true;
                }
                else if (this._tempCustomer.AlertExpiryDate != this._selectedCustomer.AlertExpiryDate)
                {
                    return true;
                }
                else if (this._tempCustomer.AvgMonthlySpend != this._selectedCustomer.AvgMonthlySpend)
                {
                    return true;
                }
                else if (this._tempCustomer.Bank != this._selectedCustomer.Bank)
                {
                    return true;
                }
                else if (this._tempCustomer.BankAccName != this._selectedCustomer.BankAccName)
                {
                    return true;
                }
                else if (this._tempCustomer.BankAccNo != this._selectedCustomer.BankAccNo)
                {
                    return true;
                }
                else if (this._tempCustomer.BankBranch != this._selectedCustomer.BankBranch)
                {
                    return true;
                }
                else if (this._tempCustomer.BillingContactName != this._selectedCustomer.BillingContactName)
                {
                    return true;
                }
                else if (this._tempCustomer.BillNotes != this._selectedCustomer.BillNotes)
                {
                    return true;
                }
                else if (this._tempCustomer.SeqBillingUnit != null && this._selectedCustomer.SeqBillingUnit != null &&
               this._tempCustomer.SeqBillingUnit.BillingUnitId != this._selectedCustomer.SeqBillingUnit.BillingUnitId)
                {
                    return true;
                }
                else if (this._tempCustomer.BondAmt != this._selectedCustomer.BondAmt)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardExpiry != this._selectedCustomer.CreditCardExpiry)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardName != this._selectedCustomer.CreditCardName)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardNo != this._selectedCustomer.CreditCardNo)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardType != null && this._selectedCustomer.CreditCardType != null &&
                    this._tempCustomer.CreditCardType.CardTypeCode != this._selectedCustomer.CreditCardType.CardTypeCode)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardTypeCode != this._selectedCustomer.CreditCardTypeCode)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCardVerifyNo != this._selectedCustomer.CreditCardVerifyNo)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditCtrlStatus != null && this._selectedCustomer.CreditCtrlStatus != null &&
                   this._tempCustomer.CreditCtrlStatus.CreditControlStatusId != this._selectedCustomer.CreditCtrlStatus.CreditControlStatusId)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditLimit != this._selectedCustomer.CreditLimit)
                {
                    return true;
                }
                else if (this._tempCustomer.CreditStatusCode != this._selectedCustomer.CreditStatusCode)
                {
                    return true;
                }
                else if (this._tempCustomer.CustAddress != this._selectedCustomer.CustAddress)
                {
                    return true;
                }

                else if (this._tempCustomer.CustCompany != null && this._selectedCustomer.CustCompany != null &&
                    this._tempCustomer.CustCompany.CompanyId != this._selectedCustomer.CustCompany.CompanyId)
                {
                    return true;
                }

                else if (this._tempCustomer.CustomerFName != this._selectedCustomer.CustomerFName)
                {
                    return true;
                }
                else if (this._tempCustomer.CustomerInitial != this._selectedCustomer.CustomerInitial)
                {
                    return true;
                }
                else if (this._tempCustomer.CustomerLName != this._selectedCustomer.CustomerLName)
                {
                    return true;
                }
                else if (this._tempCustomer.CustomerName != this._selectedCustomer.CustomerName)
                {
                    return true;
                }
                else if (this._tempCustomer.CustomerNo != this._selectedCustomer.CustomerNo)
                {
                    return true;
                }
                else if (this._tempCustomer.CustType != null && this._selectedCustomer.CustType != null &&
                    this._tempCustomer.CustType.CustomerTypeId != this._selectedCustomer.CustType.CustomerTypeId)
                {
                    return true;
                }
                else if (this._tempCustomer.DateDetailsConfirmed != this._selectedCustomer.DateDetailsConfirmed)
                {
                    return true;
                }
                else if (this._tempCustomer.DecisionMakerName != this._selectedCustomer.DecisionMakerName)
                {
                    return true;
                }
                else if (this._tempCustomer.DistrictCode != this._selectedCustomer.DistrictCode)
                {
                    return true;
                }
                else if (this._tempCustomer.EMailAddress != this._selectedCustomer.EMailAddress)
                {
                    return true;
                }
                else if (this._tempCustomer.Employer != this._selectedCustomer.Employer)
                {
                    return true;
                }
                else if (this._tempCustomer.EstimateDate != this._selectedCustomer.EstimateDate)
                {
                    return true;
                }
                else if (this._tempCustomer.Fax != this._selectedCustomer.Fax)
                {
                    return true;
                }
                else if (this._tempCustomer.IndustryDetails != null && this._selectedCustomer.IndustryDetails != null
                    && this._tempCustomer.IndustryDetails.IndustryId != this._selectedCustomer.IndustryDetails.IndustryId)
                {
                    return true;
                }
                else if (this._tempCustomer.InsertedOn != this._selectedCustomer.InsertedOn)
                {
                    return true;
                }
                else if (this._tempCustomer.InvDelivery != null && this._selectedCustomer.InvDelivery != null &&
                   this._tempCustomer.InvDelivery.InvoiceDeliveryId != this._selectedCustomer.InvDelivery.InvoiceDeliveryId)
                {
                    return true;
                }
                else if (this._tempCustomer.InvStyle != null && this._selectedCustomer.InvStyle != null &&
                   this._tempCustomer.InvStyle.InvoiceStyleId != this._selectedCustomer.InvStyle.InvoiceStyleId)
                {
                    return true;
                }
                else if (this._tempCustomer.IsAlertExpires != this._selectedCustomer.IsAlertExpires)
                {
                    return true;
                }
                else if (this._tempCustomer.IsCorrespondenceByEMail != this._selectedCustomer.IsCorrespondenceByEMail)
                {
                    return true;
                }
                else if (this._tempCustomer.IsCorrespondenceByPost != this._selectedCustomer.IsCorrespondenceByPost)
                {
                    return true;
                }
                else if (this._tempCustomer.IsDeveloper != this._selectedCustomer.IsDeveloper)
                {
                    return true;
                }
                else if (this._tempCustomer.IsNameOverride != this._selectedCustomer.IsNameOverride)
                {
                    return true;
                }
                else if (this._tempCustomer.Notes != this._selectedCustomer.Notes)
                {
                    return true;
                }
                else if (this._tempCustomer.OverdueAmt != this._selectedCustomer.OverdueAmt)
                {
                    return true;
                }
                else if (this._tempCustomer.Password != this._selectedCustomer.Password)
                {
                    return true;
                }
                else if (this._tempCustomer.Phone != this._selectedCustomer.Phone)
                {
                    return true;
                }
                else if (this._tempCustomer.PmtMethod != null && SelPayMethod != null &&
                  this._tempCustomer.PmtMethod.PayMethodId != SelPayMethod.PayMethodId)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalAddr1 != this._selectedCustomer.PostalAddr1)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalAddr2 != this._selectedCustomer.PostalAddr2)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalAddr3 != this._selectedCustomer.PostalAddr3)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalAddr4 != this._selectedCustomer.PostalAddr4)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalAddr5 != this._selectedCustomer.PostalAddr5)
                {
                    return true;
                }
                else if (this._tempCustomer.PostalPostCode != this._selectedCustomer.PostalPostCode)
                {
                    return true;
                }
                else if (this._tempCustomer.RestaurantAssnNo != this._selectedCustomer.RestaurantAssnNo)
                {
                    return true;
                }
                else if (this._tempCustomer.SeqPriority != null && this._selectedCustomer.SeqPriority != null &&
                  this._tempCustomer.SeqPriority.PriorityId != this._selectedCustomer.SeqPriority.PriorityId)
                {
                    return true;
                }
                else if (this._tempCustomer.Score != null && this._selectedCustomer.Score != null &&
                   this._tempCustomer.Score.CreditCheckScoreId != this._selectedCustomer.Score.CreditCheckScoreId)
                {
                    return true;
                }
                else if (this._tempCustomer.SeqBillCycle != null && this._selectedCustomer.SeqBillCycle != null &&
                    this._tempCustomer.SeqBillCycle.BillingCycleId != this._selectedCustomer.SeqBillCycle.BillingCycleId)
                {
                    return true;
                }
                else if (this._tempCustomer.STDCode != this._selectedCustomer.STDCode)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddr1 != this._selectedCustomer.StreetAddr1)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddr2 != this._selectedCustomer.StreetAddr2)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddr3 != this._selectedCustomer.StreetAddr3)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddr4 != this._selectedCustomer.StreetAddr4)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddr5 != this._selectedCustomer.StreetAddr5)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetAddrNo != this._selectedCustomer.StreetAddrNo)
                {
                    return true;
                }
                else if (this._tempCustomer.StreetPostCode != this._selectedCustomer.StreetPostCode)
                {
                    return true;
                }
                else if (this._tempCustomer.SeqTaxIndicator != null && this._selectedCustomer.SeqTaxIndicator != null &&
                   this._tempCustomer.SeqTaxIndicator.TaxIndicatorId != this._selectedCustomer.SeqTaxIndicator.TaxIndicatorId)
                {
                    return true;
                }
                else if (this._tempCustomer.TradingName != this._selectedCustomer.TradingName)
                {
                    return true;
                }
                else if (this._tempCustomer.WebAddress != this._selectedCustomer.WebAddress)
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadAddressTypes()
        {
            ServiceAgent.GetAddressTypes((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    AddressTypes = e.Result;
                }
            });
        }

        private void LoadBillingCycles()
        {
            ServiceAgent.GetBillingCycles((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    BillingCycles = e.Result;
                }
            });
        }

        private void LoadBillingUnits()
        {
            ServiceAgent.GetBillingUnits((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    BillingUnits = e.Result;
                }
            });
        }

        private void LoadCardTypes()
        {
            ServiceAgent.GetCardTypes((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    CardTypes = e.Result;
                }
            });
        }

        private void LoadCompanies()
        {
            ServiceAgent.GetCompanies((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    Companies = e.Result;
                }
            });
        }

        private void LoadCreditCheckScores()
        {
            ServiceAgent.GetCreditCheckScores((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    CreditCheckScores = e.Result;
                }
            });
        }

        private void LoadCreditControlStatuses()
        {
            ServiceAgent.GetCreditControlStatus((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    CreditControlStatuses = e.Result;
                }
            });
        }

        private void LoadCustomerTypes()
        {
            ServiceAgent.GetCustomerTypes((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    CustomerTypes = e.Result;
                }
            });
        }

        private void LoadFirstCustomerDetails(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                MovetoFirstCustomer();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        MovetoFirstCustomer();
                                    }
                                }
                                );
            }

        }

        private void LoadIndustries()
        {
            ServiceAgent.GetIndustries((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    Industries = e.Result;
                }
            });
        }

        private void LoadInvoiceDeliveries()
        {
            ServiceAgent.GetInvoiceDeliveries((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    InvoiceDeliveries = e.Result;
                }
            });
        }

        private void LoadInvoiceStyles()
        {
            ServiceAgent.GetInvoiceStyles((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    InvoiceStyles = e.Result;
                }
            });
        }

        private void LoadLastCustomerDetails(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                MovetoLastCustomer();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        MovetoLastCustomer();
                                    }
                                }
                                );
            }

        }

        private void LoadNextCustomerDetails(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                MoveToNextCustomer();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        MoveToNextCustomer();
                                    }
                                }
                                );
            }

        }

        private void LoadParties()
        {
            ServiceAgent.GetParties((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    Parties = e.Result;
                }
            });
        }

        private void LoadPaymentMethods()
        {
            ServiceAgent.GetPaymentMethods((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    PayMethods = e.Result;
                }
            });
        }

        private void LoadPreviousCustomerDetails(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                MovetoPreviousCustomer();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        MovetoPreviousCustomer();
                                    }
                                }
                                );
            }

        }

        private void LoadPriorities()
        {
            ServiceAgent.GetPriorities((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    Priorities = e.Result;
                }
            });
        }

        private void LoadTaxIndicators()
        {
            ServiceAgent.GetTaxIndicators((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    TaxIndicators = e.Result;
                }
            });
        }

        private void LoadTreatmentTypes()
        {
            ServiceAgent.GetTreatmentTypes((s, e) =>
            {
                if (e.Error != null)
                {
                    HandleError(e.Error);
                }
                else
                {
                    TreatmentTypes = e.Result;
                }
            });
        }

        private void MovetoFirstCustomer()
        {
            if (StoreInstance.Instance.CustomerList.Count > 0)
            {
                SelectedCustomerName = StoreInstance.Instance.CustomerList[0];
            }
        }

        private void MovetoLastCustomer()
        {
            int index = StoreInstance.Instance.CustomerList.Count - 1;
            //string customerNo = StoreInstance.Instance.CustomerList[index].CustomerNo.ToString();
            //string productID = StoreInstance.Instance.CustomerList[index].Products[0].SeqPartyId.ToString();
            //GetCustomerDetails(customerNo, productID);
            if (StoreInstance.Instance.CustomerList.Count > index && index != -1)
            {
                SelectedCustomerName = StoreInstance.Instance.CustomerList[index];
            }
        }

        private void MoveToNextCustomer()
        {
            int index = GetIndex() + 1;

            if (StoreInstance.Instance.CustomerList.Count > index && index != -1)
            {
                SelectedCustomerName = StoreInstance.Instance.CustomerList[index];
            }

        }

        private void MovetoPreviousCustomer()
        {
            int index = GetIndex() - 1;
            if (StoreInstance.Instance.CustomerList.Count > index && index != -1)
            {
                SelectedCustomerName = StoreInstance.Instance.CustomerList[index];
            }
        }

        private void NavigateToSearch(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                _regionManager.RequestNavigate("MainContentRegion", new Uri("SearchView", UriKind.Relative));
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        _regionManager.RequestNavigate("MainContentRegion", new Uri("SearchView", UriKind.Relative));
                                    }
                                }
                                );
            }
        }

        private void RaiseSelectedCustomerPropertyChanged()
        {
            RaisePropertyChanged("SelectedCustomer");
        }

        private void SaveCustDetails(object ignored)
        {

            string ValidationMessage = ValidateMandatoryFields();

            if (ValidationMessage == string.Empty)
            {
                bool isInputValid = CheckForValidInputs();
                if (isInputValid)
                {
                    IsBusy = true;
                    SelectedCustomer.PmtMethod = SelPayMethod;
                    SelectedCustomer.IsAlertExpires = IsAlertExpires;
                    ServiceAgent.SaveCustomerDetails(SelectedCustomer, (s, e) =>
                    {
                        if (e.Error != null)
                        {
                            HandleError(e.Error);
                        }
                        else
                        {
                            _tempCustomer = Utilities<CustomerDetails>.DeepCopy(this.SelectedCustomer);
                            GetCustomerDetails(_seqPartyId);
                        }

                        IsBusy = false;
                    });
                }
            }
            else
            {
                ValidationMessage = string.Concat(ApplicationResources.GetString(ConstantResources.LTPLEASEENTER), "  ", ValidationMessage.Remove(ValidationMessage.Length - 1));
                Message = ValidationMessage;
            }

        }

        private void SearchCustNo(object ignored)
        {
            bool isDirty = false;
            isDirty = IsDirty();

            if (!isDirty)
            {
                SearchCustNoOnConfirmation();
            }
            else
            {
                Dialogs.Confirm(ApplicationResources.GetString(ConstantResources.LTCONFIRMATION),
                                ApplicationResources.GetString(ConstantResources.LTCANCELCHANGES),
                                (DialogResult result) =>
                                {
                                    if (result.Result.Value)
                                    {
                                        SearchCustNoOnConfirmation();
                                    }
                                });
            }


        }

        private void SearchCustNoOnConfirmation()
        {
            if (!string.IsNullOrEmpty(CustomerNoSearchCriteria.CustomerNo))
            {
                ServiceAgent.SearchCustomer(CustomerNoSearchCriteria, (s, e) =>
                {
                    if (e.Error == null)
                    {

                        if (e.Result != null && e.Result.Count > 0 && e.Result[0].Products != null && e.Result[0].Products.Count > 0)
                        {
                            StoreInstance.Instance.CustomerList.Clear();
                            StoreInstance.Instance.CustomerList = e.Result;
                            Customers = StoreInstance.Instance.CustomerList;
                            if (Customers != null && Customers.Count > 0)
                            {
                                SelectedCustomerName = Customers[0];
                            }
                        }
                        else
                        {
                            Message = ApplicationResources.GetString(ConstantResources.LTNORESULTSFOUND);
                        }
                    }
                    else
                    {
                        Message = ApplicationResources.GetString(ConstantResources.LTNORESULTSFOUND);
                    }
                });
            }
            else
            {
                Message = ApplicationResources.GetString(ConstantResources.LTENTERCUSTOMERNO);
            }
        }

        private string ValidateMandatoryFields()
        {

            StringBuilder errorMsg = new StringBuilder();
            if (IsCompany == Visibility.Visible)
            {
                if (SelectedCustomer.CustomerName == null || SelectedCustomer.CustomerName.Trim() == string.Empty)
                {
                    errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTCOMPANYNAME), ", "));
                }

                if (SelectedCustomer.SeqPriority == null || SelectedCustomer.SeqPriority.PriorityId == 0)
                {
                    errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTPRIORITY), ", "));
                }

                if (SelectedCustomer.IndustryDetails == null || SelectedCustomer.IndustryDetails.IndustryId == 0)
                {
                    errorMsg.Append(AgilityCIS.Orion.LocalizationManager.Resources.Resource.ltIndustry + ", ");
                }
            }
            else
            {
                if (SelectedCustomer.CustomerFName == null || SelectedCustomer.CustomerFName.Trim() == string.Empty)
                {
                    errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTRESIDENCENAME), ", "));
                }

                if (SelectedCustomer.CustomerLName == null || SelectedCustomer.CustomerLName.Trim() == string.Empty)
                {
                    errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTLASTNAME), ", "));
                }
            }

            //Credit limit


            if (SelectedCustomer.CustType == null || SelectedCustomer.CustType.CustomerTypeId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTCUSTOMERTYPE), ", "));
            }

            if (SelectedCustomer.Phone == null || SelectedCustomer.Phone.Trim() == string.Empty)
            {
                errorMsg.Append(AgilityCIS.Orion.LocalizationManager.Resources.Resource.Phone + ", ");
            }

            if (SelectedCustomer.PostalAddr1 == null || SelectedCustomer.PostalAddr1.Trim() == string.Empty)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTPOSTALADDRESS), ", "));
            }

            if (SelectedCustomer.StreetAddr1 == null || SelectedCustomer.StreetAddr1.Trim() == string.Empty)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTSTREETADDRESS), ", "));
            }

            if (SelectedCustomer.SeqBillCycle == null || SelectedCustomer.SeqBillCycle.BillingCycleId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTBILLCYCLE), ", "));

            }

            if (SelectedCustomer.InvStyle == null || SelectedCustomer.InvStyle.InvoiceStyleId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTINVOICESTYLE), ", "));

            }

            if (SelectedCustomer.InvDelivery == null || SelectedCustomer.InvDelivery.InvoiceDeliveryId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTINVOICEDELIVERY), ", "));

            }

            if (SelPayMethod == null || this.SelPayMethod.PayMethodId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTPAYMENTMETHOD), ", "));

            }

            if (SelPayMethod != null)
            {
                if (SelPayMethod.IsBankAccReqd)
                {
                    if (SelectedCustomer.Bank == null || SelectedCustomer.Bank.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTBANK), ", "));

                    }
                    if (SelectedCustomer.BankAccName == null || SelectedCustomer.BankAccName.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTBANKACCOUNTNAME), ", "));

                    }

                    if (SelectedCustomer.BankAccNo == null || SelectedCustomer.BankAccNo.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTBANKACCOUNTNO), ", "));

                    }

                    if (SelectedCustomer.BankBranch == null || SelectedCustomer.BankBranch.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTBRANCH), ", "));

                    }
                }
                else if (SelPayMethod.IsCreditCardReqd)
                {
                    if (SelectedCustomer.CreditCardType == null || SelectedCustomer.CreditCardType.CardTypeCode == null || SelectedCustomer.CreditCardType.CardTypeCode.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTCARDTYPE), ", "));
                    }

                    if (SelectedCustomer.CreditCardExpiry == null || SelectedCustomer.CreditCardExpiry.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTEXPIRY), ", "));
                    }

                    if (SelectedCustomer.CreditCardName == null || SelectedCustomer.CreditCardName.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTNAME), ", "));
                    }

                    if (SelectedCustomer.CreditCardNo == null || SelectedCustomer.CreditCardNo.Trim() == string.Empty)
                    {
                        errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTNUMBER), ", "));
                    }
                }
            }

            if (SelectedCustomer.CreditCtrlStatus == null || SelectedCustomer.CreditCtrlStatus.CreditControlStatusId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTCREDITCONTROLSTATUS), ", "));

            }

            if (SelectedCustomer.Type == null || SelectedCustomer.Type.TreatmentTypeId == 0)
            {
                errorMsg.Append(string.Concat(ApplicationResources.GetString(ConstantResources.LTTREATMENTTYPE), ", "));

            }

            return errorMsg.ToString();
        }

		#endregion Methods 
    }
}
