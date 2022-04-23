using System;

namespace SharpWasher {
    class MainClass {
        public delegate void Ride(Car car, int droveKilometers);

        public static void Main(string[] args) {
            Console.WriteLine("\t*** SharpWasher ***\n");

            Garage satellite = new Garage("Satellite");            

            Car BMW_X5 = new Car("BMW", "X5");
            satellite.NewCar(BMW_X5);
            satellite.NewCar("Cadillac", "Eldorado");
            satellite.NewCar("Porshe", "Taycan");

            UI1(satellite, "");            
        }

        public static void UI1(Garage satellite, string message) {
            Ride ride = satellite.RideCar;
            
            PrintMessage(message);            
            satellite.LookAllCars();

            Console.WriteLine("Write a:\n" +
                "\t* goverment number to DRIVE a car;\n" +
                "\t* 'NEW' to add a new car;\n" +
                "\t* 'Q' to close the game.\n" +
                "");
            Console.Write("input >>> ");
            string input = Console.ReadLine();

            if (input.Length == 4) {
                bool exist = false;
                try {
                    ride(satellite.GetCarWithID(input), 0);
                    exist = true;
                } catch {
                    Console.Clear();
                    UI1(satellite, "Car with this number doesn`t exist!");
                } if (exist) {
                    Console.WriteLine("How many kilometers do you want to drive?");
                    Console.Write("input >>> ");
                    int droveKilometers = int.Parse(Console.ReadLine());
                    Console.Clear();
                    ride(satellite.GetCarWithID(input), droveKilometers);
                    UI1(satellite, "");
                }
            }
            else if (input.Length == 3) {
                Console.WriteLine("Write through the space cars brand and model name.");
                Console.Write("input >>> ");
                string inp = Console.ReadLine();
                string[] inpSplitted = inp.Trim().Split();
                satellite.NewCar(inpSplitted[0], inpSplitted[1]);
                UI1(satellite, "");
            }
            else if (input == "Q") {
                Console.Clear();
                PrintMessage("Good bye!");
            }            
        }

        public static void PrintMessage(string message) {           
            if (message != "") {                
                Console.WriteLine(new string('-', message.Length + 4));
                Console.WriteLine("* " + message + " *");
                Console.WriteLine(new string('-', message.Length + 4) + "\n");
            }
        }
    }    
}
