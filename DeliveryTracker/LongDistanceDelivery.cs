
using System;

namespace DeliveryTracker
{
    public class LongDistanceDelivery : Delivery
    {
        public LongDistanceDelivery(string trackingNumber, int destinationDistanceInMiles) : base(trackingNumber, destinationDistanceInMiles) { }

        override public double CalculateDeliveryTimeInHoursAndHundredths()
        {
            // Long distance delivery truck move faster over longer distances. 50MPH
            var timeToDeliver = (double) _destinationDistanceInMiles / 50;
            return Math.Round(timeToDeliver, 2);
        }
    }
}
