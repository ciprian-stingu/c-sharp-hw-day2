using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Interface
{
    interface IProducer
    {
        public bool ReceiveOrder(Interface.IOrder order);
        public Interface.IVehicle DeliverVehicle();
    }
}
