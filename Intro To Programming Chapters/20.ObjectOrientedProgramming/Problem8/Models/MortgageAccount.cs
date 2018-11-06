using System;

namespace Problem8.Models
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                return this.CalculateCompanyAccountInterest(months);
            }
            else if (this.Customer.Type == CustomerType.Individual)
            {
                return this.CalculateIndividualAccountInterest(months);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private decimal CalculateIndividualAccountInterest(Int32 months)
        {
            const Int32 monthsWithoudIntereset = 6;
            decimal interest = 0;

            if (months > monthsWithoudIntereset)
            {
                interest += base.CalculateInterest(months - monthsWithoudIntereset);
            }

            return interest;
        }

        private decimal CalculateCompanyAccountInterest(Int32 months)
        {
            const Int32 monntsInAYear = 12;
            decimal interest = 0;

            interest += base.CalculateInterest(months % monntsInAYear) / 2;

            if (months > monntsInAYear)
            {
                interest += base.CalculateInterest(months - monntsInAYear);
            }

            return interest;
        }
    }
}
