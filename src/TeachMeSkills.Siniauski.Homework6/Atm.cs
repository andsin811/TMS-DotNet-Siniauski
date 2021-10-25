using System;
using System.Collections.Generic;

namespace TeachMeSkills.Siniauski.Homework6
{
    internal enum Currency
    {
        BYN,
        USD,
        EUR
    }

    public class Atm
    {
        private double balance;

        private event Func<int, Currency, bool> Operation;

        private Action<int, Currency> PrintOperationInfo;

        private static Dictionary<Currency, double> ExchangeRates = new Dictionary<Currency, double>()
        {
            { Currency.BYN, 1.0 },
            { Currency.USD, 2.45 },
            { Currency.EUR, 2.85 }
        };

        private bool PutMoney(int value, Currency currency)
        {
            balance += (double)value * ExchangeRates[currency];
            return true;
        }

        private bool GetMoney(int value, Currency currency)
        {
            if ((double)value * ExchangeRates[currency] > balance)
            {
                return false;
            }
            balance -= (double)value * ExchangeRates[currency];
            return true;
        }

        private void PrintBalance() => Console.WriteLine($"Balance: {Math.Round(balance, 2)} BYN");

        private Currency GetCurrency()
        {
            while (true)
            {
                Console.WriteLine("Enter currency (BYN (0), USD (1), EUR (2)):");
                string input = Console.ReadLine();
                if (Enum.TryParse(input, out Currency currency) && Enum.IsDefined(currency))
                {
                    return currency;
                }
                Console.WriteLine("Incorrect currency value!");
            }
        }

        private int GetSumValue()
        {
            while (true)
            {
                Console.WriteLine("Enter sum value:");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int sumValue) && sumValue > 0)
                {
                    return sumValue;
                }
                Console.WriteLine("Incorrect sum value!");
            }
        }

        private void PrintGoodOperationInfo(int sumValue, Currency currency)
        {
            if (Operation == PutMoney)
            {
                Console.WriteLine($"Status: OK. {sumValue} {currency} has been successfully added to the balance");
            }
            if (Operation == GetMoney)
            {
                Console.WriteLine($"Status: OK. {sumValue} {currency} has been successfully removed from the balance");
            }
        }

        private void PrintBadOperationInfo(int sumValue, Currency currency)
        {
            Console.WriteLine($"Status: Failed");
        }

        private void RunOperation()
        {
            Currency currency = GetCurrency();
            int sumValue = GetSumValue();
            if (Operation?.Invoke(sumValue, currency) == true)
            {
                PrintOperationInfo = PrintGoodOperationInfo;
            }
            else
            {
                PrintOperationInfo = PrintBadOperationInfo;
            }
            PrintOperationInfo?.Invoke(sumValue, currency);
        }

        public void Run()
        {
            PrintBalance();
            Console.WriteLine("Work modes:" +
                    "\n\tP - put money" +
                    "\n\tG - get money" +
                    "\n\tV - view balance" +
                    "\n\texit - exit the program");
            while (true)
            {
                Console.WriteLine("Enter work mode:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "P":
                        {
                            Operation = PutMoney;
                            RunOperation();
                        }
                        break;

                    case "G":
                        {
                            Operation = GetMoney;
                            RunOperation();
                        }
                        break;

                    case "V":
                        {
                            PrintBalance();
                        }
                        break;

                    case "exit":
                        {
                            return;
                        }
                    default:
                        Console.WriteLine("Incorrect work mode!");
                        break;
                }
            }
        }
    }
}