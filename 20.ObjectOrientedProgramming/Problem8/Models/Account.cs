using Problem8.Interfaces;
using System;

namespace Problem8.Models
{
    public abstract class Account : IWithdraw
    {
        protected decimal balance;

        public Customer Customer { get; set; }
        public decimal InteresetRate { get; set; }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
        }

        public Account(Customer customer)
        {
            this.balance = 0;
            this.InteresetRate = this.InteresetRate / 100M;
            this.Customer = customer;
        }

        public Account(Customer customer, decimal balance)
            : this(customer)
        {
            this.balance = balance;
        }

        public Account(Customer customer, decimal balance, decimal interestRate)
            : this(customer, balance)
        {
            this.InteresetRate = interestRate;
        }

        public override string ToString()
        {
            return String.Format("{0} Balance:{1}", this.Customer.ToString(), this.balance);
        }

        public virtual decimal CalculateInterest(Int32 months)
        {
            return months * this.InteresetRate;
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }
}
