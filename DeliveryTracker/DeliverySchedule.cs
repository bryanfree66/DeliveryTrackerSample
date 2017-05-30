using System;
using System.Collections.Generic;

namespace DeliveryTracker
{
    public class DeliverySchedule
    {
        private List <Delivery> _deliveries;
        public DeliverySchedule(List <Delivery> deliveries )
        {
            _deliveries = deliveries;
        }

        public List <Delivery> Deliveries
        {
            get { return _deliveries;}
        }
    }
}
