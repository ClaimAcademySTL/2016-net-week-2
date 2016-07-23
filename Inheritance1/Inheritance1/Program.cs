using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance1.Objects;

namespace Inheritance1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal();

            //animal.Greet();

            //Dog dog = new Dog();

            //dog.Greet();

            //dog.WagTail();

            Chihuahua kickingDog = new Chihuahua();

            kickingDog.Greet();

            Console.ReadKey();
        }
    }
}
