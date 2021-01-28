using System;

namespace MapTracker.Models
{
    public class TrackingUpdate
    {
        public string trackingNumber { get; set; }
        public double latitude { get; set; }
        public double longitude {get ; set; }
        public DateTime timestamp { get; set; }
        public string locationDesctiption { get; set; }
        public Address Address { get; set; }

    }
}