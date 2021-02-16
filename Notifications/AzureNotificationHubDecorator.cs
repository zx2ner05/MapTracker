using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Configuration;
using MapTracker.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace MapTracker.Notifications
{
    public class AzureNotificationHubDecorator 
    {
        private readonly ILogger _log;
        private readonly NotificationHubClient _hub;

        public AzureNotificationHubDecorator(ILogger log)
        {
            _log = log;
            string connectionString = Environment.GetEnvironmentVariable("AzureNotificationHubs");
            string hubName = Environment.GetEnvironmentVariable("AzureNotificationHubName");
            _hub = NotificationHubClient.CreateClientFromConnectionString(connectionString,hubName);
        }

        public async Task RegisterAsync(RegistrationRequest request)
        {
            Installation installation = new Installation
            {
                InstallationId = request.trackingNumber,
                PushChannel = request.trackingNumber,
                Tags = new List<string>() {request.trackingNumber},
                Platform = NotificationPlatform.Fcm
            };

            await _hub.CreateOrUpdateInstallationAsync(installation);

            return;
        }

        public async Task DisconnectAsync(string trackingNumber)
        {
            await _hub.DeleteInstallationAsync(trackingNumber);
        }

        public async Task SendAsync(TrackingUpdate trackingUpdate)
        {
            FcmNotification notification = new FcmNotification(JsonConvert.SerializeObject(trackingUpdate));

            await _hub.SendNotificationAsync(notification,new List<string>() {trackingUpdate.trackingNumber});
        }
    }
}