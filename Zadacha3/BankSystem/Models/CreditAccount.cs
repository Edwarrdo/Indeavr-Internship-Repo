using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Common;
using BankSystem.Enums;

namespace BankSystem.Models
{
    public class CreditAccount : Account
    {
        public CreditAccount(Clients client, decimal balance, decimal interest) : base(client, balance, interest)
        {
        }

        public override decimal CalculateInterestOverPeriod(int months)
        {
            if(months < 0)
            {
                throw new InvalidOperationException(Messages.NegativeMonthsMessage);
            }

            //for person account
            if(this.Client == Clients.Person)
            {
                if(months <= 3)
                {
                    return 0;
                }
                return base.CalculateInterestOverPeriod(months - 3);
            }

            //for company account
            if(months <= 2)
            {
                return 0;
            }
            return base.CalculateInterestOverPeriod(months - 2);

        }
    }
}
