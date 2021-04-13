using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding.Exercise.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var token1 = new Token(1);
            var token2 = new Token(2);
            var token3 = new Token(3);
            var tokenMachine = new TokenMachine();
            var m1 = tokenMachine.AddToken(token1);
            var m2 = tokenMachine.AddToken(token2);
            var m3 = tokenMachine.AddToken(token3);

            Console.WriteLine(tokenMachine);

            tokenMachine.Revert(m2);
            Console.WriteLine(tokenMachine);
        }
    }

    public class Token
    {
        public int Value = 0;

        public Token() { }

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<int> Values { get; private set; }

        public Memento() { }

        public Memento(List<Token> tokens)
        {
            Values = tokens.Select(t => t.Value).ToList();
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            var token = new Token(value);
            Tokens.Add(token);
            return new Memento(Tokens);
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(Tokens);
        }

        public void Revert(Memento m)
        {
            Tokens = new List<Token>(m.Values.Select(v => new Token(v)).ToList());
        }

        public override string ToString()
        {
            return string.Join(" ", Tokens.Select(t => t.Value));
        }
    }
}
