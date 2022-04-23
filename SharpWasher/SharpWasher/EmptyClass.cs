using System;
namespace SharpWasher
{
    public class Washer
    {
        public Washer() { }
        public static void wash(Car car) {
            Console.WriteLine("Woo... It was too dirty! \n" +
                "It was dirty for " + car.getDirtySatus() + "\n" +
                "But now " + car.getShortName() + " is looking like a baby!\n");
            car.DirtyStatus = 0;
        }
    }
}
