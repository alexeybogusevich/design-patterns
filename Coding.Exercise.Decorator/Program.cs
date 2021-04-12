using System;

namespace Coding.Exercise.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon();
            dragon.Age = 0;
            Console.WriteLine(dragon.Crawl());
            Console.WriteLine(dragon.Fly());           
            dragon.Age = 15;
            Console.WriteLine(dragon.Crawl());
            Console.WriteLine(dragon.Fly());
        }

        public class Bird
        {
            public int Age { get; set; }

            public string Fly()
            {
                return (Age < 10) ? "flying" : "too old";
            }
        }

        public class Lizard
        {
            public int Age { get; set; }

            public string Crawl()
            {
                return (Age > 1) ? "crawling" : "too young";
            }
        }

        public class Dragon // no need for interfaces
        {
            private Bird bird = new Bird();
            private Lizard lizard = new Lizard();

            public int Age
            {
                get
                {
                    return bird.Age;
                }
                set
                {
                    bird.Age = lizard.Age = value;
                }
            }

            public string Fly()
            {
                return bird.Fly();
            }

            public string Crawl()
            {
                return lizard.Crawl();
            }
        }
    }
}
