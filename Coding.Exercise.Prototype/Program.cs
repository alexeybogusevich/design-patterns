using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace Coding.Exercise.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointA = new Point(1, 2);
            var pointB = new Point(3, 4);
            var line = new Line(pointA, pointB);

            var lineCopy = line.DeepCopy();

            lineCopy.Start.X = 100;
            lineCopy.End.X = 1000;

            Console.WriteLine(line);
            Console.WriteLine(lineCopy);
        }

        public class Point
        {
            public Point() { }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X, Y;

            public override string ToString()
            {
                return $"({X},{Y})";
            }
        }

        public class Line
        {
            public Point Start, End;

            public Line() { }

            public Line(Point start, Point end)
            {
                Start = start;
                End = end;
            }

            public Line DeepCopy()
            {
                // could also use serialization or copy constructor
                var start = new Point(Start.X, Start.Y);
                var end = new Point(End.X, End.Y);
                return new Line(start, end);
            }

            public override string ToString()
            {
                return $"Start = {Start}, End = {End}";
            }
        }
    }
}
