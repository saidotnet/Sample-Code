using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AgilityCIS.Orion.Services.DataContracts
{
    [DataContract]
    public class FaultDetail
    {
		#region Properties (2) 

        //- @ErrorCode -//
        /// <summary>
        /// Custom business-specific error code.
        /// </summary>
        [DataMember]
        public Int32 ErrorCode { get; set; }

        //- @Type -//
        /// <summary>
        /// Specifies the type of error.
        /// </summary>
        [DataMember]
        public String Type { get; set; }

		#endregion Properties 
    }

}
