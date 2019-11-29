using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.Price
{
    class Rate : Interface.Printable
    {
        public enum CurrencyType : int { EUR, USD };

        private CurrencyType currentCurrency;
        private double currentAmount;

        public Rate(CurrencyType type, double amount)
        {
            currentCurrency = type;
            if(amount <= 0)
            {
                throw new ArgumentException("[Rate] Invalid amount!");
            }
            currentAmount = amount;
        }
        
        public CurrencyType CurrentCurrency
        {
            get
            {
                return currentCurrency;
            }
        }

        public bool ConvertTo(CurrencyType type)
        {
            if (currentCurrency == type)
            {
                return true;
            }
            currentAmount *= GetConversionRate(type);
            currentCurrency = type;
            return true;
        }

        private double GetConversionRate(CurrencyType type)
        {
            if (type == CurrencyType.USD && currentCurrency == CurrencyType.EUR)
            {
                return 0.91;
            }
            else if (type == CurrencyType.EUR && currentCurrency == CurrencyType.USD)
            {
                return 1.10;
            }
            return 1;
        }

        public double GetPriceForDays(int numberOfDays)
        {
            return currentAmount * (numberOfDays > 0 ? numberOfDays : 1);
        }

        public double GetPriceForDays(int numberOfDays, CurrencyType type)
        {
            return currentAmount * (numberOfDays > 0 ? numberOfDays : 1) * GetConversionRate(type);
        }

        public double Amount
        {
            get
            {
                return currentAmount;
            }
        }
        public string Print(int tabs)
        {
            string tabsString = "";
            for(int i = 0; i < tabs; i++) {
                tabsString += "\t";
            }
            StringBuilder data = new StringBuilder();
            data.Append(tabsString + "[RATE]\r\n");
            data.Append(tabsString + "CURRENCY: " + currentCurrency + "\r\n");
            data.Append(tabsString + "AMOUNT: " + currentAmount + "\r\n");

            return data.ToString();
        }

        public static bool operator >=(Rate x, Rate y)
        {
            return x.GetPriceForDays(1, y.CurrentCurrency) >= y.GetPriceForDays(1);
        }

        public static bool operator <=(Rate x, Rate y)
        {
            return x.GetPriceForDays(1, y.CurrentCurrency) <= y.GetPriceForDays(1);
        }
        public static bool operator >(Rate x, Rate y)
        {
            return x.GetPriceForDays(1, y.CurrentCurrency) > y.GetPriceForDays(1);
        }

        public static bool operator <(Rate x, Rate y)
        {
            return x.GetPriceForDays(1, y.CurrentCurrency) < y.GetPriceForDays(1);
        }

        /*public static bool operator ==(Rate x, Rate y)
        {
            if(Object.ReferenceEquals(x, null))
            {
                if (Object.ReferenceEquals(y, null))
                {
                    return true;
                }

                return false;
            }

            if(x.Equals(y))
            {
                return true;
            }

            return x.GetPriceForDays(1, y.CurrentCurrency) == y.GetPriceForDays(1);
        }

        public static bool operator !=(Rate x, Rate y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Rate);
        }

        public bool Equals(Rate p)
        {
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.GetType() != p.GetType())
            {
                return false;
            }

            return (currentCurrency == p.currentCurrency) && (currentAmount == p.currentAmount);
        }

        public override int GetHashCode()
        {
            return (int)currentAmount * 0x00010000 + (int)currentCurrency;
        }*/
    }
}
