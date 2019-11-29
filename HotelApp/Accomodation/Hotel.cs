using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.Accomodation
{
    class Hotel : Interface.Printable
    {
        private List<Room> rooms;
        private string name;
        private string city;

        public Hotel(string name, string city)
        {
            if (name == null || name.Trim() == string.Empty)
            {
                throw new ArgumentException("[Hotel] Invalid name!");
            }
            this.name = name;
            if (city == null || city.Trim() == string.Empty)
            {
                throw new ArgumentException("[Hotel] Invalid city!");
            }
            this.city = city;
            rooms = new List<Room>();
        }

        public bool AddRoom(Room room)
        {
            rooms.Add(room);
            return true;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
        }

        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
        }

        public string Print(int tabs)
        {
            string tabsString = "";
            for (int i = 0; i < tabs; i++) {
                tabsString += "\t";
            }
            StringBuilder data = new StringBuilder();
            data.Append(tabsString + "[HOTEL]\r\n");
            data.Append(tabsString + "NAME: " + name + "\r\n");
            data.Append(tabsString + "CITY: " + city + "\r\n");
            data.Append(tabsString + "ROOMS:\r\n");
            foreach(var room in rooms)
            {
                data.Append(room.Print(1));
            }

            return data.ToString();
        }

        ~Hotel()
        {
            
        }

        public Price.Rate GetBestPrice(int numberOfDays, out Room bestRoom)
        {
            Price.Rate bestRate = null;
            bestRoom = null;
            foreach (var room in rooms)
            {
                if (bestRate == null || room.Rate <= bestRate)
                {
                    bestRate = room.Rate;
                    bestRoom = room;
                }
            }
            return new Price.Rate(bestRate.CurrentCurrency, bestRate.GetPriceForDays(numberOfDays));
        }

        public Price.Rate GetPriceForNumberOfRooms(int numberOfRooms)
        {
            Helper.RoomComparer roomComparer = new Helper.RoomComparer();

            List<Room> roomByPrice = new List<Room>();
            roomByPrice.AddRange(rooms);
            roomByPrice.Sort(roomComparer);

            Price.Rate.CurrencyType currency = roomByPrice[0].Rate.CurrentCurrency;
            double amount = 0;

            for(int i = 0; i < numberOfRooms; i++)
            {
                amount += roomByPrice[i].Rate.GetPriceForDays(1, currency);
            }

            return new Price.Rate(currency, amount);
        }
    }
}
