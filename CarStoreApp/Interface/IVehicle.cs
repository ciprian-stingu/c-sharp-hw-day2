using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.Interface
{
    interface IVehicle
    {
        public enum Currency : int { EUR, USD };
        string Model
        {
            get;
            set;
        }

        int Price
        {
            get;
            set;
        }

        Interface.IVehicle.Currency PriceCurrency
        {
            get;
            set;
        }
    }
}
