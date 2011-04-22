using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class Product
    {
		#region Properties (5) 

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string ProductDesc { get; set; }

        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public int SeqPartyId { get; set; }

        [DataMember]
        public string SiteAddress { get; set; }

		#endregion Properties 
    }
}
