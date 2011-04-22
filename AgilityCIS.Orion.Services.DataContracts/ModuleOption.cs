using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AgilityCIS.Orion.Services.DataContracts
{
 [DataContract]
    public class ModuleOption
    {
		#region Properties (3) 

     [DataMember]
     public bool IsActive { get; set; }

     [DataMember]   
     public string OptionName { get; set; }

     [DataMember]
     public int OrderNum { get; set; }

		#endregion Properties 
    }
}
