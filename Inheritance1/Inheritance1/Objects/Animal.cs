using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance1.Objects
{
    public class Animal
    {
        public virtual void Greet()
        {
            Console.WriteLine("Hello, I am a generic animal!");
        }
    }
}
