using System;
using System.Collections.Generic;

namespace Coding.Exercise.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingletonTester.IsSingleton(() => { return new List<string>(); }));
        }

        public class SingletonTester
        {
            public static bool IsSingleton(Func<object> func)
            {
                var objectA = func.Invoke();
                var objectB = func.Invoke();
                return objectA == objectB;
            }
        }
    }
}
