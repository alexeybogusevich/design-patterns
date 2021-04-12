using System;

namespace Coding.Exercise.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(17);
            // person.Drive();
            var responsiblePerson = new ResponsiblePerson(person);
            Console.WriteLine(responsiblePerson.Drink());
            Console.WriteLine(responsiblePerson.Drive());
            Console.WriteLine(responsiblePerson.DrinkAndDrive());
        }
    }

    public interface IPerson
    {
        int Age { get; set; }

        string Drink();
        string DrinkAndDrive();
        string Drive();
    }

    public class Person : IPerson
    {
        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }
        
        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private readonly Person person;

        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age 
        { 
            get
            {
                return person.Age;
            }
            set
            {
                person.Age = value;
            }
        }

        public string Drink()
        {
            if (Age < 18)
            {
                return "too young";
            }
            return person.Drink();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public string Drive()
        {
            if (Age < 16)
            {
                return "too young";
            }
            return person.Drive();
        }
    }
}
