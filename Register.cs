using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MapTracker.Models;
using MapTracker.Notifications;
using MapTracker.Carriers;

namespace MapTracker
{
    public static class Register
    {
        [FunctionName("Register")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RegistrationRequest registration = JsonConvert.DeserializeObject<RegistrationRequest>(requestBody);

            //log in app insights
            log.LogTrace("Incoming Registration: " + JsonConvert.SerializeObject(registration));

            //identify shipping service provider
            CarrierIdentificationService carrierService = new CarrierIdentificationService();
            switch (carrierService.GetCarrier(registration.trackingNumber))
            {
                case "USPS":
                    break;
                case "UPS":
                    break;
                case "FEDEX":
                    break;
            }

            //register with azure notification hubs
            //TODO throwing error when initializing azure notification hub
            AzureNotificationHubDecorator hub = new AzureNotificationHubDecorator(log);
            await hub.RegisterAsync(registration);

            return new OkObjectResult("Successfully registered trackingNumber:" + registration.trackingNumber);
        }
    }
}
