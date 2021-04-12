using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding.Exercise.Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("Hello World!");
            sentence[0].Capitalize = true;
            Console.WriteLine(sentence);
        }
    }

    public class Sentence
    {
        private readonly List<WordToken> tokens;

        public Sentence(string plainText)
        {
            tokens = new List<WordToken>();
            var words = plainText.Split(' ');
            foreach (var word in words)
            {
                var token = new WordToken { Value = word };
                tokens.Add(token);
            }
        }

        public WordToken this[int index]
        {
            get
            {
                return tokens[index];
            }
        }

        public override string ToString()
        {
            return string.Join(" ", tokens.Select(t => t.Capitalize ? t.Value.ToUpper() : t.Value));
        }

        public class WordToken
        {
            public string Value;
            public bool Capitalize;
        }
    }
}
