using System;
using System.Collections.Generic;

namespace Coding.Exercise.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                Person.Factory.CreatePerson("Alex"),
                Person.Factory.CreatePerson("Matt"),
                Person.Factory.CreatePerson("Simon")
            };

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person
    {
        private Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static PersonFactory Factory = new PersonFactory();

        public class PersonFactory
        {
            private int Id = 0;

            public Person CreatePerson(string name)
            {
                return new Person(Id++, name);
            }
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}";
        }
    }
}