using Problem8.Models;
using System;
using System.Collections.Generic;

namespace Problem8
{
    public enum CustomerType
    {
        Individual,
        Company,
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            Int32 monthsToCalculateInterest = 0;
            List<string> input = ReadInput(ref monthsToCalculateInterest);

            List<Account> accounts = ParseInput(input);

            accounts.ForEach(a => Console.WriteLine("{0:0.0000}", a.CalculateInterest(monthsToCalculateInterest)));

        }
        private static List<string> ReadInput(ref Int32 monthsToCalculateInterest)
        {
            List<string> input = new List<string>();
            Int32 numberOfLines;

            string firstLineOfInput = Console.ReadLine();

            monthsToCalculateInterest = Int32.Parse(firstLineOfInput);

            string secondLIne = Console.ReadLine();

            numberOfLines = Int32.Parse(secondLIne);

            for (int lineCounter = 0; lineCounter < numberOfLines; lineCounter++)
            {
                string line = Console.ReadLine();
                input.Add(line);
            }

            return input;
        }

        private static List<Account> ParseInput(List<string> input)
        {
            const Int32 accountTypeIndex = 0, accountNameIndex = 1, balanceIndex = 2, interestRateIndex = 3;
            List<Account> shapes = new List<Account>();

            foreach (String line in input)
            {
                String[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (words[accountTypeIndex].ToLower())
                {
                    case "loanaccount":
                        {
                            LoanAccount loanAccount = new LoanAccount(new Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestRateIndex]));
                            shapes.Add(loanAccount);
                        }
                        break;

                    case "depositaccount":
                        {
                            DepositAccount depositAccount = new DepositAccount(new Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestRateIndex]));
                            shapes.Add(depositAccount);
                        }
                        break;

                    case "mortageaccount":
                        {
                            MortgageAccount mortageAccount = new MortgageAccount(new Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestRateIndex]));
                            shapes.Add(mortageAccount);
                        }
                        break;
                    default:
                        {
                            throw new ArgumentException("Uknown type!");
                        }
                }
            }

            return shapes;
        }

    }
}
