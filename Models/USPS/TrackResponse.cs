using System.Xml.Serialization;
using System.Collections.Generic;

namespace MapTracker.Models.USPS
{
    public class TrackResponse
    {
        [XmlElement(ElementName = "TrackInfo")]
        public List<TrackInfo> TrackInfoList { get; set; }

        public TrackResponse()
        {
            
        }

        public static TrackResponse LoadFromXMLString(string xmlText)
        {
            // xmlText = xmlText.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<TrackResponse>","");
            // xmlText = xmlText.Replace("</TrackResponse>","");

            using(var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(TrackResponse ));
                return serializer.Deserialize(stringReader) as TrackResponse;
            }
        }
    }

    public class TrackInfo
    {
        [XmlAttribute]
        public string ID { get; set; }
        public string Class { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationZip { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string OriginZip { get; set; }
        public string Status { get; set; }
        public string StatusCategory { get; set; }
        public string StatusSummary { get; set; }
        public TrackSummary TrackSummary { get; set; }
        [XmlElement(ElementName = "TrackDetail")]
        public List<TrackDetail> TrackDetails { get; set; }

        public TrackInfo()
        {

        }
    }

    public class TrackSummary
    {
        public string EventTime { get; set; }
        public string EventDate { get; set; }
        public string Event { get; set; }
        public string EventCity { get; set; }
        public string EventState { get; set; }
        public string EventZIPCode { get; set; }
        public string EventCountry { get; set; }
        public string EventCode { get; set; }

        public TrackSummary()
        {

        }
    }

    public class TrackDetail
    {
        public string EventTime { get; set; }
        public string EventDate { get; set; }
        public string Event { get; set; }
        public string EventCity { get; set; }
        public string EventState { get; set; }
        public string EventZIPCode { get; set; }
        public string EventCountry { get; set; }
        public string EventCode { get; set; }

        public TrackDetail()
        {
            
        }
    }
}
