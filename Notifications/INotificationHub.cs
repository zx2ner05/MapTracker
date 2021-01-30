using System.Threading.Tasks;
using MapTracker.Models;

namespace MapTracker.Notifications
{
    public interface INotificationHub
    {
        Task RegisterAsync (RegistrationRequest request);

        Task DisconnectAsync (string trackingNumber);

        Task SendAsync(TrackingUpdate trackingUpdate);
    }
}