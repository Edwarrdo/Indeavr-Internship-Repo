using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Common;
using BankSystem.Enums;
using BankSystem.Interfaces;

namespace BankSystem.Models
{
    public class DepositAccount : Account, IDepositAccount
    {
        public DepositAccount(Clients client, decimal balance, decimal interest) : base(client, balance, interest)
        {
        }

        public int Withdraw(decimal amount)
        {
            if(amount < 0)
            {
                throw new InvalidOperationException(Messages.NegativeAmountMessage);
            }

            if(this.Balance < amount)
            {
                //returning 0 if operation failed
                return 0;
            }
            this.Balance -= amount;

            //returning 1 if operation succeeded
            return 1;
        }

        public override decimal CalculateInterestOverPeriod(int months)
        {
            if(months < 0)
            {
                throw new InvalidOperationException(Messages.NegativeMonthsMessage);
            }

            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterestOverPeriod(months);
        }
    }
}
