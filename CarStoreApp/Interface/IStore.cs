using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Interface
{
    interface IStore
    {
        public bool ReceiveOrder(Interface.IOrder order);
        public Interface.IOrder UpdateOrderDetails();
        public Interface.IVehicle DeliverVehicle();
    }
}
