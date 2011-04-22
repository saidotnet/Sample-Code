using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class BillingUnit
    {
		#region Properties (3) 

        [DataMember]
        public string BillingUnitCode { get; set; }

        [DataMember]
        public string BillingUnitDesc { get; set; }

        [DataMember]
        public int BillingUnitId { get; set; }

		#endregion Properties 
    }
}
