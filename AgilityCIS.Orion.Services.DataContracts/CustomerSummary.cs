using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class CustomerSummary
    {
		#region Properties (24) 

        [DataMember]
        public string AccMgrName { get; set; }

        [DataMember]
        public string AvgMonthlySpend { get; set; }

        [DataMember]
        public string BillingContactName { get; set; }

        [DataMember]
        public string CreditStatusCode { get; set; }

        [DataMember]
        public string CurrAmt { get; set; }

        [DataMember]
        public string CurrPeriod { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerNo { get; set; }

        [DataMember]
        public string DecisionMakerName { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string OverdueAmt { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string PostalAddr1 { get; set; }

        [DataMember]
        public string PostalAddr2 { get; set; }

        [DataMember]
        public string PostalAddr3 { get; set; }

        [DataMember]
        public string PostalPostCode { get; set; }

        [DataMember]
        public string SeqPartyId { get; set; }

        [DataMember]
        public string StreetAddr1 { get; set; }

        [DataMember]
        public string StreetAddr2 { get; set; }

        [DataMember]
        public string StreetAddr3 { get; set; }

        [DataMember]
        public string StreetAddrNo { get; set; }

        [DataMember]
        public string StreetPostCode { get; set; }

        [DataMember]
        public string TotalAmt { get; set; }

		#endregion Properties 
    }
}
