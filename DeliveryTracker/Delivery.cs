using System;

namespace DeliveryTracker
{
    public abstract class Delivery
    {
        protected const int TRACKING_NUMBER_LENGTH = 10;

        protected readonly string _trackingNumber;
        protected DateTime _scheduledDepartureTime;
        protected int _destinationDistanceInMiles;

        public Delivery(string trackingNumber, int destinationDistanceInMiles)
        {
            if (trackingNumber.Length != TRACKING_NUMBER_LENGTH) throw new ArgumentException("The tracking number must be 10 characters long.");
            _trackingNumber = trackingNumber;
            _destinationDistanceInMiles = destinationDistanceInMiles;
        }

        public void SetDepartureTime(DateTime scheduledDepartureTime)
        {   
            if(scheduledDepartureTime < DateTime.Now) throw new ArgumentException("You can't schedule deliveries in the past.");
            _scheduledDepartureTime = scheduledDepartureTime;
        }

        public DateTime GetDepartureTime()
        {
            if(_scheduledDepartureTime == DateTime.MinValue) throw new ApplicationException("Departure time not yet scheduled.");
            return _scheduledDepartureTime;
        }

        public string GetTrackingNumber()
        {
            return _trackingNumber;
        }

        public abstract double CalculateDeliveryTimeInHoursAndHundredths();
    }
}
