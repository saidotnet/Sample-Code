using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class CreditCheckScore
    {
		#region Properties (5) 

        [DataMember]
        public double BondAmount { get; set; }

        [DataMember]
        public string CreditCheckScoreDesc { get; set; }

        [DataMember]
        public int CreditCheckScoreId { get; set; }

        [DataMember]
        public bool IsBondReqd { get; set; }

        [DataMember]
        public int Score { get; set; }

		#endregion Properties 
    }
}
