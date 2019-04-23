using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.Net;
using System.ServiceModel.Description;
using System;

namespace PlayAroundConsole.Connection
{
    public class Dynamics365Connect
    {
        public IOrganizationService Connect()
        {
            IOrganizationService organizationService = null;

            // Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
            // Copy and Paste Organization Service Endpoint Address URL
            var environmentUrl = "";

            var environmentUser = "";
            var environmentPassword = "";

            try
            {
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = environmentUser;
                clientCredentials.UserName.Password = environmentPassword;

                // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
                organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(environmentUrl),
                 null, clientCredentials, null);

                return organizationService;
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException("Error: " + ex.Message);
            }
        }
    }
}
