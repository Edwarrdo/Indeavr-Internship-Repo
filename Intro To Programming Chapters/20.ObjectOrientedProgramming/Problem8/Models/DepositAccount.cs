using Problem8.Interfaces;
using System;

namespace Problem8.Models
{
    public class DepositAccount : Account, IWithdraw
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { }

        void IWithdraw.Deposit(decimal amount)
        {
            if (this.balance < amount)
                throw new InvalidOperationException();

            this.balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 1000)
            {
                return base.CalculateInterest(months);
            }
            else
            {
                return 0;
            }
        }
    }
}
