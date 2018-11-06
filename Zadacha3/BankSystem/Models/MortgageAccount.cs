using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Common;
using BankSystem.Enums;

namespace BankSystem.Models
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Clients client, decimal balance, decimal interest) : base(client, balance, interest)
        {
        }

        public override decimal CalculateInterestOverPeriod(int months)
        {
            if(months < 0)
            {
                throw new InvalidOperationException(Messages.NegativeMonthsMessage);
            }

            //for company account
            if(this.Client == Clients.Company)
            {
                if(months <= 12)
                {
                    return months / 2;
                }
                else
                {
                    return months / 2 + base.CalculateInterestOverPeriod(months - 12);
                }
            }

            //for person account
            if(months <= 6)
            {
                return 0;
            }
            return base.CalculateInterestOverPeriod(months - 6);
        }
    }
}
