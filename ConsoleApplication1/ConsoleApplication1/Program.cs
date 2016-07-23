using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleStruct s = new SimpleStruct();
            //s.X = 5;

            //s.Display();

            TheStruct a = new TheStruct();
            TheClass b = new TheClass();
            a.x = 1;
            b.x = 1;
            structtaker(a);
            classtaker(b);
            Console.WriteLine("a.x = {0}", a.x);
            Console.WriteLine("b.x = {0}", b.x);

            Console.ReadKey();
        }

    public static void structtaker(TheStruct s)
    {
        s.x = 5;
    }
    public static void classtaker(TheClass c)
    {
        c.x = 5;
    }
}



    public struct SimpleStruct
    {
        private int x;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public void Display()
        {
            Console.WriteLine("The value is {0}", x);
        }
    }

    class TheClass
    {
        public int x;
    }

    struct TheStruct
    {
        public TheStruct(int x)
        {
            this.x = x;
        }

        public int x;
    }
}
