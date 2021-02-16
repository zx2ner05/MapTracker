using System;
using System.Net.Http;
using System.Xml.Serialization;
using System.Threading.Tasks;
using MapTracker.Models.USPS;

namespace MapTracker.Carriers.USPS
{
    public class UspsTrackingService
    {
        public string _serviceUri { get; set; }
        public HttpClient _client { get; set; }

        public UspsTrackingService()
        {
            _serviceUri = Environment.GetEnvironmentVariable("UspsServiceUri");
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(10);
        }

        public async Task<TrackResponse> TrackPackages(string trackingNumber)
        {
            TrackFieldRequest requestData = new TrackFieldRequest(trackingNumber);

            string Xml = requestData.ToXML();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _serviceUri + Xml);

            HttpResponseMessage response = await _client.SendAsync(requestMessage);

            string responseXml = await response.Content.ReadAsStringAsync();

            return TrackResponse.LoadFromXMLString(responseXml);
        }
    }
}