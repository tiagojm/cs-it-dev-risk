using CSQuestion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSQuestion.Models
{
    public abstract class TradeCategory : IComparable
    {
        private readonly string _categoryName;
        private readonly int Level;

        public string CategoryName { get { return this._categoryName; } }

        public abstract bool CategoryPaymentRule(DateTime ReferenceDate, ITrade trade);

        public TradeCategory(string categoryName, int level)
        {
            _categoryName = categoryName;
            Level = level;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            TradeCategory otherCategory = obj as TradeCategory;

            if (otherCategory != null)
            {
                if (this.Level > otherCategory.Level)
                {
                    return 1;
                }
                else if (this.Level < otherCategory.Level)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new ArgumentException("Object is not a TradeCategory");
            }
        }
    }
}
