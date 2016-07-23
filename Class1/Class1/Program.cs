using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class1.Objects;

namespace Class1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuff();

            Console.ReadKey();
        }

        static void DoStuff()
        {
            Car car = new Car();
            car.Color = "Purple";
            Console.WriteLine(car.Describe());

            car = new Car("Red", "Camero");

            Console.WriteLine(car.Describe());

            car = new Car("Green", "Mini");

            Console.WriteLine(car.Describe());

            car = new Car("Blue");

            Console.WriteLine(car.Describe());

            car.Model = "Cutlass";

            Console.WriteLine(car.Model);

            car = null;
        }
    }
}
