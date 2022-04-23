using System;
using System.Collections.Generic;

namespace SharpWasher {
    public class Garage {
        private string name;
        public List<Car> cars = new List<Car>();
        public Garage(string name) {
            this.name = name;
        }
        public void NewCar(string brand, string model) {
            cars.Add(new Car(brand, model));
            Console.WriteLine("Yep! New " + brand + " in garage \"" + name + "\"\n");
        }
        public void NewCar(Car car) {
            cars.Add(car);
            Console.WriteLine("Yep! New " + car.Brand + " in garage \"" + name + "\"\n");
        }
        public bool LookAllCars() {            
            if (cars.Count == 0) {
                Console.WriteLine("Garage \"{0}\" is empty :(\n", name);
                return false;
            }
            Console.WriteLine("Garage \"{0}\"", name);
            foreach (Car car in cars)
                Console.WriteLine(car);
            return true;
        }

        public Car GetCarWithID(string id) => cars.Find(car => car.ID == id);        

        public void RideCar(Car car, int droveKilometers) => car.Ride(droveKilometers);
    }
}
