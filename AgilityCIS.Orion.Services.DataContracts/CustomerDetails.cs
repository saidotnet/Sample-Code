using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class CustomerDetails
    {
		#region Properties (91) 

        [DataMember]
        public Party AccMgr { get; set; }

        [DataMember]
        public string AccMgrName { get; set; }

        [DataMember]
        public DateTime? AgcRewards { get; set; }

        [DataMember]
        public string Alert { get; set; }

        [DataMember]
        public DateTime? AlertExpiryDate { get; set; }

        [DataMember]
        public string AvgMonthlySpend { get; set; }

        [DataMember]
        public string Bank { get; set; }

        [DataMember]
        public string BankAccName { get; set; }

        [DataMember]
        public string BankAccNo { get; set; }

        [DataMember]
        public string BankBranch { get; set; }

        [DataMember]
        public string BillingContactName { get; set; }

        [DataMember]
        public string BillNotes { get; set; }

        [DataMember]
        public double BondAmt { get; set; }

        [DataMember]
        public string CreditCardExpiry { get; set; }

        [DataMember]
        public string CreditCardName { get; set; }

        [DataMember]
        public string CreditCardNo { get; set; }

        [DataMember]
        public CardType CreditCardType { get; set; }

        [DataMember]
        public string CreditCardTypeCode { get; set; }

        [DataMember]
        public string CreditCardVerifyNo { get; set; }

        [DataMember]
        public CreditControlStatus CreditCtrlStatus { get; set; }

        [DataMember]
        public string CreditLimit { get; set; }

        [DataMember]
        public string CreditStatusCode { get; set; }

        [DataMember]
        public string CurrAmt { get; set; }

        [DataMember]
        public string CurrPeriod { get; set; }

        [DataMember]
        public AddressType CustAddress { get; set; }

        [DataMember]
        public Company CustCompany { get; set; }

        [DataMember]
        public string CustomerFName { get; set; }

        [DataMember]
        public string CustomerInitial { get; set; }

        [DataMember]
        public string CustomerLName { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerNo { get; set; }

        [DataMember]
        public CustomerType CustType { get; set; }

        [DataMember]
        public DateTime? DateDetailsConfirmed { get; set; }

        [DataMember]
        public string DecisionMakerName { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public string EMailAddress { get; set; }

        [DataMember]
        public string Employer { get; set; }

        [DataMember]
        public string EstimateDate { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public Industry IndustryDetails { get; set; }

        [DataMember]
        public DateTime InsertedOn { get; set; }

        [DataMember]
        public InvoiceDelivery InvDelivery { get; set; }

        [DataMember]
        public InvoiceStyle InvStyle { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsAlertExpires { get; set; }

        [DataMember]
        public bool IsCorrespondenceByEMail { get; set; }

        [DataMember]
        public bool IsCorrespondenceByPost { get; set; }

        [DataMember]
        public bool IsDeveloper { get; set; }

        [DataMember]
        public bool IsNameOverride { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public string OverdueAmt { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public PayMethod PmtMethod { get; set; }

        [DataMember]
        public string PostalAddr1 { get; set; }

        [DataMember]
        public string PostalAddr2 { get; set; }

        [DataMember]
        public string PostalAddr3 { get; set; }

        [DataMember]
        public string PostalAddr4 { get; set; }

        [DataMember]
        public string PostalAddr5 { get; set; }

        [DataMember]
        public string PostalPostCode { get; set; }

        [DataMember]
        public string PromptPayDisc { get; set; }

        [DataMember]
        public string RestaurantAssnNo { get; set; }

        [DataMember]
        public CreditCheckScore Score { get; set; }

        [DataMember]
        public BillingCycle SeqBillCycle { get; set; }

        [DataMember]
        public int SeqBillCycleId { get; set; }

        [DataMember]
        public BillingUnit SeqBillingUnit { get; set; }

        [DataMember]
        public int SeqBillTypeId { get; set; }

        [DataMember]
        public int SeqCreditCheckId { get; set; }

        [DataMember]
        public string SeqPartyId { get; set; }

        [DataMember]
        public string SeqPartyTypeId { get; set; }

        [DataMember]
        public int SeqPayMethodId { get; set; }

        [DataMember]
        public Priority SeqPriority { get; set; }

        [DataMember]
        public string SeqStaffId { get; set; }

        [DataMember]
        public TaxIndicator SeqTaxIndicator { get; set; }

        [DataMember]
        public int SeqTaxIndId { get; set; }

        [DataMember]
        public string STDCode { get; set; }

        [DataMember]
        public string StreetAddr1 { get; set; }

        [DataMember]
        public string StreetAddr2 { get; set; }

        [DataMember]
        public string StreetAddr3 { get; set; }

        [DataMember]
        public string StreetAddr4 { get; set; }

        [DataMember]
        public string StreetAddr5 { get; set; }

        [DataMember]
        public string StreetAddrNo { get; set; }

        [DataMember]
        public string StreetPostCode { get; set; }

        [DataMember]
        public string TotalAmt { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public int TreatmentTypeId { get; set; }

        [DataMember]
        public TreatmentType Type { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime UpdatedOn { get; set; }

        [DataMember]
        public string UpdateProcess { get; set; }

        [DataMember]
        public string WebAddress { get; set; }

		#endregion Properties 
    }
}
