using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding.Exercise.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);
            p1.Say(1);
            Console.WriteLine($"P1: {p1}");
            Console.WriteLine($"P2: {p2}");
            p2.Say(2);
            Console.WriteLine($"P1: {p1}");
            Console.WriteLine($"P2: {p2}");
        }
    }
        
    public class Participant
    {
        private readonly Mediator mediator;
        public Guid Id { get; private set; }
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            Id = Guid.NewGuid();
            this.mediator = mediator;
            mediator.Participants.Add(this);
        }

        public void Say(int n)
        {
            mediator.Broadcast(Id, n);
        }

        public override string ToString()
        {
            return $"Value: {Value}";
        }
    }

    public class Mediator
    {
        public List<Participant> Participants { get; private set; }

        public Mediator()
        {
            Participants = new List<Participant>();
        }

        public void Broadcast(Guid sourceId, int value)
        {
            foreach (var p in Participants.Where(x => x.Id != sourceId))
            {
                p.Value = value;
            }
        }
    }
}
