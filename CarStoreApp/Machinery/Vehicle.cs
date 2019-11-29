using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Machinery
{
    class Vehicle : Interface.IVehicle
    {
        public string Model
        {
            get;
            set;
        }

        public int Price
        {
            get;
            set;
        }

        public Interface.IVehicle.Currency PriceCurrency
        {
            get;
            set;
        }
    }
}
