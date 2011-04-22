using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace AgilityCIS.Orion.Services.DataContracts
{
    /// <summary>
    /// Assumption made is Company is equal to District
    /// </summary>
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int PartyId { get; set; }

        [DataMember]
        public string PartyCode { get; set; }

        [DataMember]
        public string PartyName { get; set; }

        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public string LName { get; set; }

        [DataMember]
        public string Initials { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsAccAuth { get; set; }

        [DataMember]
        public bool IsBillingContact { get; set; }

        [DataMember]
        public int PartyTypeId { get; set; }
    }
}
