using System;

namespace Class1.Objects
{

    class Car
    {
        private string _color = string.Empty;
        private string _make = string.Empty;

        public Car()
        {
            Console.WriteLine("parameterless constructor called");
        }

        public Car(string color) : this()
        {
            Console.WriteLine("constructor with ONE parameter called");
            _color = color;
        }

        public Car(string color, string make) : this(color)
        {
            Console.WriteLine("constructor with TWO parameters called");
            _make = make;
        }

        ~Car()
        {
            Console.WriteLine("PEACE OUT!");
        }

        public string Color
        {
            get
            {
                return _color.ToUpper();
            }
            set { _color = value; }
        }

        public string Make
        {
            get
            {
                return _make.ToUpper();
            }
            set { _make = value; }
        }

        public string Model { get; set; }

        public string Describe()
        {
            return string.Format("This car is a {0} {1}.", Color, Make);
        }
    }

}