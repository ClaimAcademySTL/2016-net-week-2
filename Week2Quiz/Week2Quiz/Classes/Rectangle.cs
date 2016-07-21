using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz.Classes
{
    class Rectangle
    {

        private int _height, _width;

        public Rectangle(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public int height()
        {
            { get: return _height; }
            { set: _height = value; }
        }

        public int width()
        {
            { get: return _width; }
            { set: _width = value; }
        }
    }
}
