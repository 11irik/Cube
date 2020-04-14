using System;

namespace Cube.Entities
{
    public class Cube
    {
        private Point _a;
        private Point _b;
        private Point _c;
        private Point _d;
        private Point _a1;
        private Point _b1;
        private Point _c1;
        private Point _d1;
       
        private double _baseArea;
        private double _volume;

        public Point A
        {
            get => _a;
            set => _a = value;
        }

        public Point B
        {
            get => _b;
            set => _b = value;
        }

        public Point C
        {
            get => _c;
            set => _c = value;
        }

        public Point D
        {
            get => _d;
            set => _d = value;
        }

        public Point A1
        {
            get => _a1;
            set => _a1 = value;
        }

        public Point B1
        {
            get => _b1;
            set => _b1 = value;
        }

        public Point C1
        {
            get => _c1;
            set => _c1 = value;
        }

        public Point D1
        {
            get => _d1;
            set => _d1 = value;
        }

        public double BaseArea
        {
            get => _baseArea;
        }

        public double Volume
        {
            get => _volume;
        }

        public Cube()
        {
            _a = new Point();
            _b = new Point(0, 0, 1);
            _c = new Point(1, 0, 1);
            _d = new Point(1, 0, 0);
            _a1 = new Point(0, 1, 0);
            _b1 = new Point(0, 0, 1);
            _c1 = new Point(1, 1, 1);
            _d1 = new Point(0, 0, 1);
        }

        private double GetLength(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2) + Math.Pow(pointA.Z - pointB.Z, 2));
        }
        
        public Cube(Point a, Point b, Point c, Point d, Point a1, Point b1, Point c1, Point d1)
        {
            double sideLength = GetLength(a, b);
            double sideLengthSquare = Math.Pow(sideLength, 2);
            double sqrtOfThree = Math.Sqrt(3);
            double eps = 0.01;
            
            //check that the coordinate system is rectangular and forming sides are equal
            if (Math.Abs(GetLength(a, a1) - sideLength) > eps || Math.Abs(GetLength(a, d) - sideLength) > eps)
            {
                throw new ArgumentException();
            }
            if (Math.Abs(Math.Pow(GetLength(a1, d), 2) - 2 * sideLengthSquare) > eps ||
                Math.Abs(Math.Pow(GetLength(a1, b), 2) - 2 * sideLengthSquare) > eps ||
                Math.Abs(Math.Pow(GetLength(b, d), 2) - 2 * sideLengthSquare) > eps)
            {
                throw new ArgumentException();
            }
            
            //Check other points
            //Point c1
            if (Math.Abs(GetLength(a, c1) - sideLength * sqrtOfThree) > eps ||
                Math.Abs(Math.Pow(GetLength(a1, c1), 2) - 2 * sideLengthSquare) > eps ||
                Math.Abs(Math.Pow(GetLength(d, c1), 2) - 2 * sideLengthSquare) > eps)
            {
                throw new ArgumentException();
            }
            
            //point d1
            if (Math.Abs(GetLength(b, d1) - sideLength * sqrtOfThree) > eps ||
                Math.Abs(GetLength(a1, d1) - sideLength) > eps ||
                Math.Abs(GetLength(d, d1) - sideLength) > eps)
            {
                throw new ArgumentException();
            }
            
            //point b1
            if (Math.Abs(GetLength(d, b1) - sideLength * sqrtOfThree) > eps ||
                Math.Abs(GetLength(a1, b1) - sideLength) > eps ||
                Math.Abs(GetLength(b, b1) - sideLength) > eps)
            {
                throw new ArgumentException();
            }
            
            //point c
            if (Math.Abs(GetLength(a1, c) - sideLength * sqrtOfThree) > eps ||
                Math.Abs(GetLength(b, c) - sideLength) > eps ||
                Math.Abs(GetLength(d, c) - sideLength) > eps)
            {
                throw new ArgumentException();
            }

            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _a1 = a1;
            _b1 = b1;
            _c1 = c1;
            _d1 = d1;
            _baseArea = sideLengthSquare;
            _volume = _baseArea * sideLength;
        }

        public override string ToString()
        {
            return $"a: {_a}\nb: {_b}\nc: {_c}\nd: {_d}\na1: {_a1}\nb1: {_b1}\nc1: {_d1}\nd1: {_c1}";
        }
    }
}