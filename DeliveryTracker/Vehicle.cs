using System;

namespace DeliveryTracker
{
    public class Vehicle
    {
        private DeliverySchedule _deliveries;

        public Vehicle(DeliverySchedule deliveries)
        {
            _deliveries = deliveries;
        }
        public double CalculateDeliveryTimeInHoursAndHundredths()
        {
            double totalTime = 0;
            foreach(var d in _deliveries.Deliveries)
            {
                totalTime += d.CalculateDeliveryTimeInHoursAndHundredths();
            }
            return Math.Round(totalTime, 2);
        }
    }
}
