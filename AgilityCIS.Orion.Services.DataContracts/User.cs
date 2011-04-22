using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class User
    {
		#region Properties (4) 

        [DataMember]
        public List<Module> Modules { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

		#endregion Properties 
    }
}
