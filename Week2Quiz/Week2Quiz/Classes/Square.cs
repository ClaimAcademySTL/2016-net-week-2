using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz.Classes
{
    class Square : Rectangle
    {
        private int _height, _width;

        public Square(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public int height()
        {
            { get: return _height; }

            if(_height == _width)
            {
                { set: _height = value; }
            }
        }

        public int width()
        {
            { get: return _width; }
            if (_width == _height)
            {
                { set: _width = value; }
            }
        }
    }
}
