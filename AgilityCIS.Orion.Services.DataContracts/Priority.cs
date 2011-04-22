using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
  public  class Priority
    {
		#region Properties (3) 

        [DataMember]
        public string PriorityCode { get; set; }

        [DataMember]
        public string PriorityDesc { get; set; }

        [DataMember]
        public int PriorityId { get; set; }

		#endregion Properties 
    }
}
