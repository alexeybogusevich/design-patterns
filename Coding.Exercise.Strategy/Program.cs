using System;
using System.Numerics;

namespace Coding.Exercise.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy = new RealDiscriminantStrategy();
            var solver = new QuadraticEquationSolver(strategy);
            var result = solver.Solve(1, -4, 4);
            Console.WriteLine($"Roots: {result.Item1} {result.Item2}");
        }
    }

    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = b * b - 4 * a * c;
            return discriminant < 0 ? double.NaN : discriminant;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var complexA = new Complex(a, 0);
            var complexB = new Complex(b, 0);
            var complex2A = Complex.Multiply(complexA, 2);
            var complexDiscriminant = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);

            var root1 = Complex.Divide(-complexB + Complex.Sqrt(complexDiscriminant), complex2A);
            var root2 = Complex.Divide(-complexB - Complex.Sqrt(complexDiscriminant), complex2A);

            return new Tuple<Complex, Complex>(root1, root2);
        }
    }
}
