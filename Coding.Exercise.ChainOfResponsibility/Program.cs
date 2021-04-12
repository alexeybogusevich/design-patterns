using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding.Exercise.ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var goblin1 = new Goblin(game);
            var goblin2 = new Goblin(game);
            var goblin3 = new Goblin(game);
            var goblinKing = new GoblinKing(game);
            game.Creatures.Add(goblin1);
            game.Creatures.Add(goblin2);
            game.Creatures.Add(goblin3);
            game.Creatures.Add(goblinKing);
            Console.WriteLine(game);
        }
    }

    public abstract class Creature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
    }

    public class Goblin : Creature
    {
        protected readonly Game game;

        protected int InitialAttack = 1;
        protected int InitialDefense = 1;

        public new int Attack 
        { 
            get
            {
                var kingsCount = game.Creatures.Where(c => c.GetType().Equals(typeof(GoblinKing))).Count();
                return InitialAttack + kingsCount;
            }
        }

        public new int Defense
        {
            get
            {
                return InitialDefense + game.Creatures.Count - 1;
            }
        }

        public Goblin(Game game) 
        {
            this.game = game;
        }

        public override string ToString()
        {
            return $"GOBLIN: Attack: {Attack}, Defense: {Defense}";
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game) 
        {
            InitialAttack = 3;
            InitialDefense = 3;
        }

        public override string ToString()
        {
            return $"GOBLIN KING: Attack: {Attack}, Defense: {Defense}";
        }
    }

    public class Game
    {
        public IList<Creature> Creatures;

        public Game()
        {
            Creatures = new List<Creature>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var c in Creatures)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
    }
}
