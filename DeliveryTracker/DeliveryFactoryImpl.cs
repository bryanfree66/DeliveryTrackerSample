using System;
using System.Linq;

namespace DeliveryTracker
{
    public class DeliveryFactoryImpl: DeliveryFactory
    {
        private const int TRACKING_NUMBER_LENGTH = 10;
        private Random random = new Random();

        public Delivery CreateDelivery(int distanceInMiles)
        {
            string trackingNumber = GenerateTrackingNumber();
            if (distanceInMiles < 100)
            {
                return new LocalDelivery(trackingNumber,distanceInMiles);
            }
            else
            {
                return new LongDistanceDelivery(trackingNumber, distanceInMiles);
            }
        }

        private string GenerateTrackingNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, TRACKING_NUMBER_LENGTH)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
