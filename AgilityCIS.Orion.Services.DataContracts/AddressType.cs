using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class AddressType
    {
		#region Properties (3) 

        [DataMember]
        public string AddressTypeCode { get; set; }

        [DataMember]
        public string AddressTypeDesc { get; set; }

        [DataMember]
        public int AddressTypeId { get; set; }

		#endregion Properties 
    }
}
