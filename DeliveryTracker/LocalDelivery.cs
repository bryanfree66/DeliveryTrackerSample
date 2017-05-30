using System;

namespace DeliveryTracker
{
    public class LocalDelivery: Delivery
    {
        public LocalDelivery(string trackingNumber, int destinationDistanceInMiles) : base(trackingNumber, destinationDistanceInMiles) { }
        
        override public double CalculateDeliveryTimeInHoursAndHundredths()
        {
            // Local delivery truck move slower than over the road. 20MPH
            var timeToDeliver = (double)_destinationDistanceInMiles / 20;
            return Math.Round(timeToDeliver, 2);
        }
    }
}
