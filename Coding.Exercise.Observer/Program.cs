using System;
using System.Linq;

namespace Coding.Exercise.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            var rat1 = new Rat(game);
            Console.WriteLine($"Rat1: {rat1}");

            var rat2 = new Rat(game);
            Console.WriteLine($"Rat1: {rat1}");
            Console.WriteLine($"Rat2: {rat2}");

            var rat3 = new Rat(game);
            Console.WriteLine($"Rat1: {rat1}");
            Console.WriteLine($"Rat2: {rat2}");
            Console.WriteLine($"Rat3: {rat3}");

            rat3.Dispose();
            Console.WriteLine($"Rat1: {rat1}");
            Console.WriteLine($"Rat2: {rat2}");
            Console.WriteLine($"Rat3: {rat3}");
        }
    }

    public class RatCountModifiedArgs : EventArgs
    {
        public int overallRats;

        public RatCountModifiedArgs(int overallRats)
        {
            this.overallRats = overallRats;
        }
    }

    public class Game
    {
        public event EventHandler<RatCountModifiedArgs> RatCountModified;

        private int GetOverallRatCount()
        {
            var ratCount = RatCountModified?.GetInvocationList()?.Count();
            return ratCount == null ? 1 : ratCount.Value;
        }

        public void HandleRatCountModification(Rat rat)
        {
            RatCountModified?.Invoke(rat, new RatCountModifiedArgs(GetOverallRatCount()));
        }

        // todo
        // remember - no fields or properties!
    }

    public class Rat : IDisposable
    {
        private readonly Game game;
        public int Attack = 1;

        public Rat(Game game)
        {
            this.game = game;
            game.RatCountModified += OnRatCountModified;
            game.HandleRatCountModification(this);
        }

        private void OnRatCountModified(object sender, RatCountModifiedArgs e)
        {
            Attack = e.overallRats;
        }

        public void Dispose()
        {
            game.RatCountModified -= OnRatCountModified;
            game.HandleRatCountModification(this);
            Attack = 0;
        }

        public override string ToString()
        {
            return $"Attack: {Attack}";
        }
    }
}
