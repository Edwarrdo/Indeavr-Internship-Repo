using BankSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Interfaces
{
    public interface IAccount
    {
        decimal ShowBalance();

        int Deposit(decimal amount);

        decimal CalculateInterestOverPeriod(int months);
    }
}
