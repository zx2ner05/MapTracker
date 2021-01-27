using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MapTracker.Mobile
{
    public static class Register
    {
        [FunctionName("Register")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RegistrationRequest registration = JsonConvert.DeserializeObject<RegistrationRequest>(requestBody);

            log.LogTrace("Incoming Registration: " + JsonConvert.SerializeObject(registration));

            return new OkObjectResult("Successfully registered trackingNumber:" + registration.trackingNumber);
        }
    }
}