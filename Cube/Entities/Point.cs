using System;

namespace Cube.Entities
{
    public class Point
    {
        private double _x;
        private double _y;
        private double _z;
        
        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public double Z
        {
            get => _z;
            set => _z = value;
        }

        public Point()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }
        
        public Point(double x)
        {
            _x = x;
            _y = 0;
            _z = 0;
        }
        
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
            _z = 0;
        }
        
        public Point(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public override string ToString()
        {
            return $"{_x};{_y};{_z}";
        }
    }
}