using CSQuestion.Interfaces;
using System;

namespace CSQuestion.Models
{
    public class HighRiskCategory : TradeCategory
    {
        public HighRiskCategory(int Level) : base("HIGHRISK", Level) { }

        public override bool CategoryPaymentRule(DateTime ReferenceDate, ITrade trade)
        {
            var returnValue = default(bool);

            if (trade.Value > 1000000 && trade.ClientSector == "Private")
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
