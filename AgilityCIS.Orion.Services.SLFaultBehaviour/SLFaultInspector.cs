using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace AgilityCIS.Orion.Services.SLFaultBehaviour
{
    public class SLFaultMessageInspector : IDispatchMessageInspector
    {
		#region Methods (2) 

		// Public Methods (2) 

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Do nothing to the incoming message.
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                HttpResponseMessageProperty property = new HttpResponseMessageProperty();

                // Here the response code is changed to 200.
                property.StatusCode = System.Net.HttpStatusCode.OK;


                reply.Properties[HttpResponseMessageProperty.Name] = property;
            }
        }

		#endregion Methods 
    }
}
