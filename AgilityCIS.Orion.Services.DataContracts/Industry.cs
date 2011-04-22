using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class Industry
    {
		#region Properties (3) 

        [DataMember]
        public string IndustryCode { get; set; }

        [DataMember]
        public string IndustryDesc { get; set; }

        [DataMember]
        public int IndustryId { get; set; }

		#endregion Properties 
    }
}
