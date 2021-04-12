using System;

namespace Coding.Exercise.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Triangle(new RasterRenderer()).ToString());
        }
    }

    public interface IRenderer
    {
        string WhatToRenderAs { get; set; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }

        public override string ToString() => $"Drawing {WhatToRenderAs} as lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }

        public override string ToString() => $"Drawing {WhatToRenderAs} as pixels";
    }

    public abstract class Shape
    {
        private readonly IRenderer renderer;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name 
        { 
            get
            {
                return this.renderer.WhatToRenderAs;
            }

            set
            {
                this.renderer.WhatToRenderAs = value;
            }
        }

        public override string ToString()
        {
            return renderer.ToString();
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
}
