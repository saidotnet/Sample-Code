using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
   public class RecentCustomerSearchResult
    {
		#region Properties (5) 

        [DataMember]
        public string Display { get; set; }

        [DataMember]
        public int OrderNo { get; set; }

        [DataMember]
        public int SearchSeqPartyCode { get; set; }

        [DataMember]
        public int SearchSeqPartyId { get; set; }

        [DataMember]
        public int SeqPartyId { get; set; }

		#endregion Properties 
    }
}
