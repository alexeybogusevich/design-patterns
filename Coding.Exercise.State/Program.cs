using System;

namespace Coding.Exercise.State
{
    class Program
    {
        static void Main(string[] args)
        {
            var combinationLock = new CombinationLock(new[] { 1, 1, 3, 4, 5 });
            combinationLock.EnterDigit(1);
            Console.WriteLine(combinationLock.Status);

            combinationLock.EnterDigit(2);
            Console.WriteLine(combinationLock.Status);

            combinationLock.EnterDigit(3);
            Console.WriteLine(combinationLock.Status);

            combinationLock.EnterDigit(4);
            Console.WriteLine(combinationLock.Status);

            combinationLock.EnterDigit(5);
            Console.WriteLine(combinationLock.Status);
        }
    }

    public enum EnumStatus
    {
        LOCKED,
        ERROR,
        OPEN,
        TYPING
    }

    public class CombinationLock
    {
        private int[] combination;
        private int elementAt = 0;

        public CombinationLock(int[] combination)
        {
            this.combination = combination;
        }

        // you need to be changing this on user input
        public EnumStatus ActualStatus = EnumStatus.LOCKED;
        public string Status = nameof(EnumStatus.LOCKED);

        public void EnterDigit(int digit)
        {
            switch (ActualStatus)
            {
                case (EnumStatus.LOCKED):
                    if (CheckDighit(digit))
                    {
                        Status = digit.ToString();
                        ActualStatus = EnumStatus.TYPING;
                        elementAt = 1;
                    }
                    else
                    {
                        Status = nameof(EnumStatus.ERROR);
                        ActualStatus = EnumStatus.ERROR;
                    }
                    break;
                case EnumStatus.TYPING:
                    if (CheckDighit(digit))
                    {
                        Status += digit.ToString();
                        elementAt++;

                        if (elementAt == combination.Length)
                        {
                            ActualStatus = EnumStatus.OPEN;
                            Status = nameof(EnumStatus.OPEN);
                        }
                    }
                    else
                    {
                        ActualStatus = EnumStatus.ERROR;
                        Status = nameof(EnumStatus.ERROR);
                    }
                    break;
                case EnumStatus.ERROR:
                    break;
                case EnumStatus.OPEN:
                    break;
            }
        }

        private bool CheckDighit(int digit)
        {
            return digit == combination[elementAt];
        }
    }
}
