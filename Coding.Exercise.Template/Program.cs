using System;

namespace Coding.Exercise.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            var creature1 = new Creature(1, 3);
            var creature2 = new Creature(1, 2);

            var tempGame = new TemporaryCardDamageGame(new Creature[] { creature1, creature2 });
            var winnerTemp = tempGame.Combat(0, 1);
            Console.WriteLine($"TempGame winner: {winnerTemp}");

            var permGame = new PermanentCardDamage(new Creature[] { creature1, creature2 });
            var winnerPerm = permGame.Combat(0, 1);
            Console.WriteLine($"PermGame winner: {winnerPerm}");
        }
    }

    public class Creature
    {
        public int Attack, Health;

        public Creature(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }

    public abstract class CardGame
    {
        public Creature[] Creatures;

        public CardGame(Creature[] creatures)
        {
            Creatures = creatures;
        }

        // returns -1 if no clear winner (both alive or both dead)
        public int Combat(int creature1, int creature2)
        {
            Creature first = Creatures[creature1];
            Creature second = Creatures[creature2];
            Hit(first, second);
            Hit(second, first);
            bool firstAlive = first.Health > 0;
            bool secondAlive = second.Health > 0;
            if (firstAlive == secondAlive) return -1;
            return firstAlive ? creature1 : creature2;
        }

        // attacker hits other creature
        protected abstract void Hit(Creature attacker, Creature other);
    }

    public class TemporaryCardDamageGame : CardGame
    {
        public TemporaryCardDamageGame(Creature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            if (attacker.Attack >= other.Health)
            {
                other.Health = 0;
            }
        }
    }

    public class PermanentCardDamage : CardGame
    {
        public PermanentCardDamage(Creature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            other.Health -= attacker.Attack;
        }
    }
}
