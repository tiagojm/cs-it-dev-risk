using CSQuestion.Interfaces;
using System;

namespace CSQuestion.Models
{
    public class MediumRiskCategory : TradeCategory
    {
        public MediumRiskCategory(int Level) : base("MEDIUMRISK", Level) { }

        public override bool CategoryPaymentRule(DateTime ReferenceDate, ITrade trade)
        {
            var returnValue = default(bool);

            if(trade.Value > 1000000 && trade.ClientSector == "Public")
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
