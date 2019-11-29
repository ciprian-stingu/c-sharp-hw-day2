using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Helpers
{
    class Order : Interface.IOrder
    {
        public Order()
        {
            Canceled = false;
            Confirmed = false;
        }
        public string Model
        {
            get
            {
                return Model;
            }
            set 
            {
                VehicleProducer = value.IndexOf("Ford") > 0 ? Interface.IOrder.Producer.Ford : Interface.IOrder.Producer.Skoda;
                Model = value;
            }
        }

        public int DeliveryTime
        {
            get;
            set;
        }

        public bool Cancel()
        {
            Canceled = true;
            return true;
        }

        public bool Canceled
        {
            get;
            set;
        }
        public Interface.IVehicle ProposedVehicle
        {
            get;
            set;
        }
        public Interface.IOrder.Producer VehicleProducer
        {
            get;
            set;
        }

        public bool Confirmed
        {
            get;
            set;
        }

        public bool Confirm()
        {
            Confirmed = true;
            return true;
        }
    }
}
