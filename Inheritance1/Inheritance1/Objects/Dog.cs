using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance1.Objects
{
    public class Dog : Animal
    {
        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("BARK!!!!");
        }

        public void WagTail()
        {
            Console.WriteLine("wag wag wag");
        }
    }

    public class Chihuahua : Dog
    {
        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("Yo quiro Taco Bell");
        }
    }
}
