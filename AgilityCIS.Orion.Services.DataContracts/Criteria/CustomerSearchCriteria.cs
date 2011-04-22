using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts.Criteria
{
    [DataContract]
    public class CustomerSearchCriteria
    {
		#region Properties (15) 

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public string Contact { get; set; }

        [DataMember]
        public string CustomerNo { get; set; }

        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public bool IsCurrentAccount { get; set; }

        [DataMember]
        public bool IsInclLease { get; set; }

        [DataMember]
        public string LName { get; set; }

        [DataMember]
        public string MeterNo { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Premise { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string SalesCode { get; set; }

        [DataMember]
        public int StaffId { get; set; }

        [DataMember]
        public string StreetName { get; set; }

        [DataMember]
        public string StreetNo { get; set; }

		#endregion Properties 
    }
}
