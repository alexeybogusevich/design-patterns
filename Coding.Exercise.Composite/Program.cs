using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Coding.Exercise.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var manyValues = new ManyValues() { 1, 2, 3 };
            var singleValue = new SingleValue(4);

            var list = new List<IValueContainer> { manyValues, singleValue };

            Console.WriteLine(list.Sum());
        }
    }

    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value { get; set; }

        public SingleValue()
        {

        }

        public SingleValue(int value)
        {
            Value = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return this.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
