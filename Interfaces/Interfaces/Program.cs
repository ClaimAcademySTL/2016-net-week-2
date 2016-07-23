using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(new Dog("Spot"));
            animals.Add(new Cat("Garfield"));
            animals.Add(new Dog("Fido"));
            animals.Add(new Dog("George"));

            foreach(IAnimal animal in animals)
            {
                Console.WriteLine(animal.Describe());
            }

            Console.ReadKey();
        }
    }

    public interface IAnimal
    {
        string Describe();

        string Name { get; set; }
    }

    class Dog : IAnimal
    {
        private string name;

        public Dog(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Describe()
        {
            return "Hello, I am a dog and my name is " + name + ".";
        }
    }

    class Cat : IAnimal
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Describe()
        {
            return "Hello, I am a cat and my name is " + name + ".";
        }
    }
}
