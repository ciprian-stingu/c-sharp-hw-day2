using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Interface
{
    interface IPerson
    {
        public Interface.IOrder EmitOrder(string model);
        public bool ConfirmOrder(Interface.IOrder order);

        public bool CancelOrder(Interface.IOrder order);

        public bool ReceiveVehicle(Interface.IVehicle vehicle);
    }
}
