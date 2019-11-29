using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Building
{
    class Store : Interface.IStore
    {
        Interface.IOrder order;
        Interface.IProducer producer;
        public Store(string name, string city)
        {
            Name = name;
            City = city;
            producer = new Company.Producer();
        }

        public string Name
        {
            get;
            private set;
        }
        public string City
        {
            get;
            private set;
        }

        public bool ReceiveOrder(Interface.IOrder order)
        {
            this.order = order;
            return true;
        }

        public Interface.IOrder UpdateOrderDetails()
        {
            if(order.Model.IndexOf("Ford") > 0)
            {
                Interface.IVehicle proposition = new Helpers.Catalog();
                proposition.Model = order.Model;
                proposition.Price = 15000;
                proposition.PriceCurrency = Interface.IVehicle.Currency.EUR;
                order.ProposedVehicle = proposition;
                order.DeliveryTime = 4 * 7;
            }
            else
            {
                Interface.IVehicle proposition = new Helpers.Catalog();
                proposition.Model = order.Model;
                proposition.Price = 14000;
                proposition.PriceCurrency = Interface.IVehicle.Currency.EUR;
                order.ProposedVehicle = proposition;
                order.DeliveryTime = 3 * 7;
            }
            return order;
        }

        public Interface.IVehicle DeliverVehicle()
        {
            if(order.Canceled || !order.Confirmed)
            {
                return null;
            }
            return producer.DeliverVehicle();
        }
    }
}
