using System;

namespace Coding.Exercise.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(10);
            var adapter = new SquareToRectangleAdapter(square);
            IRectangle adaptedSquare = adapter;
            Console.WriteLine(adaptedSquare.Area());
        }
    }

    public class Square
    {
        public Square() { }

        public Square(int side)
        {
            Side = side;
        }

        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;

        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }

        public int Width 
        { 
            get
            {
                return square.Side;
            }

            set
            {
                square.Side = value;
            }
        }

        public int Height
        {
            get
            {
                return square.Side;
            }

            set
            {
                square.Side = value;
            }
        }
    }
}
