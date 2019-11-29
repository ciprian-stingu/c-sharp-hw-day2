using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Interface
{
    interface IOrder
    {
        public enum Producer : int { Ford, Skoda };
        string Model
        {
            get;
            set;
        }

        int DeliveryTime
        {
            get;
            set;
        }

        public bool Cancel();
        Interface.IVehicle ProposedVehicle
        {
            get;
            set;
        }

        Interface.IOrder.Producer VehicleProducer
        {
            get;
            set;
        }

        bool Canceled
        {
            get;
            set;
        }

        bool Confirmed
        {
            get;
            set;
        }

        public bool Confirm();
    }
}
