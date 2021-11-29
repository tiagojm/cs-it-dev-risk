using CSQuestion.Interfaces;
using System;

namespace CSQuestion.Models
{
    public class PoliticallyExposedPersonCategory : TradeCategory
    {
        public PoliticallyExposedPersonCategory(int Level) : base("PEP", Level) { }

        public override bool CategoryPaymentRule(DateTime ReferenceDate, ITrade trade)
        {
            if (trade.IsPoliticallyExposed)
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
