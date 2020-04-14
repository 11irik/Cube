using System;
using Cube.Entities;
using NUnit.Framework;

namespace CubeTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PointOutOfCube()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 1);
            Point c = new Point(1, 0, 1);
            Point d = new Point(1, 0 ,0);
            Point a1 = new Point(0, 1, 0);
            Point b1 = new Point(0, 1, 1);
            Point c1 = new Point(2, 2, 2);
            Point d1 = new Point(1, 1, 0);

            Assert.Throws<ArgumentException>(
                delegate
                {
                    new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
                });
        }
        
        [Test]
        public void PointInCube()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 1);
            Point c = new Point(1, 0, 1);
            Point d = new Point(1, 0 ,0);
            Point a1 = new Point(0, 1, 0);
            Point b1 = new Point(0, 1, 1);
            Point c1 = new Point(0.5, 0.5, 0.5);
            Point d1 = new Point(1, 1, 0);

            Assert.Throws<ArgumentException>(
                delegate
                {
                    new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
                });
        }
        
        [Test]
        public void Parallelepiped()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 1);
            Point c = new Point(2, 0, 1);
            Point d = new Point(2, 0 ,0);
            Point a1 = new Point(0, 1, 0);
            Point b1 = new Point(0, 1, 1);
            Point c1 = new Point(2, 1, 1);
            Point d1 = new Point(2, 1, 0);

            Assert.Throws<ArgumentException>(
                delegate
                {
                    new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
                });
        }
        
        [Test]
        public void SymmetricalPoint()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 1);
            Point c = new Point(1, 0, 1);
            Point d = new Point(1, 0 ,0);
            Point a1 = new Point(0, 1, 0);
            Point b1 = new Point(0, 1, 1);
            Point c1 = new Point(-1, -1, -1); //opposite
            Point d1 = new Point(1, 1, 0);

            Assert.Throws<ArgumentException>(
                delegate
                {
                    new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
                });
        }

        [Test]
        public void CorrectCube()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 1);
            Point c = new Point(1, 0, 1);
            Point d = new Point(1, 0 ,0);
            Point a1 = new Point(0, 1, 0);
            Point b1 = new Point(0, 1, 1);
            Point c1 = new Point(1, 1, 1);
            Point d1 = new Point(1, 1, 0);

            Cube.Entities.Cube cube = new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
            Assert.AreEqual(1, cube.Volume);
            Assert.AreEqual(1, cube.BaseArea);
        }
        
        [Test]
        public void ZeroCube()
        {
            Point a = new Point(0, 0, 0);
            Point b = new Point(0, 0, 0);
            Point c = new Point(0, 0, 0);
            Point d = new Point(0, 0 ,0);
            Point a1 = new Point(0, 0, 0);
            Point b1 = new Point(0, 0, 0);
            Point c1 = new Point(0, 0, 0);
            Point d1 = new Point(0, 0, 0);

            Cube.Entities.Cube cube = new Cube.Entities.Cube(a, b, c, d, a1, b1, c1, d1);
            Assert.AreEqual(0, cube.Volume);
            Assert.AreEqual(0, cube.BaseArea);
        }
    }
}