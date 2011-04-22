using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel;
using AgilityCIS.Orion.Services.DataContracts;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace AgilityCIS.Orion.Services.Implementation
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SecurityOperationBehavior : Attribute, IOperationBehavior
    {
		#region Methods (4) 

		// Public Methods (4) 

        //- @AddBindingParameters -//
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //+ blank
        }

        //- @ApplyClientBehavior -//
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            //+ blank
        }

        //- @ApplyDispatchBehavior -//
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new SecurityOperationInvoker(dispatchOperation.Invoker);
        }

        //- @Validate -//
        public void Validate(OperationDescription operationDescription)
        {
            //+ blank
        }

		#endregion Methods 
    }


    public class SecurityOperationInvoker : IOperationInvoker
    {
		#region Constructors (1) 

        //+
        //- @Ctor -//
        public SecurityOperationInvoker(IOperationInvoker operationInvoker)
        {
            this.InnerOperationInvoker = operationInvoker;
        }

		#endregion Constructors 

		#region Properties (2) 

        //- $InnerOperationInvoker -//
        private IOperationInvoker InnerOperationInvoker { get; set; }

        //- @IsSynchronous -//
        public Boolean IsSynchronous
        {
            get { return InnerOperationInvoker.IsSynchronous; }
        }

		#endregion Properties 

		#region Methods (4) 

		// Public Methods (4) 

        //+
        //- @AllocateInputs -//
        public Object[] AllocateInputs()
        {
            return InnerOperationInvoker.AllocateInputs();
        }

        //- @Invoke -//
        public Object Invoke(Object instance, Object[] inputs, out Object[] outputs)
        {
          // Security by passed temporarily. Need to test it properly.
         /*   //+ authorization
            MessageHeaders messageHeadersElement = OperationContext.Current.IncomingMessageHeaders;
            Int32 id = messageHeadersElement.FindHeader("UserName", "") + messageHeadersElement.FindHeader("Password", "");
            if (id > -1)
            {
                String username = messageHeadersElement.GetHeader<String>("UserName", "");
                String password = messageHeadersElement.GetHeader<String>("Password", "");
                //  SecurityValidator.Authenticate(username, password);

                //+
                return InnerOperationInvoker.Invoke(instance, inputs, out outputs);
            }

            FaultDetail faultDetail = new FaultDetail
            {
                Type = "Unauthorized access of the service",
                ErrorCode = 63873928
            };     //+ throw     

            throw new FaultException<FaultDetail>(faultDetail, "Unauthorized access of the service");      */

            return InnerOperationInvoker.Invoke(instance, inputs, out outputs);
        }

        //- @InvokeBegin -//
        public IAsyncResult InvokeBegin(Object instance, Object[] inputs, AsyncCallback callback, Object state)
        {
            return InnerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        //- @InvokeEnd -//
        public Object InvokeEnd(Object instance, out Object[] outputs, IAsyncResult result)
        {
            return InnerOperationInvoker.InvokeEnd(instance, out outputs, result);
        }

		#endregion Methods 
    }
}
