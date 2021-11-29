using CSQuestion.Interfaces;
using System;

namespace CSQuestion.Models
{
    public class ExpiredCategory : TradeCategory
    {
        public ExpiredCategory(int Level) : base("EXPIRED", Level) { }

        public override bool CategoryPaymentRule(DateTime ReferenceDate, ITrade trade)
        {
            if ((ReferenceDate - trade.NextPaymentDate).TotalDays > 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
