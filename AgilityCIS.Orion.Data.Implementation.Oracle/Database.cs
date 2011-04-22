/* Any mods n this layer should be rebuilt and uploaded on the bin folder of Agility Site*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityCIS.Orion.Data.Interfaces;
using System.ComponentModel.Composition;
using AgilityCIS.Orion.Services.DataContracts;

namespace AgilityCIS.Orion.Data.Implementation.Oracle
{
    [Export(typeof(IDatabase))]
    class Database : IDatabase
    {
		#region Methods (24) 

		// Public Methods (23) 

        public bool DeleteCustomer(string customerNo)
        {
            throw new NotImplementedException();
        }

        public List<AddressType> GetAddressTypes()
        {
            throw new NotImplementedException();
        }

        public List<BillingCycle> GetBillingCycles()
        {
            throw new NotImplementedException();
        }

        public List<BillingUnit> GetBillingUnits()
        {
            throw new NotImplementedException();
        }

        public List<CardType> GetCardTypes()
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public List<CreditCheckScore> GetCreditCheckScores()
        {
            throw new NotImplementedException();
        }

        public List<CreditControlStatus> GetCreditControlStatus()
        {
            throw new NotImplementedException();
        }

        public CustomerDetails GetCustomerDetails(int customerNo)
        {
            throw new NotImplementedException();
        }

        public CustomerSummary GetCustomerSummaryDetails(int seqPartyId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerType> GetCustomerTypes()
        {
            throw new NotImplementedException();
        }

        public List<Industry> GetIndustries()
        {
            throw new NotImplementedException();
        }

        public List<InvoiceDelivery> GetInvoiceDeliveries()
        {
            throw new NotImplementedException();
        }

        public List<InvoiceStyle> GetInvoiceStyles()
        {
            throw new NotImplementedException();
        }

        
        public List<Party> GetParties()
        {
            throw new NotImplementedException();
        }

        public List<PayMethod> GetPaymentMethods()
        {
            throw new NotImplementedException();
        }

        public List<Priority> GetPriorities()
        {
            throw new NotImplementedException();
        }

        public List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId)
        {
            throw new NotImplementedException();
        }

        public List<TaxIndicator> GetTaxIndicators()
        {
            throw new NotImplementedException();
        }

        public List<TreatmentType> GetTreatmentTypes()
        {
            throw new NotImplementedException();
        }

        public bool SaveCustomerDetails(CustomerDetails customerDetails)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomers(Services.DataContracts.Criteria.CustomerSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
		// Private Methods (1) 

        User IDatabase.Login(User user)
        {
            throw new NotImplementedException();
        }

		#endregion Methods 
    

        public List<Contact> GetContacts(int seqPartyId)
        {
            throw new NotImplementedException();
        }
    }
}
