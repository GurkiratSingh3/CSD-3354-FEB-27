using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD_3354_FEB_27
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor();
            var order = new Order { DatePlaced = DateTime.Now, TotalPrice = 100f };
            orderProcessor.Process(order);
        }
    }
    public class OrderProcessor
    {
        private readonly ShippingCalculator _shippingCalculator;
            public OrderProcessor()
        {
            _shippingCalculator = new ShippingCalculator();
        }
        public void Proccess(Order order)
        {
            if (order.IsShipped)
                throw new InvalidIperationException("This order is already processed.");
            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1);
            }
        }
    }
}
