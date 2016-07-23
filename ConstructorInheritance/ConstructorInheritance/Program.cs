using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            bool errorHappened = false;

            try
            {
                int x = 5 / 2;
            }
            finally
            {
                Console.WriteLine(errorHappened 
                    ? "Error" 
                    : "No Error");
            }

            try
            {
                Rectangle r = new Rectangle(5, 10);
                Square s;
            
                s = new Square(10, 10);

                var shapes = new MyCollection<Rectangle>();
                shapes[0] = r;
                shapes[1] = s;

                var strings = new MyCollection<string>();
                strings[0] = "Hello";
                strings[1] = "World!";

                Console.WriteLine(r.ToString());
                Console.WriteLine(s.ToString());

                Console.Write(Rectangle.CalculateArea(5, 5));

                Console.Write(Square.CalculateArea(1, 2));
                int num = 1;
                int den = 0;
                int sum = num / den;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorHappened = true;
            }
            finally
            {
                Console.WriteLine(errorHappened ? "Error" : "No Error");
            }

            Console.ReadKey();
        }
    }

    public class Rectangle
    {
        private const string CONSTANT_VALUE = "HELLO!!!!!";

        private readonly int width = 0;
        private readonly int height = 0;

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public sealed override string ToString()
        {
            return string.Format("My width is {0} and my height is {1}.", width, height);
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }

    public sealed class Square : Rectangle
    {
        public Square(int width, int height) : base(width, height)
        {
            if (width != height)
            {
                throw new ArgumentException("A Square must have equal height and width!");
            }
        }
    }

    public class MyCollection<T>
    {
        private T[] array = new T[100];

        public T this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }
    }
}
