using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(10, 15);
            Rectangle rec2 = new Rectangle(20, 30);

            Console.WriteLine(Rectangle.CalculateArea(5, 4));

            rec.OutputArea();
            rec2.OutputArea();

            Console.ReadKey();
        }
    }

    public class Rectangle
    {
        private int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void OutputArea()
        {
            Console.WriteLine("Area output: " + Rectangle.CalculateArea(this.width, this.height));
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }
}
