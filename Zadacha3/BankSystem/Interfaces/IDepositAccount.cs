using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Interfaces
{
    public interface IDepositAccount : IAccount
    {
        int Withdraw(decimal amount);
    }
}
