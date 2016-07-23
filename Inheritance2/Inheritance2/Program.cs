using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        class BaseClass
        {
            public void SomeNotVirtualMethod()
            {
                Console.WriteLine("I'm not virtual");
            }

            public virtual void VirtualMethod()
            {

            }
        }

        class DerivedClass : BaseClass
        {
            public new void SomeNotVirtualMethod()
            {
                Console.WriteLine("i am hiding the base class method");
            }

            public sealed override void VirtualMethod()
            {
                base.VirtualMethod();
            }
        }

        class AnotherDerivedClass : DerivedClass
        {
            public new void VirtualMethod()
            {

            }
        }
    }
}
