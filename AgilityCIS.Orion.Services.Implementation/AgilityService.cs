using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityCIS.Orion.Services.Interfaces;
using System.ServiceModel.Activation;
using AgilityCIS.Orion.DataManager;
using AgilityCIS.Orion.Services.DataContracts;
using AgilityCIS.Orion.Services.DataContracts.Criteria;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.ServiceModel;
//using Microsoft.Practices.EnterpriseLibrary.Common;

namespace AgilityCIS.Orion.Services.Implementation
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AgilityService : IAgilityService
    {
		#region Fields (1) 

        DatabaseManager _dbManager;

		#endregion Fields 

		#region Constructors (1) 

        public AgilityService()
        {
            _dbManager = new DatabaseManager();
        }

		#endregion Constructors 

		#region Methods (24) 

		// Public Methods (24) 

        [SecurityOperationBehavior]
        public bool DeleteCustomer(string customerNo)
        {
            bool retVal = false;
            try
            {
                retVal = _dbManager.DeleteCustomer(customerNo);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return retVal;
        }

        [SecurityOperationBehavior]
        public List<AddressType> GetAddressTypes()
        {
            List<AddressType> addressTypes = new List<AddressType>();
            try
            {
                addressTypes = _dbManager.GetAddressTypes();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return addressTypes;
        }

        [SecurityOperationBehavior]
        public List<BillingCycle> GetBillingCycles()
        {
            List<BillingCycle> billingCycles = new List<BillingCycle>();
            try
            {
                billingCycles = _dbManager.GetBillingCycles();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return billingCycles;
        }

        [SecurityOperationBehavior]
        public List<BillingUnit> GetBillingUnits()
        {

            List<BillingUnit> billingUnits = new List<BillingUnit>();
            try
            {
                billingUnits = _dbManager.GetBillingUnits();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return billingUnits;
        }

        [SecurityOperationBehavior]
        public List<CardType> GetCardTypes()
        {
            List<CardType> cardTypes = new List<CardType>();
            try
            {
                cardTypes = _dbManager.GetCardTypes();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return cardTypes;
        }

        [SecurityOperationBehavior]
        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            try
            {
                companies = _dbManager.GetCompanies();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return companies;
        }

        [SecurityOperationBehavior]
        public List<CreditCheckScore> GetCreditCheckScores()
        {
            List<CreditCheckScore> creditCheckScores = new List<CreditCheckScore>();
            try
            {
                creditCheckScores = _dbManager.GetCreditCheckScores();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return creditCheckScores;
        }

        [SecurityOperationBehavior]
        public List<CreditControlStatus> GetCreditControlStatus()
        {
            List<CreditControlStatus> creditControlStatuses = new List<CreditControlStatus>();
            try
            {
                creditControlStatuses = _dbManager.GetCreditControlStatus();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return creditControlStatuses;
        }

        [SecurityOperationBehavior]
        public CustomerDetails GetCustomerDetails(int customerNo)
        {
            CustomerDetails custDetails = new CustomerDetails();
            try
            {
                custDetails = _dbManager.GetCustomerDetails(customerNo);
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return custDetails;
        }

        [SecurityOperationBehavior]
        public CustomerSummary GetCustomerSummaryDetails(int seqPartyId)
        {
            CustomerSummary custSumm = new CustomerSummary();
            try
            {
                custSumm = _dbManager.GetCustomerSummaryDetails(seqPartyId);
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return custSumm;
        }

        [SecurityOperationBehavior]
        public List<CustomerType> GetCustomerTypes()
        {
            List<CustomerType> customerTypes = new List<CustomerType>();
            try
            {
                customerTypes = _dbManager.GetCustomerTypes();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return customerTypes;
        }

        public List<Industry> GetIndustries()
        {
            List<Industry> industries = new List<Industry>();
            try
            {
                industries = _dbManager.GetIndustries();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return industries;
        }

        [SecurityOperationBehavior]
        public List<InvoiceDelivery> GetInvoiceDeliveries()
        {
            List<InvoiceDelivery> invoiceDeliveries = new List<InvoiceDelivery>();
            try
            {
                invoiceDeliveries = _dbManager.GetInvoiceDeliveries();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return invoiceDeliveries;
        }

        [SecurityOperationBehavior]
        public List<InvoiceStyle> GetInvoiceStyles()
        {
            List<InvoiceStyle> invoiceStyles = new List<InvoiceStyle>();
            try
            {
                invoiceStyles = _dbManager.GetInvoiceStyles();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return invoiceStyles;
        }

       
        public List<Party> GetParties()
        {
            List<Party> parties = new List<Party>();
            try
            {
                parties = _dbManager.GetParties();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return parties;
        }

        [SecurityOperationBehavior]
        public List<PayMethod> GetPaymentMethods()
        {
            List<PayMethod> payMethods = new List<PayMethod>();
            try
            {
                payMethods = _dbManager.GetPaymentMethods();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return payMethods;
        }

        [SecurityOperationBehavior]
        public List<Priority> GetPriorities()
        {
            List<Priority> priorities = new List<Priority>();
            try
            {
                priorities = _dbManager.GetPriorities();
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return priorities;
        }

        [SecurityOperationBehavior]
        public List<RecentCustomerSearchResult> GetRecentCustSearchResults(int seqPartyId)
        {
            List<RecentCustomerSearchResult> results = new List<RecentCustomerSearchResult>();
            try
            {
                results = _dbManager.GetRecentCustSearchResults(seqPartyId);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return results;
        }

        [SecurityOperationBehavior]
        public List<TaxIndicator> GetTaxIndicators()
        {
            List<TaxIndicator> taxIndicators = new List<TaxIndicator>();
            try
            {
                taxIndicators = _dbManager.GetTaxIndicators();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return taxIndicators;
        }

        [SecurityOperationBehavior]
        public List<TreatmentType> GetTreatmentTypes()
        {
            List<TreatmentType> treatmentTypes = new List<TreatmentType>();
            try
            {
                treatmentTypes = _dbManager.GetTreatmentTypes();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return treatmentTypes;
        }

        [SecurityOperationBehavior]
        public User Login(User user)
        {
            try
            {
                user = _dbManager.Login(user);
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return user;
        }

        [SecurityOperationBehavior]
        public bool SaveCustomerDetails(CustomerDetails customerDetails)
        {
            bool retVal = false;
            try
            {
                retVal = _dbManager.SaveCustomerDetails(customerDetails);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = ex.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, ex.Message);
            }
            return retVal;
        }

        [SecurityOperationBehavior]
        public List<Customer> SearchCustomers(CustomerSearchCriteria criteria)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = _dbManager.SearchCustomers(criteria);
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return customers;
        }

		#endregion Methods 
    

        public List<Contact> GetContacts(int seqPartyId)
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                contacts = _dbManager.GetContacts(seqPartyId);
            }
            catch (Exception exceptionToHandle)
            {
                ExceptionPolicy.HandleException(exceptionToHandle, "Policy");
                FaultDetail faultDetail = new FaultDetail
                {
                    Type = exceptionToHandle.Message,
                    ErrorCode = 63873928
                };     //+ throw     
                throw new FaultException<FaultDetail>(faultDetail, exceptionToHandle.Message);
            }

            return contacts;
        }
    }
}
