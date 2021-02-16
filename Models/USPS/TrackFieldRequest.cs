using System;
using System.Xml.Serialization;

namespace MapTracker.Models.USPS
{
    public class TrackFieldRequest
    {
        [XmlAttribute]
        public string USERID { get; set; }
        public int Revision { get; set; }
        public string ClientIp { get; set; }
        public string SourceId { get; set; }
        public TrackID TrackID  { get; set; }
        

        public TrackFieldRequest()
        {
            TrackID = new TrackID();
        }

        public TrackFieldRequest(string trackingNumber)
        {
            TrackID = new TrackID();

            USERID=Environment.GetEnvironmentVariable("UspsUserID");
            Revision = 1;
            ClientIp = "0.0.0.0";
            SourceId = Environment.GetEnvironmentVariable("UspsCompanyName");
            TrackID.ID = trackingNumber;
        }

        public string ToXML()
        {
            using(var stringwriter = new System.IO.StringWriter())
            { 
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            }
        }
    }

    public class TrackID
    {
        [XmlAttribute]
        public string ID { get; set; }
    }
}