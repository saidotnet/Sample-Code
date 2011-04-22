using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AgilityCIS.Orion.Services.DataContracts;
using AgilityCIS.Orion.Services.DataContracts.Criteria;

namespace AgilityCIS.Orion.Services.Interfaces
{
    [ServiceContract(
         Name = "IAgilityService",
         Namespace = @"http://schemas.agility.com/contracts")]
    public interface IAgilityService
    {
		#region Operations (23) 

        [OperationContract(
Name = "DeleteCustomer",
Action = "DeleteCustomer")]
        bool DeleteCustomer(string customerNo);

        [OperationContract(
Name = "GetAddressTypes",
Action = "GetAddressTypes")]
        List<AddressType> GetAddressTypes();

        [OperationContract(
Name = "GetBillingCycles",
Action = "GetBillingCycles")]
        List<BillingCycle> GetBillingCycles();

        [OperationContract(
Name = "GetBillingUnit",
Action = "GetBillingUnit")]
        List<BillingUnit> GetBillingUnits();

        [OperationContract(
Name = "GetCardTypes",
Action = "GetCardTypes")]
        List<CardType> GetCardTypes();

        [OperationContract(
Name = "GetCompanies",
Action = "GetCompanies")]
        List<Company> GetCompanies();

        [OperationContract(
Name = "GetCreditCheckScores",
Action = "GetCreditCheckScores")]
        List<CreditCheckScore> GetCreditCheckScores();

        [OperationContract(
Name = "GetCreditControlStatus",
Action = "GetCreditControlStatus")]
        List<CreditControlStatus> GetCreditControlStatus();

        [OperationContract(
Name = "GetCustomerDetails",
Action = "GetCustomerDetails")]
        CustomerDetails GetCustomerDetails(int customerNo);

        [OperationContract(
Name = "GetCustomerSummaryDetails",
Action = "GetCustomerSummaryDetails")]
        CustomerSummary GetCustomerSummaryDetails(int seqPartyId);

        [OperationContract(
Name = "GetCustomerTypes",
Action = "GetCustomerTypes")]
        List<CustomerType> GetCustomerTypes();

        [OperationContract(
Name = "GetIndustries",
Action = "GetIndustries")]
        List<Industry> GetIndustries();

        [OperationContract(
Name = "GetInvoiceDeliveries",
Action = "GetInvoiceDeliveries")]
        List<InvoiceDelivery> GetInvoiceDeliveries();

        [OperationContract(
Name = "GetInvoiceStyles",
Action = "GetInvoiceStyles")]
        List<InvoiceStyle> GetInvoiceStyles();

        [OperationContract(
Name = "GetParties",
Action = "GetParties")]
        List<Party> GetParties();

        [OperationContract(
Name = "GetPaymentMethods",
Action = "GetPaymentMethods")]
        List<PayMethod> GetPaymentMethods();

        [OperationContract(
           Name = "GetPriorities",
           Action = "GetPriorities")]
        List<Priority> GetPriorities();

        [OperationContract(
Name = "GetRecentCustSearchResults",
Action = "GetRecentCustSearchResults")]
        List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId);

        [OperationContract(
Name = "GetTaxIndicators",
Action = "GetTaxIndicators")]
        List<TaxIndicator> GetTaxIndicators();

        [OperationContract(
Name = "GetTreatmentTypes",
Action = "GetTreatmentTypes")]
        List<TreatmentType> GetTreatmentTypes();

        [OperationContract(
            Name = "Login",
            Action = "Login")]
        [FaultContract(typeof(FaultDetail))]
        User Login(User user);

        [OperationContract(
Name = "SaveCustomerDetails",
Action = "SaveCustomerDetails")]
        bool SaveCustomerDetails(CustomerDetails customerDetails);

        [OperationContract(
   Name = "SearchCustomers",
   Action = "SearchCustomers")]
        List<Customer> SearchCustomers(CustomerSearchCriteria criteria);


        [OperationContract(
   Name = "GetContacts",
   Action = "GetContacts")]
        List<Contact> GetContacts(int seqPartyId);


		#endregion Operations 
    }
}
