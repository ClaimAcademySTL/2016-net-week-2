using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsrtactClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList animals = new ArrayList();

            animals.Add(new Dog());
            animals.Add(new Cat());

            foreach(Animal animal in animals)
            {
                animal.Describe();
                animal.Greet();
            }

            Console.ReadKey();
        }
    }

    abstract class Animal
    {
        public virtual void Describe()
        {
            Console.WriteLine("what is this thing?");
        }

        public abstract void Greet();
    }

    class Dog : Animal
    {
        public override void Describe()
        {
            Console.WriteLine("its a dog");
        }

        public override void Greet()
        {
            Console.WriteLine("bark");
        }
    }

    class Cat : Animal
    {
        public override void Describe()
        {
            Console.WriteLine("its a cat");
        }

        public override void Greet()
        {
            Console.WriteLine("meow");
        }
    }
}
