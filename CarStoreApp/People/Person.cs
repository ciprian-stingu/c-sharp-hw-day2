using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.People
{
    class Person : Interface.IPerson
    {
        public Person(string name)
        {
            Name = name;
        }
        public Interface.IOrder EmitOrder(string model)
        {
            Interface.IOrder order = new Helpers.Order();
            order.Model = model;

            return order;
        }

        public string Name
        {
            get;
            private set;
        }

        public bool ConfirmOrder(Interface.IOrder order)
        {
            return true;
        }

        public bool CancelOrder(Interface.IOrder order)
        {
            return true;
        }

        public bool ReceiveVehicle(Interface.IVehicle vehicle)
        {
            return true;
        }
    }
}
