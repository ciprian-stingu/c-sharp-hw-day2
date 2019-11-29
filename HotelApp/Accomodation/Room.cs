using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.Accomodation
{
    class Room : Interface.Printable
    {
        private Price.Rate rate;
        private string name;
        private int adults;
        private int children;

        public Room(string name, int adults = 1, int children = 0, Price.Rate rate = null)
        {
            if(name == null || name.Trim() == string.Empty)
            {
                throw new ArgumentException("[Room] Invalid name!");
            }
            this.name = name;
            this.adults = adults > 0 ? adults : 1;
            this.children = children >= 0 ? children : 0;
            this.rate = rate;
        }

        public int Adults
        {
            get
            {
                return adults;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("[Room] Invalid adults count!");
                }
                adults = value;
            }
        }

        public int Children
        {
            get
            {
                return children;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("[Room] Invalid children count!");
                }
                children = value;
            }
        }

        public Price.Rate Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if(value == null)
                {
                    throw new InvalidOperationException("[Room] Invalid rate!");
                }
                rate = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Print(int tabs)
        {
            string tabsString = "";
            for(int i = 0; i < tabs; i++) {
                tabsString += "\t";
            }
            StringBuilder data = new StringBuilder();
            data.Append(tabsString + "[ROOM]\r\n");
            data.Append(tabsString + "NAME: " + name + "\r\n");
            data.Append(tabsString + "ADULTS: " + adults + "\r\n");
            data.Append(tabsString + "CHILDREN: " + children + "\r\n");
            data.Append(tabsString + "RATE:\r\n");
            data.Append(rate.Print(2));

            return data.ToString();
        }

        public Price.Rate GetPriceForDays(int numberOfDays)
        {
            return new Price.Rate(rate.CurrentCurrency, rate.GetPriceForDays(numberOfDays));
        }
    }
}
