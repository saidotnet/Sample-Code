using System;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace AgilityCIS.Orion.Services
{
    public class ServiceAgent : IServiceAgent
    {
		#region Fields (1) 

        AgilityServiceClient _proxy;

		#endregion Fields 

		#region Constructors (1) 

        public ServiceAgent()
        {
            _proxy = ProxyFactory.CreateProxy();
        }

		#endregion Constructors 

		#region Methods (24) 

		// Public Methods (24) 

        // Unauthorized msg was being thrown. Need to look into this.
        /*
        ~ServiceAgent()
        {
            ProxyFactory.CloseProxy();
        }*/
        public void DeleteCustomer(string customerNo, EventHandler<DeleteCustomerCompletedEventArgs> callback)
        {
            _proxy.DeleteCustomerCompleted -= callback;
            _proxy.DeleteCustomerCompleted += callback;
            _proxy.DeleteCustomerAsync(customerNo);
        }

        public void GetAddressTypes(EventHandler<GetAddressTypesCompletedEventArgs> callback)
        {
            _proxy.GetAddressTypesCompleted -= callback;
            _proxy.GetAddressTypesCompleted += callback;
            _proxy.GetAddressTypesAsync();
        }

        public void GetBillingCycles(EventHandler<GetBillingCyclesCompletedEventArgs> callback)
        {
            _proxy.GetBillingCyclesCompleted -= callback;
            _proxy.GetBillingCyclesCompleted += callback;
            _proxy.GetBillingCyclesAsync();
        }

        public void GetBillingUnits(EventHandler<GetBillingUnitCompletedEventArgs> callback)
        {
            _proxy.GetBillingUnitCompleted -= callback;
            _proxy.GetBillingUnitCompleted += callback;
            _proxy.GetBillingUnitAsync();
        }

        public void GetCardTypes(EventHandler<GetCardTypesCompletedEventArgs> callback)
        {
            _proxy.GetCardTypesCompleted -= callback;
            _proxy.GetCardTypesCompleted += callback;
            _proxy.GetCardTypesAsync();
        }

        public void GetCompanies(EventHandler<GetCompaniesCompletedEventArgs> callback)
        {
            _proxy.GetCompaniesCompleted -= callback;
            _proxy.GetCompaniesCompleted += callback;
            _proxy.GetCompaniesAsync();
        }

        public void GetCreditCheckScores(EventHandler<GetCreditCheckScoresCompletedEventArgs> callback)
        {
            _proxy.GetCreditCheckScoresCompleted -= callback;
            _proxy.GetCreditCheckScoresCompleted += callback;
            _proxy.GetCreditCheckScoresAsync();
        }

        public void GetCreditControlStatus(EventHandler<GetCreditControlStatusCompletedEventArgs> callback)
        {
            _proxy.GetCreditControlStatusCompleted -= callback;
            _proxy.GetCreditControlStatusCompleted += callback;
            _proxy.GetCreditControlStatusAsync();
        }

        public void GetCustomerTypes(EventHandler<GetCustomerTypesCompletedEventArgs> callback)
        {
            _proxy.GetCustomerTypesCompleted -= callback;
            _proxy.GetCustomerTypesCompleted += callback;
            _proxy.GetCustomerTypesAsync();
        }

        public void GetIndustries(EventHandler<GetIndustriesCompletedEventArgs> callback)
        {
            _proxy.GetIndustriesCompleted -= callback;
            _proxy.GetIndustriesCompleted += callback;
            _proxy.GetIndustriesAsync();
        }

        public void GetInvoiceDeliveries(EventHandler<GetInvoiceDeliveriesCompletedEventArgs> callback)
        {
            _proxy.GetInvoiceDeliveriesCompleted -= callback;
            _proxy.GetInvoiceDeliveriesCompleted += callback;
            _proxy.GetInvoiceDeliveriesAsync();
        }

        public void GetInvoiceStyles(EventHandler<GetInvoiceStylesCompletedEventArgs> callback)
        {
            _proxy.GetInvoiceStylesCompleted -= callback;
            _proxy.GetInvoiceStylesCompleted += callback;
            _proxy.GetInvoiceStylesAsync();
        }

      

        public void GetParties(EventHandler<GetPartiesCompletedEventArgs> callback)
        {
            _proxy.GetPartiesCompleted -= callback;
            _proxy.GetPartiesCompleted += callback;
            _proxy.GetPartiesAsync();
        }

        public void GetPaymentMethods(EventHandler<GetPaymentMethodsCompletedEventArgs> callback)
        {
            _proxy.GetPaymentMethodsCompleted -= callback;
            _proxy.GetPaymentMethodsCompleted += callback;
            _proxy.GetPaymentMethodsAsync();
        }

        public void GetPriorities(EventHandler<GetPrioritiesCompletedEventArgs> callback)
        {
            _proxy.GetPrioritiesCompleted -= callback;
            _proxy.GetPrioritiesCompleted += callback;
            _proxy.GetPrioritiesAsync();
        }

        public void GetRecentSearchResults(int custNo, EventHandler<GetRecentCustSearchResultsCompletedEventArgs> callback)
        {
            _proxy.GetRecentCustSearchResultsCompleted -= callback;
            _proxy.GetRecentCustSearchResultsCompleted += callback;
            _proxy.GetRecentCustSearchResultsAsync(custNo);
        }

        public void GetTaxIndicators(EventHandler<GetTaxIndicatorsCompletedEventArgs> callback)
        {
            _proxy.GetTaxIndicatorsCompleted -= callback;
            _proxy.GetTaxIndicatorsCompleted += callback;
            _proxy.GetTaxIndicatorsAsync();
        }

        public void GetTreatmentTypes(EventHandler<GetTreatmentTypesCompletedEventArgs> callback)
        {
            _proxy.GetTreatmentTypesCompleted -= callback;
            _proxy.GetTreatmentTypesCompleted += callback;
            _proxy.GetTreatmentTypesAsync();
        }

        public void LoadCustomerDetails(int customerNo, EventHandler<GetCustomerDetailsCompletedEventArgs> callback)
        {
            _proxy.GetCustomerDetailsCompleted -= callback;
            _proxy.GetCustomerDetailsCompleted += callback;
            _proxy.GetCustomerDetailsAsync(customerNo);
        }

        public void LoadCustomerSummary(int seqPartyId, EventHandler<GetCustomerSummaryDetailsCompletedEventArgs> callback)
        {
            _proxy.GetCustomerSummaryDetailsCompleted -= callback;
            _proxy.GetCustomerSummaryDetailsCompleted += callback;
            _proxy.GetCustomerSummaryDetailsAsync(seqPartyId);
        }

        public void Login(User user, EventHandler<LoginCompletedEventArgs> callback)
        {
            _proxy.LoginCompleted -= callback;
            _proxy.LoginCompleted += callback;
            _proxy.LoginAsync(user);
        }

        public void SaveCustomerDetails(CustomerDetails customerDetails, EventHandler<SaveCustomerDetailsCompletedEventArgs> callback)
        {
            _proxy.SaveCustomerDetailsCompleted -= callback;
            _proxy.SaveCustomerDetailsCompleted += callback;
            _proxy.SaveCustomerDetailsAsync(customerDetails);
        }

        public void SearchCustomer(CustomerSearchCriteria criteria, EventHandler<SearchCustomersCompletedEventArgs> callback)
        {
            _proxy.SearchCustomersCompleted -= callback;
            _proxy.SearchCustomersCompleted += callback;
            _proxy.SearchCustomersAsync(criteria);
        }

		#endregion Methods 
    

        public void GetContacts(int seqPartyId, EventHandler<GetContactsCompletedEventArgs> callback)
        {
            _proxy.GetContactsCompleted -= callback;
            _proxy.GetContactsCompleted += callback;
            _proxy.GetContactsAsync(seqPartyId);
        }
    }
}
