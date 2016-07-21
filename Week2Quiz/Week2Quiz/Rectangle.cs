using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz
{
    class Rectangle
    {
        public double Height {get; }
        public double Width { get; }
        public double Area { get { return Height * Width; } }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        
    }
}
