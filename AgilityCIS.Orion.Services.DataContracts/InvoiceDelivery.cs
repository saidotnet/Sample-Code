using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class InvoiceDelivery
    {
		#region Properties (3) 

        [DataMember]
        public string InvoiceDeliveryCode { get; set; }

        [DataMember]
        public string InvoiceDeliveryDesc { get; set; }

        [DataMember]
        public int InvoiceDeliveryId { get; set; }

		#endregion Properties 
    }
}
