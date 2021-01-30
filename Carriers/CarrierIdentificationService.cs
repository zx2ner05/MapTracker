namespace MapTracker.Carriers
{
    public class CarrierIdentificationService
    {
        public string _trackingNumber { get; set; }

        public string GetCarrier(string trackingNumber)
        {
            _trackingNumber = trackingNumber;

            if (isUsps())
                return "USPS";
            else if (isUps())
                return "UPS";
            else if (isFedEx())
                return "FEDEX";
            else 
                return null;
        }

        private bool isUsps()
        {
            if (_trackingNumber.StartsWith("94001") && _trackingNumber.Length == 22)
                //USPS Tracking
                return true;
            else if (_trackingNumber.StartsWith("92055") && _trackingNumber.Length == 22)
                //Priority Mail
                return true;
            else if (_trackingNumber.StartsWith("94073") && _trackingNumber.Length == 22)
                //Certified Mail
                return true;
            else if (_trackingNumber.StartsWith("93033") && _trackingNumber.Length == 22)
                //Collect On Delivery Hold For Pickup
                return true;
            else if (_trackingNumber.StartsWith("82") && _trackingNumber.Length == 10)
                //Global Express Guaranteed
                return true;
            else
                return false;
        }

        private bool isFedEx()
        {
            if (_trackingNumber.Length >= 12 && _trackingNumber.Length <= 14)
                return true;
            else
                return false;
        }

        private bool isUps()
        {
            int intTrackingNumber = 0;

            if (_trackingNumber.StartsWith("1Z"))
                return true;
            else if (_trackingNumber.StartsWith("T"))
                return true;
            else if (_trackingNumber.Length == 9 && int.TryParse(_trackingNumber, out intTrackingNumber))
                return true;
            else if (_trackingNumber.Length == 16 && int.TryParse(_trackingNumber, out intTrackingNumber))
                return true;
            else
                return false;
        }
    }
}