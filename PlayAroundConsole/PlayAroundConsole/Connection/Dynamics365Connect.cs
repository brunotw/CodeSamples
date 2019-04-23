using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.Net;
using System.ServiceModel.Description;

namespace PlayAroundConsole.Connection
{
    public class Dynamics365Connect
    {
        public void Connect()
        {
            IOrganizationService organizationService = null;

            try
            {
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = "<ProvideUserName>@<ProvideYourOrgName>.onmicrosoft.com";
                clientCredentials.UserName.Password = "<ProvideYourPassword>";

                // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                // Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
                // Copy and Paste Organization Service Endpoint Address URL
                organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri("https://<ProvideYourOrgName>.api.<CRMRegion>.dynamics.com/XRMServices/2011/Organization.svc"),
                 null, clientCredentials, null);

                if (organizationService != null)
                {
                    Guid userid = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId;

                    if (userid != Guid.Empty)
                    {
                        Console.WriteLine("Connection Established Successfully...");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to Established Connection!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught - " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
