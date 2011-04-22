using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using AgilityCIS.Orion.Services.AgilitySvcProxy;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace AgilityCIS.Orion.Services
{
    public static class ProxyFactory
    {
		#region Fields (1) 

        static AgilityServiceClient client;

		#endregion Fields 

		#region Methods (2) 

		// Internal Methods (2) 

        internal static void CloseProxy()
        {
            if (client != null)
            {
                client.CloseAsync();
            }
        }

        internal static AgilityServiceClient CreateProxy()
        {
            client = new AgilityServiceClient();
            
            // To be uncommented during security phase.
            /*OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            MessageHeaders messageHeadersElement = OperationContext.Current.OutgoingMessageHeaders;
            messageHeadersElement.Add(MessageHeader.CreateHeader("UserName", "", "JohnDoe"));
            messageHeadersElement.Add(MessageHeader.CreateHeader("Password", "", "MyPassword"));*/
            return client;
        }

		#endregion Methods 
    }
}
