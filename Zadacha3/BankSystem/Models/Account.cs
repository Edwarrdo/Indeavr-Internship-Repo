using BankSystem.Common;
using BankSystem.Enums;
using BankSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Models
{
    public abstract class Account : IAccount
    {
        protected Account(Clients client, decimal balance, decimal interest)
        {
            this.Client = client;
            this.Balance = balance;
            this.Interest = interest;
        }

        protected Clients Client { get; set; }
        protected decimal Balance { get; set; }
        protected decimal Interest { get; set; }

        public decimal ShowBalance()
        {
            return this.Balance;
        }

        public int Deposit(decimal amount)
        {
            if(amount < 0)
            {
                throw new InvalidOperationException(Messages.NegativeAmountMessage);
            }

            this.Balance += amount;
            //returning 1 if operation succeeded
            return 1;
        }

        public virtual decimal CalculateInterestOverPeriod(int months)
        {
            return months * this.Interest;
        }
    }
}
