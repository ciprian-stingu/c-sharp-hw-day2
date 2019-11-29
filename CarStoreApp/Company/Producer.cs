using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Company
{
    class Producer : Interface.IProducer
    {
        Interface.IOrder order;
        public bool ReceiveOrder(Interface.IOrder order)
        {
            this.order = order;
            return true;
        }

        public Interface.IVehicle DeliverVehicle()
        {
            Interface.IVehicle vehicle = new Machinery.Vehicle();
            vehicle.Model = order.ProposedVehicle.Model;
            vehicle.Price = order.ProposedVehicle.Price;
            vehicle.PriceCurrency = order.ProposedVehicle.PriceCurrency;

            return vehicle;
        }


    }
}
