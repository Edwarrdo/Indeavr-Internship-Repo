using BankSystem.Enums;
using BankSystem.Models;
using System;

namespace BankSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var depositAccount = new DepositAccount(Clients.Person, 100, 20);
            Console.WriteLine(depositAccount.ShowBalance());
            try
            {
                depositAccount.Deposit(-1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine(depositAccount.CalculateInterestOverPeriod(-10));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            depositAccount.Deposit(203);
            Console.WriteLine(depositAccount.ShowBalance());
            Console.WriteLine(depositAccount.CalculateInterestOverPeriod(10));
            try
            {
                Console.WriteLine($"Fail?: {depositAccount.Withdraw(100000)}");
                depositAccount.Withdraw(-10);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
