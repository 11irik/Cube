using System;
using System.Collections;
using System.IO;
using System.Linq;
using Cube.Entities;

namespace Cube
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArrayList cubeList = new ArrayList();
            string[] lines = System.IO.File.ReadAllLines("input.txt");
            
            foreach (string line in lines)
            {
                Point[] points = new Point[8];
                double[] coords = line.Split(',').Select(double.Parse).ToArray();
                
                for (int i = 0; i <= coords.Length-3; i+=3)
                {
                    points[i/3] = new Point(coords[i], coords[i+1], coords[i+2]);
                }

                try
                {
                    Entities.Cube cube = new Entities.Cube(
                        points[0], points[1], points[2], points[3], 
                        points[4], points[5], points[6], points[7]);
                    cubeList.Add(cube);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Such a cube does not exist");
                }
            }

            foreach (Entities.Cube cube in cubeList)
            {
                Console.WriteLine($"Cube:\n{cube.ToString()}\nVolume: {cube.Volume}\nBase area: {cube.BaseArea}");
            }
        }
    }
}