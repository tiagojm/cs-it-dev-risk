using CSQuestion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSQuestion.Models
{
    public class Trade : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public TradeCategory? Category { get; set; }

        public bool IsPoliticallyExposed { get; set; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            this.Value = value;
            this.ClientSector = clientSector;
            this.NextPaymentDate = nextPaymentDate;
        }

        public void DefineCategory(DateTime ReferenceDate, IReadOnlyCollection<TradeCategory> StepList)
        {
            this.Category = StepList.Where(category => category.CategoryPaymentRule(ReferenceDate, this)).FirstOrDefault();
        }
    }
}
