using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityCIS.Orion.Services.DataContracts;
using AgilityCIS.Orion.Services.DataContracts.Criteria;

namespace AgilityCIS.Orion.Data.Interfaces
{
    public interface IDatabase
    {
		#region Operations (23) 

        bool DeleteCustomer(string customerNo);

        List<AddressType> GetAddressTypes();

        List<BillingCycle> GetBillingCycles();

        List<BillingUnit> GetBillingUnits();

        List<CardType> GetCardTypes();

        List<Company> GetCompanies();

        List<CreditCheckScore> GetCreditCheckScores();

        List<CreditControlStatus> GetCreditControlStatus();

        CustomerDetails GetCustomerDetails(int customerNo);

        CustomerSummary GetCustomerSummaryDetails(int seqPartyId);

        List<CustomerType> GetCustomerTypes();

        List<Industry> GetIndustries();

        List<InvoiceDelivery> GetInvoiceDeliveries();

        List<InvoiceStyle> GetInvoiceStyles();

        List<Party> GetParties();

        List<PayMethod> GetPaymentMethods();

        List<Priority> GetPriorities();

        List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId);

        List<TaxIndicator> GetTaxIndicators();

        List<TreatmentType> GetTreatmentTypes();

        User Login(User user);

        bool SaveCustomerDetails(CustomerDetails customerDetails);

        List<Customer> SearchCustomers(CustomerSearchCriteria criteria);

		#endregion Operations 
    
        List<Contact> GetContacts(int seqPartyId);
    }
}
