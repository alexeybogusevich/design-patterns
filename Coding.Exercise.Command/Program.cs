using System;

namespace Coding.Exercise.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new Account(100);
            var cmd1 = new Command(Command.Action.Deposit, 100);
            var cmd2 = new Command(Command.Action.Withdraw, 1000);
            ba.Process(cmd1);
            Console.WriteLine(cmd1);
            Console.WriteLine(ba);

            ba.Process(cmd2);
            Console.WriteLine(cmd2);
            Console.WriteLine(ba);
        }
    }

    public class Command
    {
        public Command()
        {

        }

        public Command(Action action, int amount)
        {
            Amount = amount;
            TheAction = action;
        }

        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;

        public override string ToString()
        {
            return $"Action: {TheAction}, Amount: {Amount}, Success: {Success}";
        }
    }

    public class Account
    {
        public Account()
        {

        }

        public Account(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    if (Balance < c.Amount)
                    {
                        c.Success = false;
                        break;
                    }

                    Balance -= c.Amount;
                    c.Success = true; 
                    break;
            }
        }

        public override string ToString()
        {
            return $"Balance: {Balance}";
        }
    }
}
