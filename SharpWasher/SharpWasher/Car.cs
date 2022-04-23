using System;
using System.Globalization;

namespace SharpWasher
{
    public delegate void Wash(Car car);
    public class Car
    {
        Wash wash = Washer.wash;

        private string brand;   public string Brand { get => brand; }
        private string model;
        private string id;      public string ID { get => id.Split()[1]; }
        private void setID() {
            id = "CA ";
            Random random = new Random();
            for (int i = 1; i <= 4; i++)
                id += random.Next(0, 10).ToString();
            id += " CK";
        }
        private double dirtyStatus;     public double DirtyStatus { get => dirtyStatus; set => dirtyStatus = value; }
        public string getDirtySatus() => this.dirtyStatus.ToString("P1", CultureInfo.InvariantCulture);
        public void Ride(int droveKilometers) {
            if (droveKilometers != 0) {
                Console.Clear();
                Console.WriteLine("\n" + brand + " - " + model + " is traveling " + droveKilometers + " kilometers..." + "\n");
                dirtyStatus += droveKilometers * 0.000555;
                if (dirtyStatus >= 1.0)
                    wash(this);
            }
        }

        public Car() { }
        public Car(string brand, string model) {
            this.brand = brand;
            this.model = model;
            setID();
            dirtyStatus = 0.0;
        }
       
        public override string ToString() =>
            "\tCar: " + brand + " - " + model + "\n" +
            "\tGoverment number: " + id + "\n" +
            "\tDirty percent: " + getDirtySatus() + "\n";
        public string getShortName() => Brand + " " + model + "(" + id + ")";
    }
}
