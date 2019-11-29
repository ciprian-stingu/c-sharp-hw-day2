using System;

namespace HotelApp
{
    class Program
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Create hotel 'Hotel One'");
            Accomodation.Hotel hotel = CreateHotel("Hotel One", "Iasi");
            Console.WriteLine("----- '{0}' info ------", hotel.Name);
            Console.WriteLine(hotel.Print(0));
            Console.WriteLine("Delete hotel '{0}'", hotel.Name);
            hotel = null;

            Console.WriteLine("Create hotel 'Hotel Two'");
            hotel = CreateHotel("Hotel Two", "Bucharest");
            Console.WriteLine("----- '{0}' info ------", hotel.Name);
            Console.WriteLine(hotel.Print(0));

            Price.Rate bestRate = hotel.GetPriceForNumberOfRooms(3);
            Console.WriteLine("Best price for 1 day and {0} rooms: {1:0.00} {2}", 3, bestRate.Amount, bestRate.CurrentCurrency);

            Accomodation.Room bestRoom = null;
            bestRate = hotel.GetBestPrice(3, out bestRoom);
            Console.WriteLine("Best price for 1 room and {0} days: {1:0.00} {2} for room '{3}'", 3, bestRate.Amount, bestRate.CurrentCurrency, bestRoom.Name);

        }

        static Accomodation.Hotel CreateHotel(string name, string city)
        {
            Accomodation.Hotel hotel = null;
            try
            {
                hotel = new Accomodation.Hotel(rnd.Next(0, 2) % 2 == 0 ? null : name, rnd.Next(0, 2) % 2 == 0 ? null : city);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if(hotel == null)
            {
                hotel = new Accomodation.Hotel(name, city);
            }

            AddRoom(hotel, "Room One");
            AddRoom(hotel, "Room Two");
            AddRoom(hotel, "Room Three");
            AddRoom(hotel, "Room Four");
            AddRoom(hotel, "Room Five");

            return hotel;
        }
        static void AddRoom(Accomodation.Hotel hotel, string name)
        {
            Accomodation.Room room = null;
            
            try
            {
                room = new Accomodation.Room(
                    rnd.Next(0, 2) % 2 == 1 ? null : name,
                    rnd.Next(1, 5),
                    rnd.Next(0, 5),
                    rnd.Next(0, 10) % 2 == 1 ?
                        new Price.Rate(
                            rnd.Next(0, 10) % 2 == 1 ? Price.Rate.CurrencyType.EUR : Price.Rate.CurrencyType.USD,
                            rnd.NextDouble() * 100
                        )
                        : null
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(room == null)
            {
                room = new Accomodation.Room(
                    name,
                    rnd.Next(1, 5),
                    rnd.Next(0, 5),
                    rnd.Next(0, 10) % 2 == 1 ?
                        new Price.Rate(
                            rnd.Next(0, 10) % 2 == 1 ? Price.Rate.CurrencyType.EUR : Price.Rate.CurrencyType.USD,
                            rnd.NextDouble() * 100)
                        : null
                );
            }
            if(room.Rate == null)
            {
                room.Rate = new Price.Rate(
                        rnd.Next(0, 10) % 2 == 1 ? Price.Rate.CurrencyType.EUR : Price.Rate.CurrencyType.USD,
                        rnd.NextDouble() * 100
                );
            }
            
            hotel.AddRoom(room);
        }
    }
}
