using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace AgilityCIS.Orion.Services.SLFaultBehaviour
{
    public class SLFaultCorrector : BehaviorExtensionElement, IEndpointBehavior
    {
		#region Properties (1) 

        public override System.Type BehaviorType
        {
            get { return typeof(SLFaultCorrector); }
        }

		#endregion Properties 

		#region Methods (5) 

		// Public Methods (4) 

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            SLFaultMessageInspector inspector = new SLFaultMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
		// Protected Methods (1) 

        protected override object CreateBehavior()
        {
            return new SLFaultCorrector();
        }

		#endregion Methods 
    }
}
