using System;

namespace CarStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Interface.IPerson alex = new People.Person("Alex");
            Interface.IOrder fordOrder = alex.EmitOrder("Ford Focus 2015");

            Interface.IStore fordStore = new Building.Store("Ford", "Bucharest");
            fordStore.ReceiveOrder(fordOrder);
            fordOrder = fordStore.UpdateOrderDetails();
            alex.ConfirmOrder(fordOrder);

            Interface.IStore skodaStore = new Building.Store("Skoda", "Bucharest");
            Interface.IOrder skodaOrder = alex.EmitOrder("Skoda Octavia 2015");
            skodaStore.ReceiveOrder(skodaOrder);
            skodaOrder = skodaStore.UpdateOrderDetails();
            alex.ConfirmOrder(skodaOrder);

            alex.CancelOrder(fordOrder);

            //wait 3 weeks
            alex.ReceiveVehicle(skodaStore.DeliverVehicle());

        }
    }
}
