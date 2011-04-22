using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AgilityCIS.Orion.Data.Interfaces;

using AgilityCIS.Orion.Services.DataContracts;
using AgilityCIS.Orion.Services.DataContracts.Criteria;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace AgilityCIS.Orion.DataManager
{
    public class DatabaseManager
    {
		#region Methods (11) 

		// Public Methods (11) 

        public bool DeleteCustomer(string customerNo)
        {
           return Database.DeleteCustomer(customerNo);
        }

        public List<AddressType> GetAddressTypes()
        {
            return Database.GetAddressTypes();
        }

        public List<BillingUnit> GetBillingUnits()
        {
            return Database.GetBillingUnits();
        }

        public List<Company> GetCompanies()
        {
            return Database.GetCompanies();
        }

        public List<CustomerType> GetCustomerTypes()
        {
            return Database.GetCustomerTypes();
        }

        public List<Industry> GetIndustries()
        {
            return Database.GetIndustries();
        }

        
        public List<Party> GetParties()
        {
            return Database.GetParties();
        }

        public List<Priority> GetPriorities()
        {
            return Database.GetPriorities();
        }

        public List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId)
        {
            return Database.GetRecentCustSearchResults( seqPartyId);
        }

        public List<TaxIndicator> GetTaxIndicators()
        {
            return Database.GetTaxIndicators();
        }

		#endregion Methods 



        #region?Constructors?(1)?

        public DatabaseManager()
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            Database = container.Resolve<IDatabase>();
        }

        #endregion?Constructors?


        #region?Properties?(1)?
        private IDatabase Database { get; set; }
        #endregion?Properties?


        #region?Methods?(2)?
        public User Login(User user)
        {
            return Database.Login(user);
        }

        public List<Customer> SearchCustomers(CustomerSearchCriteria criteria)
        {
            return Database.SearchCustomers(criteria);
        }

        public CustomerSummary GetCustomerSummaryDetails(int seqPartyId)
        {
            return Database.GetCustomerSummaryDetails(seqPartyId);
        }

        public CustomerDetails GetCustomerDetails(int customerNo)
        {
            return Database.GetCustomerDetails(customerNo);
        }

        public List<BillingCycle> GetBillingCycles()
        {
            return Database.GetBillingCycles();
        }

        public bool SaveCustomerDetails(CustomerDetails customerDetails)
        {
            return Database.SaveCustomerDetails(customerDetails);
        }

        public List<InvoiceStyle> GetInvoiceStyles()
        {
            return Database.GetInvoiceStyles();
        }

        public List<InvoiceDelivery> GetInvoiceDeliveries()
        {
            return Database.GetInvoiceDeliveries();
        }

        public List<CreditCheckScore> GetCreditCheckScores()
        {
            return Database.GetCreditCheckScores();
        }

        public List<PayMethod> GetPaymentMethods()
        {
            return Database.GetPaymentMethods();
        }

        public List<CardType> GetCardTypes()
        {
            return Database.GetCardTypes();
        }

        public List<CreditControlStatus> GetCreditControlStatus()
        {
            return Database.GetCreditControlStatus();
        }

        public List<TreatmentType> GetTreatmentTypes()
        {
            return Database.GetTreatmentTypes();
        }
        #endregion?Methods?

        public List<Contact> GetContacts(int seqPartyId)
        {
            return Database.GetContacts(seqPartyId);
        }
    }
}
