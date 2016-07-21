using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Color = "Purple";

            Console.WriteLine(car.Describe());

            car = new Car("Red", "Camaro");

            Console.WriteLine(car.Describe());

            car = new Car("Green", "Mini");

            Console.WriteLine(car.Describe());

            car = new Car("Blue");

            Console.WriteLine(car.Describe());

            Console.ReadKey();
        }
    }

    class Car
    {
        private string _color = string.Empty;
        private string _make = string.Empty;

        public Car()
        {
            Console.WriteLine("parameterless constructor called");
        }

        public Car(string color) : this()
        {
            Console.WriteLine("constructor with one parameter called");
            _color = color;
        }

        public Car(string color, string make) : this()
        {
            Console.WriteLine("constructor with two parameters called");
            _make = make;
        }

        ~Car()
        {
            Console.WriteLine("Goodbye");
        }

        public string Color
        {
            get
            {
                return _color.ToUpper();
            }
            set { _color = value;  }
        }

        public string Make
        {
            get
            {
                return _make.ToUpper();
            }
            set { _make = value; }
        }

        public string Describe()
        {
            return string.Format("This car is {0} {1}.", Color, Make);
        }
    }
}
