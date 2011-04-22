using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class TaxIndicator
    {
		#region Properties (3) 

        [DataMember]
        public string TaxIndicatorCode { get; set; }

        [DataMember]
        public string TaxIndicatorDesc { get; set; }

        [DataMember]
        public int TaxIndicatorId { get; set; }

		#endregion Properties 
    }
}
