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
using AgilityCIS.Orion.Services.AgilitySvcProxy;

namespace AgilityCIS.Orion.Services
{
    public interface IServiceAgent
    {
		#region Operations (24) 

        void DeleteCustomer(string customerNo, EventHandler<DeleteCustomerCompletedEventArgs> callback);

        void GetAddressTypes(EventHandler<GetAddressTypesCompletedEventArgs> callback);

        void GetBillingCycles(EventHandler<GetBillingCyclesCompletedEventArgs> callback);

        void GetBillingUnits(EventHandler<GetBillingUnitCompletedEventArgs> callback);

        void GetCardTypes(EventHandler<GetCardTypesCompletedEventArgs> callback);

        void GetCompanies(EventHandler<GetCompaniesCompletedEventArgs> callback);

        void GetCreditCheckScores(EventHandler<GetCreditCheckScoresCompletedEventArgs> callback);

        void GetCreditControlStatus(EventHandler<GetCreditControlStatusCompletedEventArgs> callback);

        void GetCustomerTypes(EventHandler<GetCustomerTypesCompletedEventArgs> callback);

        void GetIndustries(EventHandler<GetIndustriesCompletedEventArgs> callback);

        void GetInvoiceDeliveries(EventHandler<GetInvoiceDeliveriesCompletedEventArgs> callback);

        void GetInvoiceStyles(EventHandler<GetInvoiceStylesCompletedEventArgs> callback);        

        void GetParties(EventHandler<GetPartiesCompletedEventArgs> callback);

        void GetPaymentMethods(EventHandler<GetPaymentMethodsCompletedEventArgs> callback);

        void GetPriorities(EventHandler<GetPrioritiesCompletedEventArgs> callback);

        void GetRecentSearchResults(int custNo, EventHandler<GetRecentCustSearchResultsCompletedEventArgs> callback);

        void GetTaxIndicators(EventHandler<GetTaxIndicatorsCompletedEventArgs> callback);

        void GetTreatmentTypes(EventHandler<GetTreatmentTypesCompletedEventArgs> callback);

        void LoadCustomerDetails(int customerNo, EventHandler<GetCustomerDetailsCompletedEventArgs> callback);

        void LoadCustomerSummary(int seqPartyId, EventHandler<GetCustomerSummaryDetailsCompletedEventArgs> callback);

        void Login(User user, EventHandler<LoginCompletedEventArgs> callback);

        void SaveCustomerDetails(CustomerDetails customerDetails, EventHandler<SaveCustomerDetailsCompletedEventArgs> callback);

        void SearchCustomer(CustomerSearchCriteria criteria, EventHandler<SearchCustomersCompletedEventArgs> callback);

        void GetContacts(int seqPartyId, EventHandler<GetContactsCompletedEventArgs> callback);

		#endregion Operations 
    }

}
